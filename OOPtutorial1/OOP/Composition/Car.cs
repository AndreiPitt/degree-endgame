using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learnProject.OOPtutorial1.OOP.Composition
{
    internal class Car
    {
        private Engine _engine = new Engine();

        public void Drive() { 
            _engine.Start();
            Console.WriteLine("Masina se deplaseaza");
        }
    }
}
