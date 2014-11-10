using System;
using System.Collections.Generic;
using System.Linq;

namespace Automata
{
    public class State<T> : IAmState<T>
    {
        private readonly string _name;

        private readonly Action _action;

        public Action Action
        {
            get { return _action; }
        }

        public State(string name)
        {
            _name = name;
           _action = () => {};
        }

        public State(string name, Action action)
        {
            _name = name;
            _action = action;
        }

        public string Name
        {
            get { return _name; }
        }

        private readonly List<Transition<T>> _transitions = new List<Transition<T>>();

        public TransitionAccepter<T> To(State<T> target)
        {
            return new TransitionAccepter<T>(this, target);
        }

        public void AddTransition(Transition<T> t)
        {
            _transitions.Add(t);
        }

        public IEnumerable<IAmTransition<T>> Transitions
        {
            get
            {
                return _transitions.ToList();
            }
        }
    }
}