using System.Collections.Generic;
using System.ComponentModel.Composition;
using Viticulture.Logic.Actions.Winter;
using Viticulture.Logic.Cards.Visitors.Summer;
using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Visitors.Winter
{
    public class JackOfAllTradesCard : SelectManyVisitorCard
    {
        public override string Name => "Jack-of-all-trades";
        public override Season Season => Season.Winter;

        [Import]
        public HarvestFieldAction HarvestField { get; set; }

        [Import]
        public MakeWineAction MakeWine { get; set; }

        [Import]
        public FillOrderAction FillOrder { get; set; }


        protected override IEnumerable<Option> Options => new List<Option>
        {
            new Option("harvest 1 field", state => HarvestField.OnExecute(), state => HarvestField.CanExecuteSpecial),
            new Option("make up to 2 wine", state => MakeWine.OnExecute(), state => MakeWine.CanExecuteSpecial),
            new Option("fill 1 order", state => FillOrder.OnExecute(), state => FillOrder.CanExecuteSpecial)
        };

        protected override int RequiredSelections => 2;
    }
}