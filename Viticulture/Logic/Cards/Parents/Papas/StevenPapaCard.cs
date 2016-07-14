using Viticulture.Logic.State;
using Viticulture.Services;

namespace Viticulture.Logic.Cards.Parents.Papas
{
    public class StevenPapaCard : PapaCard
    {
        public override string Name => "Steven";

        protected override string Option1 => "1 lira";
        protected override string Option2 => "yoke";

        protected override int StartingMoney => 3;

        protected override void OnSetup(IGameState gameState, Selection selection)
        {
            if (selection == Selection.Option1) gameState.Money += 1;
            else gameState.Yoke.IsBought = true;
        }
    }
}