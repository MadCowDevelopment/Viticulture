using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using Viticulture.Logic.Actions.Summer;
using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Visitors.Summer
{
    public class HomesteaderCard : TwoChoicesVisitorCard
    {
        public override string Name => "Homesteader";
        public override Season Season => Season.Summer;

        [Import]
        public BuildStructureAction BuildStructure { get; set; }

        [Import]
        public PlantVineAction PlantVine { get; set; }

        protected override Task<bool> ApplyOption1(IGameState gameState)
        {
            BuildStructure.BuildingBonus = 3;
            return BuildStructure.OnExecute();
        }

        protected override async Task<bool> ApplyOption2(IGameState gameState)
        {
            return await PlantVine.OnExecute() && await PlantVine.OnExecute();
        }

        protected override bool CanApplyOption1(IGameState gameState)
        {
            return gameState.Structures.Any(p => !p.IsBought && p.Cost <= gameState.Money + 3);
        }

        protected override bool CanApplyOption2(IGameState gameState)
        {
            return gameState.Hand.Vines.Count() >= 2;
        }

        protected override bool CanDoBoth(IGameState gameState)
        {
            return gameState.VictoryPoints > GameState.MinimumVictoryPoints + 1;
        }

        protected override string DoBothCost => "1 VP";

        protected override void ApplyCostforDoingBoth(IGameState gameState)
        {
            base.ApplyCostforDoingBoth(gameState);
            gameState.VictoryPoints--;
        }

        protected override string Option1 => "build 1 structure at a 3 lira discount";
        protected override string Option2 => "plant up to 2 vines. You may lose 1 VP to do both";
    }
}