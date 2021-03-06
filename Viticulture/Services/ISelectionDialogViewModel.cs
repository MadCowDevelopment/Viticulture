using System.Collections.Generic;
using Viticulture.Logic;

namespace Viticulture.Services
{
    public interface ISelectionDialogViewModel<T> : IDialogViewModel<T> where T : class, IHasDescription
    {
        string Title { get; set; }

        string Message { get; set; }

        IEnumerable<T> Selections { get; set; }
    }
}