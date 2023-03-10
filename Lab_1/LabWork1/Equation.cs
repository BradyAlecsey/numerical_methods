using System;
using System.Collections.Generic;

namespace LabWork1
{
    public static class Equation
    {
        // метод половинного деления
        public static List<Data> Bissection(double a, double b, double h, int count)
        {
            var datalist = new List<Data>();
            double c;

            while (b - a > h)
            {
                c = (a + b) / 2;
                if (Math.Sign(a) * Math.Sign(c) < 0)
                {
                    b = c;
                }
                else
                {
                    a = c;
                }
                count++;

                var data = new Data();
                data.Count = count;
                data.RefinedRoot = a;
                data.UptoDate = c;
                data.FuncUptoDate = Function.Solving(c);
                datalist.Add(data);
            }
            return datalist;
        }

        // метод Ньютона
        public static List<Data> Newton(double a, double b, double h, int count)
        {
            var datalist = new List<Data>();

            double x1, y;
            do
            {
                x1 = a - Function.Solving(a)/ Function.Manufacturer(a);
                a = x1;
                y = Function.Solving(a);
                count++;

                var data = new Data();
                data.Count = count;
                data.RefinedRoot = a;
                data.UptoDate = x1;
                data.FuncUptoDate = Function.Solving(x1);
                datalist.Add(data);
            }
            while (Math.Abs(y) >= h);

            return datalist;
        }

        // метод Хорд
        public static List<Data> Chord(double a, double b, double h, int count)
        {
            var datalist = new List<Data>();
            double tmp;

            while (Math.Abs(b - a) > h)
            {
                tmp = a - (Function.Solving(b)/(Function.Solving(b)-Function.Solving(a)))*(b-a);
                a = tmp;
                count++;

                var data = new Data();
                data.Count = count;
                data.RefinedRoot = a;
                data.UptoDate = tmp;
                data.FuncUptoDate = Function.Manufacturer(tmp);
                datalist.Add(data);
            }

            return datalist;
        }
    }
}