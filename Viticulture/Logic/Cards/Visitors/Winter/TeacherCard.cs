using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using Viticulture.Logic.Actions.Winter;
using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Visitors.Winter
{
    public class TeacherCard : TwoChoicesVisitorCard
    {
        public override string Name => "Teacher";
        public override Season Season => Season.Winter;

        [Import]
        public MakeWineAction MakeWine { get; set; }

        protected override Task<bool> ApplyOption1(IGameState gameState)
        {
            return MakeWine.OnExecute();
        }

        protected override Task<bool> ApplyOption2(IGameState gameState)
        {
            var worker = gameState.BuyWorker(2);
            return Task.FromResult(worker != null);
        }

        protected override bool CanApplyOption1(IGameState gameState)
        {
            return gameState.Grapes.Count() >= 2;
        }

        protected override bool CanApplyOption2(IGameState gameState)
        {
            return gameState.Money >= 2 && gameState.Workers.Any(p => !p.IsBought);
        }

        protected override string Option1 => "make up to 2 wine";
        protected override string Option2 => "pay 2 lira to train 1 worker";
    }
}