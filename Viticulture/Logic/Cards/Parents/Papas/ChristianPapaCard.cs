using Viticulture.Logic.State;
using Viticulture.Services;

namespace Viticulture.Logic.Cards.Parents.Papas
{
    public class ChristianPapaCard : PapaCard
    {
        public override string Name => "Christian";

        protected override string Option1 => "3 lira";
        protected override string Option2 => "irigation";

        protected override int StartingMoney => 3;

        protected override void OnSetup(IGameState gameState, Selection selection)
        {
            if (selection == Selection.Option1) gameState.Money += 3;
            else gameState.Irigation.IsBought = true;
        }
    }
}