using Viticulture.Logic.State;
using Viticulture.Services;

namespace Viticulture.Logic.Cards.Parents.Papas
{
    public class JayPapaCard : PapaCard
    {
        public override string Name => "Jay";

        protected override string Option1 => "2 lira";
        protected override string Option2 => "yoke";

        protected override int StartingMoney => 5;

        protected override void OnSetup(IGameState gameState, Selection selection)
        {
            if (selection == Selection.Option1) gameState.Money += 2;
            else gameState.Yoke.IsBought = true;
        }
    }
}