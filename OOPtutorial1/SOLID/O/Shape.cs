using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learnProject.OOPtutorial1.SOLID.O
{
    public abstract class Shape 
    {
        //abstract -- pot avea metode care nu au nevoie neaparat de corp {}
        public abstract double CalculateArea();
    }




    //internal class Shape
    //{
        // bad method
        //public ShapeType Type { get; set; }
        //public double Radius { get; set; }
        //public double Lenght { get; set; }
        //public double Width { get; set; }

        //public double CalculateArea() {
        //    switch (Type) {
        //        case ShapeType.Circle:
        //            return Math.PI * Math.Pow(Radius, 2);
        //        case ShapeType.Rectangle:
        //            return Lenght * Width;
        //        default:
        //            throw new InvalidOperationException("Unsupported shape type");
        //    }
        //}
    //}
}
