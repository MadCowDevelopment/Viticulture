using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using Viticulture.Logic.Actions.Summer;
using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Visitors.Summer
{
    public class CultivatorCard : VisitorCard
    {
        public override string Description
            => "Plant 1 vine. You may plant it on a field even if the total value is exceeded";

        public override string Name => "Cultivator";
        public override Season Season => Season.Summer;

        [Import]
        public PlantVineAction PlantVine { get; set; }

        public override bool CanPlay(IGameState gameState)
        {
            return gameState.Hand.Vines.Any();
        }

        protected override Task<bool> OnApply(IGameState gameState)
        {
            PlantVine.IgnoreMaxValue = true;
            return PlantVine.OnExecute();
        }
    }
}