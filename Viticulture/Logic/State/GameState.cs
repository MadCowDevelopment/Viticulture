using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Caliburn.Micro;
using Viticulture.Logic.Cards.Vines;
using Viticulture.Logic.Pieces;

namespace Viticulture.Logic.State
{
    [Export(typeof(IGameState))]
    public class GameState : PropertyChangedBase, IGameState
    {
        private readonly List<VineCard> _vineCards;

        private List<Worker> _workers;

        [ImportingConstructor]
        public GameState([ImportMany]IEnumerable<VineCard> vineCards)
        {
            _vineCards = vineCards.ToList();
        }

        public Grande Grande { get; private set; }
        public int Money { get; set; }
        public Irigation Irigation { get; private set; }
        public IEnumerable<Worker> Workers => _workers;
        public Deck VineDeck { get; private set; }
        public Hand Hand { get; private set; }
        public int RemainingBonusActions { get; set; }
        public int Round { get; set; }

        public void Reset()
        {
            Money = 0;
            RemainingBonusActions = 0;
            Round = 1;

            Hand = new Hand();
            VineDeck = new Deck(Hand, _vineCards);

            Irigation = new Irigation();

            Grande = new Grande();

            _workers = new List<Worker>();
            for (var i = 0; i < 5; i++)
            {
                _workers.Add(new Worker());
            }
        }
    }
}
