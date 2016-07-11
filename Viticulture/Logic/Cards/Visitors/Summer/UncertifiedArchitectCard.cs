using System.Linq;
using System.Threading.Tasks;
using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Visitors.Summer
{
    public class UncertifiedArchitectCard : TwoChoicesVisitorCard
    {
        public override string Name => "Uncertified Architect";
        public override Season Season => Season.Summer;

        protected override async Task<bool> ApplyOption1(IGameState gameState)
        {
            var selectedStructure =
                await
                    PlayerSelection.Select("Select structure", "Choose a structure to build",
                        gameState.Structures.Where(p => !p.IsBought && (p.Cost == 2 || p.Cost == 3)));
            if (selectedStructure == null) return false;
            selectedStructure.IsBought = true;
            return true;
        }

        protected override async Task<bool> ApplyOption2(IGameState gameState)
        {
            var selectedStructure =
                await
                    PlayerSelection.Select("Select structure", "Choose a structure to build",
                        gameState.Structures.Where(p => !p.IsBought));
            if (selectedStructure == null) return false;
            selectedStructure.IsBought = true;
            return true;
        }

        protected override bool CanApplyOption1(IGameState gameState)
        {
            return gameState.Structures.Any(p => !p.IsBought && (p.Cost == 2 || p.Cost == 3));
        }

        protected override bool CanApplyOption2(IGameState gameState)
        {
            return gameState.Structures.Any(p => !p.IsBought);
        }

        protected override string Option1 => "lose 1 VP to build a 2 or 3 value structure";
        protected override string Option2 => "lose 2 VP to build any structure";
    }
}