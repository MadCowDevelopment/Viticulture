using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using Viticulture.Logic.Actions.Summer;
using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Visitors.Summer
{
    public class ArtisanCard : ThreeChoicesVisitorCard
    {
        public override string Name => "Artisan";
        public override Season Season => Season.Summer;

        [Import]
        public BuildStructureAction BuildStructure { get; set; }

        [Import]
        public PlantVineAction PlantVine { get; set; }


        protected override Task<bool> ApplyOption1(IGameState gameState)
        {
            gameState.Money += 3;
            return Task.FromResult(true);
        }

        protected override Task<bool> ApplyOption2(IGameState gameState)
        {
            BuildStructure.BuildingBonus = 1;
            return BuildStructure.OnExecute();
        }

        protected override async Task<bool> ApplyOption3(IGameState gameState)
        {
            var success = await PlantVine.OnExecute();
            if (!success) return false;
            await PlantVine.OnExecute();
            return true;
        }

        protected override bool CanApplyOption1(IGameState gameState)
        {
            return true;
        }

        protected override bool CanApplyOption2(IGameState gameState)
        {
            return gameState.Structures.Any(p => !p.IsBought && p.Cost - 1 <= gameState.Money);
        }

        protected override bool CanApplyOption3(IGameState gameState)
        {
            return gameState.Hand.Vines.Any();
        }

        protected override string Option1 => "gain 3 lira";
        protected override string Option2 => "build a structure at a 1 lira discount";
        protected override string Option3 => "plant up to 2 vines";
    }
}