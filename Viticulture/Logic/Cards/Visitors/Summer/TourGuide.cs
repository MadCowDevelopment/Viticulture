using System.ComponentModel.Composition;
using System.Threading.Tasks;
using Viticulture.Logic.Actions.Winter;
using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Visitors.Summer
{
    public class TourGuide : TwoChoicesVisitorCard
    {
        public override string Name => "Tour Guide";
        public override Season Season => Season.Summer;

        [Import]
        public HarvestFieldAction HarvestAction { get; set; }

        protected override Task<bool> ApplyOption1(IGameState gameState)
        {
            gameState.Money += 4;
            return Task.FromResult(true);
        }

        protected override async Task<bool> ApplyOption2(IGameState gameState)
        {
            return await HarvestAction.OnExecute();
        }

        protected override bool CanApplyOption1(IGameState gameState)
        {
            return true;
        }

        protected override bool CanApplyOption2(IGameState gameState)
        {
            return HarvestAction.CanExecuteSpecial;
        }

        protected override string Option1 => "gain 4 lira";
        protected override string Option2 => "harvest 1 field";
    }
}