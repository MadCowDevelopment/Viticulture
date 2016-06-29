using System.ComponentModel.Composition;

namespace Viticulture.Logic.GameModes
{
    public class NormalGameMode : GameMode
    {
        [ImportingConstructor]
        public NormalGameMode(INormalGameModeInitializer normalGameModeInitializer) : base(normalGameModeInitializer)
        {
        }
        
        public override string Name => "Normal";

        public override string Description => "No special rules apply.";
    }
}