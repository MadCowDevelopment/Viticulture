using Viticulture.Logic.State;
using Viticulture.Services;

namespace Viticulture.Logic.Cards.Parents.Papas
{
    public class JoshPapaCard : PapaCard
    {
        public override string Name => "Josh";

        protected override string Option1 => "4 lira";
        protected override string Option2 => "medium cellar";

        protected override int StartingMoney => 3;

        protected override void OnSetup(IGameState gameState, Selection selection)
        {
            if (selection == Selection.Option1) gameState.Money += 4;
            else gameState.MediumCellar.IsBought = true;
        }
    }
}