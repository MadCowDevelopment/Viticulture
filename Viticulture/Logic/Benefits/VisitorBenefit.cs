using System.ComponentModel.Composition;
using Viticulture.Logic.State;
using Viticulture.Services;

namespace Viticulture.Logic.Benefits
{
    public class VisitorBenefit : Benefit
    {
        private readonly IPlayerSelection _playerSelection;

        [ImportingConstructor]
        public VisitorBenefit(IPlayerSelection playerSelection)
        {
            _playerSelection = playerSelection;
        }

        public override string Name => "Summer or winter visitor";

        public override async void OnApply(IGameState gameState)
        {
            var selection = await _playerSelection.Select("Benefit", "Which visitor card do you want?", "Summer", "Winter");

            if (selection == Selection.Option1) gameState.SummerVisitorDeck.DrawToHand();
            else gameState.WinterVisitorDeck.DrawToHand();
        }
    }
}