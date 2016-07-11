using System.Linq;
using System.Threading.Tasks;
using Viticulture.Logic.Pieces;
using Viticulture.Logic.State;
using Viticulture.Services;

namespace Viticulture.Logic.Cards.Visitors.Summer
{
    public class SurveyorCard : TwoChoicesVisitorCard
    {
        public override string Name => "Surveyor";
        public override Season Season => Season.Summer;

        protected override Task<bool> ApplyOption1(IGameState gameState)
        {
            gameState.Money += gameState.Fields.Count(p => !p.IsSold && !p.Vines.Any());
            return Task.FromResult(true);
        }

        protected override Task<bool> ApplyOption2(IGameState gameState)
        {
            gameState.VictoryPoints += gameState.Fields.Count(p => !p.IsSold && p.Vines.Any());
            return Task.FromResult(true);
        }

        protected override bool CanApplyOption1(IGameState gameState)
        {
            return true;
        }

        protected override bool CanApplyOption2(IGameState gameState)
        {
            return true;
        }

        protected override string Option1 => "gain 2 lira for each empty field";
        protected override string Option2 => "gain 1 VP for each planted field";
    }
}
