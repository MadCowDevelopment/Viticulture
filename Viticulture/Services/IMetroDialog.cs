using System.Threading.Tasks;
using Caliburn.Micro;
using MahApps.Metro.Controls.Dialogs;

namespace Viticulture.Services
{
    public interface IMetroDialog
    {
        Task<MessageDialogResult> ShowMessage(string title, string message,
            MessageDialogStyle style = MessageDialogStyle.Affirmative, MetroDialogSettings settings = null);

        //Task ShowDialog<T>(T screen) where T : IScreen;

        Task ShowDialog(IDialogViewModel viewModel);

        Task CloseDialog();
    }
}