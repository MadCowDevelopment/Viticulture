using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Parents.Mamas
{
    public class DanyelMamaCard : MamaCard
    {
        public override string Name => "Danyel";

        protected override void OnSetup(IGameState gameState)
        {
            gameState.SummerVisitorDeck.DrawToHand();
            gameState.SummerVisitorDeck.DrawToHand();
            gameState.WinterVisitorDeck.DrawToHand();
        }

        protected override string Benefits => "2 summer visitors and 1 winter visitor";
    }
}