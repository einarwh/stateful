using System;

namespace Automata
{
    public class MutableTransition<T> : IAmTransition<T>
    {
        private readonly Func<T, bool> _p;

        public MutableTransition(Func<T, bool> predicate)
        {
            _p = predicate;
        }

        public IAmState<T> Source { get; set; }

        public IAmState<T> Target { get; set; }

        public bool Evaluate(T t)
        {
            return _p(t);
        }
    }
}