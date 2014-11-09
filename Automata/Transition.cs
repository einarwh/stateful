using System;

namespace Automata
{
    public class Transition<T> : IAmTransition<T>
    {
        private readonly Func<T, bool> _p;

        private readonly IAmState<T> _targetState;

        public Transition(Func<T, bool> predicate, State<T> targetState, Action action)
        {
            _p = predicate;
            _targetState = targetState;
            Action = action;
        }

        public Transition(Func<T, bool> predicate, State<T> targetState)
        {
            _p = predicate;
            _targetState = targetState;
        }

        public IAmState<T> Target
        {
            get
            {
                return _targetState;
            }
        }

        public bool Evaluate(T t)
        {
            return _p(t);
        }

        public Action Action { get; private set; }
    }
}