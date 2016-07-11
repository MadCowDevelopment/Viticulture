using System.ComponentModel.Composition;
using System.Threading.Tasks;
using Viticulture.Logic.Actions.Winter;
using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Visitors.Summer
{
    public class NoviceGuideCard : TwoChoicesVisitorCard
    {
        public override string Name => "Novice Guide";
        public override Season Season => Season.Summer;

        [Import]
        public MakeWineAction MakeWine { get; set; }

        protected override Task<bool> ApplyOption1(IGameState gameState)
        {
            gameState.Money += 3;
            return Task.FromResult(true);
        }

        protected override async Task<bool> ApplyOption2(IGameState gameState)
        {
            return await MakeWine.OnExecute();
        }

        protected override bool CanApplyOption1(IGameState gameState)
        {
            return true;
        }

        protected override bool CanApplyOption2(IGameState gameState)
        {
            return MakeWine.CanExecuteSpecial;
        }

        protected override string Option1 => "gain 3 lira";
        protected override string Option2 => "make up to 2 wine";
    }
}