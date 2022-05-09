using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace lab1._1G
{
    public partial class Lab4 : Form
    {
        double[,] kv = new double[4, 3];
        double[,] osi = new double[4, 3];
        double[,] v18 = new double[4, 3];
        double[,] k1 = new double[4, 3];
        double[,] k2 = new double[4, 3];
        double[,] matr_sdv = new double[3, 3];
        double[,] matr_pov = new double[3, 3];
        double[,] matr_mash = new double[3, 3];
        double[,] firstMove = new double[1, 3];
        double[,] secondMove = new double[1, 3];
        double[,] pivo1 = null;
        double[,] pivo2 = null;
        double k, l, kp,lp;
        int otr = 1;
        bool f = true;
        bool h = true;
        bool isKv = false;
        bool isV18 = false;
        double m = 1;
        double m1 = 1;
        double m2= 1;
        Color current_Color = Color.Blue;

        private void Init_kvadrat()
        {
            kv[0, 0] = -50; kv[0, 1] = 0; kv[0, 2] = 1;
            kv[1, 0] = 0; kv[1, 1] = 50; kv[1, 2] = 1;
            kv[2, 0] = 50; kv[2, 1] = 0; kv[2, 2] = 1;
            kv[3, 0] = 0; kv[3, 1] = -50; kv[3, 2] = 1;
        }
        private void Init_Korabl1()
        {
            k1[0, 0] = -12.5; k1[0, 1] = -21.25; k1[0, 2] = 1;
            k1[1, 0] = 0; k1[1, 1] = -13.75; k1[1, 2] = 1;
            k1[2, 0] = 12.5; k1[2, 1] = -21.25; k1[2, 2] = 1;
            k1[3, 0] = 0; k1[3, 1] = 21.25; k1[3, 2] = 1;
        }
        private void Init_Korabl2()
        {
            k2[0, 0] = -12.5; k2[0, 1] = 21.25; k2[0, 2] = 1;
            k2[1, 0] = 0; k2[1, 1] = 13.75; k2[1, 2] = 1;
            k2[2, 0] = 12.5; k2[2, 1] = 21.25; k2[2, 2] = 1;
            k2[3, 0] = 0; k2[3, 1] = -21.25; k2[3, 2] = 1;
        }

        private void Init_V18()
        {
            v18[0, 0] = -50; v18[0, 1] = -85; v18[0, 2] = 1;
            v18[1, 0] = 0; v18[1, 1] = -55; v18[1, 2] = 1;
            v18[2, 0] = 50; v18[2, 1] = -85; v18[2, 2] = 1;
            v18[3, 0] =0; v18[3, 1] = 85; v18[3, 2] = 1;
        }
        private void Init_matr_preob(double k1, double l1)
        {
            matr_sdv[0, 0] = 1; matr_sdv[0, 1] = 0; matr_sdv[0, 2] = 0;
            matr_sdv[1, 0] = 0; matr_sdv[1, 1] = otr; matr_sdv[1, 2] = 0;
            matr_sdv[2, 0] = k1; matr_sdv[2, 1] = l1; matr_sdv[2, 2] = 1;
        }
        private void Init_osi()
        {
            osi[0, 0] = -200; osi[0, 1] = 0; osi[0, 2] = 1;
            osi[1, 0] = 200; osi[1, 1] = 0; osi[1, 2] = 1;
            osi[2, 0] = 0; osi[2, 1] = 200; osi[2, 2] = 1;
            osi[3, 0] = 0; osi[3, 1] = -200; osi[3, 2] = 1;
        }
        private void Init_Matr_Povorot(double fi)
        {
            matr_pov[0, 0] =Math.Cos(fi) ; matr_pov[0, 1] = Math.Sin(fi); matr_pov[0, 2] = 0;
            matr_pov[1, 0] = -Math.Sin(fi); matr_pov[1, 1] = Math.Cos(fi); matr_pov[1, 2] = 0;
            matr_pov[2, 0] =0 ; matr_pov[2, 1] = 0; matr_pov[2, 2] = 1;
        }
        
        private void Init_Matr_mash(double m)
        {
            matr_mash[0, 0] = 1; matr_mash[0, 1] = 0; matr_mash[0, 2] = 0;
            matr_mash[1, 0] = 0; matr_mash[1, 1] = 1; matr_mash[1, 2] = 0;
            matr_mash[2, 0] = 0; matr_mash[2, 1] = 0; matr_mash[2, 2] = m;
        }

        private double[,] Multiply_matr(double[,] a, double[,] b)
        {
            int n = a.GetLength(0);
            int m = a.GetLength(1);

            double[,] r = new double[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    r[i, j] = 0;
                    for (int ii = 0; ii < m; ii++)
                    {
                        r[i, j] += a[i, ii] * b[ii, j];
                    }
                }
            }
            return r;
        }

        private void Draw_V18_Povorot(Color curentColor, double k, double l,ref double[,] matr, double m)
        {
            Init_Matr_mash(m);
            matr = Multiply_matr(matr, matr_pov);
            Init_matr_preob(k, l);
            double[,] v18_1 = Multiply_matr(matr, matr_mash);
            if (m != 1)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        v18_1[i, j] = v18_1[i, j] / m;
                    }
                }
            }
             v18_1 = Multiply_matr(v18_1, matr_sdv);
            
            DravFigure(curentColor, v18_1);
        }

        private void Draw_V18(Color curentColor, double k, double l, ref double[,] matr, double m)
        {
            isV18 = true;
            Init_Matr_mash(m);
            Init_matr_preob(k, l);
            double[,] v11_1 = Multiply_matr(matr, matr_mash);
            if (m != 1)
            {
                for (int i = 0; i < 4; i++)
                {
                    for(int j = 0; j < 3; j++)
                    {
                        v11_1[i, j] = v11_1[i, j] / m;
                    }
                }
            }  
            v11_1 = Multiply_matr(v11_1, matr_sdv);

            DravFigure(curentColor, v11_1);
        }

        private void Draw_Kv(Color curentColor, double k, double l)
        {
            isKv = true;
            Init_matr_preob(k, l);
            double[,] kv1 = Multiply_matr(kv, matr_sdv);
            DravFigure(curentColor, kv1);
        }
        private void DravFigure(Color curentColor, double [ , ] matr)
        {
            Pen myPen = new Pen(curentColor, 2);
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            // рисуем 1 сторону квадрата
            g.DrawLine(myPen, (int)matr[0, 0], (int)matr[0, 1], (int)matr[1, 0], (int)matr[1, 1]);
            // рисуем 2 сторону квадрата
            g.DrawLine(myPen, (int)matr[1, 0], (int)matr[1, 1], (int)matr[2, 0], (int)matr[2, 1]);
            // рисуем 3 сторону квадрата
            g.DrawLine(myPen, (int)matr[2, 0], (int)matr[2, 1], (int)matr[3, 0], (int)matr[3, 1]);
            // рисуем 4 сторону квадрата
            g.DrawLine(myPen, (int)matr[3, 0], (int)matr[3, 1], (int)matr[0, 0], (int)matr[0, 1]);
            g.Dispose();
            myPen.Dispose();
        }

        private void Draw_osi(double k, double l)
        {
         
            Init_osi();
            Init_matr_preob(k, l);
            double[,] osi1 = Multiply_matr(osi, matr_sdv);
            Pen myPen = new Pen(Color.Red, 1);// цвет линии и ширина
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            // рисуем ось ОХ
            g.DrawLine(myPen, (int)osi1[0, 0], (int)osi1[0, 1], (int)osi1[1, 0], (int)osi1[1,
            1]);
            // рисуем ось ОУ
            g.DrawLine(myPen, (int)osi1[2, 0], (int)osi1[2, 1], (int)osi1[3, 0], (int)osi1[3,1]);
            g.Dispose();
            myPen.Dispose();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Init_kvadrat();
            Init_V18();
            
            if (radioButton5.Checked == true)
            {
                Draw_Kv(current_Color, k ,l);
            }
            else if (radioButton6.Checked == true)
            {
                Draw_V18(current_Color, k, l,ref v18,m);
            }
            else
            {
                MessageBox.Show("Вы не выбрали фигуру");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Draw_osi(pictureBox1.Width / 2,
            pictureBox1.Height / 2);
        }

        private void ChooseFigureSdv(int direction,ref double xOrY)
        {
            if (radioButton5.Checked == true)
            {
                Draw_Kv(pictureBox1.BackColor, k, l);
                Draw_osi(pictureBox1.Width / 2,
               pictureBox1.Height / 2);
                if(isV18)
                {
                    Draw_V18(current_Color, kp, lp, ref v18,m);
                }
                xOrY += direction;
                Draw_Kv(current_Color, k, l);
            }
            if(radioButton6.Checked == true)
            {
                Draw_V18(pictureBox1.BackColor, k, l, ref v18,m);
                Draw_osi(pictureBox1.Width / 2,
               pictureBox1.Height / 2);
                if (isKv) 
                {
                    Draw_Kv(current_Color, kp, lp);
                }
                xOrY += direction;
                Draw_V18(current_Color, k, l, ref v18,m);
            }    
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ChooseFigureSdv(5, ref k);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true ||
                radioButton2.Checked == true ||
                radioButton3.Checked == true ||
                radioButton4.Checked == true)
            {
                timer1.Interval = 100;
                button8.Text = "Стоп";
                if (f == true)
                {
                    timer1.Start();
                }
                else
                {
                    timer1.Stop();
                    button8.Text = "Старт";
                }
                f = !f;
            }
            else
            {
                MessageBox.Show("Вы не выбрали направление сдвига");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                ChooseFigureSdv(1, ref k);
            }
            else if (radioButton2.Checked == true)
            {
                ChooseFigureSdv(-1, ref k);
            }
            else if (radioButton3.Checked == true)
            {
                ChooseFigureSdv(1, ref l);
            }
            else if (radioButton4.Checked == true)
            {
                ChooseFigureSdv(-1, ref l);
            } 
            Thread.Sleep(100);  
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ChooseFigureSdv(-5, ref k);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ChooseFigureSdv(5, ref l);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ChooseFigureSdv(-5, ref l);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (radioButton6.Checked == true)
            {
                Init_Matr_Povorot(Math.PI/3);
                Draw_V18(pictureBox1.BackColor, k, l, ref v18,m);
                Draw_osi(pictureBox1.Width / 2,
                   pictureBox1.Height / 2);
                Draw_V18_Povorot(current_Color, k, l, ref v18,m);
            }
        }

        private void Lab4_Load(object sender, EventArgs e)
        {
            kp = pictureBox1.Width / 2;
            lp = pictureBox1.Height / 2;
            k = pictureBox1.Width / 2;
            l = pictureBox1.Height / 2;
            Init_Matr_mash(m);
        }

        private void button10_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "")
            {
                if (radioButton6.Checked == true)
                {
                    Draw_V18(pictureBox1.BackColor, k, l, ref v18,m);
                    Draw_osi(pictureBox1.Width / 2,
                        pictureBox1.Height / 2);
                }
                //if (!h)
                //{
                //    Draw_V18(pictureBox1.BackColor, k, l, ref k1);
                //}
                m = m * double.Parse(textBox1.Text);
                textBox1.Text = "";
                Init_Matr_mash(m);

                if (radioButton6.Checked == true)
                {
                    Draw_V18(current_Color, k, l, ref v18,m);
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if(radioButton6.Checked == true)
            {
                Draw_V18(pictureBox1.BackColor, k, l, ref v18,m);
                Draw_osi(pictureBox1.Width / 2,
                    pictureBox1.Height / 2);
                otr = -otr;
                if (l > pictureBox1.Height / 2)
                {
                    l = l - 2 * (l - pictureBox1.Height / 2);
                }
                else
                {
                    l = l + 2 * (pictureBox1.Height / 2 - l);
                }
                Draw_V18(current_Color, k, l, ref v18,m);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                current_Color = colorDialog1.Color;
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (radioButton6.Checked == true)
            {
                Draw_V18(pictureBox1.BackColor, k, l, ref v18,m);
                Draw_osi(pictureBox1.Width / 2,
                    pictureBox1.Height / 2);
            }
            //if (!h)
            //{
            //    Draw_V18(pictureBox1.BackColor, k, l, ref k1);
            //}
            m = m/double.Parse(textBox2.Text);
            textBox2.Text = "";
            Init_Matr_mash(m);
            if (radioButton6.Checked == true)
            {
                Draw_V18(current_Color, k, l, ref v18,m);
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
   
            firstMove[0, 0] = 100;
            firstMove[0, 1] = 0;
            firstMove[0, 2] = 1;
            secondMove[0, 0] = 200;
            secondMove[0, 1] = 0;
            secondMove[0, 2] = 1;
            // firstMove = Multiply_matr(firstMove, matr_sdv);
            pictureBox1.Refresh();
            g.DrawEllipse(new Pen(Color.Green, 2), pictureBox1.Width / 2 - 25, pictureBox1.Height / 2 - 25, 50, 50);
            g.Dispose();
            Init_Korabl1();
            Init_Korabl2();
            double fi = 2;
            
            timer2.Interval = 100;
            button14.Text = "Стоп";
            if (h == true)
            {
                timer2.Start();
                timer3.Start();
            }
            else
            {
                timer2.Stop();
                timer3.Stop();
                button14.Text = "Полёт";
            }
            h = !h;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Init_Matr_Povorot(2*Math.PI / 180);
            Init_matr_preob(pictureBox1.Width / 2, pictureBox1.Height / 2);
            if (pivo1 != null)
            {
                Draw_V18(pictureBox1.BackColor, pivo1[0, 0], pivo1[0, 1], ref k1,m1);
            }
            firstMove = Multiply_matr(firstMove, matr_pov);
            if(firstMove[0,0] < 0)
            {
                m1 = m1 * 1.01;
            }
            else
            {
                m1 = m1 / 1.01;
            }
            Init_matr_preob(pictureBox1.Width / 2, pictureBox1.Height / 2);
            pivo1 = Multiply_matr(firstMove, matr_sdv);
            Draw_V18_Povorot(current_Color, pivo1[0, 0], pivo1[0, 1], ref k1,m1);
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            Init_Matr_Povorot(-2 * Math.PI / 180);
            Init_matr_preob(pictureBox1.Width / 2, pictureBox1.Height / 2);
            if (pivo2 != null)
            {
                Draw_V18(pictureBox1.BackColor, pivo2[0, 0], pivo2[0, 1], ref k2,m2);
            }
            secondMove = Multiply_matr(secondMove, matr_pov);
            if (secondMove[0, 0] < 0)
            {
                m2 = m2 / 1.01;
            }
            else
            {
                m2 = m2 * 1.01;
            }
            Init_matr_preob(pictureBox1.Width / 2, pictureBox1.Height / 2);
            pivo2 = Multiply_matr(secondMove, matr_sdv);
            Draw_V18_Povorot(current_Color, pivo2[0, 0], pivo2[0, 1], ref k2,m2);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.DrawString("60 лет ТУСУР", new Font("Arial", 14), Brushes.Blue, pictureBox1.Width / 2 - 57, pictureBox1.Height/2 - 10);
            g.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            isKv = false;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            double swap = l;
            l = lp;
            lp = swap;
            swap = kp;
            kp = k;
            k = swap;
        }

        public Lab4()
        {
            InitializeComponent();
        }
    }
}
