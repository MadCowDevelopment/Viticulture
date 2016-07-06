using System;
using System.ComponentModel.Composition;
using Caliburn.Micro;
using Viticulture.Logic.Pieces;
using Viticulture.Logic.State;

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
        private Lazy<IGameState> LazyState { get; set; }

        protected IGameState GameState => LazyState.Value;

        public abstract string Text { get; }

        protected virtual bool IsUnlimited => false;

        public void Handle(GameStateChanged message)
        {
            Refresh();
        }

        public void Execute()
        {
            if (!OnExecute()) return;

            if (HasBeenUsed) GameState.Grande.HasBeenUsed = true;
            else GameState.GetFirstAvailableWorker().HasBeenUsed = true;

            HasBeenUsed = true;

            NotifyOfPropertyChange(() => CanExecute);
        }

        public abstract bool OnExecute();

        public bool CanExecute
        {
            get
            {
                if (GameState.AutomaCard == null) return false;
                if (GameState.GetFirstAvailableWorker() == null) return false;
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