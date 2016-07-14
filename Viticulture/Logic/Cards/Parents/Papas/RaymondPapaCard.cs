using Viticulture.Logic.State;
using Viticulture.Services;

namespace Viticulture.Logic.Cards.Parents.Papas
{
    public class RaymondPapaCard : PapaCard
    {
        public override string Name => "Raymond";

        protected override string Option1 => "3 lira";
        protected override string Option2 => "cottage";

        protected override int StartingMoney => 3;

        protected override void OnSetup(IGameState gameState, Selection selection)
        {
            if (selection == Selection.Option1) gameState.Money += 3;
            else gameState.Cottage.IsBought = true;
        }
    }
}