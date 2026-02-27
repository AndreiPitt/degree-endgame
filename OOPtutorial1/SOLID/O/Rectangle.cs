using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learnProject.OOPtutorial1.SOLID.O
{
    internal class Rectangle : Shape
    {
        public double Lenght { get; set; }
        public double Width { get; set; }

        public override double CalculateArea()
        {
            return Lenght * Width;
        }
    }
}
