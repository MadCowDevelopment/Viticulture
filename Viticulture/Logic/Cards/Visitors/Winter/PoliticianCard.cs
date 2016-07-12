using System.Threading.Tasks;
using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Visitors.Winter
{
    public class PoliticianCard : VisitorCard
    {
        public override string Description
            => "If you have less than 0 VP, gain 6 lira. Otherwise draw 1 vine, 1 summer visitor and 1 order";

        public override string Name => "Politician";
        public override Season Season => Season.Winter;
        public override bool CanPlay(IGameState gameState)
        {
            return true;
        }

        protected override Task<bool> OnApply(IGameState gameState)
        {
            if (gameState.VictoryPoints < 0)gameState.Money += 6;
            else
            {
                gameState.VineDeck.DrawToHand();
                gameState.SummerVisitorDeck.DrawToHand();
                gameState.OrderDeck.DrawToHand();
            }

            return Task.FromResult(true);
        }
    }
}