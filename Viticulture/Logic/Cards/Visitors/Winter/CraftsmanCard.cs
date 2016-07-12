using System.Collections.Generic;
using System.Threading.Tasks;
using Viticulture.Logic.Cards.Visitors.Summer;
using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Visitors.Winter
{
    public class CraftsmanCard : SelectManyVisitorCard
    {
        private IEnumerable<Option> _options;

        public override string Name => "Craftsman";
        public override Season Season => Season.Winter;

        protected override IEnumerable<Option> Options => _options ?? (_options = new List<Option>
        {
            new Option("draw 1 order", state =>
            {
                state.OrderDeck.DrawToHand();
                return Task.FromResult(true);
            }, state => true),
            new Option("upgrade your cellar at the regular cost", state =>
            {
                if (!state.MediumCellar.IsBought)
                {
                    state.MediumCellar.IsBought = true;
                    state.Money -= state.MediumCellar.Cost;
                }
                else
                {
                    state.LargeCellar.IsBought = true;
                    state.Money -= state.LargeCellar.Cost;
                }

                return Task.FromResult(true);
            }, state => (!state.MediumCellar.IsBought && state.Money >= state.MediumCellar.Cost) ||
                        (!state.LargeCellar.IsBought && state.Money >= state.LargeCellar.Cost)),
            new Option("gain 1 VP",
                state =>
                {
                    state.VictoryPoints++;
                    return Task.FromResult(true);
                }, state => true)
        });

        protected override int RequiredSelections => 2;
    }
}