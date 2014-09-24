namespace Automata
{
    public interface IAmTransition<T>
    {
        bool Evaluate(T t);

        IAmState<T> Target { get; }
    }
}