using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        struct a
        {
            public double x;
            public double y;

        };

        const int iter = 50;
        const double min = 1e-3;
        const double max = 1e+3;


        public void Draw(int tx1, int ty1)
        {
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            Pen pen = new Pen(Color.Red);
            double p;
            int n;
            a z, t, d = new a();

            double x0 = -1.0, xn = 0.7;
            double y0 = -0.7, yn = 1.0;


            int mx = (int)Math.Round(tx1 / (xn - x0));
            int my = (int)Math.Round(ty1 / (yn - y0));


            int x1 = -mx, x2 = tx1 - mx;
            int y1 = -my, y2 = ty1 - my;

            for (int y = y1; y < y2; y++)
            {
                for (int x = x1; x < x2; x++)
                {
                    n = 0;
                    z.x = x * 0.005;
                    z.y = y * 0.005;
                    d = z;

                    while ((Math.Pow(z.x, 2) + Math.Pow(z.y, 2) < max) && (Math.Pow(d.x, 2) + Math.Pow(d.y, 2) > min) && (n < iter))
                    {
                        t = z;
                        p = Math.Pow(Math.Pow(t.x, 2) + Math.Pow(t.y, 2), 2);
                        z.x = 2.0 / 3.0 * t.x + (Math.Pow(t.x, 2) - Math.Pow(t.y, 2)) / (3.0 * p);
                        z.y = 2.0 / 3.0 * t.y * (1 - t.x / p);
                        d.x = Math.Abs(t.x - z.x);
                        d.y = Math.Abs(t.y - z.y);
                        n++;
                    }
                    pen.Color = Color.FromArgb(255, 0, (n * 9) % 255, (n * 9) % 255);
                    g.DrawRectangle(pen, mx + x, my + y, 1, 1);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int tx = pictureBox1.Width, ty = pictureBox1.Height;
            Draw(tx, ty);
        }
    }
}
