using Viticulture.Logic.State;
using Viticulture.Services;

namespace Viticulture.Logic.Cards.Parents.Papas
{
    public class MattPapaCard : PapaCard
    {
        public override string Name => "Matt";

        protected override string Option1 => "6 lira";
        protected override string Option2 => "tasting room";

        protected override int StartingMoney => 0;

        protected override void OnSetup(IGameState gameState, Selection selection)
        {
            if (selection == Selection.Option1) gameState.Money += 6;
            else gameState.TastingRoom.IsBought = true;
        }
    }
}