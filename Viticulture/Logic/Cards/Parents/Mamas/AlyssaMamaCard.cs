using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Parents.Mamas
{
    public class AlyssaMamaCard : MamaCard
    {
        public override string Name => "Alyssa";

        protected override void OnSetup(IGameState gameState)
        {
            gameState.VineDeck.DrawToHand();
            gameState.SummerVisitorDeck.DrawToHand();
            gameState.WinterVisitorDeck.DrawToHand();
        }

        protected override string Benefits => "1 vine, 1 summer visitor and 1 winter visitor";
    }
}