using System.Collections.Generic;
using System.ComponentModel.Composition;
using Viticulture.Logic;
using Viticulture.Logic.GameModes;
using Viticulture.Services;

namespace Viticulture.Components.Game
{
    [Export(typeof(IGameViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GameViewModel : ViewModel<IGameMode>, IGameViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IGameLogic _gameLogic;
        private List<IViewModel> _tabs;

        [ImportingConstructor]
        public GameViewModel(INavigationService navigationService, IGameLogic gameLogic)
        {
            _navigationService = navigationService;
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
        public IVisitorsViewModel Visitors { get; private set; }

        [Import]
        public IBuildingsViewModel Buildings { get; private set; }

        [Import]
        public ICrushpadViewModel Crushpad { get; private set; }

        [Import]
        public ICellarViewModel Cellar { get; private set; }
    }
}