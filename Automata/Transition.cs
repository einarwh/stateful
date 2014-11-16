using System;
using System.Collections.Generic;

namespace Automata
{
    public class Transition<T> : IAmTransition<T>
    {
        private readonly Func<T, bool> _p;

        private readonly IAmState<T> _targetState;

        private readonly List<Action> _actions = new List<Action>(); 

        public Transition(Func<T, bool> predicate, State<T> targetState, params Action[] actions)
        {
            _p = predicate;
            _targetState = targetState;
            _actions.AddRange(actions);
        }

        public void AddAction(Action a)
        {
            _actions.Add(a);
        }

        public void Execute()
        {
            foreach (var a in _actions) a();
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
    }
}