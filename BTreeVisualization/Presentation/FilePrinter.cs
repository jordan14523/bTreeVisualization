using BTreeVisualization.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTreeVisualization.Presentation
{
    public class FilePrinter : IPrinter, IDisposable
    {
        private StreamWriter _writer;

        public FilePrinter(string outputFilePath)
        {
            _writer = new StreamWriter(outputFilePath);
        }

        public void PrintLine(string toPrint)
        {
            _writer.WriteLine(toPrint);    
        }

        public void Dispose()
        {
            _writer.Dispose();
        }

    }
}
