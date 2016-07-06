using System.Collections;
using System.Collections.Generic;
using Caliburn.Micro;
using Viticulture.Logic.Cards.Automa;
using Viticulture.Logic.Cards.Orders;
using Viticulture.Logic.Cards.Vines;
using Viticulture.Logic.Cards.Visitors;
using Viticulture.Logic.Pieces;
using Viticulture.Logic.Pieces.Buildings;

namespace Viticulture.Logic.State
{
    public interface IGameState : INotifyPropertyChangedEx
    {
        Grande Grande { get; }
        int Money { get; set; }

        Trellis Trellis { get; }
        Irigation Irigation { get; }
        Yoke Yoke { get; }
        TastingRoom TastingRoom { get; }
        Cottage Cottage { get; }
        Windmill Windmill { get; }
        MediumCellar MediumCellar { get; }
        LargeCellar LargeCellar { get; }


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
        int NumberOfRounds { get; set; }
        int ResidualMoney { get; set; }
        IEnumerable<GamePiece> Pieces { get; }
        void Reset();
    }
}