using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learnProject.OOPtutorial1.OOP.Interfaces
{
    internal class Report
    {
        private IPrinter _printer;

        public Report(IPrinter printer)
        {
            _printer = printer;
        }
        public void Generate() {
            _printer.Print("Raport generat.");
        }
    }
}
