using System.Collections.Generic;
using System.ComponentModel.Composition;
using Viticulture.Logic;
using Viticulture.Logic.GameModes;
using Viticulture.Screens.Game.Actions;
using Viticulture.Screens.Game.Cellar;
using Viticulture.Screens.Game.Crushpad;
using Viticulture.Screens.Game.Fields;
using Viticulture.Screens.Game.Hand;
using Viticulture.Screens.Game.PlayerStatus;
using Viticulture.Screens.Game.Structures;

namespace Viticulture.Screens.Game
{
    [Export(typeof(IGameViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GameViewModel : ViewModel<IGameMode>, IGameViewModel
    {
        private readonly IGameLogic _gameLogic;
        private List<IViewModel> _tabs;

        [ImportingConstructor]
        public GameViewModel(IGameLogic gameLogic)
        {
            _gameLogic = gameLogic;
        }

        public override void Initialize(IGameMode initObject)
        {
            _gameLogic.Initialize(initObject);
        }

        public List<IViewModel> Tabs
        {
            get { return _tabs ?? (_tabs = new List<IViewModel> {Actions, Visitors}); }
        }

        [Import]
        public IPlayerStatusViewModel PlayerStatus { get; private set; }

        [Import]
        public IActionsViewModel Actions { get; private set; }

        [Import]
        public IHandViewModel Visitors { get; private set; }

        [Import]
        public IStructuresViewModel Structures { get; private set; }

        [Import]
        public ICrushpadViewModel Crushpad { get; private set; }

        [Import]
        public ICellarViewModel Cellar { get; private set; }

        [Import]
        public IFieldsViewModel Fields { get; private set; }
    }
}