using Viticulture.Logic.State;
using Viticulture.Services;

namespace Viticulture.Logic.Cards.Parents.Papas
{
    public class JoelPapaCard : PapaCard
    {
        public override string Name => "Joel";

        protected override string Option1 => "3 lira";
        protected override string Option2 => "medium cellar";

        protected override int StartingMoney => 4;

        protected override void OnSetup(IGameState gameState, Selection selection)
        {
            if (selection == Selection.Option1) gameState.Money += 3;
            else gameState.MediumCellar.IsBought = true;
        }
    }
}