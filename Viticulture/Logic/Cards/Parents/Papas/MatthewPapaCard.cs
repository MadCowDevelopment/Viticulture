using Viticulture.Logic.State;
using Viticulture.Services;

namespace Viticulture.Logic.Cards.Parents.Papas
{
    public class MatthewPapaCard : PapaCard
    {
        public override string Name => "";

        protected override string Option1 => "5 lira";
        protected override string Option2 => "windmill";

        protected override int StartingMoney => 1;

        protected override void OnSetup(IGameState gameState, Selection selection)
        {
            if (selection == Selection.Option1) gameState.Money += 5;
            else gameState.Windmill.IsBought = true;
        }
    }
}