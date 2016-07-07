using Caliburn.Micro;
using Viticulture.Logic.Pieces;

namespace Viticulture.Screens.Game.Actions.Summer.SellGrapeOrField
{
    public class GrapeViewModel : PropertyChangedBase
    {
        public Grape Grape { get; }

        public GrapeViewModel(Grape grape)
        {
            Grape = grape;
        }

        public int Value => Grape.Value;
        public bool IsSelected { get; set; }
    }
}