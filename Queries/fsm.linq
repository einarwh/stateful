<Query Kind="Program">
  <Reference Relative="..\Automata\bin\Debug\Automata.dll">C:\github\stateful\Automata\bin\Debug\Automata.dll</Reference>
  <Namespace>Automata</Namespace>
</Query>

void Main()
{
	RunWith(Examples.BabyStates());
}

void RunWith(List<State<string>> states) {
	var machine = new Automaton<string>(states.First());
	var thing = new DrawThing();
	var str = thing.GetDotGraphString(machine, states);
	var img = thing.CreateGraphImage(str);
	img.Dump();
	
	while (true) {
		var s = Console.ReadLine().Trim();
		if ("quit".Equals(s)) break;
		machine.Accept(s);
		Util.ClearResults();
		str = thing.GetDotGraphString(machine, states);
		img = thing.CreateGraphImage(str);
		img.Dump();
	}
}