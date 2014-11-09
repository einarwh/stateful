using System;

namespace Automata
{
    public interface IAmMachine<T>
    {
        IAmState<T> State { get; }

        void Accept(T input);

        void Accept(T input, Action action );
    }
}