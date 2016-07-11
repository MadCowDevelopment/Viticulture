using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Caliburn.Micro;
using Viticulture.Logic.Cards.Visitors;
using Viticulture.Services;

namespace Viticulture.Logic.Actions.Winter
{
    [Export(typeof(PlayWinterVisitorAction))]
    public class PlayWinterVisitorAction : PlayVisitorAction, IWinterAction
    {
        public override string Text => "Play winter visitor";
        public override bool CanExecuteSpecial => GameState.Hand.WinterVisitors.Any();

        [ImportingConstructor]
        public PlayWinterVisitorAction(IEventAggregator eventAggregator, IMetroDialog metroDialog,
            IMefContainer mefContainer) : base(eventAggregator, metroDialog, mefContainer)
        {
        }

        protected override IEnumerable<VisitorCard> Cards => GameState.Hand.WinterVisitors;
    }
}