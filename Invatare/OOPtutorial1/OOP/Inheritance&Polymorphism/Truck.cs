using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learnProject.Inheritance
{
    //1. Truck
    //Creează o clasă Truck care moștenește Vehicle și adaugă:
    //- int LoadCapacity(kg)
    //- bool HasTrailer
    //🧪 Creează un obiect Truck, setează Brand, Year, LoadCapacity, HasTrailer, și apelează Start() și Stop().

    internal class Truck : Vehicle
    {
        public int LoadCapacity { get; set; }
        public bool HasTrailer { get; set; }

        public Truck(string brand, int year) { 
            this.Brand = brand;
            this.Year = year;
        }

        public override void Start()
        {
            Console.WriteLine("Truck is starting..");
        }

        public override void Stop()
        {
            Console.WriteLine("Truck is stopping..");
        }

    }
}
