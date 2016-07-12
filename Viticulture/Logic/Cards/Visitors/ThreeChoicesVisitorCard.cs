using System.ComponentModel.Composition;
using System.Threading.Tasks;
using Viticulture.Logic.State;
using Viticulture.Screens.Game.Actions.Visitors;
using Viticulture.Services;

namespace Viticulture.Logic.Cards.Visitors
{
    public abstract class ThreeChoicesVisitorCard : VisitorCard
    {
        [Import]
        public IMetroDialog MetroDialog { get; set; }

        [Import]
        public IMefContainer MefContainer { get; set; }

        public override string Description => $"{Option1} OR {Option2} OR {Option3}";

        protected override async Task<bool> OnApply(IGameState gameState)
        {
            var threeChoicesViewModel = MefContainer.GetExportedValue<IThreeChoicesViewModel>();
            threeChoicesViewModel.Option1 = Option1;
            threeChoicesViewModel.Option2 = Option2;
            threeChoicesViewModel.CanSelectOption1 = CanApplyOption1(gameState);
            threeChoicesViewModel.CanSelectOption2 = CanApplyOption2(gameState);

            var result = await MetroDialog.ShowDialog(threeChoicesViewModel);
            if (result == Selection.None) return false;

            if (result == Selection.Option1) return await ApplyOption1(gameState);
            if (result == Selection.Option2) return await ApplyOption2(gameState);
            if (result == Selection.Option3) return await ApplyOption3(gameState);
            return false;
        }

        protected abstract Task<bool> ApplyOption1(IGameState gameState);
        protected abstract Task<bool> ApplyOption2(IGameState gameState);
        protected abstract Task<bool> ApplyOption3(IGameState gameState);

        protected abstract bool CanApplyOption1(IGameState gameState);
        protected abstract bool CanApplyOption2(IGameState gameState);
        protected abstract bool CanApplyOption3(IGameState gameState);

        protected abstract string Option1 { get; }
        protected abstract string Option2 { get; }
        protected abstract string Option3 { get; }

        public override bool CanPlay(IGameState gameState)
        {
            return CanApplyOption1(gameState) || CanApplyOption2(gameState) || CanApplyOption3(gameState);
        }
    }
}