using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    public class Solving
    {
        public static double Lagrange(double x, double[] X, double[] Y)
        {
            double lagrange = 0;

            for (int i = 0; i < X.Length; i++)
            {
                double Pol = 1;

                for (int j = 0; j < X.Length; j++)
                    if (j != i)
                        Pol *= (x - X[j]) / (X[i] - X[j]);

                lagrange += Pol * Y[i];
            }

            return lagrange;
        }
    }
}
