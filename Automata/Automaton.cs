using System;
using System.Linq;

namespace Automata
{
    public class Automaton<T> : IAmMachine<T>
    {
        private IAmState<T> _state;

        public Automaton(IAmState<T> startState)
        {
            _state = startState;
        }

        public IAmState<T> State
        {
            get
            {
                return _state;
            }
        }

        public void Accept(T input)
        {
            Accept(input, () => { });
        }

        /// <summary>
        /// Order of evaluation:
        /// - action given to Accept method
        /// - transition actions
        /// - state actions
        /// </summary>
        /// <param name="input"></param>
        /// <param name="action"></param>
        public void Accept(T input, Action action)
        {
            if (_state.Transitions.Any())
            {
                foreach (var t in _state.Transitions)
                {
                    if (t.Evaluate(input))
                    {
                        _state = t.Target;
                        action();
                        if (t.Action != null)
                        {
                            t.Action();
                        }
                        if (_state.Action != null)
                        {
                            _state.Action();
                        }
                        return;
                    }
                }
            }
            throw new Exception("Can not accept input in state: " + _state.Name);
        }
    }
}