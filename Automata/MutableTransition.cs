using System;
using System.Collections.Generic;

namespace Automata
{
    public class MutableTransition<T> : IAmTransition<T>
    {
        private readonly Func<T, bool> _p;

        private readonly List<Action> _actions = new List<Action>();

        public MutableTransition(Func<T, bool> predicate, params Action[] actions)
        {
            _p = predicate;
            _actions.AddRange(actions);
        }

        public MutableTransition(Func<T, bool> predicate)
        {
            _p = predicate;
        }

        public IAmState<T> Source { get; set; }

        public void AddAction(Action a)
        {
            throw new NotImplementedException();
        }

        public void Execute()
        {
            foreach (var a in _actions) a();
        }

        public IAmState<T> Target { get; set; }

        public bool Evaluate(T t)
        {
            return _p(t);
        }
    }
}