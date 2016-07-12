using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Viticulture.Logic.Actions.Winter;
using Viticulture.Logic.Cards.Visitors.Summer;
using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Visitors.Winter
{
    public class ExporterCard : SelectManyVisitorCard
    {
        private IEnumerable<Option> _options;
        public override string Name => "Export";
        public override Season Season => Season.Winter;

        [Import]
        public MakeWineAction MakeWine { get; set; }

        [Import]
        public FillOrderAction FillOrder { get; set; }

        protected override IEnumerable<Option> Options => _options ?? (_options = new List<Option>
        {
            new Option("make up to 2 wine", state => MakeWine.OnExecute(), state => MakeWine.CanExecuteSpecial),
            new Option("fill 1 order", state => FillOrder.OnExecute(), state => FillOrder.CanExecuteSpecial),
            new Option("discard 1 grape to gain 2 VP", async state =>
            {
                var selectedGrape = await PlayerSelection.Select("Select grape", "Choose a grape to discard",
                    state.Grapes.Where(p => p.IsBought));
                if (selectedGrape == null) return false;
                selectedGrape.IsBought = false;
                state.VictoryPoints += 2;
                return true;
            }, state => state.Grapes.Any())
        });

        protected override int RequiredSelections => 2;
    }
}