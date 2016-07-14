using Viticulture.Logic.State;
using Viticulture.Services;

namespace Viticulture.Logic.Cards.Parents.Papas
{
    public class AlanPapaCard : PapaCard
    {
        public override string Name => "Alan";

        protected override string Option1 => "2 lira";
        protected override string Option2 => "1 VP";

        protected override int StartingMoney => 5;

        protected override void OnSetup(IGameState gameState, Selection selection)
        {
            if (selection == Selection.Option1) gameState.Money += 2;
            else gameState.VictoryPoints++;
        }
    }
}