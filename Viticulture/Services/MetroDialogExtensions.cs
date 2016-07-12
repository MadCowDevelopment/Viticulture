using System.Threading.Tasks;
using MahApps.Metro.Controls.Dialogs;

namespace Viticulture.Services
{
    public static class MetroDialogExtensions
    {
        public static async Task<bool> DoneOrCancelVisitor(this IMetroDialog metroDialog, string operation)
        {
            return (await metroDialog.ShowMessage("Done or cancel",
                $"Are you done {operation} or do you want to cancel the visitor card",
                MessageDialogStyle.AffirmativeAndNegative,
                new MetroDialogSettings {AffirmativeButtonText = "Done", NegativeButtonText = "Cancel"})) ==
                   MessageDialogResult.Affirmative;
        }
    }
}