using System.ComponentModel.Composition;

namespace Viticulture.Logic.GameModes
{
    [InheritedExport(typeof(IGameMode))]
    public abstract class GameMode : IGameMode
    {
        public abstract string Name { get; }

        public abstract string Description { get; }
    }
}