using System;

namespace Automata
{
    public class ActionAccepter<T>
    {
        private Transition<T> _;

        public ActionAccepter(Transition<T> transition)
        {
            _ = transition;
        }

        public void Do(params Action[] actions)
        {
            foreach (var a in actions) _.AddAction(a);
        }
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

        public ActionAccepter<T> On(Func<T, bool> p)
        {
            var transition = new Transition<T>(p, _toState);    
            _fromState.AddTransition(transition);
            return new ActionAccepter<T>(transition);
        }

        public ActionAccepter<T> On(Func<T, bool> p, Action action)
        {
            var transition = new Transition<T>(p, _toState, action);
            _fromState.AddTransition(transition);
            return new ActionAccepter<T>(transition);
        }

        public ActionAccepter<T> On(T t, Action action)
        {
            return On(input => input.Equals(t), action);
        }
 
        public ActionAccepter<T> On(T t)
        {
            return On(input => input.Equals(t));
        }
    }
}