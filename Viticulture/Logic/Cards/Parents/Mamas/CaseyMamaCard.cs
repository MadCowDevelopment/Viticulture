using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Parents.Mamas
{
    public class CaseyMamaCard : MamaCard
    {
        public override string Name => "Casey";

        protected override void OnSetup(IGameState gameState)
        {
            gameState.OrderDeck.DrawToHand();
            gameState.OrderDeck.DrawToHand();
            gameState.WinterVisitorDeck.DrawToHand();
        }

        protected override string Benefits => "2 orders and 1 winter visitor";
    }
}