using System.Linq;

namespace Automata
{
    class Automaton<T> : IAmMachine<T>
    {
        private State<T> _state;

        public Automaton(State<T> startState)
        {
            _state = startState;
        }

        public State<T> State
        {
            get
            {
                return _state;
            }
        }

        public void Accept(T input)
        {
            if (_state.Transitions.Any())
            {
                foreach (var t in _state.Transitions)
                {
                    if (t.Evaluate(input))
                    {
                        _state = t.Target;
                        return;
                    }
                }
            }
        }
    }
}