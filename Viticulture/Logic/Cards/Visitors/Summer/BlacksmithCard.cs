using System.Linq;
using System.Threading.Tasks;
using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Visitors.Summer
{
    public class BlacksmithCard : VisitorCard
    {
        public override string Description
            => "Build a structure at a 2 lira discount. If it is a 5+ lira structure also gain 1 VP.";

        public override string Name => "Blacksmith";

        public override Season Season => Season.Summer;
        public override bool CanPlay(IGameState gameState)
        {
            return gameState.Structures.Any(p => !p.IsBought && p.Cost - 2 <= gameState.Money);
        }

        protected override async Task<bool> OnApply(IGameState gameState)
        {
            var building = await PlayerSelection.Select("Select structure", "Choose a structure you want to build",
                gameState.Structures.Where(p => !p.IsBought && p.Cost - 2 <= gameState.Money));
            if (building == null) return false;

            building.IsBought = true;
            gameState.Money -= building.Cost - 2;
            if (building.Cost >= 5) gameState.VictoryPoints++;
            return true;
        }
    }
}