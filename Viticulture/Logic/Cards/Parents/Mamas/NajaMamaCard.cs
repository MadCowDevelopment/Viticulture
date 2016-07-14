using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Parents.Mamas
{
    public class NajaMamaCard : MamaCard
    {
        public override string Name => "Naja";

        protected override void OnSetup(IGameState gameState)
        {
            gameState.SummerVisitorDeck.DrawToHand();
            gameState.WinterVisitorDeck.DrawToHand();
            gameState.WinterVisitorDeck.DrawToHand();
        }

        protected override string Benefits => "1 summer visitor and 2 winter visitors";
    }
}