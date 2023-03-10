using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lab_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double a, b, h;
            a = -3;   // Convert.ToDouble(textBox1.Text);
            b = 2;   // Convert.ToDouble(textBox2.Text);
            h = 1; // Convert.ToDouble(textBox3.Text);
            int n = (int)((b - a) / h + 1);
            double[] X = new double[n];
            double[] Y = new double[n];

            chart1.Series.Clear();
            chart1.Series.Add("График функции");
            chart1.Series[0].ChartType = SeriesChartType.Line;
            chart1.Series[0].Color = Color.Red;
            for (double i = a, j = 0; i <= b; i += h, j++)
                chart1.Series[0].Points.AddXY(X[(int)j] = i, Y[(int)j] = f(i));
            
            chart1.Series.Add("Полином Ньютона");
            chart1.Series[1].ChartType = SeriesChartType.Line;
            chart1.Series[1].Color = Color.DarkBlue;
            for (double xx = a; xx <= b; xx += 0.1)
                chart1.Series[1].Points.AddXY(xx, Newton(xx, X.Length, X, Y, h));
        }

        private double f(double x)
        {
            return Math.Pow(Math.E, x) + 1;
        }

        private double Newton(double x, int numberOfLines, double[] X, double[] Y, double step)
        {
            double[,] table = FillingTable(X, Y, numberOfLines);
            double[] dY = new double[numberOfLines];

            for (int i = 1; i < numberOfLines + 1; i++)
                dY[i - 1] = table[i, 0];

            double[] xN = new double[numberOfLines - 1];
            xN[0] = x - table[0, 0];
            for (int i = 1; i < numberOfLines - 1; i++)
                xN[i] = xN[i - 1] * (x - table[0, i]);

            double result = dY[0];
            for (int i = 1, fact = 1; i < numberOfLines; i++)
            {
                fact *= i;
                result += (dY[i] * xN[i - 1]) / (fact * Math.Pow(step, i));
            }

            return result;
        }

        private double[,] FillingTable(double[] X, double[] Y, int numberOfLines)
        {
            double[,] table = new double[numberOfLines + 1, numberOfLines];

            for (int i = 0; i < 2; i++)
                for (int j = 0; j < numberOfLines; j++)
                {
                    if (i == 0)
                        table[i, j] = X[j];
                    else
                        table[i, j] = Y[j];
                }

            for (int i = 2, n = numberOfLines - 1; i < numberOfLines + 1; i++)
            {
                for (int j = 0; j < n; j++)
                    table[i, j] = table[i - 1, j + 1] - table[i - 1, j];
                n--;
            }

            return table;
        }
    }
}
