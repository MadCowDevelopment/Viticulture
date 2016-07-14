using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Parents.Mamas
{
    public class MeganMamaCard : MamaCard
    {
        public override string Name => "Megan";

        protected override void OnSetup(IGameState gameState)
        {
            gameState.VineDeck.DrawToHand();
            gameState.VineDeck.DrawToHand();
            gameState.SummerVisitorDeck.DrawToHand();
        }

        protected override string Benefits => "2 vines and 1 summer visitor";
    }
}