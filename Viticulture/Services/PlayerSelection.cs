using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MahApps.Metro.Controls.Dialogs;
using Viticulture.Components.Game;

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

            var selectionViewModel = _mefContainer.GetExportedValue<ISelectionViewModel>();

            selectionViewModel.Title = title;
            selectionViewModel.Message = message;
            selectionViewModel.Option1 = option1;
            selectionViewModel.Option2 = option2;

            var result = await
                _metroDialog.ShowMessage(title, message, MessageDialogStyle.AffirmativeAndNegative,
                    new MetroDialogSettings { AffirmativeButtonText = option1, NegativeButtonText = option2 });

            return result == MessageDialogResult.Affirmative ? Selection.Option1 : Selection.Option2;
        }
    }
}
