using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Parents.Mamas
{
    public class FalonMamaCard : MamaCard
    {
        public override string Name => "Falon";

        protected override void OnSetup(IGameState gameState)
        {
            gameState.OrderDeck.DrawToHand();
            gameState.WinterVisitorDeck.DrawToHand();
            gameState.WinterVisitorDeck.DrawToHand();
        }

        protected override string Benefits => "1 order and 2 winter visitors";
    }
}