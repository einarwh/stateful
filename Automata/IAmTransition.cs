namespace Automata
{
    public interface IAmTransition<T>
    {
        bool Evaluate(T t);

        State<T> Target { get; }
    }
}