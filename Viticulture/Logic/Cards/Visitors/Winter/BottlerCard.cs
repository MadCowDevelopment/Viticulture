using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using Viticulture.Logic.Actions.Winter;
using Viticulture.Logic.State;
using Viticulture.Services;

namespace Viticulture.Logic.Cards.Visitors.Winter
{
    public class BottlerCard : VisitorCard
    {
        public override string Description => "Make up to 3 wine. Gain 1 VP for each type of wine you make.";
        public override string Name => "Bottler";
        public override Season Season => Season.Winter;

        [Import]
        public MakeWineAction MakeWine { get; set; }

        public override bool CanPlay(IGameState gameState)
        {
            return MakeWine.CanExecuteSpecial;
        }

        protected override async Task<bool> OnApply(IGameState gameState)
        {
            var redWinesBefore = gameState.RedWines.Count(p => p.IsBought);
            var whiteWinesBefore = gameState.WhiteWines.Count(p => p.IsBought);
            var blushWinesBefore = gameState.BlushWines.Count(p => p.IsBought);
            var sparklingWinesBefore = gameState.SparklingWines.Count(p => p.IsBought);

            var success = await MakeWine.MakeWine();
            if (!success) return false;

            if (!MakeWine.CanExecuteSpecial) return true;
            success = await MakeWine.MakeWine();
            if (!success)
            {
                AddVictoryPoints(gameState, redWinesBefore, whiteWinesBefore, blushWinesBefore, sparklingWinesBefore);
                return await MetroDialog.DoneOrCancelVisitor("harvesting");
            }

            if (!MakeWine.CanExecuteSpecial) return true;
            success = await MakeWine.MakeWine();
            if (!success)
            {
                AddVictoryPoints(gameState, redWinesBefore, whiteWinesBefore, blushWinesBefore, sparklingWinesBefore);
                return await MetroDialog.DoneOrCancelVisitor("harvesting");
            }

            AddVictoryPoints(gameState, redWinesBefore, whiteWinesBefore, blushWinesBefore, sparklingWinesBefore);

            return true;
        }

        private void AddVictoryPoints(IGameState gameState, int redWinesBefore, int whiteWinesBefore,
            int blushWinesBefore, int sparklingWinesBefore)
        {
            var redWinesAfter = gameState.RedWines.Count(p => p.IsBought);
            var whiteWinesAfter = gameState.WhiteWines.Count(p => p.IsBought);
            var blushWinesAfter = gameState.BlushWines.Count(p => p.IsBought);
            var sparklingWinesAfter = gameState.SparklingWines.Count(p => p.IsBought);

            var typesOfWineMade = 0;
            if (redWinesAfter > redWinesBefore) typesOfWineMade++;
            if (whiteWinesAfter > whiteWinesBefore) typesOfWineMade++;
            if (blushWinesAfter > blushWinesBefore) typesOfWineMade++;
            if (sparklingWinesAfter > sparklingWinesBefore) typesOfWineMade++;

            gameState.VictoryPoints += typesOfWineMade;
        }
    }
}