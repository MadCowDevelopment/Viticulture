using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using MahApps.Metro.Controls.Dialogs;
using Viticulture.Logic.Actions.Winter;
using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Visitors.Winter
{
    public class CrushExpertCard : TwoChoicesVisitorCard
    {
        public override string Name => "Crush Expert";
        public override Season Season => Season.Winter;

        [Import]
        public MakeWineAction MakeWine { get; set; }

        protected override Task<bool> ApplyOption1(IGameState gameState)
        {
            gameState.Money += 3;
            gameState.OrderDeck.DrawToHand();
            return Task.FromResult(true);
        }

        protected override async Task<bool> ApplyOption2(IGameState gameState)
        {
            var success = await MakeWine.OnExecute();
            if (!success) return false;

            return await MakeWine.OnExecuteBonus();
        }

        protected override bool CanApplyOption1(IGameState gameState)
        {
            return true;
        }

        protected override bool CanApplyOption2(IGameState gameState)
        {
            return gameState.Grapes.Count() >= 3;
        }

        protected override string Option1 => "gain 3 lira and draw 1 order card";
        protected override string Option2 => "make up to 3 wine";
    }
}