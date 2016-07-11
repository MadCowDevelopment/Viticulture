using System;
using System.Threading.Tasks;
using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Visitors.Summer
{
    public class Option
    {
        public Option(string text, Func<IGameState, Task<bool>> apply, Func<IGameState, bool> canApply)
        {
            Text = text;
            Apply = apply;
            CanApply = canApply;
        }

        public string Text { get; }
        public Func<IGameState, Task<bool>> Apply { get; }

        public Func<IGameState, bool> CanApply { get; }
    }
}