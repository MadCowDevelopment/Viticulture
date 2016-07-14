using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Parents.Mamas
{
    public class NicoleMamaCard : MamaCard
    {
        public override string Name => "Nicole";

        protected override void OnSetup(IGameState gameState)
        {
            gameState.Money += 2;
            gameState.VineDeck.DrawToHand();
            gameState.WinterVisitorDeck.DrawToHand();
        }

        protected override string Benefits => "2 lira, 1 vine and 2 winter visitors";
    }
}