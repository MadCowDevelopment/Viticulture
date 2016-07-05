using System;
using System.ComponentModel.Composition;
using Caliburn.Micro;
using Viticulture.Logic.State;

namespace Viticulture.Logic.Actions
{
    [InheritedExport(typeof(PlayerAction))]
    public abstract class PlayerAction : PropertyChangedBase, IHandle<GameStateChanged>
    {
        [Import]
        private Lazy<IGameState> GameState { get; set; }

        protected IGameState State => GameState.Value;

        public abstract string Text { get; }

        public abstract string BonusText { get; }

        public abstract void Execute();

        public void Handle(GameStateChanged message)
        {
            Refresh();
        }
    }
}
