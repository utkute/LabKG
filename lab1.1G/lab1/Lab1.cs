using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.IO;

namespace lab1._1G
{
    public partial class Lab_1 : Form
    {
        const int MaximumN = 4;
        int n = 2;
        const int MaxDimension = 3;
        int dimension;
        TextBox[,] MatrText = null;
        TextBox[] vectorCoord = null;
        double[] vectorCoordF = new double[MaxDimension];
        double[] vectorCoordS = new double[MaxDimension];
        double[,] Matrix_1 = new double[MaximumN, MaximumN];
        double[,] Matrix_2 = new double[MaximumN, MaximumN];
        double[,] Matrix_Res = new double[MaximumN, MaximumN];
        bool fullMatrix_1;
        bool fullMatrix_2;
        bool fullVecF;
        bool fullVecS;
        int dx = 40, dy = 20;
        Lab1Sup supForm = null;
        ErrorOverMaxValue errorOver = null;

        private void Lab_1_Load(object sender, EventArgs e)
        {

            textBox1.Text = "";
            fullMatrix_1 = fullMatrix_2 = false;
            label2.Text = "false";
            label3.Text = "false";
            label4.Text = "false";
            label5.Text = "false";
            supForm = new Lab1Sup();
            errorOver = new ErrorOverMaxValue();
            MatrText = new TextBox[MaximumN, MaximumN];
            vectorCoord = new TextBox[MaxDimension];
            for (int i = 0; i < MaxDimension; i++)
            {
                vectorCoord[i] = new TextBox();
                vectorCoord[i] = new TextBox();
                vectorCoord[i].Text = "0";
                vectorCoord[i].Location = new System.Drawing.Point(10 + i * dx);
                vectorCoord[i].Size = new System.Drawing.Size(dx, dy);
                vectorCoord[i].Visible = false;
                vectorCoord[i].KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
                supForm.Controls.Add(vectorCoord[i]);
            }
            for (int i = 0; i < MaximumN; i++)
            {
                for (int j = 0; j < MaximumN; j++)
                {
                    MatrText[i, j] = new TextBox();
                    MatrText[i, j].Text = "0";
                    MatrText[i, j].Location = new System.Drawing.Point(10 + i * dx, 10 + j * dy);
                    MatrText[i, j].Size = new System.Drawing.Size(dx, dy);
                    MatrText[i, j].Visible = false;
                    MatrText[i, j].KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
                    supForm.Controls.Add(MatrText[i, j]);

                }
            }
        }
        private void ClearForm()
        {
            for (int i = 0; i < MaximumN; i++)
            {
                for (int j = 0; j < MaximumN; j++)
                {
                    MatrText[i, j].Visible = false;
                }
            }
            for (int i = 0; i < MaxDimension; i++)
            {
                vectorCoord[i].Visible = false;
            }
        }


        private void ClearVector()
        {
            for (int i = 0; i < dimension; i++)
            {
                vectorCoord[i].Text = "0";
            }
            ClearForm();
        }
        private void ClearMatrText()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    MatrText[i, j].Text = "0";
                }
            }
            ClearForm();
        }

        private void TextVectorForming()
        {
            ClearVector();
            for (int i = 0; i < dimension; i++)
            {
                vectorCoord[i].TabIndex = i * n;
                vectorCoord[i].Visible = true;
            }
            supForm.Width = 10 + dimension * dx + 20;
            supForm.Height = 10 + dimension * dy + supForm.button1.Height + 50;
            supForm.button1.Left = 10;
            supForm.button1.Top = 10 + dimension * dy + 10;
            supForm.button1.Width = supForm.Width - 30;
        }

        private void TextMatrixForming()
        {
            ClearMatrText();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    MatrText[i, j].TabIndex = i * n + j + 1;
                    MatrText[i, j].Visible = true;
                }
            }
            supForm.Width = 10 + n * dx + 20;
            supForm.Height = 10 + n * dy + supForm.button1.Height + 50;
            supForm.button1.Left = 10;
            supForm.button1.Top = 10 + n * dy + 10;
            supForm.button1.Width = supForm.Width - 30;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                return;
            }
            n = int.Parse(textBox1.Text);
            if (CoreckSizeCheck())
            {
                TextMatrixForming();
                if (supForm.ShowDialog() == DialogResult.OK)
                {
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            if (MatrText[i, j].Text != "")
                            {
                                Matrix_1[i, j] = Double.Parse(MatrText[i, j].Text);
                            }
                            else
                            {
                                Matrix_1[i, j] = 0;
                            }
                        }
                    }
                    fullMatrix_1 = true;
                    label2.Text = "true";
                }
            }
            else
            {
                this.Enabled = false;
                if (errorOver.ShowDialog() == DialogResult.OK)
                {
                    this.Enabled = true;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                return;
            }
            n = int.Parse(textBox1.Text);
            if (CoreckSizeCheck())
            {
                TextMatrixForming();
                if (supForm.ShowDialog() == DialogResult.OK)
                {
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            if (MatrText[i, j].Text != "")
                            {
                                Matrix_2[i, j] = Double.Parse(MatrText[i, j].Text);
                            }
                            else
                            {
                                Matrix_2[i, j] = 0;
                            }
                        }
                    }
                    fullMatrix_2 = true;
                    label3.Text = "true";
                }

            }
            else
            {
                this.Enabled = false;
                if (errorOver.ShowDialog() == DialogResult.OK)
                {
                    this.Enabled = true;
                }
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            int nn = int.Parse(textBox1.Text);
            if (nn != n)
            {
                fullMatrix_1 = fullMatrix_2 = false;
                label2.Text = "false";
                label3.Text = "false";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!((fullMatrix_1 == true) && (fullMatrix_2 == true)))
            {
                return;
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Matrix_Res[j, i] = 0;
                    for (int k = 0; k < n; k++)
                    {
                        Matrix_Res[j, i] = Matrix_Res[j, i] + Matrix_1[k, i] * Matrix_2[j, k];
                    }
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    MatrText[i, j].TabIndex = i * n + j + 1;
                    MatrText[i, j].Text = Matrix_Res[i, j].ToString();
                }
            }
            supForm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (CoreckSizeCheck())
            {
                FileStream fileWorker = null;
                string result;
                byte[] resultByte = null;
                fileWorker = new FileStream("Res_Matr.txt", FileMode.Create);
                result = n.ToString() + "\r\n";
                resultByte = Encoding.Default.GetBytes(result);
                fileWorker.Write(resultByte, 0, resultByte.Length);
                result = "";
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        result = result + Matrix_Res[i, j].ToString() + "  ";
                    }
                    result = result + "\r\n";
                }
                resultByte = Encoding.Default.GetBytes(result);
                fileWorker.Write(resultByte, 0, resultByte.Length);
                if (fileWorker != null)
                {
                    fileWorker.Close();
                }
            }
            else
            {
                this.Enabled = false;
                if (errorOver.ShowDialog() == DialogResult.OK)
                {
                    this.Enabled = true;
                }
            }
        }

        private bool CoreckSizeCheck()
        {
            if (MaximumN < n || n < 1)
            {
                return false;
            }
            return true;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 45 && e.KeyChar != 46)
                e.Handled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                return;
            }
            dimension = int.Parse(textBox2.Text);
            if (VectSizeCheck())
            {
                TextVectorForming();
                if (supForm.ShowDialog() == DialogResult.OK)
                {
                    for (int i = 0; i < dimension; i++)
                    {
                        if (vectorCoord[i].Text != "")
                        {
                            vectorCoordF[i] = Double.Parse(vectorCoord[i].Text);
                        }
                        else
                        {
                            vectorCoordF[i] = 0;
                        }
                    }
                    fullVecF = true;
                    label4.Text = "true";
                }
            }
            else
            {
                this.Enabled = false;
                if (errorOver.ShowDialog() == DialogResult.OK)
                {
                    this.Enabled = true;
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                return;
            }
            dimension = int.Parse(textBox2.Text);
            if (VectSizeCheck())
            {
                TextVectorForming();
                if (supForm.ShowDialog() == DialogResult.OK)
                {
                    for (int i = 0; i < dimension; i++)
                    {
                        if (vectorCoord[i].Text != "")
                        {
                            vectorCoordS[i] = Double.Parse(vectorCoord[i].Text);
                        }
                        else
                        {
                            vectorCoordS[i] = 0;
                        }
                    }
                    fullVecS = true;
                    label5.Text = "true";
                }
            }
            else
            {
                this.Enabled = false;
                if (errorOver.ShowDialog() == DialogResult.OK)
                {
                    this.Enabled = true;
                }
            }
        }

        private bool VectSizeCheck()
        {
            if (dimension == 2 || dimension == 3)
            {
                return true;
            }
            return false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            double result = 0;
            ClearForm();
            if (!((fullVecF == true) && (fullVecS == true)))
            {
                return;
            }
            for (int i = 0; i < dimension; i++)
            {
                result += vectorCoordF[i] * vectorCoordS[i];
                vectorCoord[i].Text = (vectorCoordF[i] * vectorCoordS[i]).ToString();
            }
            ClearVector();
            vectorCoord[0].Text = result.ToString();
            vectorCoord[0].Visible = true;
            supForm.ShowDialog();
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            int nn = int.Parse(textBox2.Text);
            if (nn != dimension)
            {
                fullVecF = fullVecS = false;
                label4.Text = "false";
                label5.Text = "false";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ClearForm();
            if (!((fullVecF == true) && (fullVecS == true)))
            {
                return;
            }
            if (dimension == 3)
            {
                vectorCoord[0].Text = (vectorCoordF[1] * vectorCoordS[2] - vectorCoordF[2] * vectorCoordS[1]).ToString();
                vectorCoord[1].Text = (vectorCoordF[2] * vectorCoordS[0] - vectorCoordF[0] * vectorCoordS[2]).ToString();
                vectorCoord[2].Text = (vectorCoordF[0] * vectorCoordS[1] - vectorCoordF[1] * vectorCoordS[0]).ToString();
                for (int i=0; i < dimension; i++)
                {
                    vectorCoord[i].Visible = true;
                }
                supForm.ShowDialog();
            }
            else
            {
                return;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (!((fullMatrix_1 == true) && (fullMatrix_2 == true)))
            {
                return;
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Matrix_Res[i, j] = Matrix_1[i, j] + Matrix_2[i, j];
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    MatrText[i, j].TabIndex = i * n + j + 1;
                    MatrText[i, j].Text = Matrix_Res[i, j].ToString();
                }
            }
            supForm.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (!((fullMatrix_1 == true) && (fullMatrix_2 == true)))
            {
                return;
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Matrix_Res[i, j] = Matrix_1[i, j] - Matrix_2[i, j];
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    MatrText[i, j].TabIndex = i * n + j + 1;
                    MatrText[i, j].Text = Matrix_Res[i, j].ToString();
                }
            }
            supForm.ShowDialog();
        }

        public Lab_1()
        {
            InitializeComponent();
        }
    }
}
