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

    public interface IPlayerSelection
    {
        Task<Selection> Select(string title, string message, string option1, string option2);
    }

    [Export(typeof(IPlayerSelection))]
    public class PlayerSelection : IPlayerSelection
    {
        private readonly IMetroDialog _metroDialog;

        [ImportingConstructor]
        public PlayerSelection(IMetroDialog metroDialog)
        {
            _metroDialog = metroDialog;
        }

        public async Task<Selection> Select(string title, string message, string option1, string option2)
        {
            return await _metroDialog.ShowMessage(title, message, MessageDialogStyle.AffirmativeAndNegative,
                new MetroDialogSettings {AffirmativeButtonText = option1, NegativeButtonText = option2}) ==
                   MessageDialogResult.Affirmative
                ? Selection.Option1
                : Selection.Option2;
        }
    }

    public enum Selection
    {
        Option1,
        Option2
    }
}