using System.Collections.Generic;
using System.ComponentModel.Composition;
using Viticulture.Logic;

namespace Viticulture.Services
{
    [Export(typeof(ISelectionDialogViewModel<>))]
    public class SelectionDialogViewModel<T> : DialogViewModel<T>, ISelectionDialogViewModel<T> where T : Entity
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public IEnumerable<T> Selections { get; set; }

        public void Select(T selectedItem)
        {
            Close(selectedItem);
        }

        public void Cancel()
        {
            Close(null);
        }
    }
}