using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using Viticulture.Logic.Actions.Summer;
using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Visitors.Summer
{
    public class StonemasonCard : VisitorCard
    {
        public override string Description => "Pay 8 lira to build 2 structures.";
        public override string Name => "Stonemason";
        public override Season Season => Season.Summer;

        [Import]
        public BuildStructureAction BuildStructure { get; set; }
        
        public override bool CanPlay(IGameState gameState)
        {
            return gameState.Money >= 8 && gameState.Structures.Count(p => !p.IsBought) >= 2;
        }

        protected override async Task<bool> OnApply(IGameState gameState)
        {
            BuildStructure.BuildingBonus = gameState.Structures.Max(p => p.Cost);
            var success = await BuildStructure.OnExecute();
            if (!success) return false;

            BuildStructure.BuildingBonus = gameState.Structures.Max(p => p.Cost);
            success = await BuildStructure.OnExecute();
            if (!success) return false;

            gameState.Money -= 8;
            return true;
        }
    }
}