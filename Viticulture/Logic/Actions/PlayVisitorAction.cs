using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Viticulture.Logic.Cards.Visitors;
using Viticulture.Screens.Game.Actions.Visitors;
using Viticulture.Services;

namespace Viticulture.Logic.Actions
{
    public abstract class PlayVisitorAction : BonusAction
    {
        private readonly IMetroDialog _metroDialog;
        private readonly IMefContainer _mefContainer;
        public override string BonusText => "+1 visitor";

        [ImportingConstructor]
        protected PlayVisitorAction(IEventAggregator eventAggregator, IMetroDialog metroDialog,
            IMefContainer mefContainer) : base(eventAggregator)
        {
            _metroDialog = metroDialog;
            _mefContainer = mefContainer;
        }

        public override async Task<bool> OnExecute()
        {
            return await ChooseAndPlayCard();
        }

        private async Task<bool> ChooseAndPlayCard()
        {
            var cardSelectionViewModel = _mefContainer.GetExportedValue<ICardSelectionViewModel>();
            cardSelectionViewModel.Initialize(Cards.Where(p => p.CanPlay(GameState)));
            var selectedCard = await _metroDialog.ShowDialog(cardSelectionViewModel);
            if (selectedCard == null) return false;
            var result = await selectedCard.Apply(GameState);
            if (!result) return false;
            selectedCard.Discard();
            return true;
        }

        protected override async Task<bool> OnExecuteBonus()
        {
            return await ChooseAndPlayCard();
        }

        protected abstract IEnumerable<VisitorCard> Cards { get; }
    }
}
