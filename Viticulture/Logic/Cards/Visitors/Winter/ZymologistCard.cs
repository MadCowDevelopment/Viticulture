using System.ComponentModel.Composition;
using System.Threading.Tasks;
using Viticulture.Logic.Actions.Winter;
using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Visitors.Winter
{
    public class ZymologistCard : VisitorCard
    {
        public override string Description
            => "Make up to 2 wine of value 4 or greater even if you haven't upgraded your cellar";

        public override string Name => "Zymologist";

        public override Season Season => Season.Winter;

        [Import]
        public MakeWineAction MakeWine { get; set; }

        public override bool CanPlay(IGameState gameState)
        {
            return MakeWine.CanExecuteSpecial;
        }

        protected override async Task<bool> OnApply(IGameState gameState)
        {
            MakeWine.MinimumValue = 4;
            MakeWine.IgnoreCellarRestriction = true;
            return await MakeWine.OnExecute();
        }
    }
}