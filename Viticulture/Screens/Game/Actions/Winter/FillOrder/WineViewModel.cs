using Viticulture.Logic.Pieces;

namespace Viticulture.Screens.Game.Actions.Winter.FillOrder
{
    public class WineViewModel
    {
        public WineViewModel(Wine wine)
        {
            Wine = wine;
        }

        public Wine Wine { get; }

        public bool IsSelected { get; set; }

        public string DisplayText => $"{Wine.Type} - {Wine.Value}";
    }
}