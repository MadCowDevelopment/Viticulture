using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Caliburn.Micro;
using Viticulture.Logic.Cards.Visitors;
using Viticulture.Services;

namespace Viticulture.Logic.Actions.Summer
{
    [Export(typeof(PlaySummerVisitorAction))]
    public class PlaySummerVisitorAction : PlayVisitorAction, ISummerAction
    {
        public override string Text => "Play summer visitor";
        public override bool CanExecuteSpecial => GameState.Hand.SummerVisitors.Any();

        [ImportingConstructor]
        public PlaySummerVisitorAction(IEventAggregator eventAggregator, IMetroDialog metroDialog,
            IMefContainer mefContainer) : base(eventAggregator, metroDialog, mefContainer)
        {
        }

        protected override IEnumerable<VisitorCard> Cards => GameState.Hand.SummerVisitors;
    }
}