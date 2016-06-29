using System.ComponentModel.Composition;
using System.Threading.Tasks;
using System.Windows;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace Viticulture.Services
{
    [Export(typeof(IMetroDialog))]
    public class MetroDialog : IMetroDialog
    {
        private MetroWindow MetroWindow => Application.Current.MainWindow as MetroWindow;

        public async Task<MessageDialogResult> ShowMessage(string title, string message,
            MessageDialogStyle style = MessageDialogStyle.Affirmative, MetroDialogSettings settings = null)
        {
            return await MetroWindow.ShowMessageAsync(title, message, style, settings);
        }
    }
}