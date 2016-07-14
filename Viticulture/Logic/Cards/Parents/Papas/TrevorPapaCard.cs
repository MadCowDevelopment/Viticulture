using Viticulture.Logic.State;
using Viticulture.Services;

namespace Viticulture.Logic.Cards.Parents.Papas
{
    public class TrevorPapaCard : PapaCard
    {
        public override string Name => "Trevor";

        protected override string Option1 => "5 lira";
        protected override string Option2 => "tasting room";

        protected override int StartingMoney => 1;

        protected override void OnSetup(IGameState gameState, Selection selection)
        {
            if (selection == Selection.Option1) gameState.Money += 5;
            else gameState.TastingRoom.IsBought = true;
        }
    }
}