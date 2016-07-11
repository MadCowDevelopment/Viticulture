using System.Threading.Tasks;
using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Visitors.Summer
{
    public class BankerCard : VisitorCard
    {
        public override string Description => "Gain 5 lira.";
        public override string Name => "Banker";
        public override Season Season => Season.Summer;

        public override bool CanPlay(IGameState gameState)
        {
            return true;
        }

        protected override Task<bool> OnApply(IGameState gameState)
        {
            gameState.Money += 5;
            return Task.FromResult(true);
        }
    }
}