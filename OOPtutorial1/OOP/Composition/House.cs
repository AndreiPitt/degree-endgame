using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learnProject.OOPtutorial1.OOP.Composition
{
    internal class House
    {
        private IAction action;
        private Window _window;
        private Door _door;

        public void MyHouse() { 
            _door = new Door();
            _window = new Window();
            action = _door;
            Console.WriteLine("Asta este casa mea!");
            action.Open();
        }
    }
}
