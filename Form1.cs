using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simpsons_3._8_rule
{
    public partial class Form1 : Form
    {
        Graphics gr;

        public Form1()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer
                 | ControlStyles.AllPaintingInWmPaint
                 | ControlStyles.UserPaint,
                 true);

            UpdateStyles();

            MainMenu();
        }
        private void MainMenu()
        {
            gr = this.CreateGraphics();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            double k = GetNumber(textBox1.Text);
            double wt = GetNumber(textBox2.Text);
            int stepAmount = (int)GetNumber(textBox4.Text);

            if (stepAmount % 3 != 0)
            {
                MessageBox.Show("step must be aliquot to 3!!!!");
                stepAmount = 3;
            }

            double aLim = GetNumber(textBox5.Text);
            double bLim = GetNumber(textBox6.Text);

            double h = (bLim - aLim) / stepAmount;

            double result = CountFunction(h, stepAmount, k, wt, 0);

            textBox3.Text = $"{result}";

            Console.WriteLine(result);
        }

        static double GetNumber(string str)
        {
            if (str == "Pi" || str == "pi" || str == "PI")
            {
                return Math.PI;
            }
            else
            {
                double number;
                bool success = Double.TryParse(str, out number);

                if (success)
                {
                    return number;
                }
                else
                {
                    MessageBox.Show("Enter Number!!!");
                    return 0;
                }
            }
        }

        static double CountFunction(double h, int step, double k, double wt, double wt0)
        {
            //double resultH = (1 / Math.PI) * (3 * h / 8);
            double resultH = 3 * h / 8;

            double resultWt = 0;
            int coef;

            for (int i = 0; i < step + 1; i++)
            {
                if (i == 0 || i % 3 == 0)
                {
                    coef = 1;
                }
                else
                {
                    coef = 3;
                }
                resultWt = resultWt + coef * Simpsone(k, wt, wt0 + i * h);
            }

            return resultH * resultWt;
        }

        static double Simpsone(double k, double wt, double wt_)
        {
            return k*Math.Sin(wt*wt_);
        }

    }
}
