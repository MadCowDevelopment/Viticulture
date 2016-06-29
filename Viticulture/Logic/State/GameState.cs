using System.Collections.Generic;
using System.ComponentModel.Composition;
using Caliburn.Micro;
using Viticulture.Logic.Cards.Vines;
using Viticulture.Logic.Pieces;

namespace Viticulture.Logic.State
{
    [Export(typeof(IGameState))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GameState : PropertyChangedBase, IGameState
    {
        private readonly List<Worker> _workers = new List<Worker>();

        [ImportingConstructor]
        public GameState([ImportMany]IEnumerable<VineCard> vineCards)
        {

            Hand = new Hand();
            VineDeck = new Deck(Hand, vineCards);

            Irigation = new Irigation();

            Grande = new Grande();
            for (var i = 0; i < 5; i++)
            {
                _workers.Add(new Worker());
            }
        }

        public Grande Grande { get; }
        public int Money { get; set; }
        public Irigation Irigation { get; }
        public IEnumerable<Worker> Workers => _workers;
        public Deck VineDeck { get; }
        public Hand Hand { get; }
    }
}
