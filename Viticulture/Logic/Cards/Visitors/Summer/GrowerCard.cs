using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using Viticulture.Logic.Actions.Summer;
using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Visitors.Summer
{
    public class GrowerCard : VisitorCard
    {
        public override string Description => "Plant 1 vine. Then if you have planted at least 6 vines gain 2 VP";
        public override string Name => "Grower";
        public override Season Season => Season.Summer;

        [Import]
        public PlantVineAction PlantVine { get; set; }

        public override bool CanPlay(IGameState gameState)
        {
            return gameState.Hand.Vines.Any();
        }

        protected override async Task<bool> OnApply(IGameState gameState)
        {
            var success = await PlantVine.OnExecute();
            if (!success) return false;

            if (gameState.Fields.SelectMany(p => p.Vines).Count() >= 6) gameState.VictoryPoints++;
            return true;
        }
    }
}