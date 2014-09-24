namespace Automata
{
    public interface IAmMachine<T>
    {
        IAmState<T> State { get; }

        void Accept(T input);
    }
}