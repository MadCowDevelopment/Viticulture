using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Caliburn.Micro;
using Viticulture.Logic.Cards.Automa;
using Viticulture.Logic.Cards.Orders;
using Viticulture.Logic.Cards.Vines;
using Viticulture.Logic.Cards.Visitors;
using Viticulture.Logic.Pieces;
using Viticulture.Logic.Pieces.Buildings;

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
        public Trellis Trellis { get; private set; }
        public Irigation Irigation { get; private set; }
        public Yoke Yoke { get; private set; }
        public TastingRoom TastingRoom { get; private set; }
        public Cottage Cottage { get; private set; }
        public Windmill Windmill { get; private set; }
        public MediumCellar MediumCellar { get; private set; }
        public LargeCellar LargeCellar { get; private set; }
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
        public int NumberOfRounds { get; set; }
        public int ResidualMoney { get; set; }

        public IEnumerable<GamePiece> Pieces
            =>
                _workers.Concat(new List<GamePiece>
                {
                    Grande,
                    Trellis,
                    Irigation,
                    Yoke,
                    Windmill,
                    Cottage,
                    MediumCellar,
                    LargeCellar,
                    TastingRoom
                });

        public void Reset()
        {
            VictoryPoints = 0;
            Money = 0;
            NumberOfRounds = 0;
            ResidualMoney = 0;
            RemainingBonusActions = 0;
            Round = 1;

            Hand = new Hand();

            VineDeck = new Deck<VineCard>(Hand, _vineCards);
            OrderDeck = new Deck<OrderCard>(Hand, _orderCards);
            SummerVisitorDeck = new Deck<VisitorCard>(Hand, _visitorCards.Where(p => p.Season == Season.Summer));
            WinterVisitorDeck = new Deck<VisitorCard>(Hand, _visitorCards.Where(p => p.Season == Season.Winter));
            AutomaDeck = new Deck<AutomaCard>(Hand, _automaCards);

            Trellis = new Trellis(_eventAggregator);
            Irigation = new Irigation(_eventAggregator);
            Yoke = new Yoke(_eventAggregator);
            TastingRoom = new TastingRoom(_eventAggregator);
            Cottage = new Cottage(_eventAggregator);
            Windmill = new Windmill(_eventAggregator);
            MediumCellar = new MediumCellar(_eventAggregator);
            LargeCellar = new LargeCellar(_eventAggregator);

            Grande = new Grande(_eventAggregator);
            NeutralWorker = new Worker(_eventAggregator);

            _workers = new List<Worker>();
            for (var i = 0; i < 5; i++)
            {
                _workers.Add(new Worker(_eventAggregator));
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

    public static class GameStateExtensions
    {
        public static Worker GetFirstAvailableWorker(this IGameState gameState)
        {
            if (gameState.NeutralWorker.IsBought && !gameState.NeutralWorker.HasBeenUsed)
                return gameState.NeutralWorker;
            if (gameState.Workers.Any(p => p.IsBought && !p.HasBeenUsed))
                return gameState.Workers.First(p => p.IsBought && !p.HasBeenUsed);
            if (gameState.Grande.IsBought && !gameState.Grande.HasBeenUsed)
                return gameState.Grande;

            return null;
        }
    }
}
