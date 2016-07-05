using System.Windows;
using System.Windows.Controls;
using Viticulture.Logic.Actions;

namespace Viticulture.Screens.Game.Actions.Summer
{
    public class ActionTemplateSelector : DataTemplateSelector
    {
        public DataTemplate PlayerActionTemplate { get; set; }

        public DataTemplate BonusActionTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if(item is BonusAction) return BonusActionTemplate;
            return PlayerActionTemplate;
        }
    }
}
