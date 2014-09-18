using System.Collections.Generic;

namespace Automata
{
    public interface IAmState<T>
    {
        string Name { get; }

        IEnumerable<Transition<T>> Transitions { get; }
    }
}