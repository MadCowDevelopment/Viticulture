using System.ComponentModel.Composition;
using System.Threading.Tasks;
using MahApps.Metro.Controls.Dialogs;

namespace Viticulture.Services
{
    [Export(typeof(IPlayerSelection))]
    public class PlayerSelection : IPlayerSelection
    {
        private readonly IMetroDialog _metroDialog;


        [ImportingConstructor]
        public PlayerSelection(IMetroDialog metroDialog)
        {
            _metroDialog = metroDialog;
        }

        public async Task<Selection> Select(string title, string message, string option1, string option2)
        {
            var result = await
                _metroDialog.ShowMessage(title, message, MessageDialogStyle.AffirmativeAndNegative,
                    new MetroDialogSettings { AffirmativeButtonText = option1, NegativeButtonText = option2 });

            return result == MessageDialogResult.Affirmative ? Selection.Option1 : Selection.Option2;
        }
    }
}
