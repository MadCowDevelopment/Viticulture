using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using Viticulture.Logic.Actions.Summer;
using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Visitors.Summer
{
    public class ArchitectCard : TwoChoicesVisitorCard
    {
        public override string Name => "Architect";
        public override Season Season => Season.Summer;

        [Import]
        public BuildStructureAction BuildStructure { get; set; }

        protected override async Task<bool> ApplyOption1(IGameState gameState)
        {
            BuildStructure.BuildingBonus = 3;
            return await BuildStructure.OnExecute();
        }

        protected override Task<bool> ApplyOption2(IGameState gameState)
        {
            gameState.VictoryPoints += gameState.Structures.Count(p => p.IsBought && p.Cost == 4);
            return Task.FromResult(true);
        }

        protected override bool CanApplyOption1(IGameState gameState)
        {
            BuildStructure.BuildingBonus = 3;
            return BuildStructure.CanExecuteSpecial;
        }

        protected override bool CanApplyOption2(IGameState gameState)
        {
            return true;
        }

        protected override string Option1 => "build a structure at a 3 lira discount";
        protected override string Option2 => "gain 1 VP for each 4 lira structure you have built";
    }
}