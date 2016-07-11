using System.ComponentModel.Composition;
using System.Threading.Tasks;
using Viticulture.Logic.State;
using Viticulture.Screens.Game.Actions.Visitors;
using Viticulture.Services;

namespace Viticulture.Logic.Cards.Visitors
{
    public abstract class TwoChoicesVisitorCard : VisitorCard
    {
        [Import]
        public IMetroDialog MetroDialog { get; set; }

        [Import]
        public IMefContainer MefContainer { get; set; }

        public override string Description => $"{Option1} or {Option2}";

        protected override async Task<bool> OnApply(IGameState gameState)
        {
            var twoChoicesViewModel = MefContainer.GetExportedValue<ITwoChoicesViewModel>();
            twoChoicesViewModel.Option1 = Option1;
            twoChoicesViewModel.Option2 = Option2;
            twoChoicesViewModel.CanSelectOption1 = CanApplyOption1(gameState);
            twoChoicesViewModel.CanSelectOption2 = CanApplyOption2(gameState);

            var result = await MetroDialog.ShowDialog(twoChoicesViewModel);
            if (result == Selection.None) return false;
            return result == Selection.Option1 ? await ApplyOption1(gameState) : await ApplyOption2(gameState);
        }

        protected abstract Task<bool> ApplyOption1(IGameState gameState);
        protected abstract Task<bool> ApplyOption2(IGameState gameState);

        protected abstract bool CanApplyOption1(IGameState gameState);

        protected abstract bool CanApplyOption2(IGameState gameState);

        protected abstract string Option1 { get; }
        protected abstract string Option2 { get; }

        public override bool CanPlay(IGameState gameState)
        {
            return CanApplyOption1(gameState) || CanApplyOption2(gameState);
        }
    }
}