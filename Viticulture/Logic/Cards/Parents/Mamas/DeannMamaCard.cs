using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Parents.Mamas
{
    public class DeannMamaCard : MamaCard
    {
        public override string Name => "Deann";

        protected override void OnSetup(IGameState gameState)
        {
            gameState.VineDeck.DrawToHand();
            gameState.WinterVisitorDeck.DrawToHand();
            gameState.OrderDeck.DrawToHand();
        }

        protected override string Benefits => "1 vine, 1 winter visitor and 1 order";
    }
}