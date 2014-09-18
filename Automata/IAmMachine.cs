namespace Automata
{
    public interface IAmMachine<T>
    {
        State<T> State { get; }

        void Accept(T input);
    }
}