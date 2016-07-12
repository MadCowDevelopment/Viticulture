using System;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using Viticulture.Logic.Actions.Winter;
using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Visitors.Winter
{
    public class MerchantCard : TwoChoicesVisitorCard
    {
        public override string Name => "Merchant";
        public override Season Season => Season.Winter;

        [Import]
        public FillOrderAction FillOrder { get; set; }

        protected override Task<bool> ApplyOption1(IGameState gameState)
        {
            gameState.RedGrapes.First(p => p.Value == 1).IsBought = true;
            gameState.WhiteGrapes.First(p => p.Value == 1).IsBought = true;
            gameState.Money -= 3;
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
            return gameState.Money >= 3;
        }

        protected override bool CanApplyOption2(IGameState gameState)
        {
            return gameState.Hand.Orders.Any();
        }

        protected override string Option1 => "pay 3 lira to put 1 red and 1 white grape on your crushpad";

        protected override string Option2 => "fill 1 order and gain 1 VP extra";
    }
}
