using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;

namespace Automata
{
    public class DrawThing
    {
        public string GetDotGraphString<T>(
            IAmMachine<T> machine,
            IEnumerable<IAmState<T>> states)
        {
            var sb = new StringBuilder();
            sb.AppendLine("digraph G {");

            foreach (var state in states)
            {
                var ss = state.Name;
                bool isCurrent = machine.State.Equals(state);
                if (isCurrent)
                {
                    // color=".7 .3 1.0"
                    ss += " [style=filled, color=lightblue]";
                }

                sb.Append(" ").AppendLine(ss);

                // Draw state.
                foreach (var t in state.Transitions)
                {
                    // Draw edges please.
                    var ts = string.Format("{0} -> {1}", state.Name, t.Target.Name);
                    sb.Append(" ").AppendLine(ts);
                }
            }
            sb.AppendLine("}");

            return sb.ToString();
        }

        public Image CreateGraphImage(string s)
        {
            const string graphVizPath = @"C:\tools\Graphviz2.38\bin";
            var baseFileName = string.Format("g-{0}", DateTime.UtcNow.Ticks);
            var dotFileName = baseFileName + ".txt";
            var dotFilePath = Path.Combine(graphVizPath, dotFileName);
            File.WriteAllText(dotFilePath, s);
            var startInfo = new ProcessStartInfo
                                {
                                    WorkingDirectory = graphVizPath,
                                    FileName = "dot.exe",
                                    Arguments = string.Format("-Tpng -O {0}", dotFilePath)
                                };
            var p = Process.Start(startInfo);
            p.WaitForExit();
            return Image.FromFile(dotFilePath + ".png");
        }
    }
}