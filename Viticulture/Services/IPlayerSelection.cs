using System.Collections.Generic;
using System.Threading.Tasks;
using Viticulture.Logic;
using Viticulture.Logic.Cards.Visitors.Summer;

namespace Viticulture.Services
{
    public interface IPlayerSelection
    {
        Task<Selection> Select(string title, string message, string option1, string option2);

        Task<T> Select<T>(string title, string message, IEnumerable<T> selections) where T : class, IHasDescription;

        Task<IEnumerable<Option>> SelectMany(IEnumerable<Option> options, int requiredSelections,
            SelectionRequirement selectionRequirement = SelectionRequirement.ExactMatch);
    }
}