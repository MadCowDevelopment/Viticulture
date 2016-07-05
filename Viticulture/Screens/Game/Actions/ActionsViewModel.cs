using System;
using System.ComponentModel.Composition;
using Caliburn.Micro;
using Viticulture.Logic.State;
using Viticulture.Screens.Game.Actions.Spring;
using Viticulture.Screens.Game.Actions.Summer;
using Viticulture.Screens.Game.Actions.Winter;
using Viticulture.Utils;

namespace Viticulture.Screens.Game.Actions
{
    [Export(typeof(IActionsViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public sealed class ActionsViewModel : ViewModel, IActionsViewModel, IHandle<GameStateChanged>
    {
        private readonly ISpringActionsViewModel _springActionsViewModel;
        private readonly ISummerActionsViewModel _summerActionsViewModel;
        private readonly IWinterActionsViewModel _winterActionsViewModel;

        [ImportingConstructor]
        public ActionsViewModel(
            IEventAggregator eventAggregator,
            ISpringActionsViewModel springActionsViewModel,
            ISummerActionsViewModel summerActionsViewModel,
            IWinterActionsViewModel winterActionsViewModel)
        {
            DisplayName = "Actions";

            eventAggregator.Subscribe(this);
            _springActionsViewModel = springActionsViewModel;
            _summerActionsViewModel = summerActionsViewModel;
            _winterActionsViewModel = winterActionsViewModel;

            CurrentSeason = Season.Spring.ToString();
            CurrentActions = _springActionsViewModel;
        }

        public string CurrentSeason { get; private set; }

        public IViewModel CurrentActions { get; private set; }

        public void Handle(GameStateChanged message)
        {
            if (MemberNameHelper.GetMemberName<IGameState>(p => p.Season) == message.PropertyName)
            {
                CurrentSeason = message.GameState.Season.ToString();
                CurrentActions = GetActionsForSeason(message.GameState.Season);
            }
        }

        private IViewModel GetActionsForSeason(Season season)
        {
            switch (season)
            {
                case Season.Spring:
                    return _springActionsViewModel;
                case Season.Summer:
                    return _summerActionsViewModel;
                case Season.Winter:
                    return _winterActionsViewModel;
                default:
                    return CurrentActions;
            }
        }
    }
}