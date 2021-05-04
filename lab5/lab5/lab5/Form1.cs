using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao.Platform.Windows;
using Tao.OpenGl;
using Tao.FreeGlut;


namespace lab5
{
   
    public partial class Form1 : Form
    {
        float angleFigureA = 0;
        float scaleFigureA = 1;
        float angleFigureB = 0;
        float scaleFigureB = 1;
        float shiftFigureAX = 0;
        float shiftFigureAY = 0;
        float shiftFigureBX = 0;
        float shiftFigureBY = 0;
        public Form1()
        {
            InitializeComponent();
            holst.InitializeContexts();
        }
        private void holst_Load(object sender, EventArgs e)
        {
            //устновка порта вывода в соответствии с размерами компонента holst
            Gl.glViewport(0, 0, holst.Width, holst.Height);
            Gl.glClearColor(1, 1, 1, 1);
            Draw(angleFigureB, scaleFigureB, angleFigureA, scaleFigureA,
               shiftFigureBX, shiftFigureBY, shiftFigureAX, shiftFigureAY);
        }
        private void Draw(float angle, float s, float ang, float r, float
       shiftFigureBX, float shiftFigureBY, float shiftFigureAX, float shiftFigureAY)
        {
            //построение фигуры Б
            Gl.glPushMatrix(); 
            Gl.glViewport(0, 0, holst.Width, holst.Height);
            Gl.glColor3f(0, 0, 0);
            Gl.glClearColor(1, 1, 1, 1);
            Gl.glLineWidth(2);
            Gl.glTranslatef(shiftFigureBX, shiftFigureBY, 0);
            Gl.glRotatef(angle, 0.0f, 0.0f, 1.0f);
            Gl.glScalef(s, s, s);

            Gl.glPointSize(3);

            Gl.glBegin(Gl.GL_POINTS);
            Gl.glEnable(Gl.GL_POINT_SMOOTH);
            Gl.glVertex2d(0.0d, -0.6d);
            Gl.glEnd();

            Gl.glLineWidth(3);

            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glVertex2d(-0.1d, -0.5d);
            Gl.glVertex2d(-0.3d, -0.3d);
            Gl.glVertex2d(-0.3d, -0.7d);
            Gl.glVertex2d(0.3d, -0.7d);
            Gl.glVertex2d(0.3d, -0.9d);
            Gl.glVertex2d(0.1d, -0.7d);
            Gl.glVertex2d(0.3d, -0.7d);
            Gl.glVertex2d(0.3d, -0.5d);
            Gl.glVertex2d(-0.3d, -0.5d);
            Gl.glEnd();

            Gl.glPopMatrix(); 

            //построение фигуры А
                              float R = 0.1f;
            Gl.glPushMatrix();
            Gl.glColor3f(250, 50, 1);
            Gl.glLineWidth(3);
            Gl.glRotatef(ang, 0.0f, 0.0f, 1.0f);
            Gl.glTranslatef(0f, -0.5f, 0);
            Gl.glTranslatef(shiftFigureAX, shiftFigureAY, 0);
            Gl.glScalef(r, r, r);

            Gl.glColor3d(0, 1, 0);
            Gl.glLineWidth(3);
            Gl.glBegin(Gl.GL_POLYGON);
            for (int i = 0; i < 6; i++)
            {
                double x = 0.3 * Math.Cos(2 * Math.PI * i / 6);
                double y = 0.3 * Math.Sin(2 * Math.PI * i / 6);
                double x1 = 0.3 * Math.Cos(2 * Math.PI * (i + 1) / 6);
                double y1 = 0.3 * Math.Sin(2 * Math.PI * (i + 1) / 6);
                Gl.glVertex2d(x, y);
                Gl.glVertex2d(x1, y1);
            }
            Gl.glEnd();

            Gl.glColor3d(0, 0, 0);
            Gl.glPointSize(3);
            Gl.glEnable(Gl.GL_POINT_SMOOTH);
            Gl.glBegin(Gl.GL_POINTS);
            Gl.glVertex2d(0.0d, 0.0d);
            for (int i = 0; i < 6; i++)
            {
                double x = 0.3 * Math.Cos(2 * Math.PI * i / 6);
                double y = 0.3 * Math.Sin(2 * Math.PI * i / 6);
                double x1 = 0.3 * Math.Cos(2 * Math.PI * (i + 1) / 6);
                double y1 = 0.3 * Math.Sin(2 * Math.PI * (i + 1) / 6);
                Gl.glVertex2d(x, y);
                Gl.glVertex2d(x1, y1);
            }
            Gl.glEnd();

            Gl.glEnable(Gl.GL_BLEND); 
            Gl.glColor4f(0f,0f,1f, 0.7f);
            Gl.glBlendFunc(Gl.GL_SRC_ALPHA,Gl.GL_ONE_MINUS_SRC_ALPHA);
            Gl.glLineWidth(4);
            Gl.glBegin(Gl.GL_POLYGON);
            for (int i = 0; i < 4; i++)
            {
                double x = 0.3 * Math.Cos(2 * Math.PI * i / 3);
                double y = 0.3 * Math.Sin(2 * Math.PI * i / 3);
                double x1 = 0.3 * Math.Cos(2 * Math.PI * (i + 1) / 3);
                double y1 = 0.3 * Math.Sin(2 * Math.PI * (i + 1) / 3);
                Gl.glVertex2d(x, y);
                Gl.glVertex2d(x1, y1);
            }
            Gl.glEnd();
            
            
            Gl.glPopMatrix();
            holst.Invalidate(); 
        }
        private void holst_KeyDown(object sender, KeyEventArgs e)
        {
            //фигура Б
            if (e.KeyCode == Keys.E) //поворот фигуры Б по часовой
            {
                Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
                angleFigureB--;
                if (angleFigureB == 360)
                {
                    angleFigureB = 0;
                }
                Draw(angleFigureB, scaleFigureB, angleFigureA, scaleFigureA,
               shiftFigureBX, shiftFigureBY, shiftFigureAX, shiftFigureAY);
            }
            if (e.KeyCode == Keys.Q) //поворот фигуры Б против часовой
            {
                Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
                angleFigureB++;
                if (angleFigureB == 360)
                {
                    angleFigureB = 0;
                }
                Draw(angleFigureB, scaleFigureB, angleFigureA, scaleFigureA,
               shiftFigureBX, shiftFigureBY, shiftFigureAX, shiftFigureAY);
            }
            if (e.KeyCode == Keys.X) //увеличение
            {
                Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
                scaleFigureB += 0.1f;
                Draw(angleFigureB, scaleFigureB, angleFigureA, scaleFigureA,
               shiftFigureBX, shiftFigureBY, shiftFigureAX, shiftFigureAY);
            }
            if (e.KeyCode == Keys.Z) //уменьшение
            {
                Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
                scaleFigureB -= 0.1f;
                Draw(angleFigureB, scaleFigureB, angleFigureA, scaleFigureA,
               shiftFigureBX, shiftFigureBY, shiftFigureAX, shiftFigureAY);
            }
            if (e.KeyCode == Keys.A) //сдвиг влево
            {
                Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
                shiftFigureBX -= 0.1f;
                Draw(angleFigureB, scaleFigureB, angleFigureA, scaleFigureA,
               shiftFigureBX, shiftFigureBY, shiftFigureAX, shiftFigureAY);
            }
            if (e.KeyCode == Keys.D) //сдвиг вправо
            {
                Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
                shiftFigureBX += 0.1f;
                Draw(angleFigureB, scaleFigureB, angleFigureA, scaleFigureA,
               shiftFigureBX, shiftFigureBY, shiftFigureAX, shiftFigureAY);
            }
            if (e.KeyCode == Keys.W) //сдвиг вверх
            {
                Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
                shiftFigureBY += 0.1f;
                Draw(angleFigureB, scaleFigureB, angleFigureA, scaleFigureA,
               shiftFigureBX, shiftFigureBY, shiftFigureAX, shiftFigureAY);
            }
            if (e.KeyCode == Keys.S) //сдвиг вниз
            {
                Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
                shiftFigureBY -= 0.1f;
                Draw(angleFigureB, scaleFigureB, angleFigureA, scaleFigureA,
               shiftFigureBX, shiftFigureBY, shiftFigureAX, shiftFigureAY);
            }
            //фигура А
            if (e.KeyCode == Keys.NumPad9) //поворот фигуры А по часовой
            {
                Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
                angleFigureA--;
                if (angleFigureA == 360)
                {
                    angleFigureA = 0;
                }
                Draw(angleFigureB, scaleFigureB, angleFigureA, scaleFigureA,
               shiftFigureBX, shiftFigureBY, shiftFigureAX, shiftFigureAY);
            }
            if (e.KeyCode == Keys.NumPad7) //поворот фигуры А против часовой
            {
                Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
                angleFigureA++;
                if (angleFigureA == 360)
                {
                    angleFigureA = 0;
                }
                Draw(angleFigureB, scaleFigureB, angleFigureA, scaleFigureA,
               shiftFigureBX, shiftFigureBY, shiftFigureAX, shiftFigureAY);
            }
            if (e.KeyCode == Keys.Add) //// увеличение
            {
                Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
                scaleFigureA += 0.1f;
                Draw(angleFigureB, scaleFigureB, angleFigureA, scaleFigureA,
               shiftFigureBX, shiftFigureBY, shiftFigureAX, shiftFigureAY);
            }
            if (e.KeyCode == Keys.OemMinus) //уменьшение
            {
                Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
                scaleFigureA -= 0.1f;
                Draw(angleFigureB, scaleFigureB, angleFigureA, scaleFigureA,
               shiftFigureBX, shiftFigureBY, shiftFigureAX, shiftFigureAY);
            }
            if (e.KeyCode == Keys.NumPad4) //сдвиг влево
            {
                Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
                shiftFigureAX -= 0.1f;
                Draw(angleFigureB, scaleFigureB, angleFigureA, scaleFigureA,
               shiftFigureBX, shiftFigureBY, shiftFigureAX, shiftFigureAY);
            }
            if (e.KeyCode == Keys.NumPad6) //сдвиг по y (вправо)
            {
                Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
                shiftFigureAX += 0.1f;
                Draw(angleFigureB, scaleFigureB, angleFigureA, scaleFigureA,
               shiftFigureBX, shiftFigureBY, shiftFigureAX, shiftFigureAY);
            }
            if (e.KeyCode == Keys.NumPad8) //сдвиг вверх
            {
                Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
                shiftFigureAY += 0.1f;
                Draw(angleFigureB, scaleFigureB, angleFigureA, scaleFigureA,
               shiftFigureBX, shiftFigureBY, shiftFigureAX, shiftFigureAY);
            }
            if (e.KeyCode == Keys.NumPad2) //сдвиг вниз
            {
                Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
                shiftFigureAY -= 0.1f;
                Draw(angleFigureB, scaleFigureB, angleFigureA, scaleFigureA,
               shiftFigureBX, shiftFigureBY, shiftFigureAX, shiftFigureAY);
            }
            if (e.KeyCode == Keys.NumPad3) //вращение фигуры А вокруг фигуры Б по часовой
            {
                angleFigureA -= 2;
                if (angleFigureB == 360)
                {
                    angleFigureB = 0;
                }
                Draw(angleFigureB, scaleFigureB, angleFigureA, scaleFigureA,
               shiftFigureBX, shiftFigureBY, shiftFigureAX, shiftFigureAY);
            }
            if (e.KeyCode == Keys.NumPad1) //вращение фигуры А вокруг фигуры Б против часовой
            {
                angleFigureA += 2;
                if (angleFigureB == 360)
                {
                    angleFigureB = 0;
                }
                Draw(angleFigureB, scaleFigureB, angleFigureA, scaleFigureA,
               shiftFigureBX, shiftFigureBY, shiftFigureAX, shiftFigureAY);
            }
        }
    }
}
