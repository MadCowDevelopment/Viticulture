using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using Viticulture.Logic.Actions.Summer;
using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Visitors.Summer
{
    public class OverseerCard : VisitorCard
    {
        public override string Description => "Build 1 structure and plant 1 vine. If it is a 4 value vine gain 1 VP.";
        public override string Name { get; }
        public override Season Season { get; }

        [Import]
        public BuildStructureAction BuildStructure { get; set; }

        [Import]
        public PlantVineAction PlantVine { get; set; }

        public override bool CanPlay(IGameState gameState)
        {
            return BuildStructure.CanExecuteSpecial && PlantVine.CanExecuteSpecial;
        }

        protected override async Task<bool> OnApply(IGameState gameState)
        {
            var success = await BuildStructure.OnExecute();
            if (!success) return false;

            var allVinesBeforePlanting = gameState.Hand.Vines.ToList();
            success = await PlantVine.OnExecute();
            if (!success) return false;

            var allVinesAfterPlanting = gameState.Hand.Vines.ToList();
            var plantedVine = allVinesBeforePlanting.Except(allVinesAfterPlanting).Single();
            if (plantedVine.WhiteValue + plantedVine.RedValue == 4) gameState.VictoryPoints++;

            return true;
        }
    }
}