using System.Collections.Generic;
using Viticulture.Logic.Cards.Visitors.Summer;

namespace Viticulture.Services
{
    public interface IMultipleSelectionDialogViewModel : IDialogViewModel<IEnumerable<Option>>
    {
        void Initialize(IEnumerable<Option> options, int requiredSelections);
    }
}