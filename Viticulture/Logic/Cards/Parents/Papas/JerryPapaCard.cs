using Viticulture.Logic.State;
using Viticulture.Services;

namespace Viticulture.Logic.Cards.Parents.Papas
{
    public class JerryPapaCard : PapaCard
    {
        public override string Name => "Jerry";

        protected override string Option1 => "4 lira";
        protected override string Option2 => "windmill";

        protected override int StartingMoney => 2;

        protected override void OnSetup(IGameState gameState, Selection selection)
        {
            if (selection == Selection.Option1) gameState.Money += 4;
            else gameState.Windmill.IsBought = true;
        }
    }
}