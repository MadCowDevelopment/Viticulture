using Caliburn.Micro;
using Viticulture.Logic.Cards.Visitors.Summer;

namespace Viticulture.Services
{
    public class OptionViewModel : PropertyChangedBase
    {
        public Option Option { get; }

        public bool IsChecked { get; set; }

        public string Text => Option.Text;

        public OptionViewModel(Option option)
        {
            Option = option;
        }
    }
}