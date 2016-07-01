using System.ComponentModel.Composition;
using Viticulture.Components.Game;
using Viticulture.Logic.State;
using Viticulture.Services;

namespace Viticulture.Logic.Cards.Parents.Papas
{
    public class SamplePapaCard : PapaCard
    {
        public override string Name => "Papa Sample";

        protected override string Option1 => "3 lira";
        protected override string Option2 => "Irigation";

        protected override void OnSetup(IGameState gameState, Selection selection)
        {
            gameState.Money += 3;
            if (selection == Selection.Option1) gameState.Money += 3;
            else gameState.Irigation.IsBought = true;
        }
    }

    public interface IPlayerSelection
    {
        Selection Select(string title, string message, string option1, string option2);
    }

    [Export(typeof(IPlayerSelection))]
    public class PlayerSelection : IPlayerSelection
    {
        private readonly IMetroDialog _metroDialog;
        private readonly IMefContainer _mefContainer;

        [ImportingConstructor]
        public PlayerSelection(IMetroDialog metroDialog, IMefContainer mefContainer)
        {
            _metroDialog = metroDialog;
            _mefContainer = mefContainer;
        }

        public Selection Select(string title, string message, string option1, string option2)
        {
            
            var selectionViewModel = _mefContainer.GetExportedValue<ISelectionViewModel>();

            selectionViewModel.Title = title;
            selectionViewModel.Message = message;
            selectionViewModel.Option1 = option1;
            selectionViewModel.Option2 = option2;

            _metroDialog.ShowDialog(selectionViewModel);
            return selectionViewModel.SelectedOption;
        }
    }

    public enum Selection
    {
        Option1,
        Option2
    }
}