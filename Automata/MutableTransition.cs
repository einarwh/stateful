using System;

namespace Automata
{
    public class MutableTransition<T> : IAmTransition<T>
    {
        private readonly Func<T, bool> _p;

        private State<T> _sourceState;
        private State<T> _targetState;

        public MutableTransition(Func<T, bool> predicate)
        {
            _p = predicate;
        }

        public State<T> Source
        {
            get { return _sourceState; }
            set { _sourceState = value; }
        }

        public State<T> Target
        {
            get { return _targetState; }
            set { _targetState = value; }
        }

        public bool Evaluate(T t)
        {
            return _p(t);
        }
    }
}