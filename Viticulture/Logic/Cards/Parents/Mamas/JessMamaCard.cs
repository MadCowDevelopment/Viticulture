using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Parents.Mamas
{
    public class JessMamaCard : MamaCard
    {
        public override string Name => "Jess";

        protected override void OnSetup(IGameState gameState)
        {
            gameState.SummerVisitorDeck.DrawToHand();
            gameState.OrderDeck.DrawToHand();
            gameState.OrderDeck.DrawToHand();
        }

        protected override string Benefits => "1 summer visitor and 2 orders";
    }
}