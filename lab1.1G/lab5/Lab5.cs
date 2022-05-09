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
    public partial class Lab5 : Form
    {
        public struct Point3D
        {
            public double X;
            public double Y;
            public double Z;
        }
        public Point3D MakePoint(double x, double y, double z)
        {
            Point3D point = new Point3D();
            point.X = x;
            point.Y = y;
            point.Z = z;
            return point;
        }
        double[,] osi = new double[4, 4];
        double[,] perenos = new double[4, 4];
        double[,] vrashOX = new double[4, 4];
        double[,] kub = new double[12, 4];
        double[,] mash = new double[4, 4];
        double[,] matr_liniipow = new double[2, 4];
        int p, q, r;
        double n1, n2, n3;
        int step = 5;
        int oX, oY, oZ;
        double mX, mY, mZ;
        double s = 1;
        int v1, v2, v3, v4, v5, v6 ,v7;
        double x1, x2, x3, y1, y2, y3, z1, z2, z3;
        double fi;
        int lineSize = 2;
        bool isLine = false;
        Color curentColor = Color.Blue;

        private void Init_kub()
        {
            kub[0, 0] = 11; kub[0, 1] = 32; kub[0, 2] = -25; kub[0, 3] = 1;
            kub[1, 0] = -28; kub[1, 1] = 20; kub[1, 2] = -25; kub[1, 3] = 1;
            kub[2, 0] = -28; kub[2, 1] = -20; kub[2, 2] = -25; kub[2, 3] = 1;
            kub[3, 0] = 11; kub[3, 1] = -32; kub[3, 2] = -25; kub[3, 3] = 1;
            kub[4, 0] = 34; kub[4, 1] = 0; kub[4, 2] = -25; kub[4, 3] = 1;
            kub[5, 0] = 34; kub[5, 1] = 0; kub[5, 2] = 25; kub[5, 3] = 1;
            kub[6, 0] = 11; kub[6, 1] = -32; kub[6, 2] = 25; kub[6, 3] = 1;
            kub[7, 0] = -28; kub[7, 1] = -20; kub[7, 2] = 25; kub[7, 3] = 1;
            kub[8, 0] = -28; kub[8, 1] = 20; kub[8, 2] = 25; kub[8, 3] = 1;
            kub[9, 0] = 11; kub[9, 1] = 32; kub[9, 2] = 25; kub[9, 3] = 1;
        }
        private void Init_PolygonLab6(double[,] matr, Color color)
        {
            Point3D[] polygon1 = new Point3D[]
            {
                MakePoint( matr[0,0],  matr[0,1], matr[0,2]),
                MakePoint( matr[1,0],  matr[1,1], matr[1,2]),
                MakePoint( matr[2,0],  matr[2,1], matr[2,2]),
                MakePoint( matr[3,0],  matr[3,1], matr[3,2]),
                MakePoint( matr[4,0],  matr[4,1], matr[4,2]),
                };
            Point3D[] polygon2 = new Point3D[]
            {
                MakePoint( matr[5,0],  matr[5,1], matr[5,2]),
                MakePoint( matr[6,0],  matr[6,1], matr[6,2]),
                MakePoint( matr[7,0],  matr[7,1], matr[7,2]),
                MakePoint( matr[8,0],  matr[8,1], matr[8,2]),
                MakePoint( matr[9,0],  matr[9,1], matr[9,2]),
                };
            Point3D[] polygon3 = new Point3D[]
           {
                MakePoint( matr[0,0],  matr[0,1], matr[0,2]),
                MakePoint( matr[1,0],  matr[1,1], matr[1,2]),
                MakePoint( matr[8,0],  matr[8,1], matr[8,2]),
                MakePoint( matr[9,0],  matr[9,1], matr[9,2]),
               };
            Point3D[] polygon4 = new Point3D[]
          {
                MakePoint( matr[1,0],  matr[1,1], matr[1,2]),
                MakePoint( matr[2,0],  matr[2,1], matr[2,2]),
                MakePoint( matr[7,0],  matr[7,1], matr[7,2]),
                MakePoint( matr[8,0],  matr[8,1], matr[8,2]),
              };
            Point3D[] polygon5 = new Point3D[]
          {
                MakePoint( matr[2,0],  matr[2,1], matr[2,2]),
                MakePoint( matr[3,0],  matr[3,1], matr[3,2]),
                MakePoint( matr[6,0],  matr[6,1], matr[6,2]),
                MakePoint( matr[7,0],  matr[7,1], matr[7,2]),
              };
            Point3D[] polygon6 = new Point3D[]
          {
                MakePoint( matr[3,0],  matr[3,1], matr[3,2]),
                MakePoint( matr[4,0],  matr[4,1], matr[4,2]),
                MakePoint( matr[5,0],  matr[5,1], matr[5,2]),
                MakePoint( matr[6,0],  matr[6,1], matr[6,2]),
              };
            Point3D[] polygon7 = new Point3D[]
          {
                MakePoint( matr[0,0],  matr[0,1], matr[0,2]),
                MakePoint( matr[4,0],  matr[4,1], matr[4,2]),
                MakePoint( matr[5,0],  matr[5,1], matr[5,2]),
                MakePoint( matr[9,0],  matr[9,1], matr[9,2]),
              };
            
            RobertsonLab6(polygon3, color, matr);
            RobertsonLab6(polygon4, color, matr);
            RobertsonLab6(polygon5, color, matr);
            RobertsonLab6(polygon6, color, matr);
            RobertsonLab6(polygon7, color, matr);
            RobertsonLab6(polygon2, color, matr);
            RobertsonLab6(polygon1, color, matr);
            
            if (oZ == 0)
            {
                p -= pictureBox1.Width / 2;
                q -= pictureBox1.Height / 2;
            }
            else if (oY == 0)
            {
                p -= pictureBox1.Width / 2;
                r -= pictureBox1.Height / 2;
            }
            else if (oX == 0)
            {
                q -= pictureBox1.Width / 2;
                r -= pictureBox1.Height / 2;
            }
        }

        private void Init_Linia_Poworota()
        {
            matr_liniipow[0, 0] = -(n1*50); matr_liniipow[0, 1] = -(n2*50); matr_liniipow[0, 2] = -(n3*50); matr_liniipow[0, 3] = 1;
            matr_liniipow[1, 0] = (n1 * 50); matr_liniipow[1, 1] = (n2 * 50); matr_liniipow[1, 2] = (n3 * 50); matr_liniipow[1, 3] = 1;
        }

        private void Init_Osi(int x ,int y, int z)
        {
            osi[0, 0] = 0; osi[0, 1] = 0; osi[0, 2] = 0; osi[0, 3] = 1;
            osi[1, 0] = x-20; osi[1, 1] = 0; osi[1, 2] = 0; osi[1, 3] = 1;
            osi[2, 0] = 0; osi[2, 1] = y-20; osi[2, 2] = 0; osi[2, 3] = 1;
            osi[3, 0] = 0; osi[3, 1] = 0; osi[3, 2] = z-20; osi[3, 3] = 1;
        }

        private void Init_Perenos(int p, int q, int r)
        {
            perenos[0, 0] = oX; perenos[0, 1] = 0; perenos[0, 2] = 0; perenos[0, 3] = 0;
            perenos[1, 0] = 0; perenos[1, 1] = oY; perenos[1, 2] = 0; perenos[1, 3] = 0;
            perenos[2, 0] = 0; perenos[2, 1] = 0; perenos[2, 2] = oZ; perenos[2, 3] = 0;
            perenos[3, 0] = p; perenos[3, 1] = q; perenos[3, 2] = r; perenos[3, 3] = 1;
        }
        private void Init_Mash()
        {
            mash[0, 0] = mX; mash[0, 1] = 0; mash[0, 2] = 0; mash[0, 3] = 0;
            mash[1, 0] = 0; mash[1, 1] = mY; mash[1, 2] = 0; mash[1, 3] = 0;
            mash[2, 0] = 0; mash[2, 1] = 0; mash[2, 2] = mZ; mash[2, 3] = 0;
            mash[3, 0] = 0; mash[3, 1] = 0; mash[3, 2] = 0; mash[3, 3] = s;
        }

        private void Init_Vrash()
        {
            vrashOX[0, 0] = Math.Pow(n1,2)+(1- Math.Pow(n1, 2))* Math.Cos((Math.PI*fi)/180);
            vrashOX[0, 1] = n1*n2*(1- Math.Cos((Math.PI * fi) / 180))+n3* Math.Sin((Math.PI * fi) / 180);
            vrashOX[0, 2] = n1*n3* (1 - Math.Cos((Math.PI * fi) / 180))-n2* Math.Sin((Math.PI * fi) / 180);
            vrashOX[0, 3] = 0;
            vrashOX[1, 0] = n1 * n2 * (1 - Math.Cos((Math.PI * fi) / 180)) - n3 * Math.Sin((Math.PI * fi) / 180);
            vrashOX[1, 1] = Math.Pow(n2, 2) + (1 - Math.Pow(n2, 2)) * Math.Cos((Math.PI * fi) / 180);
            vrashOX[1, 2] = n2 * n3 * (1 - Math.Cos((Math.PI * fi) / 180)) + n1 * Math.Sin((Math.PI * fi) / 180);
            vrashOX[1, 3] = 0;
            vrashOX[2, 0] = n1 * n3 * (1 - Math.Cos((Math.PI * fi) / 180)) + n2 * Math.Sin((Math.PI * fi) / 180);
            vrashOX[2, 1] = n2 * n3 * (1 - Math.Cos((Math.PI * fi) / 180)) - n1 * Math.Sin((Math.PI * fi) / 180);
            vrashOX[2, 2] = Math.Pow(n3, 2) + (1 - Math.Pow(n3, 2)) * Math.Cos((Math.PI * fi) / 180);
            vrashOX[2, 3] = 0;
            vrashOX[3, 0] = 0;
            vrashOX[3, 1] = 0;
            vrashOX[3, 2] = 0;
            vrashOX[3, 3] = 1;
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

        private double[,] Mashtab(double[,] matr)
        {
            Init_Mash();
            matr = Multiply_matr(matr, mash);
            if (mash[3, 3] != 1)
            {
                int n = matr.GetLength(0);
                int m = matr.GetLength(1);
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        matr[i, j] = matr[i, j] / s;
                    }
                }
            }
            return matr;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if(textBox5.Text != "" && textBox5.Text != "-")
            {
                label12.Text = "ф = " + double.Parse(textBox5.Text).ToString();
                fi = double.Parse(textBox5.Text);
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            textBox5.Text = "";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox2.Text != "-")
            {
                n1 = double.Parse(textBox2.Text);
                label11.Text = "("+ n1.ToString() + ";" + n2.ToString() +";" +n3.ToString() +")"; 
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text != "" && textBox3.Text != "-")
            {
                n2 = double.Parse(textBox3.Text);
                label11.Text = "(" + n1.ToString() + ";" + n2.ToString() + ";" + n3.ToString() + ")";
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            textBox3.Text = "";
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text != "" && textBox4.Text != "-")
            {
                n3 = double.Parse(textBox4.Text);
                label11.Text = "(" + n1.ToString() + ";" + n2.ToString() + ";" + n3.ToString() + ")";
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            textBox4.Text = "";
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 45)
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 45)
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 45)
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 45)
            {
                e.Handled = true;
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox6.Text != "")
            {
                lineSize = int.Parse(textBox6.Text);
                label14.Text = "Текущий размер линии: " + lineSize.ToString();
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            textBox6.Text = "";
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57))
            {
                e.Handled = true;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                curentColor = colorDialog1.Color;
            }
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            Draw_Osi(pictureBox1.BackColor, pictureBox1.Width / 2, pictureBox1.Height / 2, pictureBox1.Height / 2);
            Draw_Kub(pictureBox1.BackColor);
            isLine = !isLine;
            Draw_Osi(Color.Red, pictureBox1.Width / 2, pictureBox1.Height / 2, pictureBox1.Height / 2);
            Draw_Kub(curentColor);
        }

        private void Draw_Osi(Color currentColor, int p, int q, int r)
        {
            int firstPoint = 0;
            int secondPoint = 1;
            if (oZ == 0)
            {
                p = pictureBox1.Width / 2;
                q = pictureBox1.Height / 2;
                r = 0;
                firstPoint = 0;
                secondPoint = 1;
            }
            else if (oY == 0)
            {
                p = pictureBox1.Width / 2;
                q = 0;
                r = pictureBox1.Height / 2;
                firstPoint = 0;
                secondPoint = 2;
            }
            else if (oX == 0)
            {
                p = 0;
                q = pictureBox1.Width / 2;
                r = pictureBox1.Height / 2;
                firstPoint = 1;
                secondPoint = 2;
            }
            Init_Osi(p, q, r);
            Init_Perenos(p, q, r);
            double[,] osi_1 = Multiply_matr(osi, perenos);
            Font font = new Font("Arial", 8);
            StringFormat format = new StringFormat();
            Pen myPen = new Pen(currentColor, 2);
            SolidBrush brush = new SolidBrush(currentColor);
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            g.DrawLine(myPen, (int)osi_1[0, firstPoint], (int)osi_1[0, secondPoint], (int)osi_1[1, firstPoint], (int)osi_1[1, secondPoint]);
            g.DrawString("x", font, brush, (int)osi_1[1, firstPoint], (int)osi_1[1, secondPoint], format);
            g.DrawString("-391", font, brush, 0, 200, format);
            g.DrawString("391", font, brush, 380 * 2, 200, format);
            g.DrawString("-228", font, brush, 420, 0, format);
            g.DrawString("228", font, brush, 420, 218 * 2, format);
            g.DrawLine(myPen, (int)osi_1[0, firstPoint], (int)osi_1[0, secondPoint], (int)osi_1[2, firstPoint], (int)osi_1[2, secondPoint]);
            g.DrawString("y", font, brush, (int)osi_1[2, firstPoint], (int)osi_1[2, secondPoint], format);
            g.DrawLine(myPen, (int)osi_1[0, firstPoint], (int)osi_1[0, secondPoint], (int)osi_1[3, firstPoint], (int)osi_1[3, secondPoint]);
            g.DrawString("z", font, brush, (int)osi_1[3, firstPoint], (int)osi_1[3, secondPoint], format);
            g.Dispose();
            myPen.Dispose();
        }
        private void Draw_Kub_vrash()
        {
            if (oZ == 0)
            {
                p += pictureBox1.Width / 2;
                q += pictureBox1.Height / 2;
            }
            else if (oY == 0)
            {
                p += pictureBox1.Width / 2;
                r += pictureBox1.Height / 2;
            }
            else if (oX == 0)
            {
                q += pictureBox1.Width / 2;
                r += pictureBox1.Height / 2;
            }
            Init_Perenos(p, q,r); 
            Init_Vrash(); 
            kub = Multiply_matr(kub, vrashOX);
            double[,] proecsXOY = Mashtab(kub);
            proecsXOY = Multiply_matr(proecsXOY, perenos);
            if (radioButton4.Checked == true)
            {
                Init_PolygonLab6(proecsXOY, curentColor);
            }
            else
            {
                DravFigure(curentColor, proecsXOY);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SrLab5 sr = new SrLab5();
            sr.Show();
        }

        private void Draw_Kub(Color curentColor)
        {
            if (oZ == 0)
            {
                p += pictureBox1.Width / 2;
                q += pictureBox1.Height / 2;
            }
            else if (oY == 0)
            {
                p += pictureBox1.Width / 2;
                r += pictureBox1.Height / 2;
            }
            else if (oX == 0)
            {
                q += pictureBox1.Width / 2;
                r += pictureBox1.Height / 2;
            }
            Init_Perenos(p,q,r);
            double[,] proecsXOY = Mashtab(kub);
            proecsXOY = Multiply_matr(proecsXOY, perenos);
            if (radioButton4.Checked == true)
            {
                Init_PolygonLab6(proecsXOY, curentColor);
            }
            else
            {
                DravFigure(curentColor, proecsXOY);
            }
        }

        private void DravFigure(Color curentColor, double[,] matr)
        {
            int firstPoint = 0;
            int secondPoint = 1;
            if (oZ == 0)
            {
                firstPoint = 0;
                secondPoint = 1;
            }
            else if (oY == 0)
            {
                firstPoint = 0;
                secondPoint = 2;
            }
            else if (oX == 0)
            {
                firstPoint = 1;
                secondPoint = 2;
            }
            Pen myPen = new Pen(curentColor, lineSize);
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            if (isLine)
            {
                Init_Linia_Poworota();
                double[,] mL = Multiply_matr(matr_liniipow, perenos);
                if (curentColor == pictureBox1.BackColor)
                {
                    g.DrawLine(myPen, (int)Math.Round(mL[0, firstPoint]), (int)Math.Round(mL[0, secondPoint]), (int)Math.Round(mL[1, firstPoint]), (int)Math.Round(mL[1, secondPoint]));
                }
                else
                {
                    Pen myPenLine = new Pen(Color.Black, lineSize);
                    g.DrawLine(myPenLine, (int)Math.Round(mL[0, firstPoint]), (int)Math.Round(mL[0, secondPoint]), (int)Math.Round(mL[1, firstPoint]), (int)Math.Round(mL[1, secondPoint]));
                    myPenLine.Dispose();
                }
            }
            for (int i = 0; i < 10; i++)
            {
                if (i == 9)
                {
                    g.DrawLine(myPen, (int)Math.Round(matr[i, firstPoint]), (int)Math.Round(matr[i, secondPoint]), (int)Math.Round(matr[0, firstPoint]), (int)Math.Round(matr[0, secondPoint]));
                }
                else
                {
                    g.DrawLine(myPen, (int)Math.Round(matr[i, firstPoint]), (int)Math.Round(matr[i, secondPoint]), (int)Math.Round(matr[i + 1, firstPoint]), (int)Math.Round(matr[i + 1, secondPoint]));
                }
            }
            g.DrawLine(myPen, (int)Math.Round(matr[4, firstPoint]), (int)Math.Round(matr[4, secondPoint]), (int)Math.Round(matr[0, firstPoint]), (int)Math.Round(matr[0, secondPoint]));
            g.DrawLine(myPen, (int)Math.Round(matr[3, firstPoint]), (int)Math.Round(matr[3, secondPoint]), (int)Math.Round(matr[6, firstPoint]), (int)Math.Round(matr[6, secondPoint]));
            g.DrawLine(myPen, (int)Math.Round(matr[2, firstPoint]), (int)Math.Round(matr[2, secondPoint]), (int)Math.Round(matr[7, firstPoint]), (int)Math.Round(matr[7, secondPoint]));
            g.DrawLine(myPen, (int)Math.Round(matr[1, firstPoint]), (int)Math.Round(matr[1, secondPoint]), (int)Math.Round(matr[8, firstPoint]), (int)Math.Round(matr[8, secondPoint]));
            g.DrawLine(myPen, (int)Math.Round(matr[5, firstPoint]), (int)Math.Round(matr[5, secondPoint]), (int)Math.Round(matr[9, firstPoint]), (int)Math.Round(matr[9, secondPoint]));
            g.Dispose();
            myPen.Dispose();
            if (oZ == 0)
            {
                p -= pictureBox1.Width / 2;
                q -= pictureBox1.Height / 2;
            }
            else if (oY == 0)
            {
                p -= pictureBox1.Width / 2;
                r -= pictureBox1.Height / 2;
            }
            else if (oX == 0)
            {
                q -= pictureBox1.Width / 2;
                r -= pictureBox1.Height / 2;
            }
        }
        private void RobertsonLab6(Point3D[] polygon, Color curentColor, double[,] matr)
        {
            Point3D P = MakePoint(0, 0, 1);
            Point3D W = MakePoint(0, 0, 0);
            for (int i = 0; i < 10; i++)
            {
                W.X += matr[i, 0] / 10;
                W.Y += matr[i, 1] / 10;
                W.Z += matr[i, 2] / 10;
            }
            Point3D vec1;
            Point3D vec2;
            vec1.X = polygon[0].X - polygon[1].X;
            vec2.X = polygon[2].X - polygon[1].X;
            vec1.Y = polygon[0].Y - polygon[1].Y;
            vec2.Y = polygon[2].Y - polygon[1].Y;
            vec1.Z = polygon[0].Z - polygon[1].Z;
            vec2.Z = polygon[2].Z - polygon[1].Z;
            double A = vec1.Y * vec2.Z - vec2.Y * vec1.Z;
            double B = vec1.Z * vec2.X - vec2.Z * vec1.X;
            double C = vec1.X * vec2.Y - vec2.X * vec1.Y;
            double D = -(A * polygon[0].X + B * polygon[0].Y + C * polygon[0].Z);
            if (A * W.X + B * W.Y + C * W.Z + D < 0)
            {
                A = -A;
                B = -B;
                C = -C;
                D = -D;
            }
            if (A * P.X + B * P.Y + C * P.Z + D > 0)
            {
                DravPoligoneLab6(polygon, curentColor);
            }
            else
            {
               // DravPoligone(polygon, Color.Orange);
            }

        }
        private void DravPoligoneLab6(Point3D[] polygon, Color curentColor)
        {
            Pen myPen = new Pen(curentColor, lineSize);
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            for (int i = 0; i < polygon.Length; i++)
            {
                if (i == polygon.Length - 1)
                {
                    g.DrawLine(myPen, (int)polygon[0].X, (int)polygon[0].Y, (int)polygon[polygon.Length - 1].X, (int)polygon[polygon.Length - 1].Y);
                }
                else
                {
                    g.DrawLine(myPen, (int)polygon[i].X, (int)polygon[i].Y, (int)polygon[i + 1].X, (int)polygon[i + 1].Y);
                }
            }
            g.Dispose();
            myPen.Dispose();
        }
        
        private void Smeshenie(int step)
        {
            if (checkBox1.Checked == true)
            {
                p += step;
            }
            if(checkBox2.Checked == true)
            {
                q += step;
            }
            if(checkBox3.Checked == true)
            {
                r += step;
            }
            if(checkBox4.Checked == true)
            {
                p -= step;
            }    
            if(checkBox5.Checked == true)
            {
                q -= step;
            }
            if(checkBox6.Checked == true)
            {
                r -= step;
            }
            if(checkBox1.Checked != true && checkBox2.Checked != true && checkBox3.Checked != true &&
                checkBox4.Checked != true && checkBox5.Checked != true && checkBox6.Checked != true)
            {
                MessageBox.Show("Вы не выбрали направление сдвига!");
            }
        }

        public Lab5()
        {
            InitializeComponent();
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            CheckForTrack();
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            CheckForTrack();
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            CheckForTrack();
        }
        private void CheckForTrack()
        {
            if (checkBox7.Checked == true && checkBox8.Checked != true && checkBox9.Checked != true)
            {
                trackBar2.Value = v1;
            }
            else if (checkBox7.Checked == true && checkBox8.Checked == true && checkBox9.Checked != true)
            {
                trackBar2.Value =v2;
            }
            else if (checkBox7.Checked == true && checkBox8.Checked != true && checkBox9.Checked == true)
            {
                trackBar2.Value =v3;
            }
            else if (checkBox7.Checked != true && checkBox8.Checked == true && checkBox9.Checked != true)
            {
                trackBar2.Value=v4;
            }
            else if (checkBox7.Checked != true && checkBox8.Checked == true && checkBox9.Checked == true)
            {
                trackBar2.Value=v5;
            }
            else if (checkBox7.Checked != true && checkBox8.Checked != true && checkBox9.Checked == true)
            {
                trackBar2.Value=v6;
            }
            else if (checkBox7.Checked == true && checkBox8.Checked == true && checkBox9.Checked == true)
            {
                trackBar2.Value = v7;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Draw_Osi(pictureBox1.BackColor, pictureBox1.Width / 2, pictureBox1.Height / 2, pictureBox1.Height / 2);
            Draw_Osi(Color.Red, pictureBox1.Width / 2, pictureBox1.Height / 2, pictureBox1.Height / 2);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                label2.Text = "Tекущий шаг: " + int.Parse(textBox1.Text).ToString();
                step = int.Parse(textBox1.Text);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked == true)
            {
                Draw_Osi(pictureBox1.BackColor, pictureBox1.Width / 2, pictureBox1.Height / 2, pictureBox1.Height / 2);
                Draw_Kub(pictureBox1.BackColor);
                oX = 1;
                oY = 1;
                oZ = 0;
                Draw_Osi(Color.Red, pictureBox1.Width / 2, pictureBox1.Height / 2, pictureBox1.Height / 2);
                Draw_Kub(curentColor);
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton2.Checked == true)
            {
                Draw_Osi(pictureBox1.BackColor, pictureBox1.Width / 2, pictureBox1.Height / 2, pictureBox1.Height / 2);
                Draw_Kub(pictureBox1.BackColor);
                oX = 0;
                oY = 1;
                oZ = 1;
                Draw_Osi(Color.Red, pictureBox1.Width / 2, pictureBox1.Height / 2, pictureBox1.Height / 2);
                Draw_Kub(curentColor);
            }
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            Draw_Osi(pictureBox1.BackColor, pictureBox1.Width / 2, pictureBox1.Height / 2, pictureBox1.Height / 2);
            Draw_Kub(pictureBox1.BackColor);
            if (checkBox7.Checked == true && checkBox8.Checked != true && checkBox9.Checked != true)
            {
                x1 = ((double)trackBar2.Value / 5);
                v1 = trackBar2.Value ;
            }
            else if (checkBox7.Checked == true && checkBox8.Checked == true && checkBox9.Checked != true)
            {
                x2 =  ((double)trackBar2.Value / 5);
                y1 =  ((double)trackBar2.Value / 5);
                v2 = trackBar2.Value;
            }
            else if (checkBox7.Checked == true && checkBox8.Checked != true && checkBox9.Checked == true)
            {
                x3 =  ((double)trackBar2.Value / 5);
                z1 =  ((double)trackBar2.Value / 5);
                v3 = trackBar2.Value;
            }
            else if (checkBox7.Checked != true && checkBox8.Checked == true && checkBox9.Checked != true)
            {
                y2 = ((double)trackBar2.Value / 5);
                v4 = trackBar2.Value;
            }
            else if (checkBox7.Checked != true && checkBox8.Checked == true && checkBox9.Checked == true)
            {
                y3 =  ((double)trackBar2.Value / 5);
                z2 =  ((double)trackBar2.Value / 5);
                v5 = trackBar2.Value;
            }
            else if(checkBox7.Checked != true && checkBox8.Checked != true && checkBox9.Checked == true)
            {
                z3 = ((double)trackBar2.Value / 5);
                v6 = trackBar2.Value;
            }
            else if (checkBox7.Checked == true && checkBox8.Checked == true && checkBox9.Checked == true)
            {
                s = 1 / ((double)trackBar2.Value / 5);
                v7 = trackBar2.Value;
            }
            mX = x1 * x2 * x3;
            mY = y1 * y2 * y3;
            mZ = z1 * z2 * z3;
            Draw_Osi(Color.Red, pictureBox1.Width / 2, pictureBox1.Height / 2, pictureBox1.Height / 2);
            Draw_Kub(curentColor);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton3.Checked == true)
            {
                Draw_Osi(pictureBox1.BackColor, pictureBox1.Width / 2, pictureBox1.Height / 2, pictureBox1.Height / 2);
                Draw_Kub(pictureBox1.BackColor);
                oX = 1;
                oY = 0;
                oZ = 1;
                Draw_Osi(Color.Red, pictureBox1.Width / 2, pictureBox1.Height / 2, pictureBox1.Height / 2);
                Draw_Kub(curentColor);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Draw_Osi(pictureBox1.BackColor, pictureBox1.Width / 2, pictureBox1.Height / 2, pictureBox1.Height / 2);
            Draw_Kub(pictureBox1.BackColor);
            Smeshenie(step);
            Draw_Osi(Color.Red, pictureBox1.Width / 2, pictureBox1.Height / 2, pictureBox1.Height / 2);
            Draw_Kub(curentColor);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57))
            { 
                e.Handled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            n1 = 1;
            n2 = 0;
            n3 = 0;
            label11.Text = "(" + n1.ToString() + ";" + n2.ToString() + ";" + n3.ToString() + ")";
            r = 0;
            p = 0;
            q = 0;
            mX = 1;
            mY = 1;
            mZ = 1;
            v1 = v2 = v3 = v4 = v5 = v6 = v7 = 5;
            x1 = x2 = x3 = y1 = y2 = y3 = z1 = z2 = z3 = 1;
            radioButton1.Checked = true;
            fi = 15;
            label12.Text = "ф = " + fi.ToString();
            Init_kub();
        }   

        private void button4_Click(object sender, EventArgs e)
        {
            Draw_Kub(pictureBox1.BackColor);
            Draw_Osi(Color.Red, pictureBox1.Width / 2, pictureBox1.Height / 2, pictureBox1.Height / 2);
            if (Math.Sqrt(Math.Pow(n1,2)+ Math.Pow(n3, 2) + Math.Pow(n2, 2))!=1)
            {
                double vec = Math.Sqrt(Math.Pow(n1, 2) + Math.Pow(n3, 2) + Math.Pow(n2, 2));
                n1 = n1 / vec;
                n2 = n2 / vec;
                n3 = n3 / vec;
            }
            Draw_Kub_vrash();
        }

        private void Lab5_Load(object sender, EventArgs e)
        {
            n1 = 1;
            n2 = 0;
            n3 = 0;
            label11.Text = "(" + n1.ToString() + ";" + n2.ToString() + ";" + n3.ToString() + ")";
            r = 0;
            p = 0;
            q = 0;
            mX = 1;
            mY = 1;
            mZ = 1;
            v1 = v2 = v3 = v4 = v5 = v6 =v7= 5;
            x1 = x2 = x3 = y1 = y2 = y3 = z1 = z2 = z3 = 1;
            radioButton1.Checked = true;
            fi = 15;
            label12.Text = "ф = " + fi.ToString();
            Init_kub();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Draw_Kub(pictureBox1.BackColor);
            Draw_Kub(curentColor);
        }
    }
}
