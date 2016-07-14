using Viticulture.Logic.State;
using Viticulture.Services;

namespace Viticulture.Logic.Cards.Parents.Papas
{
    public class RafaelPapaCard : PapaCard
    {
        public override string Name => "Rafael";

        protected override string Option1 => "4 lira";
        protected override string Option2 => "1 worker";

        protected override int StartingMoney => 3;

        protected override void OnSetup(IGameState gameState, Selection selection)
        {
            if (selection == Selection.Option1) gameState.Money += 4;
            else gameState.BuyWorker(0);
        }
    }
}