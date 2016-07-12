using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Viticulture.Logic.Cards.Visitors.Summer;
using Viticulture.Logic.State;
using Viticulture.Utils;

namespace Viticulture.Logic.Cards.Visitors.Winter
{
    public class CaravanCard : VisitorCard
    {
        public override string Description
            => "Turn the top card of each deck face up. Draw 2 of these and discard the others.";

        public override string Name => "Caravan";
        public override Season Season => Season.Winter;

        public override bool CanPlay(IGameState gameState)
        {
            return true;
        }

        protected override async Task<bool> OnApply(IGameState gameState)
        {
            var cards = new List<Card>
            {
                gameState.VineDeck.Draw(),
                gameState.SummerVisitorDeck.Draw(),
                gameState.OrderDeck.Draw(),
                gameState.WinterVisitorDeck.Draw()
            };
        
            var options = cards.Select(p => new Option<Card>(p, p.DisplayText)).ToList();

            var selectedCards =
                (await PlayerSelection.SelectMany(options, 2)).OfType<Option<Card>>()
                    .Select(p => p.WrappedObject)
                    .ToList();

            if (selectedCards.Count != 2) return false;
            selectedCards.ForEach(p => p.TakeToHand());
            cards.Except(selectedCards).ForEach(p => p.Discard());
            return true;
        }
    }
}