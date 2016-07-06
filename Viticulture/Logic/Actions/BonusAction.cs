using System.ComponentModel.Composition;
using Caliburn.Micro;

namespace Viticulture.Logic.Actions
{
    public abstract class BonusAction : PlayerAction
    {
        [ImportingConstructor]
        protected BonusAction(IEventAggregator eventAggregator) : base(eventAggregator)
        {
        }

        public abstract string BonusText { get; }

        public bool CanExecuteWithBonus => CanExecute && GameState.RemainingBonusActions > 0;

        public void ExecuteWithBonus()
        {
            Execute();
            OnExecuteBonus();
            GameState.RemainingBonusActions--;
        }

        protected abstract void OnExecuteBonus();

        public override void Refresh()
        {
            base.Refresh();
            NotifyOfPropertyChange(() => CanExecuteWithBonus);
        }
    }
}
