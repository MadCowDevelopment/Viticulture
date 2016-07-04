using System.Collections.Generic;
using Viticulture.Logic.GameModes;

namespace Viticulture.Screens.GameModeSelection
{
    public interface IGameModeSelectionViewModel : IViewModel
    {
        IGameMode SelectedGameMode { get; set; }

        IEnumerable<IGameMode> GameModes { get; }

        void GoBack();

        void StartGame();
    }
}