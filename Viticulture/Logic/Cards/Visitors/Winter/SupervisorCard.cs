using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using Viticulture.Logic.Actions.Winter;
using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Visitors.Winter
{
    public class SupervisorCard : VisitorCard
    {
        public override string Description => "Make up to 2 wine. Gain 1 VP for each sparkling wine you make.";
        public override string Name => "Supervisor";
        public override Season Season => Season.Winter;

        [Import]
        public MakeWineAction MakeWine { get; set; }

        public override bool CanPlay(IGameState gameState)
        {
            return MakeWine.CanExecuteSpecial;
        }

        protected override async Task<bool> OnApply(IGameState gameState)
        {
            var numberOfSparklingWinesBefore = gameState.SparklingWines.Count(p => p.IsBought);
            var success = await MakeWine.OnExecute();
            if (!success) return false;

            var numberOfSparklingWinesAfter = gameState.SparklingWines.Count(p => p.IsBought);
            gameState.VictoryPoints += numberOfSparklingWinesAfter - numberOfSparklingWinesBefore;
            return true;
        }
    }
}