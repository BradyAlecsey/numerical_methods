using System;

namespace LabWork1
{
    public static class Function
    {
        public static double Solving(double x) => Math.Sin(x)/x;
        public static double Manufacturer(double x) => Math.Cos(x)/x - Math.Sin(x)/Math.Pow(x,2);
    }
}
