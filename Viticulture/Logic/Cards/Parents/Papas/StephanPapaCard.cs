using Viticulture.Logic.State;
using Viticulture.Services;

namespace Viticulture.Logic.Cards.Parents.Papas
{
    public class StephanPapaCard : PapaCard
    {
        public override string Name => "Stephan";

        protected override string Option1 => "2 lira";
        protected override string Option2 => "irigation";

        protected override int StartingMoney => 4;

        protected override void OnSetup(IGameState gameState, Selection selection)
        {
            if (selection == Selection.Option1) gameState.Money += 2;
            else gameState.Irigation.IsBought = true;
        }
    }
}