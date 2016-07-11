using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using Viticulture.Logic.Actions;
using Viticulture.Logic.Actions.Summer;
using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Visitors.Summer
{
    public class Horticulturist : TwoChoicesVisitorCard
    {
        public override string Name => "Horticulturist";
        public override Season Season => Season.Summer;

        [Import]
        public PlantVineAction PlantVine { get; set; }

        [Import]
        public UprootVineAction UprootVine { get; set; }

        protected override Task<bool> ApplyOption1(IGameState gameState)
        {
            PlantVine.IgnoreRequirements = true;
            return PlantVine.OnExecute();
        }

        protected override async Task<bool> ApplyOption2(IGameState gameState)
        {
            var success = await UprootVine.OnExecute();
            if (!success) return false;

            success = await UprootVine.OnExecute();
            if (!success) return false;

            gameState.VictoryPoints += 3;

            return true;
        }

        protected override bool CanApplyOption1(IGameState gameState)
        {
            return gameState.Hand.Vines.Any();
        }

        protected override bool CanApplyOption2(IGameState gameState)
        {
            return gameState.Fields.SelectMany(p => p.Vines).Count() >= 2;
        }

        protected override string Option1 => "plant any 1 vine (ignore structures)";
        protected override string Option2 => "uproot and discard 2 vines to gain 3 VP";
    }
}