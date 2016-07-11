using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using Viticulture.Logic.Actions.Summer;
using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Visitors.Summer
{
    public class LandscaperCard : TwoChoicesVisitorCard
    {
        public override string Name => "Landscaper";
        public override Season Season => Season.Summer;

        [Import]
        public PlantVineAction PlantVine { get; set; }

        protected override async Task<bool> ApplyOption1(IGameState gameState)
        {
            gameState.VineDeck.DrawToHand();
            return await PlantVine.OnExecute();
        }

        protected override async Task<bool> ApplyOption2(IGameState gameState)
        {
            var options = new List<VineCardOption>();
            foreach (var field in gameState.Fields)
            {
                foreach (var vineCard in field.Vines)
                {
                    options.Add(new VineCardOption($"F{field.Value}: {vineCard.DisplayText}",
                        state => Task.FromResult(true),
                        state => true, vineCard));
                }
            }
            var selections = (await PlayerSelection.SelectMany(options, 2)).OfType<VineCardOption>().ToList();
            if (selections.Count != 2) return false;

            var firstVine = selections[0].VineCard;
            var firstVineField = gameState.Fields.First(p => p.Vines.Any(v => v == firstVine));

            var secondVine = selections[1].VineCard;
            var secondVineField = gameState.Fields.First(p => p.Vines.Any(v => v == secondVine));

            firstVineField.UprootVine(firstVine);
            secondVineField.UprootVine(secondVine);

            if (!firstVineField.CanPlant(secondVine) || !secondVineField.CanPlant(firstVine)) return false;

            firstVineField.PlantVine(secondVine);
            secondVineField.PlantVine(firstVine);

            return true;
        }

        protected override bool CanApplyOption1(IGameState gameState)
        {
            return PlantVine.CanExecuteSpecial;
        }

        protected override bool CanApplyOption2(IGameState gameState)
        {
            return gameState.Fields.SelectMany(p => p.Vines).Count() >= 2;
        }

        protected override string Option1 => "draw 1 vine and plant 1 vine";
        protected override string Option2 => "switch 2 vines on your fields";
    }
}