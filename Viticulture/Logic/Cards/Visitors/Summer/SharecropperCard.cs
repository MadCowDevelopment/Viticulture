using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using Viticulture.Logic.Actions;
using Viticulture.Logic.Actions.Summer;
using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Visitors.Summer
{
    public class SharecropperCard : TwoChoicesVisitorCard
    {
        public override string Name => "Sharecropper";
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
            var vinesBeforeUproot = gameState.Hand.Vines.ToList();
            var success = await UprootVine.OnExecute();
            if (!success) return false;

            gameState.Hand.Vines.Except(vinesBeforeUproot).Single().Discard();
            gameState.VictoryPoints += 2;

            return true;
        }

        protected override bool CanApplyOption1(IGameState gameState)
        {
            return gameState.Hand.Vines.Any();
        }

        protected override bool CanApplyOption2(IGameState gameState)
        {
            return gameState.Fields.SelectMany(p => p.Vines).Any();
        }

        protected override string Option1 => "plant 1 vine (ignore structures)";
        protected override string Option2 => "uproot and discard 1 vine to gain 2 VP";
    }
}