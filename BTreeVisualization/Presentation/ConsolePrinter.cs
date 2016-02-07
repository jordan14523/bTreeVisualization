using BTreeVisualization.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTreeVisualization.Presentation
{
    public class ConsolePrinter : IPrinter
    {
        public void PrintLine(string toPrint)
        {
            Console.WriteLine(toPrint);
        }
    }
}
