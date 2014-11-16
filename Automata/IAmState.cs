using System;
using System.Collections.Generic;

namespace Automata
{
    public interface IAmState<T>
    {
        string Name { get; }

        void Execute();

        IEnumerable<IAmTransition<T>> Transitions { get; }
    }
}