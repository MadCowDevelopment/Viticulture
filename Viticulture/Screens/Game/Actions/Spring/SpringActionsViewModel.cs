using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using Viticulture.Logic;
using Viticulture.Logic.Benefits;
using Viticulture.Logic.State;

namespace Viticulture.Screens.Game.Actions.Spring
{
    [Export(typeof(ISpringActionsViewModel))]
    public class SpringActionsViewModel : ViewModel, ISpringActionsViewModel
    {
        private readonly IGameLogic _gameLogic;
        private readonly IGameState _gameState;
        private readonly ObservableCollection<Benefit> _benefits;

        [ImportingConstructor]
        public SpringActionsViewModel(IGameLogic gameLogic, IGameState gameState, IEnumerable<Benefit> benefits)
        {
            _gameLogic = gameLogic;
            _gameState = gameState;
            _benefits = new ObservableCollection<Benefit>(benefits);
        }

        public IEnumerable<Benefit> Benefits => _benefits;

        public void SelectBenefit(Benefit benefit)
        {
            benefit.Apply(_gameState);
            _benefits.Remove(benefit);
            _gameLogic.EndSeason();
            Refresh();
        }
    }
}