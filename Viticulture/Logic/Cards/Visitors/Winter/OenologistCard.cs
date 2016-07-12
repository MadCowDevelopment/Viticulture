using System;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Visitors.Winter
{
    public class OenologistCard : TwoChoicesVisitorCard
    {
        public override string Name => "Oenologist";
        public override Season Season => Season.Winter;

        [Import]
        public Lazy<IGameLogic> GameLogic { get; set; }

        protected override Task<bool> ApplyOption1(IGameState gameState)
        {
            GameLogic.Value.AgeGrapes();
            GameLogic.Value.AgeGrapes();
            return Task.FromResult(true);
        }

        protected override Task<bool> ApplyOption2(IGameState gameState)
        {
            if (gameState.MediumCellar.IsBought) gameState.LargeCellar.IsBought = true;
            else gameState.MediumCellar.IsBought = true;
            gameState.Money -= 3;
            return Task.FromResult(true);
        }

        protected override bool CanApplyOption1(IGameState gameState)
        {
            return true;
        }

        protected override bool CanApplyOption2(IGameState gameState)
        {
            return gameState.Money >= 3 && (!gameState.MediumCellar.IsBought || !gameState.LargeCellar.IsBought);
        }

        protected override string Option1 => "age all wine in your cellar twice";
        protected override string Option2 => "pay 3 lira to upgrade your cellar to the next level";
    }
}