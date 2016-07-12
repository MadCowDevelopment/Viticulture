using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using Viticulture.Logic.Actions.Summer;
using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Visitors.Winter
{
    public class DesignerCard : VisitorCard
    {
        public override string Description => "Build 1 structure. Then, if you have at least 6 structures, gain 2 VP.";
        public override string Name => "Designer";
        public override Season Season => Season.Winter;

        [Import]
        public BuildStructureAction BuildStructure { get; set; }

        public override bool CanPlay(IGameState gameState)
        {
            return BuildStructure.CanExecuteSpecial;
        }

        protected override async Task<bool> OnApply(IGameState gameState)
        {
            var success = await BuildStructure.OnExecute();
            if (!success) return false;

            if (gameState.Structures.Count(p => p.IsBought) >= 6) gameState.VictoryPoints += 2;
            return true;
        }
    }
}