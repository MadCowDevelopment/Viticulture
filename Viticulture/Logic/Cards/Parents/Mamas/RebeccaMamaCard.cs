using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Parents.Mamas
{
    public class RebeccaMamaCard : MamaCard
    {
        public override string Name => "Rebecca";

        protected override void OnSetup(IGameState gameState)
        {
            gameState.SummerVisitorDeck.DrawToHand();
            gameState.SummerVisitorDeck.DrawToHand();
            gameState.OrderDeck.DrawToHand();
        }

        protected override string Benefits => "2 summer visitors and 1 order";
    }
}