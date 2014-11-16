using System;

namespace Automata
{
    public interface IAmTransition<T>
    {
        bool Evaluate(T t);

        void AddAction(Action a);

        void Execute();

        IAmState<T> Target { get; }
    }
}