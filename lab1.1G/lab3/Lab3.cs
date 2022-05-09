namespace lab1._1G
{
    public partial class Lab3 : Form
    {
        struct Pixel
        {
            public int X;
            public int Y;
        };
        struct Rebro
        {
            int y; //начальная точка ребра по у координате,х0 - х координата точки пересечения ребра с наивысшей сканирующей строкой.
            int dx; //dx–смещение по x при движении вдоль ребра, соответствующее увеличению y-координаты на 1
            int dy; //число пересекаемых ребром строк.
        }

        public int xn, yn, xk, yk;
        int oX1, oY1, oX2, oY2, oX3, oY3, oX4, oY4;
        Bitmap mybitmap;
        Color current_color = Color.Black;
        Color zaliv_color = Color.Red;
        double[] vershX = new double[4];
        double[] vershY = new double[4];
        List<double> otsechX = new List<double>();
        List<double> otsechY = new List<double>();
        bool otsech = false;

        private void button2_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                current_color = colorDialog1.Color;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            //создаем новый экземпляр Bitmap размером с элемент
            //pictureBox1 (mybitmap)
            //на нем выводим попиксельно отрезок
            using (Graphics g = Graphics.FromHwnd(pictureBox1.Handle))
            {
                if (radioButton1.Checked == true)
                {
                    //рисуем прямоугольник
                    CDA(10, 10, 10, 110);
                    CDA(10, 10, 110, 10);
                    CDA(10, 110, 110, 110);
                    CDA(110, 10, 110, 110);
                    CDA(40, 40, 40, 70);
                    CDA(40, 40, 70, 40);
                    CDA(40, 70, 70, 70);
                    CDA(70, 40, 70, 70);
                    //рисуем треугольник
                    CDA(150, 10, 150, 100);
                    //CDA(150, 10, 150, 150);
                    CDA(150, 10, 200, 60);
                    CDA(150, 100, 200, 60);
                }
                else
                {
                    if (radioButton2.Checked == true)
                    {
                        //получаем растр созданного рисунка в mybitmap
                        mybitmap = pictureBox1.Image as Bitmap;

                        // задаем координаты затравки
                        xn = 50;
                        yn = 50;
                        // вызываем рекурсивную процедуру заливки с затравкой
                        Zaliv(xn, yn);
                    }
                }
                pictureBox1.Image = mybitmap;
                // обновляем pictureBox и активируем кнопки
                pictureBox1.Refresh();
                button1.Enabled = true;
                button2.Enabled = true;

            }
        }


        public Lab3()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (colorDialog2.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                zaliv_color = colorDialog2.Color;
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (radioButton4.Checked == true)
            {
                xn = e.X;
                yn = e.Y;
            }
            else if (radioButton3.Checked == true)
            {
                EasyZaliv(e.X, e.Y);
            }
            else
            {
                MessageBox.Show("Вы не выбрали алгоритм заливки фигуры или линии!");
            }
        }

        private void CDA(int x1, int y1, int x2, int y2)
        {
            int i, n;
            double xt, yt, dx, dy;

            xn = x1;
            yn = y1;
            xk = x2;
            yk = y2;
            dx = xk - xn;
            dy = yk - yn;
            n = 100;
            xt = xn;
            yt = yn;
            for (i = 1; i <= n; i++)
            {
                Pen myPen = new Pen(current_color, 1);
                mybitmap.SetPixel((int)xt, (int)yt, current_color);
                xt = xt + dx / n;
                yt = yt + dy / n;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (radioButton4.Checked == true)
            {
                yk = e.Y;
                xk = e.X;
                LineB(xn, yn, xk, yk, current_color);
            }
        }

        private void Lab3_Load(object sender, EventArgs e)
        {
            mybitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        }

        private void button4_Click(object sender, EventArgs e)
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
            LineB(xn, yn, xk, yk, current_color);
            xn = xe;
            yn = ye;
            LineB(xn, yn, xk, yk, current_color);
            xn = xs;
            yn = ys;
            xk = xCenter;
            yk = yCenter2;
            LineB(xn, yn, xk, yk, current_color);
            xn = xe;
            yn = ye;
            LineB(xn, yn, xk, yk, current_color);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            mybitmap = null;
            mybitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            otsechX.Clear();
            otsechY.Clear();
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            otsech = true;
            if (textBox2.Text != "" && textBox1.Text != "")
            {
                oX1 = int.Parse(textBox2.Text);
                oY1 = int.Parse(textBox1.Text);
                if (textBox3.Text != "" && textBox4.Text != "")
                {
                    oX2 = int.Parse(textBox3.Text);
                    oY2 = int.Parse(textBox4.Text);
                    LineB(oX1, oY1, oX2, oY2, Color.Red);
                }
                if (textBox5.Text != "" && textBox6.Text != "")
                {
                    oX3 = int.Parse(textBox3.Text);
                    oY3 = int.Parse(textBox4.Text);
                    LineB(oX1, oY1, oX3, oY3, Color.Red);
                }
            }
            otsech = false;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            otsech = true;
            if (textBox2.Text != "" && textBox1.Text != "")
            {
                oX1 = int.Parse(textBox2.Text);
                oY1 = int.Parse(textBox1.Text);
                if (textBox3.Text != "" && textBox4.Text != "")
                {
                    oX2 = int.Parse(textBox3.Text);
                    oY2 = int.Parse(textBox4.Text);
                    LineB(oX1, oY1, oX2, oY2, Color.Red);
                }
                if (textBox7.Text != "" && textBox8.Text != "")
                {
                    oX4 = int.Parse(textBox7.Text);
                    oY4 = int.Parse(textBox8.Text);
                    LineB(oX1, oY1, oX4, oY4, Color.Red);
                }

            }
            otsech = false;
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            otsech = true;
            if (textBox3.Text != "" && textBox4.Text != "")
            {
                oX2 = int.Parse(textBox3.Text);
                oY2 = int.Parse(textBox4.Text);
                if (textBox2.Text != "" && textBox1.Text != "")
                {
                    oX1 = int.Parse(textBox2.Text);
                    oY1 = int.Parse(textBox1.Text);
                    LineB(oX1, oY1, oX2, oY2, Color.Red);
                }
                if (textBox5.Text != "" && textBox6.Text != "")
                {
                    oX3 = int.Parse(textBox5.Text);
                    oY3 = int.Parse(textBox6.Text);
                    LineB(oX2, oY2, oX3, oY3, Color.Red);
                }
            }
            otsech = false;
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            otsech = true;
            if (textBox3.Text != "" && textBox4.Text != "")
            {
                oX2 = int.Parse(textBox3.Text);
                oY2 = int.Parse(textBox4.Text);
                if (textBox2.Text != "" && textBox1.Text != "")
                {
                    oX1 = int.Parse(textBox2.Text);
                    oY1 = int.Parse(textBox1.Text);
                    LineB(oX1, oY1, oX2, oY2, Color.Red);
                }
                if (textBox5.Text != "" && textBox6.Text != "")
                {
                    oX3 = int.Parse(textBox5.Text);
                    oY3 = int.Parse(textBox6.Text);
                    LineB(oX2, oY2, oX3, oY3, Color.Red);
                }
            }
            otsech = false;
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            otsech = true;
            if (textBox5.Text != "" && textBox6.Text != "")
            {
                oX3 = int.Parse(textBox5.Text);
                oY3 = int.Parse(textBox6.Text);
                if (textBox3.Text != "" && textBox4.Text != "")
                {
                    oX2 = int.Parse(textBox3.Text);
                    oY2 = int.Parse(textBox4.Text);
                    LineB(oX3, oY3, oX2, oY2, Color.Red);
                }
                if (textBox7.Text != "" && textBox8.Text != "")
                {
                    oX4 = int.Parse(textBox7.Text);
                    oY4 = int.Parse(textBox8.Text);
                    LineB(oX3, oY3, oX4, oY4, Color.Red);
                }
            }
            otsech = false;
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            otsech = true;
            if (textBox5.Text != "" && textBox6.Text != "")
            {
                oX3 = int.Parse(textBox5.Text);
                oY3 = int.Parse(textBox6.Text);
                if (textBox3.Text != "" && textBox4.Text != "")
                {
                    oX2 = int.Parse(textBox3.Text);
                    oY2 = int.Parse(textBox4.Text);
                    LineB(oX3, oY3, oX2, oY2, Color.Red);
                }
                if (textBox7.Text != "" && textBox8.Text != "")
                {
                    oX4 = int.Parse(textBox7.Text);
                    oY4 = int.Parse(textBox8.Text);
                    LineB(oX3, oY3, oX4, oY4, Color.Red);
                }
            }
            otsech = false;
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            otsech = true;
            if (textBox7.Text != "" && textBox8.Text != "")
            {
                oX4 = int.Parse(textBox7.Text);
                oY4 = int.Parse(textBox8.Text);
                if (textBox2.Text != "" && textBox1.Text != "")
                {
                    oX1 = int.Parse(textBox2.Text);
                    oY1 = int.Parse(textBox1.Text);
                    LineB(oX4, oY4, oX1, oY1, Color.Red);
                }
                if (textBox5.Text != "" && textBox6.Text != "")
                {
                    oX3 = int.Parse(textBox5.Text);
                    oY3 = int.Parse(textBox6.Text);
                    LineB(oX4, oY4, oX3, oY3, Color.Red);
                }
            }
            otsech = false;
        }

        private void textBox8_Leave(object sender, EventArgs e)
        {
            otsech = true;
            if (textBox7.Text != "" && textBox8.Text != "")
            {
                oX4 = int.Parse(textBox7.Text);
                oY4 = int.Parse(textBox8.Text);
                if (textBox2.Text != "" && textBox1.Text != "")
                {
                    oX1 = int.Parse(textBox2.Text);
                    oY1 = int.Parse(textBox1.Text);
                    LineB(oX4, oY4, oX1, oY1, Color.Red);
                }
                if (textBox5.Text != "" && textBox6.Text != "")
                {
                    oX3 = int.Parse(textBox5.Text);
                    oY3 = int.Parse(textBox6.Text);
                    LineB(oX4, oY4, oX3, oY3, Color.Red);
                }
            }
            otsech = false;
        }

        private void Zaliv(int x1, int y1)
        {
            // получаем цвет текущего пикселя с координатами x1, y1
            //Color old_color = mybitmap.GetPixel(x1, y1);
            // сравнение цветов происходит в формате RGB
            // для этого используем метод ToArgb объекта Color
            if ((mybitmap.GetPixel(x1, y1).ToArgb() == current_color.ToArgb()) ||
           (mybitmap.GetPixel(x1, y1).ToArgb() == Color.Green.ToArgb()))
            {
                return;
            }
            else
            {
                //перекрашиваем пиксель
                mybitmap.SetPixel(x1, y1, Color.Green);

                //вызываем метод для 4-х соседних пикселей
                Zaliv(x1 + 1, y1);
                Zaliv(x1 - 1, y1);
                Zaliv(x1, y1 + 1);
                Zaliv(x1, y1 - 1);
                //выходим из методf
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Otsech();
        }

        private void EasyZaliv(int x, int y)
        {
            Stack<Pixel> zalivStack = new Stack<Pixel>(15);
            bool zalivCheck;
            int temporaryX, rigthX, leftX;
            Pixel pixel;
            pixel.X = x;
            pixel.Y = y;
            zalivStack.Push(pixel);
            while (zalivStack.Count != 0)
            {
                pixel = zalivStack.Pop();
                mybitmap.SetPixel(pixel.X, pixel.Y, zaliv_color);
                temporaryX = pixel.X;
                pixel.X += 1;
                while (mybitmap.GetPixel(pixel.X, pixel.Y).ToArgb() != current_color.ToArgb())
                {
                    mybitmap.SetPixel(pixel.X, pixel.Y, zaliv_color);
                    pixel.X += 1;
                }
                rigthX = pixel.X - 1;
                pixel.X = temporaryX;
                pixel.X -= 1;
                while (mybitmap.GetPixel(pixel.X, pixel.Y).ToArgb() != current_color.ToArgb())
                {
                    mybitmap.SetPixel(pixel.X, pixel.Y, zaliv_color);
                    pixel.X -= 1;
                }
                leftX = pixel.X + 1;
                pixel.X = leftX;
                pixel.Y += 1;
                while (pixel.X <= rigthX)
                {
                    zalivCheck = false;
                    while (mybitmap.GetPixel(pixel.X, pixel.Y).ToArgb() != current_color.ToArgb() &&
                       mybitmap.GetPixel(pixel.X, pixel.Y).ToArgb() != zaliv_color.ToArgb() &&
                       pixel.X < rigthX)
                    {
                        if (!zalivCheck)
                        {
                            zalivCheck = true;
                        }
                        pixel.X += 1;
                    }
                    if (zalivCheck)
                    {
                        if (pixel.X == rigthX && mybitmap.GetPixel(pixel.X, pixel.Y).ToArgb() != current_color.ToArgb() &&
                       mybitmap.GetPixel(pixel.X, pixel.Y).ToArgb() != zaliv_color.ToArgb())
                        {
                            zalivStack.Push(pixel);
                        }
                        else
                        {
                            pixel.X -= 1;
                            zalivStack.Push(pixel);
                        }
                        zalivCheck = false;
                    }
                    temporaryX = pixel.X;
                    while (mybitmap.GetPixel(pixel.X, pixel.Y).ToArgb() == current_color.ToArgb() ||
                        mybitmap.GetPixel(pixel.X, pixel.Y).ToArgb() == zaliv_color.ToArgb() &&
                        pixel.X < rigthX)
                    {
                        pixel.X += 1;
                    }
                    if (temporaryX == pixel.X)
                    {
                        pixel.X += 1;
                    }
                }
                //  pixel.Y = y;
                pixel.X = leftX;
                pixel.Y = pixel.Y - 2;
                while (pixel.X <= rigthX)
                {
                    zalivCheck = false;
                    while (mybitmap.GetPixel(pixel.X, pixel.Y).ToArgb() != current_color.ToArgb() &&
                       mybitmap.GetPixel(pixel.X, pixel.Y).ToArgb() != zaliv_color.ToArgb() &&
                       pixel.X < rigthX)
                    {
                        if (!zalivCheck)
                        {
                            zalivCheck = true;
                        }
                        pixel.X += 1;
                    }
                    if (zalivCheck)
                    {
                        if (pixel.X == rigthX && mybitmap.GetPixel(pixel.X, pixel.Y).ToArgb() != current_color.ToArgb() &&
                       mybitmap.GetPixel(pixel.X, pixel.Y).ToArgb() != zaliv_color.ToArgb())
                        {
                            zalivStack.Push(pixel);
                        }
                        else
                        {
                            pixel.X -= 1;
                            zalivStack.Push(pixel);
                        }
                        zalivCheck = false;
                    }
                    temporaryX = pixel.X;
                    while (mybitmap.GetPixel(pixel.X, pixel.Y).ToArgb() == current_color.ToArgb() ||
                        mybitmap.GetPixel(pixel.X, pixel.Y).ToArgb() == zaliv_color.ToArgb() &&
                        pixel.X < rigthX)
                    {
                        pixel.X += 1;
                    }
                    if (temporaryX == pixel.X)
                    {
                        pixel.X += 1;
                    }
                }
            }
            pictureBox1.Refresh();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            LoopBypass();
        }

        private void LineB(int x0, int y0, int x1, int y1, Color color)
        {
            if (!otsech)
            {
                otsechX.Add(x0);
                otsechX.Add(x1);
                otsechY.Add(y0);
                otsechY.Add(y1);
            }
            Pen myPen = new Pen(current_color, 1);
            bool swaped = false;
            int ystep = 1;
            if (Math.Abs(y1 - y0) >= Math.Abs(x1 - x0))
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
            if (y1 - y0 < 0)
            {
                ystep = -1;
            }
            //1
            int x = x0;
            int y = y0;
            using (Graphics g = Graphics.FromHwnd(pictureBox1.Handle))
            {
                if (swaped)
                {
                    mybitmap.SetPixel(y, x, color);
                }
                else
                {
                    mybitmap.SetPixel(x, y, color);
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
                        mybitmap.SetPixel(y, x, color);
                    }
                    else
                    {
                        mybitmap.SetPixel(x, y, color);
                    }
                }
                pictureBox1.Image = mybitmap;
                pictureBox1.Refresh();
            }
        }

        private void LoopBypass()
        {
            Pixel pixel;
            pixel.X = 0;
            pixel.Y = 0;
            while(mybitmap.GetPixel(pixel.X,pixel.Y).ToArgb() != current_color.ToArgb())
            {
                pixel.X++;
                if(pixel.X == pictureBox1.Height)
                {
                    pixel.Y++;
                    pixel.X = 0;
                }
                if (pixel.X == pictureBox1.Width && pixel.Y == pictureBox1.Height)
                {
                    MessageBox.Show("На экране нет контрура");
                }
            }
            Stack<Pixel> pixels = new Stack<Pixel>();
            pixels.Push(pixel);
            while(pixels.Count != 0)
            {
                pixel = pixels.Pop();
                mybitmap.SetPixel(pixel.X, pixel.Y, Color.Red);
                for (int i = 1; i != -2; i--)
                {
                    pixel.X += i;
                    for (int j = 1; j != -2; j--)
                    {
                        if(i == 0 && j == 0)
                        {
                            continue;
                        }
                        pixel.Y += j;
                        if (mybitmap.GetPixel(pixel.X, pixel.Y).ToArgb() == current_color.ToArgb())
                        {
                            pixels.Push(pixel);
                        }
                        pixel.Y -= j;
                    }
                    pixel.X -= i;
                }
            }
            pictureBox1.Refresh();
        }
        private bool OtsechCheck(double x1, double y1, double x2, double y2)
        {
            if (x1 < oX1 && x2 < oX1)
            {
                LineB((int)x1, (int)y1, (int)x2, (int)y2, Color.Yellow);
                return false;
            }
            if (x1 > oX3 && x2 > oX3)
            {
                LineB((int)x1, (int)y1, (int)x2, (int)y2, Color.Yellow);
                return false;
            }
            if (y1 < oY1 && y2 < oY1)
            {
                LineB((int)x1, (int)y1, (int)x2, (int)y2, Color.Yellow);
                return false;
            }
            if (y1 > oY3 && y2 > oY3)
            {
                LineB((int)x1, (int)y1, (int)x2, (int)y2, Color.Yellow);
                return false;
            }
            return true;
        }

        private void Otsech()
        {
            otsech = true;
            double nX1, nX2, nY1, nY2;
            double m;
            bool isPastView = false;
            for (int i = 0; i < otsechX.Count; i=i+2)
            {
                nX1 = otsechX[i];
                nY1 = otsechY[i];
                nX2 = otsechX[i+1];
                nY2 = otsechY[i+1];
                m = (otsechY[i+1] - otsechY[i]) / (otsechX[i + 1] - otsechX[i]);
                if (otsechX[i] < oX1 || otsechX[i] > oX3)
                {
                    if(OtsechCheck(otsechX[i], otsechY[i], otsechX[i+1], otsechY[i+1]))
                    {
                        if (otsechX[i] < oX1)
                        {
                            nY2 = m * (oX1 - otsechX[i]) + otsechY[i];
                            nX2 = oX1;
                        }
                        if (otsechX[i] > oX3)
                        {
                            nY2 = m * (oX3 - otsechX[i]) + otsechY[i];
                            nX2 = oX3;
                        }
                        isPastView = true;
                    }
                }
                if (otsechX[i+1] < oX1 || otsechX[i+1] > oX3)
                {
                    if (OtsechCheck(otsechX[i], otsechY[i], otsechX[i + 1], otsechY[i + 1]))
                    {
                        if (otsechX[i+1] < oX1)
                        {
                            nY1 = m * (oX1 - otsechX[i+1]) + otsechY[i+1];
                            nX1 = oX1;
                        }
                        if (otsechX[i+1] > oX3)
                        {
                            nY1 = m * (oX3 - otsechX[i+1]) + otsechY[i+1];
                            nX1 = oX3;
                        }
                        isPastView = true;
                    }
                }
                if (otsechY[i] < oY1 || otsechY[i] > oY2)
                {
                    if (OtsechCheck(otsechX[i], otsechY[i], otsechX[i + 1], otsechY[i + 1]))
                    {
                        if (otsechY[i] < oY1)
                        {
                            nX2 = otsechX[i] +(1/m)* (oY1 - otsechY[i]);
                            nY2 = oY1;
                        }
                        if (otsechX[i] > oY2)
                        {
                            nX2 = otsechX[i] + (1 / m) * (oY2 - otsechY[i]);
                            nY2 = oY2;
                        }
                        isPastView = true;
                    }
                }
                if (otsechY[i+1] < oY1 || otsechY[i+1] > oY2)
                {
                    if (OtsechCheck(otsechX[i], otsechY[i], otsechX[i + 1], otsechY[i + 1]))
                    {
                        if (otsechY[i+1] < oY1)
                        {
                            nX1 = otsechX[i+1] + (1 / m) * (oY1 - otsechY[i+1]);
                            nY1 = oY1;
                        }
                        if (otsechY[i+1] > oY2)
                        {
                            nX1 = otsechX[i+1] + (1 / m) * (oY2 - otsechY[i+1]);
                            nY1 = oY2;
                        }
                        isPastView = true;
                    }
                }
                if(isPastView)
                {
                    LineB((int)nX1, (int)nY1, (int)nX2, (int)nY2, Color.Yellow);
                    isPastView = false;
                }
            }
            otsech = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //vershX[0] = 150;
            //vershY[0] = 150;
            //vershX[1] = 150;
            //vershY[1] = 250;
            //vershX[2] = 250;
            //vershY[2] = 250;
            //vershX[3] = 250;
            //vershY[3] = 150;
            vershX[0] = 150;
            vershY[0] = 150;
            vershX[1] = 105;
            vershY[1] = 294;
            vershX[2] = 60;
            vershY[2] = 150;
            vershX[3] = 105;
            vershY[3] = 168;
            ZalivMnog();
        }

        private double[] SortY(double[] a, ref int[] numbY)
        {
            double[] array = a;
            int indx;
            for (int i = 0; i < array.Length; i++)
            {
                indx = i;
                for (int j = i; j < array.Length; j++)
                {
                    if (array[j] < array[indx])
                    {
                        indx = j;
                    }
                }
                if (array[indx] == array[i])
                {
                    continue;
                }
                int temp1 = numbY[i];
                numbY[i] = numbY[indx];
                numbY[indx] = temp1;
                double temp = array[i];
                array[i] = array[indx];
                array[indx] = temp;
            }
            return array;
        }
        private double[] SortX(double[] array)
        {
            int indx;
            for (int i = 0; i < array.Length; i++)
            {
                indx = i;
                for (int j = i; j < array.Length; j++)
                {
                    if (array[j] < array[indx])
                    {
                        indx = j;
                    }
                }
                if (array[indx] == array[i])
                {
                    continue;
                }
                double temp = array[i];
                array[i] = array[indx];
                array[indx] = temp;
            }
            return array;
        }

        private void ZalivMnog()
        {
            List<double> rebMaxY = new List<double>();
            List<double> dX = new List<double>();
            List<double> rebStartX = new List<double>();
            Stack<int> nubVershY = new Stack<int>();
            double nextY;
            int left = 0;
            int right = 0;
            double xTek;
            double yTek;
            int counter = 0;
            Pen myPen = new Pen(zaliv_color, 1);
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            int[] numbY = new int[vershY.Length];
            double[] sortY = new double[vershY.Length];
            for (int i = 0; i < vershY.Length; i++)
            {
                numbY[i] = i;
                sortY[i] = vershY[i];
            }
            sortY = SortY(sortY, ref numbY);
            double curentY = sortY[0];
            yTek = sortY[0];
            xTek = 0;
            int c = 0;
            while (curentY != sortY[sortY.Length - 1])
            {
                for (int i = 0; i < sortY.Length; i++)
                {
                    if (curentY == sortY[i])
                    {
                        nubVershY.Push(i);
                    }
                }
                if (nubVershY.Count != 0)
                {
                    while (nubVershY.Count != 0)
                    {
                        counter = nubVershY.Pop();
                        for (int i = 0; i < numbY.Length; i++)
                        {
                            if ((numbY[i] - 1) % numbY.Length == numbY[counter] || ((numbY[i] - 1) % numbY.Length < 0 && i + 1 == numbY.Length))
                            {
                                right = numbY[i];
                            }
                            if ((numbY[i] + 1) % numbY.Length == numbY[counter])
                            {
                                left = numbY[i];
                            }
                        }
                        if (vershY[left] != vershY[numbY[counter]] || vershY[right] != vershY[numbY[counter]])
                        {
                            if (vershY[left] != vershY[numbY[counter]])
                            {
                                rebMaxY.Add(vershY[left]);
                                rebStartX.Add(vershX[numbY[counter]]);
                                dX.Add(vershX[left] - vershX[numbY[counter]]);
                            }
                            if (vershY[right] != vershY[numbY[counter]])
                            {
                                rebMaxY.Add(vershY[right]);

                                rebStartX.Add(vershX[numbY[counter]]);

                                dX.Add(vershX[right] - vershX[numbY[counter]]);
                            }
                            c++;
                        }
                        
                    }
                }
                else 
                {
                    c++;
                }
                //double[] finalX = new double[rebMaxY.Count];
                double[] finalSortX = new double[rebMaxY.Count];
                //for (int i = 0; i < rebMaxY.Count; i++)
                //{
                //    finalX[i] = rebStartX[i];
                //}
                int k = 0;
                for (double i = curentY+1; i < sortY[c]; i++)
                {
                    k = 0;
                    while (rebMaxY.Count != k)
                    {
                        rebStartX[k] = rebStartX[k] + dX[k] / (rebMaxY[k] - yTek);
                        finalSortX[k] = rebStartX[k];
                        k++;   
                    }
                    finalSortX = SortX(finalSortX);
                    for (int h = 0; h< finalSortX.Length - 1;h+=2)
                    {
                        g.DrawLine(myPen, (int)finalSortX[h], (int)curentY, (int)finalSortX[h + 1], (int)curentY);
                    }
                    xTek++;
                    curentY++;
                }
                if(curentY + 1 == sortY[sortY.Length - 1])
                {
                    return;
                }
                else
                {
                    for (int p = rebMaxY.Count - 1; p > -1; p--)
                    {
                        if (rebMaxY[p] == sortY[c])
                        {
                            rebMaxY.RemoveAt(p);
                            rebStartX.RemoveAt(p);
                            dX.RemoveAt(p);
                        }
                    }
                }
            }
        }
    }
}