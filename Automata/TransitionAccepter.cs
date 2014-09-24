using System;

namespace Automata
{
    public class ActionAccepter<T>
    {
        
    }

    public class TransitionAccepter<T>
    {
        private readonly State<T> _fromState;
        private readonly State<T> _toState;

        public TransitionAccepter(State<T> fromState, State<T> toState)
        {
            _fromState = fromState;
            _toState = toState;
        }

        public void On(Func<T, bool> p)
        {
            _fromState.AddTransition(new Transition<T>(p, _toState));
        }

        public void On(T t)
        {
            On(input => input.Equals(t));
        }
    }
}