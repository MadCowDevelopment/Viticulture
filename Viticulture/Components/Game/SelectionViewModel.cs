using System.ComponentModel.Composition;
using Viticulture.Logic.Cards.Parents.Papas;
using Viticulture.Services;

namespace Viticulture.Components.Game
{
    [Export(typeof(ISelectionViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class SelectionViewModel : ViewModel, ISelectionViewModel
    {
        private readonly IMetroDialog _metroDialog;

        [ImportingConstructor]
        public SelectionViewModel(IMetroDialog metroDialog)
        {
            _metroDialog = metroDialog;
        }

        public string Title { get; set; }
        public string Message { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }

        public void SelectOption1()
        {
            SelectedOption = Selection.Option1;
            _metroDialog.CloseDialog();
        }

        public void SelectOption2()
        {
            SelectedOption = Selection.Option2;
            _metroDialog.CloseDialog();
        }

        public Selection SelectedOption { get; set; }
    }
}