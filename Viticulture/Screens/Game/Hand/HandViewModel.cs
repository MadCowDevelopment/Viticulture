using System.Collections.Generic;
using System.ComponentModel.Composition;
using Viticulture.Logic.Cards;
using Viticulture.Logic.State;

namespace Viticulture.Screens.Game.Hand
{
    [Export(typeof(IHandViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public sealed class HandViewModel : ViewModel, IHandViewModel
    {
        private readonly IGameState _gameState;

        [ImportingConstructor]
        public HandViewModel(IGameState gameState)
        {
            _gameState = gameState;
            DisplayName = "Hand";
        }

        public IEnumerable<Card> Cards => _gameState.Hand.Cards;
    }
}