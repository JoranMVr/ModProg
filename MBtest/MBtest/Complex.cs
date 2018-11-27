using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBtest
{
    public class Complex
    {
        public double a; //real
        public double b; //imaginary
        private int v1;
        private int v2;

        public Complex(int v1, int v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

        public Complex(double a, double b)
        {
            this.a = a;
            this.b = b;
        }

        public void Square()
        {
            double temp = (a * a) - (b * b);
            b = 2.0 * a * b;
            a = temp;
        }
        public double Magnitude()
        {
            return Math.Sqrt((a * a) + (b * b));
        }
        public void Add(Complex c)
        {
            a += c.a;
            b += c.b;
        }
    }
}
