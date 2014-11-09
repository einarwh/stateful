using System;

namespace Automata
{
    public interface IAmTransition<T>
    {
        bool Evaluate(T t);

        Action Action { get;}

        IAmState<T> Target { get; }
    }
}