using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Caliburn.Micro;
using Viticulture.Logic.Cards.Automa;
using Viticulture.Logic.Cards.Orders;
using Viticulture.Logic.Cards.Vines;
using Viticulture.Logic.Cards.Visitors;
using Viticulture.Logic.Pieces;

namespace Viticulture.Logic.State
{
    [Export(typeof(IGameState))]
    public class GameState : PropertyChangedBase, IGameState
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IEnumerable<AutomaCard> _automaCards;
        private readonly List<VisitorCard> _visitorCards;
        private readonly List<OrderCard> _orderCards;
        private readonly List<VineCard> _vineCards;

        private List<Worker> _workers;

        [ImportingConstructor]
        public GameState(
            IEventAggregator eventAggregator,
            [ImportMany] IEnumerable<VineCard> vineCards,
            [ImportMany] IEnumerable<OrderCard> orderCards,
            [ImportMany] IEnumerable<VisitorCard> visitorCards,
            [ImportMany] IEnumerable<AutomaCard> automaCards)
        {
            _eventAggregator = eventAggregator;
            _automaCards = automaCards;

            _vineCards = vineCards.ToList();
            _orderCards = orderCards.ToList();
            _visitorCards = visitorCards.ToList();

            PropertyChanged += StateChanged;
        }

        private void StateChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            _eventAggregator.PublishOnCurrentThread(new GameStateChanged(this, e.PropertyName));
        }

        public Grande Grande { get; private set; }
        public int Money { get; set; }
        public Irigation Irigation { get; private set; }
        public IEnumerable<Worker> Workers => _workers;
        public Deck<VineCard> VineDeck { get; private set; }
        public Deck<VisitorCard> SummerVisitorDeck { get; private set; }
        public Deck<VisitorCard> WinterVisitorDeck { get; private set; }
        public Deck<OrderCard> OrderDeck { get; private set; }
        public Deck<AutomaCard> AutomaDeck { get; private set; }
        public Hand Hand { get; private set; }
        public int RemainingBonusActions { get; set; }
        public int Round { get; set; }
        public Season Season { get; set; }
        public int VictoryPoints { get; set; }

        public Worker NeutralWorker { get; private set; }
        public AutomaCard AutomaCard { get; set; }

        public void Reset()
        {
            VictoryPoints = 0;
            Money = 0;
            RemainingBonusActions = 0;
            Round = 1;

            Hand = new Hand();

            VineDeck = new Deck<VineCard>(Hand, _vineCards);
            OrderDeck = new Deck<OrderCard>(Hand, _orderCards);
            SummerVisitorDeck = new Deck<VisitorCard>(Hand, _visitorCards.Where(p => p.Season == Season.Summer));
            WinterVisitorDeck = new Deck<VisitorCard>(Hand, _visitorCards.Where(p => p.Season == Season.Winter));
            AutomaDeck = new Deck<AutomaCard>(Hand, _automaCards);

            Irigation = new Irigation();

            Grande = new Grande();
            NeutralWorker = new Worker();

            _workers = new List<Worker>();
            for (var i = 0; i < 5; i++)
            {
                _workers.Add(new Worker());
            }
        }
    }

    public class GameStateChanged
    {
        public GameStateChanged(GameState gameState, string propertyName)
        {
            GameState = gameState;
            PropertyName = propertyName;
        }

        public GameState GameState { get; }
        public string PropertyName { get; }
    }
}
