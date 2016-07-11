using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using Viticulture.Logic.Actions;
using Viticulture.Logic.Actions.Summer;
using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Visitors.Summer
{
    public class PlanterCard : TwoChoicesVisitorCard
    {
        public override string Name => "Planter";
        public override Season Season => Season.Summer;

        [Import]
        public PlantVineAction PlantVine { get; set; }

        [Import]
        public UprootVineAction UprootVine { get; set; }

        protected override async Task<bool> ApplyOption1(IGameState gameState)
        {
            var clone = gameState.Clone();
            var firstPlantResult = await PlantVine.OnExecute();
            if (!firstPlantResult)
            {
                gameState.SetFromClone(clone);
                return false;
            }

            var secondPlantResult = await PlantVine.OnExecute();
            if (!secondPlantResult)
            {
                gameState.SetFromClone(clone);
                return false;
            }

            return true;
        }

        protected override async Task<bool> ApplyOption2(IGameState gameState)
        {
            return await UprootVine.OnExecute();
        }

        protected override bool CanApplyOption1(IGameState gameState)
        {
            return gameState.Hand.Vines.Count() >= 2 && PlantVine.CanExecuteSpecial;
        }

        protected override bool CanApplyOption2(IGameState gameState)
        {
            return UprootVine.CanExecuteSpecial;
        }

        protected override string Option1 => "plant up to 2 vines and gain 1 lira";
        protected override string Option2 => "uproot and discard 1 vine to gain 2 VP";
    }
}