using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Parents.Mamas
{
    public class MargotMamaCard : MamaCard
    {
        public override string Name => "Margot";

        protected override void OnSetup(IGameState gameState)
        {
            gameState.SummerVisitorDeck.DrawToHand();
            gameState.OrderDeck.DrawToHand();
            gameState.WinterVisitorDeck.DrawToHand();
        }

        protected override string Benefits => "1 summer visitor, 1 order and 1 winter visitor";
    }
}