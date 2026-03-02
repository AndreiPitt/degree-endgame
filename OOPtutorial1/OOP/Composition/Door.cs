using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learnProject.OOPtutorial1.OOP.Composition
{
    internal class Door : IAction
    {
        public void Open()
        {
            Console.WriteLine("Geamul e deschis");
        }

        public void Close()
        {
            Console.WriteLine("Geamul e inchis");
        }
    }
}
