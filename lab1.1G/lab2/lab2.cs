using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab1._1G
{
    public partial class lab2 : Form
    {
        public int xn, yn, xk, yk;
        public Color customColor = Color.Black;
        public int line;
        public int dash;
        public bool isDash = false;
        public int size = 1;
        LineStyle style = null;
        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        public void DrawSection()
        {
            int n;
            double xt, yt, dx, dy;
            dx = xk - xn;
            dy = yk - yn;
            n = 100;
            xt = xn;
            yt = yn;
            //Объявляем объект "myPen", задающий цвет и толщину пера
            Pen myPen = new Pen(customColor, size);
            //Объявляем объект "g" класса Graphics и предоставляем
            //ему возможность рисования на pictureBox1:
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            if (isDash)
            {
                DashLine(xt, yt, dx, dy, n, myPen, g);
            }
            else
            {
                for (int i = 1; i <= n; i++)
                {
                    //Рисуем прямоугольник:
                    g.DrawRectangle(myPen, (int)xt, (int)yt, 2, 2);
                    //Рисуем закрашенный прямоугольник:
                    //Объявляем объект "redBrush", задающий цвет кисти
                    // SolidBrush redBrush = new SolidBrush(Color.Red);
                    //Рисуем закрашенный прямоугольник
                    // g.FillRectangle(redBrush, (int)xt, (int)yt, 2, 2);
                    xt = xt + dx / n;
                    yt = yt + dy / n;
                }
            }
        }
        private void DashLine(double xt, double yt, double dx, double dy, int n, Pen myPen, Graphics g)
        {
            int l = line;
            int d = dash;
            dash = 0;
            for (int i = 1; i <= n; i++)
            {
                if (line != 0)
                {
                    //Рисуем прямоугольник:
                    g.DrawRectangle(myPen, (int)xt, (int)yt, 2, 2);
                    //Рисуем закрашенный прямоугольник:
                    //Объявляем объект "redBrush", задающий цвет кисти
                    // SolidBrush redBrush = new SolidBrush(Color.Red);
                    //Рисуем закрашенный прямоугольник
                    // g.FillRectangle(redBrush, (int)xt, (int)yt, 2, 2);
                    line--;
                    if (line == 0)
                    {
                        dash = d;
                    }
                }
                if (dash != 0)
                {
                    dash--;
                    if (dash == 0)
                    {
                        line = l;
                    }
                }
                xt = xt + dx / n;
                yt = yt + dy / n;
            }
            line = l;
            dash = d;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lab2SegmentDrawer segment = new lab2SegmentDrawer();
            if (segment.ShowDialog() == DialogResult.OK)
            {
                xn = segment.xn;
                yn = segment.yn;
                xk = segment.xk;
                yk = segment.yk;
                DrawSection();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                customColor = colorDialog1.Color;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (style.ShowDialog() == DialogResult.OK)
            {
                isDash = style.isDash;
                if (isDash)
                {
                    line = style.line;
                    dash = style.dash;
                }
                size = style.size;
            }
        }

        private void lab2_Load(object sender, EventArgs e)
        {
            style = new LineStyle();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                xk = 0;
                yk = 0;
                xk = e.X;
                yk = e.Y;
                DrawSection();
            }
            if (radioButton2.Checked == true)
            {
                xk = 0;
                yk = 0;
                xk = e.X;
                yk = e.Y;
                DrawCicle();
            }
            if (radioButton3.Checked == true)
            {
                xk = 0;
                yk = 0;
                xk = e.X;
                yk = e.Y;
                DrawRectangular();
            }
            if (radioButton4.Checked == true)
            {
                xk = 0;
                yk = 0;
                xk = e.X;
                yk = e.Y;
                LineB(xn,yn,xk,yk);
            }
        }

        //Простая
        private void LineBrez()
        {
            int x = xn;
            int y = yn;
            int px = Math.Abs(xk - xn);
            int py = Math.Abs(yk - yn);
            int E;
            int i;
            Pen myPen = new Pen(customColor, size);
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            g.DrawRectangle(myPen, (int)xn, (int)yn, 2, 2);
            //1
            if (px > py && xk - xn >= 0 && yk - yn >= 0)
            {
                E = 2 * py - px;
                i = px;
                while (i-- >= 0)
                {
                    if (E >= 0)
                    {
                        y++;
                        x++;
                        E = E + 2 * (py - px);
                    }
                    else
                    {
                        x++;
                        E = E + 2 * py;
                    }
                    g.DrawRectangle(myPen, x, y, 2, 2);

                }
            }
            if (py >= px && xk - xn >= 0 && yk - yn >= 0)
            {
                E = 2 * px - py;
                i = py;
                while (i-- >= 0)
                {
                    if (E >= 0)
                    {
                        x++;
                        y++;
                        E = E + 2 * (px - py);
                    }
                    else
                    {
                        y++;
                        E = E + 2 * px;
                    }
                    g.DrawRectangle(myPen, x, y, 2, 2);

                }
            }
            //4
            if (px > py && xk - xn > 0 && yk - yn <= 0)
            {
                E = 2 * py - px;
                i = px;
                while (i-- >= 0)
                {
                    if (E >= 0)
                    {
                        y--;
                        x++;
                        E = E + 2 * (py - px);
                    }
                    else
                    {
                        x++;
                        E = E + 2 * py;
                    }
                    g.DrawRectangle(myPen, x, y, 2, 2);
                }
            }
            if (px <= py && xk - xn > 0 && yk - yn <= 0)
            {
                E = 2 * px - py;
                i = py;
                while (i-- >= 0)
                {
                    if (E >= 0)
                    {
                        x++;
                        y--;
                        E = E + 2 * (px - py);
                    }
                    else
                    {
                        y--;
                        E = E + 2 * px;
                    }
                    g.DrawRectangle(myPen, x, y, 2, 2);
                }
            }
            //2
            if (px > py && xk - xn <= 0 && yk - yn > 0)
            {
                E = 2 * py - px;
                i = px;
                while (i-- >= 0)
                {
                    if (E >= 0)
                    {
                        y++;
                        x--;
                        E = E + 2 * (py - px);
                    }
                    else
                    {
                        x--;
                        E = E + 2 * py;
                    }
                    g.DrawRectangle(myPen, x, y, 2, 2);
                }
            }
            if (px <= py && xk - xn <= 0 && yk - yn > 0)
            {
                E = 2 * px - py;
                i = py;
                while (i-- >= 0)
                {
                    if (E >= 0)
                    {
                        x--;
                        y++;
                        E = E + 2 * (px - py);
                    }
                    else
                    {
                        y++;
                        E = E + 2 * px;
                    }
                    g.DrawRectangle(myPen, x, y, 2, 2);
                }
            }
            //3
            if (px > py && xk - xn <= 0 && yk - yn <= 0)
            {
                E = 2 * py - px;
                i = px;
                while (i-- >= 0)
                {
                    if (E >= 0)
                    {
                        y--;
                        x--;
                        E = E + 2 * (py - px);
                    }
                    else
                    {
                        x--;
                        E = E + 2 * py;
                    }
                    g.DrawRectangle(myPen, x, y, 2, 2);
                }
            }
            if (px <= py && xk - xn <= 0 && yk - yn <= 0)
            {
                E = 2 * px - py;
                i = py;
                while (i-- >= 0)
                {
                    if (E >= 0)
                    {
                        x--;
                        y--;
                        E = E + 2 * (px - py);
                    }
                    else
                    {
                        y--;
                        E = E + 2 * px;
                    }
                    g.DrawRectangle(myPen, x, y, 2, 2);
                }
            }
        }

       //Более красивая
        private void LineB(int x0, int y0, int x1, int y1)
        {
            bool swaped = false;
            int ystep = 1;
            if(Math.Abs(y1 - y0) >= Math.Abs(x1 - x0))
            {
                swaped = true;
                int swap = x0;
                x0 = y0;
                y0 = swap;
                swap = y1;
                y1 = x1;
                x1 = swap;
            }
            if (x1 - x0 < 0)
            {
                int swap = x0;
                x0 = x1;
                x1 = swap;
                swap = y0;
                y0 = y1;
                y1 = swap;
            }
            int px = Math.Abs(x1 - x0);
            int py = Math.Abs(y1 - y0);
            int E;
            int i;
            Pen myPen = new Pen(customColor, size);
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            if (y1 - y0 < 0)
            {
                ystep = -1;
            }
            //1
            int x = x0;
            int y = y0;
            if (swaped)
            {
                g.DrawRectangle(myPen, y, x, 2, 2);
            }
            else
            {
                g.DrawRectangle(myPen, x, y, 2, 2);
            }
            E = 2 * py - px;
            i = px;
            while (i-- >= 0)
            {
                if (E >= 0)
                {
                    y = y + ystep;
                    x++;
                    E = E + 2 * (py - px);
                }
                else
                {
                    x++;
                    E = E + 2 * py;
                }
                if (swaped)
                {
                    g.DrawRectangle(myPen, y, x, 2, 2);
                }
                else
                { 
                    g.DrawRectangle(myPen, x, y, 2, 2);
                }
            }
        }


        private void DrawRectangular()
        {
            int xs = xn;
            int ys = yn;
            int xe = xk;
            int ye = yk;
            xk = xn;
            DrawSection();
            xn = xk;
            yn = yk;
            xk = xe;
            DrawSection();
            yn = ys;
            xk = xe;
            yk = yn;
            DrawSection();
            xn = xk;
            yk = ye;
            DrawSection();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            int xs = 150;
            int ys = 150;
            int xe = 60;
            int ye = 150;
            int xCenter = (xs + xe) / 2;
            int yCenter = (int)(2.8 * xCenter);
            int yCenter2 = (int)(1.6 * xCenter);
            xn = xs;
            yn = ys;
            xk = xCenter;
            yk = yCenter;
            DrawSection();
            xn = xe;
            yn = ye;
            DrawSection();
            xn = xs;
            yn = ys;
            xk = xCenter;
            yk = yCenter2;
            DrawSection();
            xn = xe;
            yn = ye;
            DrawSection();

        }

        private void DrawCicle()
        {
            //Объявляем объект "myPen", задающий цвет и толщину пера
            Pen myPen = new Pen(customColor, size);
            //Объявляем объект "g" класса Graphics и предоставляем
            //ему возможность рисования на pictureBox1:
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            int x, y, r;
            
            x = 0;
            y =(int)Math.Sqrt(Math.Pow((xn - xk),2) + Math.Pow((yn - yk),2));
            r = y;
            int dd, di=0;
            dd = 1-2*r;
            while (y >= 0)
            {
                g.DrawRectangle(myPen, (int)(x + xn), (int)(y + yn), 2, 2);
                g.DrawRectangle(myPen, (int)(y + xn), (int)(x + yn), 2, 2);
                g.DrawRectangle(myPen, (int)(-x + xn), (int)(y + yn), 2, 2);
                g.DrawRectangle(myPen, (int)(-y + xn), (int)(x + yn), 2, 2);
                g.DrawRectangle(myPen, (int)(-x + xn), (int)(-y + yn), 2, 2);
                g.DrawRectangle(myPen, (int)(-y + xn), (int)(-x + yn), 2, 2);
                g.DrawRectangle(myPen, (int)(x + xn), (int)(-y + yn), 2, 2);
                g.DrawRectangle(myPen, (int)(y + xn), (int)(-x + yn), 2, 2);
                di = 2 * (dd + y) - 1;
                if (dd < 0 && di <= 0)
                {
                    x++;
                    dd += 2 * x + 1;
                    continue;
                }
                di = 2 * (dd - x) - 1;
                if (dd > 0 && di > 0)
                {
                    y--;
                    dd += 1 - 2 * y;
                    continue;
                }
                x++;
                dd += 2 * (x - y);
                y--;

            }
        }

        public lab2()
        {
            InitializeComponent();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (radioButton1.Checked == true || radioButton2.Checked == true || radioButton3.Checked == true || radioButton4.Checked == true)
            {
                xn = e.X;
                yn = e.Y;
            }
          
            else MessageBox.Show("Вы не выбрали алгоритм вывода фигуры!");
        }
    }
}
