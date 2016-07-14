using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Parents.Mamas
{
    public class EmilyMamaCard : MamaCard
    {
        public override string Name => "Emily";

        protected override void OnSetup(IGameState gameState)
        {
            gameState.VineDeck.DrawToHand();
            gameState.SummerVisitorDeck.DrawToHand();
            gameState.SummerVisitorDeck.DrawToHand();
        }

        protected override string Benefits => "1 vine and 2 summer visitors";
    }
}