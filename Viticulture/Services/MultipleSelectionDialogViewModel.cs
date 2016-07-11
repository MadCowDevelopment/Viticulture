using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using Viticulture.Logic.Cards.Visitors.Summer;
using Viticulture.Utils;

namespace Viticulture.Services
{
    [Export(typeof(IMultipleSelectionDialogViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class MultipleSelectionDialogViewModel : DialogViewModel<IEnumerable<Option>>, IMultipleSelectionDialogViewModel
    {
        private int _requiredSelections;

        public string Title => "Select options";

        public string Message => $"Choose {_requiredSelections} of the following options";

        public IEnumerable<OptionViewModel> Options { get; private set; }

        public bool CanFinish => Options.Count(p => p.IsChecked) == _requiredSelections;
        
        public void Finish()
        {
            UnregisterEvents();
            Close(Options.Where(p => p.IsChecked).Select(p => p.Option));
        }

        public void Cancel()
        {
            UnregisterEvents();
            Close(Enumerable.Empty<Option>());
        }

        public void Initialize(IEnumerable<Option> options, int requiredSelections)
        {
            _requiredSelections = requiredSelections;
            Options = options.Select(p => new OptionViewModel(p)).ToList();
            Options.ForEach(p => p.PropertyChanged += OptionPropertyChanged);
        }

        private void OptionPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Refresh();
        }

        private void UnregisterEvents()
        {
            Options.ForEach(p => p.PropertyChanged -= OptionPropertyChanged); 
        }
    }
}