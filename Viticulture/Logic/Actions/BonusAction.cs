using System.ComponentModel.Composition;
using Caliburn.Micro;
using Viticulture.Logic.State;

namespace Viticulture.Logic.Actions
{
    public abstract class BonusAction : PlayerAction, IHandle<GameStateChanged>
    {
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

        [ImportingConstructor]
        public BonusAction(IEventAggregator eventAggregator) : base(eventAggregator)
        {
        }
    }
}
