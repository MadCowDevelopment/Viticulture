using System;
using System.Threading.Tasks;
using Viticulture.Logic.Cards.Vines;
using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Visitors.Summer
{
    public class VineCardOption : Option
    {
        public VineCard VineCard { get; }

        public VineCardOption(string text, Func<IGameState, Task<bool>> apply, Func<IGameState, bool> canApply,
            VineCard vineCard) : base(text, apply, canApply)
        {
            VineCard = vineCard;
        }
    }
}