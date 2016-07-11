using System;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using Caliburn.Micro;
using Viticulture.Logic.Pieces;
using Viticulture.Logic.State;
using Viticulture.Services;

namespace Viticulture.Logic.Actions
{
    [InheritedExport(typeof(PlayerAction))]
    public abstract class PlayerAction : PropertyChangedBase, IHandle<GameStateChanged>, IHandle<GamePieceChanged>
    {
        private readonly IEventAggregator _eventAggregator;

        [ImportingConstructor]
        protected PlayerAction(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
        }

        [Import]
        public IPlayerSelection PlayerSelection { get; set; }

        [Import]
        private Lazy<IGameState> LazyState { get; set; }

        protected IGameState GameState => LazyState.Value;

        public abstract string Text { get; }

        public abstract bool CanExecuteSpecial { get; }


        protected virtual bool IsUnlimited => false;

        public void Handle(GameStateChanged message)
        {
            Refresh();
        }

        public async void Execute()
        {
            var result = await OnExecute();
            if (!result) return;

            AfterExecute();
        }

        protected void AfterExecute()
        {
            if (IsUnlimited)
            {
                var worker = GameState.GetFirstAvailableWorker();
                worker.HasBeenUsed = true;
            }
            else
            {
                if (HasBeenUsed) GameState.Grande.HasBeenUsed = true;
                else GameState.GetFirstAvailableWorker().HasBeenUsed = true;
            }

            HasBeenUsed = true;

            NotifyOfPropertyChange(() => CanExecute);
        }

        public abstract Task<bool> OnExecute();

        public bool CanExecute
        {
            get
            {
                if (GameState.AutomaCard == null) return false;
                if (GameState.GetFirstAvailableWorker() == null) return false;
                if (!CanExecuteSpecial) return false;
                return IsUnlimited || !HasBeenUsed || !GameState.Grande.HasBeenUsed;
            }
        }

        public bool HasBeenUsed { get; set; }

        public override void Refresh()
        {
            base.Refresh();
            NotifyOfPropertyChange(() => CanExecute);
        }

        public void Handle(GamePieceChanged message)
        {
            Refresh();
        }

        public void Reset()
        {
            HasBeenUsed = false;
        }
    }
}