using System.ComponentModel.Composition;
using System.Threading.Tasks;
using MahApps.Metro.Controls.Dialogs;
using Viticulture.Logic.State;
using Viticulture.Services;

namespace Viticulture.Logic.Cards.Parents.Papas
{
    public class SamplePapaCard : PapaCard
    {
        public override string Name => "Papa Sample";

        protected override string Option1 => "3 lira";
        protected override string Option2 => "Irigation";

        protected override void OnSetup(IGameState gameState, Selection selection)
        {
            gameState.Money += 3;
            if (selection == Selection.Option1) gameState.Money += 3;
            else gameState.Irigation.IsBought = true;
        }
    }
}