using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using Viticulture.Logic.Benefits;
using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Visitors.Summer
{
    public class OrganizerCard : VisitorCard
    {
        public override string Description => "Choose a spring action and take its benefit.";
        public override string Name => "Organizer";
        public override Season Season => Season.Summer;

        [ImportMany]
        public IEnumerable<Benefit> Benefits { get; set; }

        public override bool CanPlay(IGameState gameState)
        {
            return true;
        }

        protected override async Task<bool> OnApply(IGameState gameState)
        {
            var selectedBenefit =
                await PlayerSelection.Select("Select benefit", "Choose the spring benefit you want to take", Benefits);
            if (selectedBenefit == null) return false;

            selectedBenefit.OnApply(gameState);
            return true;
        }
    }
}