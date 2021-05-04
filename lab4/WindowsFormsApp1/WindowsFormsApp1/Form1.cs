using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        float[,] mas = new float[8, 4];

        private void xy()
        {
            int h = pictureBox1.Height;
            int w = pictureBox1.Width;

            Graphics g = pictureBox1.CreateGraphics();
            Pen blackPen = new Pen(Color.Black, 1);
            Pen redPen = new Pen(Color.Red, 3);
            Font font = new Font("Arial", 10);
            SolidBrush brush = new SolidBrush(Color.Black);


            g.DrawLine(blackPen, 2 * w / 5, 0, 2 * w / 5, 3 * h / 5);
            g.DrawLine(blackPen, w, 3 * h / 5, 2 * w / 5, 3 * h / 5);
            g.DrawLine(blackPen, 0, h, 2 * w / 5, 3 * h / 5);
            
           
            
            g.DrawString("X", font, brush, w - 30, 3 * h / 5 + 5);
            g.DrawString("Y", font, brush, 2 * w / 5 - 15, 15);
            g.DrawString("Z", font, brush, 2, h - 30);
            g.DrawString("0", font, brush, 2 * w / 5, 3 * h / 5);
            g.DrawString("1", font, brush, 2 * w / 5, 3 * h / 5 - 30);
            g.DrawString("1", font, brush, 2 * w / 5 + 30, 3 * h / 5);
            g.DrawString("1", font, brush, 2 * w / 5 - 10, 3 * h / 5 + 15);

            
            PointF[] triangleY = new PointF[]
                {
                new PointF(2*w / 5, 0), new PointF(2*w / 5 - 7, 15), new PointF(2*w / 5 + 7, 15),
                };
            PointF[] triangleX = new PointF[]
                {
                 new PointF(w, 3*h / 5), new PointF(w - 15,3* h / 5 - 7), new PointF(w - 15, 3*h / 5 + 7),
                 };
            PointF[] triangleZ = new PointF[]
                {
                 new PointF(0,h), new PointF(3,h-15), new PointF(15,h-5),
                 };
            g.FillPolygon(brush, triangleX);
            g.FillPolygon(brush, triangleY);
            g.FillPolygon(brush, triangleZ);
        }

        private void figure(float[,] mas)
        {
            Graphics pb = pictureBox1.CreateGraphics();
            int h = pictureBox1.Height;
            int w = pictureBox1.Width;

            pb.TranslateTransform(2 * w / 5, 3 * h / 5);

            float z = 65;

            mas[0, 0] = w / 5; mas[0, 1] = 4 * h / 5; mas[0, 2] = z; mas[0, 3] = 1;
            mas[1, 0] = 3 * w / 5; mas[1, 1] = 4 * h / 5; mas[1, 2] = z; mas[1, 3] = 1;
            mas[2, 0] = w / 5; mas[2, 1] = 2 * h / 5; mas[2, 2] = z; mas[2, 3] = 1;
            mas[3, 0] = 3 * w / 5; mas[3, 1] = 2 * h / 5; mas[3, 2] = z; mas[3, 3] = 1;

            mas[4, 0] = w / 5 + z; mas[4, 1] = 4 * h / 5 - z; mas[4, 2] = -z; mas[4, 3] = 1;
            mas[5, 0] = 3 * w / 5 + z; mas[5, 1] = 4 * h / 5 - z; mas[5, 2] = -z; mas[5, 3] = 1;
            mas[6, 0] = w / 5 + z; mas[6, 1] = 2 * h / 5 - z; mas[6, 2] = -z; mas[6, 3] = 1;
            mas[7, 0] = 3 * w / 5 + z; mas[7, 1] = 2 * h / 5 - z; mas[7, 2] = -z; mas[7, 3] = 1;

        }

        private void DrawFigure(float[,] mas)
        {
            Graphics pb = pictureBox1.CreateGraphics();
            Pen redPen = new Pen(Color.Red, 3);

            var point1 = new PointF(mas[0, 0], mas[0, 1]);
            var point2 = new PointF(mas[1, 0], mas[1, 1]);
            var point3 = new PointF(mas[3, 0], mas[3, 1]);
            var point4 = new PointF(mas[2, 0], mas[2, 1]);

            var point5 = new PointF(mas[4, 0], mas[4, 1]);
            var point6 = new PointF(mas[5, 0], mas[5, 1]);
            var point7 = new PointF(mas[7, 0], mas[7, 1]);
            var point8 = new PointF(mas[6, 0], mas[6, 1]);

            pb.DrawLine(redPen, point1, point2);
            pb.DrawLine(redPen, point2, point3);
            pb.DrawLine(redPen, point3, point4);
            pb.DrawLine(redPen, point4, point1);

            pb.DrawLine(redPen, point5, point6);
            pb.DrawLine(redPen, point6, point7);
            pb.DrawLine(redPen, point7, point8);
            pb.DrawLine(redPen, point8, point5);

            pb.DrawLine(redPen, point1, point5);
            pb.DrawLine(redPen, point2, point6);
            pb.DrawLine(redPen, point3, point7);
            pb.DrawLine(redPen, point4, point8);

        }

        static float[,] Mul(float[,] matrixA, float[,] matrixB)
        {
            var matrixC = new float[8, 4];

            for (var i = 0; i < 8; i++)
            {
                for (var j = 0; j < 4; j++)
                {
                    matrixC[i, j] = 0;

                    for (var k = 0; k < 4; k++)
                    {
                        matrixC[i, j] += matrixA[i, k] * matrixB[k, j];
                    }
                }
            }
            matrixA = matrixC;
            return matrixA;
        }



        private void rotationX(float a)
        {
            
            float[,] arr = new float[4, 4];
            float alp = (float)(a * Math.PI / 180);
            arr[0, 0] = 1; arr[0, 1] = 0; arr[0, 2] = 0; arr[0, 3] = 0;
            arr[1, 0] = 0; arr[1, 1] = (float)Math.Cos(alp); arr[1, 2] = (float)Math.Sin(alp); arr[1, 3] = 0;
            arr[2, 0] = 0; arr[2, 1] = -(float)Math.Sin(alp); arr[2, 2] = (float)Math.Cos(alp); arr[2, 3] = 0;
            arr[3, 0] = 0; arr[3, 1] = 0; arr[3, 2] = 0; arr[3, 3] = 1;

            mas = Mul(mas, arr);
            xy();
            DrawFigure(mas);
        }

        private void rotationY(float a)
        {
            
            float[,] arr = new float[4, 4];
            float alp = (float)(a * Math.PI / 180);
            arr[0, 0] = (float)Math.Cos(alp); arr[0, 1] = 0; arr[0, 2] = -(float)Math.Sin(alp); arr[0, 3] = 0;
            arr[1, 0] = 0; arr[1, 1] = 1; arr[1, 2] = 0; arr[1, 3] = 0;
            arr[2, 0] = (float)Math.Sin(alp); arr[2, 1] = 0; arr[2, 2] = (float)Math.Cos(alp); arr[2, 3] = 0;
            arr[3, 0] = 0; arr[3, 1] = 0; arr[3, 2] = 0; arr[3, 3] = 1;
            mas = Mul(mas, arr);
            xy();
            DrawFigure(mas);
        }

        private void rotationZ(float a)
        {
            
            float alp = (float)(a * Math.PI / 180);
            float[,] arr = new float[4, 4];

            arr[0, 0] = (float)Math.Cos(alp); arr[0, 1] = (float)Math.Sin(alp); arr[0, 2] = 0; arr[0, 3] = 0;
            arr[1, 0] = -(float)Math.Sin(alp); arr[1, 1] = (float)Math.Cos(alp); arr[1, 2] = 0; arr[1, 3] = 0;
            arr[2, 0] = 0; arr[2, 1] = 0; arr[2, 2] = 1; arr[2, 3] = 0;
            arr[3, 0] = 0; arr[3, 1] = 0; arr[3, 2] = 0; arr[3, 3] = 1;
            mas = Mul(mas, arr);

            xy();
            DrawFigure(mas);
        }

        private void projection(float[,] mas)
        {
            
            float r = 0.001f;
            float[,] arr = new float[4, 4];
            arr[0, 0] = 1; arr[0, 1] = 0; arr[0, 2] = 0; arr[0, 3] = 0;
            arr[1, 0] = 0; arr[1, 1] = 1; arr[1, 2] = 0; arr[1, 3] = 0;
            arr[2, 0] = 0; arr[2, 1] = 0; arr[2, 2] = 0; arr[2, 3] = r;
            arr[3, 0] = 0; arr[3, 1] = 0; arr[3, 2] = 0; arr[3, 3] = 1;
            mas = Mul(mas, arr);
            Del(mas);
            xy();
            DrawFigure(mas);
        }
        static float[,] Del(float[,] masrez)
        {
            for (int i = 0; i < 8; i++)
            {
                masrez[i, 0] = masrez[i, 0] / masrez[i, 3];
                masrez[i, 1] = masrez[i, 1] / masrez[i, 3];
                masrez[i, 2] = masrez[i, 2] / masrez[i, 3];
            }
            return masrez;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Refresh();
            xy();
            figure(mas);
            DrawFigure(mas);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Refresh();
            rotationX(10);
        } 
        private void button3_Click(object sender, EventArgs e)
        {
            Refresh();
            rotationY(10);
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Refresh();
            rotationZ(10);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Refresh();
            projection(mas);
        }
    }
}