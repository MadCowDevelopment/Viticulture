using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Parents.Mamas
{
    public class TeruyoMamaCard : MamaCard
    {
        public override string Name => "Teruyo";

        protected override void OnSetup(IGameState gameState)
        {
            gameState.VineDeck.DrawToHand();
            gameState.VineDeck.DrawToHand();
            gameState.OrderDeck.DrawToHand();
        }

        protected override string Benefits => "2 vines and 1 order";
    }
}