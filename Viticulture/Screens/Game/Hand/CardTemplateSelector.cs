using System.Windows;
using System.Windows.Controls;
using Viticulture.Logic.Cards.Orders;
using Viticulture.Logic.Cards.Vines;
using Viticulture.Logic.Cards.Visitors;

namespace Viticulture.Screens.Game.Hand
{
    public class CardTemplateSelector : DataTemplateSelector
    {
        public DataTemplate OrderTemplate { get; set; }
        public DataTemplate VineTemplate { get; set; }
        public DataTemplate VisitorTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is VisitorCard) return VisitorTemplate;
            if (item is OrderCard) return OrderTemplate;
            if(item is VineCard) return VineTemplate;
            return null;
        }
    }
}
