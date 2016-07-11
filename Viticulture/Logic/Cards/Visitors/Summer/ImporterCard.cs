using System.Threading.Tasks;
using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Visitors.Summer
{
    public class ImporterCard : VisitorCard
    {
        public override string Description => "Draw 3 winter visitors.";
        public override string Name => "Importer";
        public override Season Season => Season.Summer;
        public override bool CanPlay(IGameState gameState)
        {
            return true;
        }

        protected override Task<bool> OnApply(IGameState gameState)
        {
            gameState.WinterVisitorDeck.DrawToHand();
            gameState.WinterVisitorDeck.DrawToHand();
            gameState.WinterVisitorDeck.DrawToHand();
            return Task.FromResult(true);
        }
    }
}