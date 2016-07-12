using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using Viticulture.Logic.Actions.Winter;
using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Visitors.Winter
{
    public class CrusherCard : TwoChoicesVisitorCard
    {
        public override string Name => "Crusher";
        public override Season Season => Season.Winter;

        [Import]
        public MakeWineAction MakeWine { get; set; }

        protected override Task<bool> ApplyOption1(IGameState gameState)
        {
            gameState.Money += 3;
            gameState.SummerVisitorDeck.DrawToHand();
            return Task.FromResult(true);
        }

        protected override Task<bool> ApplyOption2(IGameState gameState)
        {
            gameState.OrderDeck.DrawToHand();
            return MakeWine.OnExecute();
        }

        protected override bool CanApplyOption1(IGameState gameState)
        {
            return true;
        }

        protected override bool CanApplyOption2(IGameState gameState)
        {
            return gameState.Grapes.Any(p => p.IsBought);
        }

        protected override string Option1 => "gain 3 lira and draw 1 summer visitor";
        protected override string Option2 => "draw 1 order and make up to 2 wine";
    }
}