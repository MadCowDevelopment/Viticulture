using System.Collections;
using System.Collections.Generic;
using Caliburn.Micro;
using Viticulture.Logic.Cards.Automa;
using Viticulture.Logic.Cards.Orders;
using Viticulture.Logic.Cards.Vines;
using Viticulture.Logic.Cards.Visitors;
using Viticulture.Logic.Pieces;

namespace Viticulture.Logic.State
{
    public interface IGameState : INotifyPropertyChangedEx
    {
        Grande Grande { get; }
        int Money { get; set; }
        Irigation Irigation { get; }

        IEnumerable<Worker> Workers { get; }
        Deck<VineCard> VineDeck { get; }
        Deck<OrderCard> OrderDeck { get; }
        Deck<VisitorCard> WinterVisitorDeck { get; }
        Deck<VisitorCard> SummerVisitorDeck { get; }
        Deck<AutomaCard> AutomaDeck { get; }

        Hand Hand { get; }
        int RemainingBonusActions { get; set; }
        int Round { get; set; }
        Season Season { get; set; }
        int VictoryPoints { get; set; }
        Worker NeutralWorker { get; }
        AutomaCard AutomaCard { get; set; }
        void Reset();
    }
}