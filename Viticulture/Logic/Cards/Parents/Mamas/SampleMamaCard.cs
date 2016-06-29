using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Parents.Mamas
{
    public class SampleMamaCard : MamaCard
    {
        public override string Name => "Mama Sample";

        protected override void OnSetup(IGameState gameState)
        {
            gameState.VineDeck.DrawToHand();
        }
    }
}