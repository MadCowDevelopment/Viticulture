using System.Collections;
using System.Collections.Generic;
using Caliburn.Micro;
using Viticulture.Logic.Pieces;

namespace Viticulture.Logic.State
{
    public interface IGameState : INotifyPropertyChangedEx
    {
        Grande Grande { get; }
        int Money { get; set; }
        Irigation Irigation { get; }

        IEnumerable<Worker> Workers { get; }
        Deck VineDeck { get; }
        Deck OrderDeck { get; }
        Deck WinterVisitorDeck { get; }
        Deck SummerVisitorDeck { get; }

        Hand Hand { get; }
        int RemainingBonusActions { get; set; }
        int Round { get; set; }
        Season Season { get; set; }
        int VictoryPoints { get; set; }
        Worker NeutralWorker { get; }
        void Reset();
    }
}