using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using Viticulture.Logic.Actions.Summer;
using Viticulture.Logic.State;
using Viticulture.Utils;

namespace Viticulture.Logic.Cards.Visitors.Summer
{
    public class AgriculturistCard : VisitorCard
    {
        public override string Description
            => "Plant 1 vine. Then, if you have at least 3 different types of vine planted on that field, gain 2 VP";

        public override string Name => "Agriculturist";
        public override Season Season => Season.Summer;

        [Import]
        public PlantVineAction PlantVine { get; set; }

        public override bool CanPlay(IGameState gameState)
        {
            return gameState.Hand.Vines.Any();
        }

        protected override async Task<bool> OnApply(IGameState gameState)
        {
            var fieldValuesBefore = gameState.Fields.Select(p => p.Value).ToList();
            var success = await PlantVine.OnExecute();
            if (!success) return false;

            var fieldValuesAfter = gameState.Fields.Select(p => p.Value).ToList();
            var fieldIndex = 0;
            for (int i = 0; i < fieldValuesBefore.Count(); i++)
            {
                if (fieldValuesBefore[i] != fieldValuesAfter[i])
                {
                    fieldIndex = i;
                    break;
                }
            }

            var fieldThatChanged = gameState.Fields.ElementAt(fieldIndex);
            if (fieldThatChanged.Vines.GroupBy(p => p.Name).Count() >= 3) gameState.VictoryPoints += 2;
            return true;
        }
    }
}