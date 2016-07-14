using Viticulture.Logic.State;
using Viticulture.Services;

namespace Viticulture.Logic.Cards.Parents.Papas
{
    public class GaryPapaCard : PapaCard
    {
        public override string Name => "Gary";

        protected override string Option1 => "3 lira";
        protected override string Option2 => "1 worker";

        protected override int StartingMoney => 3;

        protected override void OnSetup(IGameState gameState, Selection selection)
        {
            if (selection == Selection.Option1) gameState.Money += 3;
            else gameState.BuyWorker(0);
        }
    }
}