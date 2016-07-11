using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Viticulture.Logic.Cards.Visitors.Summer;
using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Visitors
{
    public abstract class SelectManyVisitorCard : VisitorCard
    {
        public override string Description => string.Join(" or ", Options.Select(p => p.Text));
        protected abstract IEnumerable<Option> Options { get; }

        public override bool CanPlay(IGameState gameState)
        {
            return Options.Count(p => p.CanApply(gameState)) >= RequiredSelections;
        }

        protected abstract int RequiredSelections { get; }
        protected override async Task<bool> OnApply(IGameState gameState)
        {
            var selections = (await PlayerSelection.SelectMany(Options, RequiredSelections)).ToList();
            if (selections.Count != RequiredSelections) return false;

            var gameStateClone = gameState.Clone();
            foreach (var selection in selections)
            {
                if (!await selection.Apply(gameState))
                {
                    gameState.SetFromClone(gameStateClone);
                    return false;
                }
            }

            return true;
        }
    }
}