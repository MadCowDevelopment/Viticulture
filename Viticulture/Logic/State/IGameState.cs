using System.Collections;
using System.Collections.Generic;
using Viticulture.Logic.Pieces;

namespace Viticulture.Logic.State
{
    public interface IGameState
    {
        Grande Grande { get; }
        int Money { get; set; }
        Irigation Irigation { get; }

        IEnumerable<Worker> Workers { get; }
        Deck VineDeck { get; }

        Hand Hand { get; }
    }
}