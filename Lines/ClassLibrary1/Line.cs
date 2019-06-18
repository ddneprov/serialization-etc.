using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Xml.Serialization;

namespace ClassLibrary1
{
    [Serializable]
    public class Line
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }

        public Line(double A, double B, double C)
        {
            this.A = A;
            this.B = B;
            this.C = C;
        }
        public Line() { }
        public static double operator %(Point p, Line l)
        {
            try
            {
                return l.A * p.X + l.B * p.Y + l.C;
            }
            catch (Exception)
            {
                throw new ArgumentException("хоба");
            }
        }
        public override string ToString()
        {
            return $"A = {A}\t B = {B}\t C={C}";
        }


    }
}
