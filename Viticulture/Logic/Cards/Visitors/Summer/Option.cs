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

        public Option(string text) : this(text, state => Task.FromResult(true), state => true)
        {
        }

        public string Text { get; }
        public Func<IGameState, Task<bool>> Apply { get; }

        public Func<IGameState, bool> CanApply { get; }
    }

    public class Option<T> : Option
    {
        public T WrappedObject { get; private set; }

        public Option(T wrappedObject, string text, Func<IGameState, Task<bool>> apply, Func<IGameState, bool> canApply) : base(text, apply, canApply)
        {
            WrappedObject = wrappedObject;
        }

        public Option(T wrappedObject, string text) : this(wrappedObject, text, state => Task.FromResult(true), state => true)
        {
        }
    }
}