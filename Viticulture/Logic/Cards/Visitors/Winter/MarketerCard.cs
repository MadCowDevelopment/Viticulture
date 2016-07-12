using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using Viticulture.Logic.Actions.Winter;
using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Visitors.Winter
{
    public class MarketerCard : TwoChoicesVisitorCard
    {
        public override string Name => "Marketer";
        public override Season Season => Season.Winter;

        [Import]
        public FillOrderAction FillOrder { get; set; }

        protected override Task<bool> ApplyOption1(IGameState gameState)
        {
            gameState.SummerVisitorDeck.DrawToHand();
            gameState.SummerVisitorDeck.DrawToHand();
            gameState.Money++;
            return Task.FromResult(true);
        }

        protected override async Task<bool> ApplyOption2(IGameState gameState)
        {
            var success = await FillOrder.OnExecute();
            if (!success) return false;
            gameState.VictoryPoints++;
            return true;
        }

        protected override bool CanApplyOption1(IGameState gameState)
        {
            return true;
        }

        protected override bool CanApplyOption2(IGameState gameState)
        {
            return gameState.Hand.Orders.Any();
        }

        protected override string Option1 => "draw 2 summer visitors and gain 1 lira";
        protected override string Option2 => "fill 1 order and gain 1 VP extra";
    }
}