using System.Threading.Tasks;
using MahApps.Metro.Controls.Dialogs;

namespace Viticulture
{
    public interface IMetroDialog
    {
        Task<MessageDialogResult> ShowMessage(string title, string message,
            MessageDialogStyle style = MessageDialogStyle.Affirmative, MetroDialogSettings settings = null);
    }
}