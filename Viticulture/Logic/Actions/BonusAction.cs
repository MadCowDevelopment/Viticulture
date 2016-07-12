using System.ComponentModel.Composition;
using System.Threading.Tasks;
using Caliburn.Micro;
using Viticulture.Logic.State;

namespace Viticulture.Logic.Actions
{
    public abstract class BonusAction : PlayerAction
    {
        private GameState _gameStateClone;

        [ImportingConstructor]
        protected BonusAction(IEventAggregator eventAggregator) : base(eventAggregator)
        {
        }

        public abstract string BonusText { get; }

        public bool CanExecuteWithBonus => CanExecute && GameState.RemainingBonusActions > 0;

        public async void ExecuteWithBonus()
        {
            _gameStateClone = GameState.Clone();

            var result = await OnExecute();
            if (!result) return;

            
            result = await OnExecuteBonus();
            if (!result)
            {
                GameState.SetFromClone(_gameStateClone);
                return;
            }

            AfterExecute();

            GameState.RemainingBonusActions--;
        }

        public abstract Task<bool> OnExecuteBonus();

        public override void Refresh()
        {
            base.Refresh();
            NotifyOfPropertyChange(() => CanExecuteWithBonus);
        }
    }
}
