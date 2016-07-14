using Viticulture.Logic.State;
using Viticulture.Services;

namespace Viticulture.Logic.Cards.Parents.Papas
{
    public class PaulPapaCard : PapaCard
    {
        public override string Name => "Paul";

        protected override string Option1 => "1 lira";
        protected override string Option2 => "trellis";

        protected override int StartingMoney => 5;

        protected override void OnSetup(IGameState gameState, Selection selection)
        {
            if (selection == Selection.Option1) gameState.Money += 1;
            else gameState.Trellis.IsBought = true;
        }
    }
}