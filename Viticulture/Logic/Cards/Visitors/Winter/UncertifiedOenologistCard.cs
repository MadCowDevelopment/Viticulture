using System;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Visitors.Winter
{
    public class UncertifiedOenologistCard : TwoChoicesVisitorCard
    {
        public override string Name => "UncertifiedOenologist";
        public override Season Season => Season.Winter;

        [Import]
        public Lazy<IGameLogic> GameLogic { get; set; }

        protected override Task<bool> ApplyOption1(IGameState gameState)
        {
            GameLogic.Value.AgeWines();
            GameLogic.Value.AgeWines();
            return Task.FromResult(true);
        }

        protected override Task<bool> ApplyOption2(IGameState gameState)
        {
            if (!gameState.MediumCellar.IsBought)
            {
                gameState.MediumCellar.IsBought = true;
            }
            else
            {
                gameState.LargeCellar.IsBought = true;
            }

            gameState.VictoryPoints--;

            return Task.FromResult(true);
        }

        protected override bool CanApplyOption1(IGameState gameState)
        {
            return true;
        }

        protected override bool CanApplyOption2(IGameState gameState)
        {
            return gameState.VictoryPoints > GameState.MinimumVictoryPoints;
        }

        protected override string Option1 => "age all wine in your cellar twice";
        protected override string Option2 => "lose 1 VP to upgrade your cellar to the next level";
    }
}