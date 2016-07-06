using System.Collections.Generic;
using System.ComponentModel.Composition;
using Caliburn.Micro;
using Viticulture.Logic.Pieces;
using Viticulture.Logic.State;

namespace Viticulture.Screens.Game.Fields
{
    [Export(typeof(IFieldsViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class FieldsViewModel : ViewModel, IFieldsViewModel, IHandle<GamePieceChanged>
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IGameState _gameState;

        [ImportingConstructor]
        public FieldsViewModel(IEventAggregator eventAggregator, IGameState gameState)
        {
            _eventAggregator = eventAggregator;
            _gameState = gameState;
            _eventAggregator.Subscribe(this);
        }

        public IEnumerable<Field> Fields => _gameState.Fields;

        public void Handle(GamePieceChanged message)
        {
            Refresh();
        }
    }
}