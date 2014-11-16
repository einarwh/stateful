using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Automata
{
    public class DelayedAutomaton<T> : IAmMachine<T>
    {
        private IAmState<T> _state;

        public DelayedAutomaton(IAmState<T> startState)
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
                    // Allow more spirits in here
                    Thread.Sleep(2000);
                    if (t.Evaluate(input))
                    {
                        _state = t.Target;
                        action();
                        t.Execute();
                        _state.Execute();
                        return;
                    }
                }
            }
            throw new Exception("Can not accept input in state: " + _state.Name);
        }
    }
}