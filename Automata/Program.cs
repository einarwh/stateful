using System.Collections.Generic;

namespace Automata
{
    class Program
    {
        private static void Mood()
        {
            var neutral = new State<string>("neutral");
            var drunk = new State<string>("drunk");
            var happy = new State<string>("happy");
            var moody = new State<string>("moody");
            var angry = new State<string>("angry");

            neutral.To(happy).On("tickle");
            neutral.To(moody).On("hassle");
            neutral.To(drunk).On(s => s.Contains("beer"));

            moody.To(angry).On("tickle");
            moody.To(neutral).On(s => s.Contains("beer"));

            happy.To(neutral).On(s => "hassle".Equals(s));

            var states = new List<State<string>> { neutral, moody, happy, angry, drunk };
            var machine = new Automaton<string>(neutral);

            var thing = new DrawThing();
            var str = thing.GetDotGraphString(machine, states);
            var img = thing.CreateGraphImage(str);

        }

        static void Main(string[] args)
        {

        }
    }
}
