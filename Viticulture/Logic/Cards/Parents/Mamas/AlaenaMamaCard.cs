using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Parents.Mamas
{
    public class AlaenaMamaCard : MamaCard
    {
        public override string Name => "Alaena";

        protected override void OnSetup(IGameState gameState)
        {
            gameState.VineDeck.DrawToHand();
            gameState.SummerVisitorDeck.DrawToHand();
            gameState.OrderDeck.DrawToHand();
        }

        protected override string Benefits => "1 vine, 1 summer visitor and 1 order";
    }
}