using System.Threading.Tasks;
using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Visitors.Summer
{
    public class VendorCard : VisitorCard
    {
        public override string Description => "draw 1 vine, 1 order and 1 winter visitor";
        public override string Name => "Vendor";
        public override Season Season => Season.Summer;
        public override bool CanPlay(IGameState gameState)
        {
            return true;
        }

        protected override Task<bool> OnApply(IGameState gameState)
        {
            gameState.VineDeck.DrawToHand();
            gameState.OrderDeck.DrawToHand();
            gameState.WinterVisitorDeck.DrawToHand();
            return Task.FromResult(true);
        }
    }
}