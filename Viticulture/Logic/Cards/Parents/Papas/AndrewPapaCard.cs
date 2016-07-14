using Viticulture.Logic.State;
using Viticulture.Services;

namespace Viticulture.Logic.Cards.Parents.Papas
{
    public class AndrewPapaCard : PapaCard
    {
        public override string Name => "Andrew";

        protected override string Option1 => "2 lira";
        protected override string Option2 => "trellis";

        protected override int StartingMoney => 3;

        protected override void OnSetup(IGameState gameState, Selection selection)
        {
            if (selection == Selection.Option1) gameState.Money += 2;
            else gameState.Trellis.IsBought = true;
        }
    }
}