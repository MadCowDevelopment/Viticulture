using System;
using System.Threading.Tasks;
using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Parents
{
    public abstract class ParentCard : Card
    {
        public override string Description => string.Empty;

        public abstract Task Setup(IGameState gameState);
    }
}