using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using Viticulture.Logic.State;
using Viticulture.Services;
using Viticulture.Utils;

namespace Viticulture.Logic.Cards.Parents
{
    [InheritedExport(typeof(MamaCard))]
    public abstract class MamaCard : ParentCard
    {
        [Import]
        public IMetroDialog MetroDialog { get; set; }
        public sealed override async Task Setup(IGameState gameState)
        {
            await MetroDialog.ShowMessage($"Mama {Name}", $"Mama {Name} gives you {Benefits}.");
            gameState.Workers.Where(p => !p.IsBought).Take(2).ForEach(p => p.IsBought = true);
            OnSetup(gameState);
        }

        protected abstract void OnSetup(IGameState gameState);

        protected abstract string Benefits { get; }
    }
}