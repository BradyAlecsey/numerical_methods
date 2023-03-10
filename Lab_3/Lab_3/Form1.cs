using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lab_3
{


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double x1, x2, h;
            x1 = Convert.ToDouble(textBoxX1.Text);
            x2 = Convert.ToDouble(textBoxX2.Text);
            h = Convert.ToDouble(textBoxH.Text);
            int n = dataGridView1.Rows.Count - 1;
            double[] X = new double[n];
            double[] Y = new double[n];
            

            for (int i = 0; i < n; i++)
            {
                X[i] = Convert.ToDouble(dataGridView1[0, i].Value);
                Y[i] = Convert.ToDouble(dataGridView1[1, i].Value);
            }

            chart1.Series.Clear();
            chart1.Series.Add("График 1");
            chart1.Series[0].ChartType = SeriesChartType.Line;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                chart1.Series[0].Points.AddXY(X[i], Y[i]);

            chart1.Series.Add("График 2");
            chart1.Series[1].ChartType = SeriesChartType.Line;
            for (double i = x1; i < x2; i += h)
            {
                double L = Solving.Lagrange(i, X, Y);
                chart1.Series[1].Points.AddXY(i, L);
            }
        }
    }
}
