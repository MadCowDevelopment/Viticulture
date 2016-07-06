using System;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Caliburn.Micro;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Viticulture.Screens;

namespace Viticulture.Services
{
    [Export(typeof(IMetroDialog))]
    public class MetroDialog : IMetroDialog
    {
        private BaseMetroDialog _currentlyShownDialog;

        [ImportingConstructor]
        public MetroDialog()
        {
        }

        private MetroWindow MetroWindow => Application.Current.MainWindow as MetroWindow;

        public async Task<MessageDialogResult> ShowMessage(string title, string message,
            MessageDialogStyle style = MessageDialogStyle.Affirmative, MetroDialogSettings settings = null)
        {
            return await MetroWindow.ShowMessageAsync(title, message, style, settings);
        }

        //public Task ShowDialog<T>(T screen) where T : IScreen
        //{
        //    var view = ViewLocator.LocateForModel(screen, null, null) as UserControl;
        //    view.Loaded += (sender, args) =>
        //    {
        //        ViewModelBinder.Bind(screen, view, null);
        //    };

        //    var dialog = new CustomMetroDialog();
        //    dialog.MainContent.Content = view;
        //    _currentlyShownDialog = dialog;
            
        //    return MetroWindow.ShowMetroDialogAsync(dialog);
        //}

        public async Task ShowDialog(IDialogViewModel viewModel)
        {
            var view = ViewLocator.LocateForModel(viewModel, null, null) as UserControl;
            view.Loaded += (sender, args) =>
            {
                ViewModelBinder.Bind(viewModel, view, null);
            };

            var dialog = new CustomMetroDialog();
            dialog.MainContent.Content = view;
            _currentlyShownDialog = dialog;

            await MetroWindow.ShowMetroDialogAsync(dialog);
            await viewModel.Task;
            await MetroWindow.HideMetroDialogAsync(dialog);
        }

        public async Task CloseDialog()
        {
            if (_currentlyShownDialog == null) return;

            await MetroWindow.HideMetroDialogAsync(_currentlyShownDialog);
        }
    }

    public interface IDialogViewModel : IViewModel
    {
        event EventHandler Closed;
        Task Task { get; }
    }
}