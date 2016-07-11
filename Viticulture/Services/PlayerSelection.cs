using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using MahApps.Metro.Controls.Dialogs;
using Viticulture.Logic;
using Viticulture.Logic.Cards.Visitors.Summer;

namespace Viticulture.Services
{
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

        public async Task<Selection> Select(string title, string message, string option1, string option2)
        {
            var result = await
                _metroDialog.ShowMessage(title, message, MessageDialogStyle.AffirmativeAndNegative,
                    new MetroDialogSettings { AffirmativeButtonText = option1, NegativeButtonText = option2 });

            return result == MessageDialogResult.Affirmative ? Selection.Option1 : Selection.Option2;
        }

        public async Task<T> Select<T>(string title, string message, IEnumerable<T> selections) where T : Entity
        {
            var selectionDialogViewModel = _mefContainer.GetExportedValue<ISelectionDialogViewModel<T>>();
            selectionDialogViewModel.Title = title;
            selectionDialogViewModel.Message = message;
            selectionDialogViewModel.Selections = selections;
            var selection = await _metroDialog.ShowDialog(selectionDialogViewModel);
            return selection;
        }

        public async Task<IEnumerable<Option>> SelectMany(IEnumerable<Option> options, int requiredSelections)
        {
            var multipleSelectionDialogViewModel = _mefContainer.GetExportedValue<IMultipleSelectionDialogViewModel>();
            multipleSelectionDialogViewModel.Initialize(options, requiredSelections);
            return await _metroDialog.ShowDialog(multipleSelectionDialogViewModel);
        }
    }
}
