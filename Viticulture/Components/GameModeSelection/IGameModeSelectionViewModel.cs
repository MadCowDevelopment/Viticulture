using System.Collections;
using System.Collections.Generic;
using Caliburn.Micro;
using Viticulture.Logic;
using Viticulture.Logic.GameModes;

namespace Viticulture.Components.GameModeSelection
{
    public interface IGameModeSelectionViewModel : IScreen
    {
        IGameMode SelectedGameMode { get; set; }

        IEnumerable<IGameMode> GameModes { get; }

        void GoBack();

        void StartGame();
    }
}