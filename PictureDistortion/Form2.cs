using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureDistortion
{
    public partial class Form2 : Form
    {
        Image image1;
        Image image2;
        string ControlPath = String.Empty;
        string TargetPath = String.Empty;
        string ControlKeyPointPath = String.Empty;
        string TargetKeyPointPath = String.Empty;
        int CanTrans;
        int ChaZhiType;
        public Form2()
        {
            InitializeComponent();
            CanTrans = 0;
            this.button1.Enabled = false;
            ChaZhiType = 1;
        }
        private static double U(double r)
        {
            if (r == 0)
            {
                return 0;
            }
            else
            {
                return r * r * Math.Log(r * r);
            }
        }
        private static double Distance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
        }
        static void Bilinear(double x, double y, Image image, int[] pic_new)
        {
            Bitmap bitmap = image as Bitmap;
            int i, j;
            double u, v;
            i = (int)Math.Floor(x);
            j = (int)Math.Floor(y);
            u = x - i;
            v = y - j;
            if (i == image.Width - 1 || j == image.Height - 1)
            {
                i = Math.Min(i, image.Width - 2);
                j = Math.Min(j, image.Height - 2);
            }
            else if (i > image.Width - 1 || j > image.Height - 1)
            {
                pic_new[0] = 0;
                pic_new[1] = 0;
                pic_new[2] = 0;
                return;
            }

            if (i < 0 || j < 0)
            {
                pic_new[0] = 0;
                pic_new[1] = 0;
                pic_new[2] = 0;
                return;
            }
            pic_new[0] = (int)(((1 - u) * bitmap.GetPixel(i, j).R + u * bitmap.GetPixel(i + 1, j).R) * (1 - v) + ((1 - u) * bitmap.GetPixel(i, j + 1).R + u * bitmap.GetPixel(i + 1, j + 1).R) * v);
            pic_new[1] = (int)(((1 - u) * bitmap.GetPixel(i, j).G + u * bitmap.GetPixel(i + 1, j).G) * (1 - v) + ((1 - u) * bitmap.GetPixel(i, j + 1).G + u * bitmap.GetPixel(i + 1, j + 1).G) * v);
            pic_new[2] = (int)(((1 - u) * bitmap.GetPixel(i, j).B + u * bitmap.GetPixel(i + 1, j).B) * (1 - v) + ((1 - u) * bitmap.GetPixel(i, j + 1).B + u * bitmap.GetPixel(i + 1, j + 1).B) * v);
        }
        static void Nearest(double x, double y, Image image, int[] pic_new)
        {
            Bitmap bitmap = image as Bitmap;
            double x_new = 0, y_new = 0;
            switch ((x - Math.Floor(x)) < 0.5)
            {
                case true:
                    x_new = Math.Floor(x);
                    break;
                case false:
                    x_new = Math.Ceiling(x);
                    break;
                default:
                    break;
            }
            switch ((y - Math.Floor(y)) < 0.5)
            {
                case true:
                    y_new = Math.Floor(y);
                    break;
                case false:
                    y_new = Math.Ceiling(y);
                    break;
                default:
                    break;
            }
            if ((int)x_new < 0)
            {
                pic_new[0] = 0;
                pic_new[1] = 0;
                pic_new[2] = 0;
                return;
            }
            else if ((int)x_new > image.Width - 1)
            {
                pic_new[0] = 0;
                pic_new[1] = 0;
                pic_new[2] = 0;
                return;
            }

            if ((int)y_new < 0)
            {
                pic_new[0] = 0;
                pic_new[1] = 0;
                pic_new[2] = 0;
                return;
            }
            else if ((int)y_new > image.Height - 1)
            {
                pic_new[0] = 0;
                pic_new[1] = 0;
                pic_new[2] = 0;
                return;
            }
            pic_new[0] = bitmap.GetPixel((int)x_new, (int)y_new).R;
            pic_new[1] = bitmap.GetPixel((int)x_new, (int)y_new).G;
            pic_new[2] = bitmap.GetPixel((int)x_new, (int)y_new).B;
        }
        private static Bitmap TPS(double[,] Control, double[,] Target, string InputPath1, string InputPath2, int h, int w, int type)
        {
            Image image = Image.FromFile(InputPath1);
            Image image1 = Image.FromFile(InputPath2);
            Bitmap bitmap = image1 as Bitmap;
            double[,] L = new double[71, 71];
            double[,] Y = new double[71, 2];
            double[,] Ans = new double[71, 2];
            double[,,] Fxy = new double[w, h, 2];
            //L矩阵初始化
            for (int i = 0; i < 68; i++)
            {
                for (int j = i; j < 68; j++)
                {
                    L[i, j] = U(Distance(Control[i, 0], Control[i, 1], Control[j, 0], Control[j, 1]));
                    L[j, i] = L[i, j];
                }
            }
            for (int i = 0; i < 68; i++)
            {
                L[i, 68] = 1;
                L[i, 69] = Control[i, 0];
                L[i, 70] = Control[i, 1];
                L[68, i] = 1;
                L[69, i] = Control[i, 0];
                L[70, i] = Control[i, 1];
            }
            for (int i = 68; i < 71; i++)
            {
                L[i, 68] = 0;
                L[i, 69] = 0;
                L[i, 70] = 0;
            }
            //Y矩阵初始化
            for (int i = 0; i < 68; i ++)
            {
                Y[i, 0] = Target[i, 0];
                Y[i, 1] = Target[i, 1];
            }
            for (int i = 68; i < 71; i ++)
            {
                Y[i, 0] = 0;
                Y[i, 1] = 0;
            }
            //对L进行LU分解
            double sum1;
            double sum2;
            int[] IP = new int[71];
            double[,] LC = new double[71, 71];
            int p;
            double temp;
            for (int i = 0;i < 71; i ++)
            {
                IP[i] = i;
                for (int j = 0;j < 71; j ++)
                {
                    LC[i, j] = L[i, j];
                }
            }
            for (int i = 0; i < 71; i ++)
            {
                p = i;
                for (int j = i; j < 71; j ++)
                {
                    if (Math.Abs(LC[j, i]) > Math.Abs(LC[p, i]))
                    {
                        p = j;
                    }
                }
                int ptemp = IP[i];
                IP[i] = IP[p];
                IP[p] = ptemp;
                for (int j = 0; j < 71; j ++)
                {
                    temp = LC[i, j];
                    LC[i, j] = LC[p, j];
                    LC[p, j] = temp;
                }
                
                for (int j = i + 1; j < 71; j ++)
                {
                    LC[j, i] /= LC[i, i];
                    for (int k = i + 1; k < 71; k ++)
                    {
                        LC[j, k] -= LC[j, i] * LC[i, k];
                    }
                }
            }
            //解出Ans
            for (int i = 0; i < 71; i ++)
            {
                Ans[i, 0] = Y[IP[i], 0];
                Ans[i, 1] = Y[IP[i], 1];
                for (int j = 0; j < i; j ++)
                {
                    Ans[i, 0] -= LC[i, j] * Ans[j, 0];
                    Ans[i, 1] -= LC[i, j] * Ans[j, 1];
                }
            }
            for (int i = 70; i >= 0; i --)
            {
                for (int j = 70; j > i; j --)
                {
                    Ans[i, 0] -= LC[i, j] * Ans[j, 0];
                    Ans[i, 1] -= LC[i, j] * Ans[j, 1];
                }
                Ans[i, 0] /= LC[i, i];
                Ans[i, 1] /= LC[i, i];
            }
            //对图片进行变形并做插值
            int[] pic_new = new int[3];
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    int y = image.Height - 1 - i;
                    sum1 = 0;
                    sum2 = 0;
                    for (int k = 0; k < 68; k++)
                    {
                        sum1 += Ans[k, 0] * U(Distance(Control[k, 0], Control[k, 1], j, i));
                        sum2 += Ans[k, 1] * U(Distance(Control[k, 0], Control[k, 1], j, i));
                    }
                    Fxy[j, i, 0] = Ans[68, 0] + Ans[69, 0] * j + Ans[70, 0] * i + sum1;
                    Fxy[j, i, 1] = Ans[68, 1] + Ans[69, 1] * j + Ans[70, 1] * i + sum2;
                    switch (type)
                    {
                        case 1:
                            Nearest(Fxy[j, i, 0], Fxy[j, i, 1], image, pic_new);
                            break;
                        case 2:
                            Bilinear(Fxy[j, i, 0], Fxy[j, i, 1], image, pic_new);
                            break;
                        default:
                            Nearest(Fxy[j, i, 0], Fxy[j, i, 1], image, pic_new);
                            break;
                    }
                    bitmap.SetPixel(j, i, Color.FromArgb(pic_new[0], pic_new[1], pic_new[2]));
                }
            }
            return bitmap;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            StreamReader f = new StreamReader(ControlKeyPointPath);
            image1 = Image.FromFile(ControlPath);
            string line;
            double[,] Control = new double[68, 2];
            int i = 0;
            while ((line = f.ReadLine()) != null)
            {
                string s1,s2;
                s1 = line.Split(' ')[0];
                s2 = line.Split(' ')[1];
                Control[i, 0] = Convert.ToDouble(s1);
                Control[i, 1] = Convert.ToDouble(s2);
                i++;
            }
            f = new StreamReader(TargetKeyPointPath);
            image2 = Image.FromFile(TargetPath);
            double[,] Target = new double[68, 2];
            i = 0;
            while ((line = f.ReadLine()) != null)
            {
                string s1, s2;
                s1 = line.Split(' ')[0];
                s2 = line.Split(' ')[1];
                Target[i, 0] = Convert.ToDouble(s1);
                Target[i, 1] = Convert.ToDouble(s2);
                i++;
            }
            try
            {
                this.pictureBox3.Image = (Image)TPS(Control, Target, TargetPath, ControlPath, image1.Height, image1.Width, 1);
            }
            catch (Exception error)
            {
                MessageBox.Show("请检查文件是否匹配！");
            }
        }

        private void Control_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.Title = "请选择图片";
            ofd.Filter = "JPG图像(*jpg)|*.jpg|PNG图像(*png)|*.png|BMP图像(*bmp)|*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ControlPath = ofd.FileName.ToString();
            }
            else
            {
                ControlPath = ControlPath;
            }
            if (ControlPath != String.Empty)
            {
                image1 = Image.FromFile(ControlPath);
                this.pictureBox1.Image = image1;
                this.ControlLabel.Text = "控制图图片" + ControlPath;
                CanTrans += 1;
                if (CanTrans == 4)
                {
                    this.button1.Enabled = true;
                }
            }
            ofd.Dispose();
        }

        private void Target_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.Title = "请选择图片";
            ofd.Filter = "JPG图像(*jpg)|*.jpg|PNG图像(*png)|*.png|BMP图像(*bmp)|*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                TargetPath = ofd.FileName.ToString();
            }
            else
            {
                TargetPath = TargetPath;
            }
            if (TargetPath != String.Empty)
            {
                image2 = Image.FromFile(TargetPath);
                this.pictureBox2.Image = image2;
                this.TargetLabel.Text = "目标图图片" + TargetPath;
                CanTrans += 1;
                if (CanTrans == 4)
                {
                    this.button1.Enabled = true;
                }
            }
            ofd.Dispose();
        }

        private void ControlKeypoint_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.Title = "请选择关键点文件";
            ofd.Filter = "txt文件(*txt)|*.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ControlKeyPointPath = ofd.FileName.ToString();
            }
            else
            {
                ControlKeyPointPath = ControlKeyPointPath;
            }
            if (ControlKeyPointPath != String.Empty)
            {
                this.ControlKeyPointLabel.Text = "目标图关键点文件" + ControlKeyPointPath;
                CanTrans += 1;
                if (CanTrans == 4)
                {
                    this.button1.Enabled = true;
                }
            }
            ofd.Dispose();
        }

        private void TargetKeypoint_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.Title = "请选择关键点文件";
            ofd.Filter = "txt文件(*txt)|*.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                TargetKeyPointPath = ofd.FileName.ToString();
            }
            else
            {
                TargetKeyPointPath = TargetKeyPointPath;
            }
            if (TargetKeyPointPath != String.Empty)
            {
                this.TargetKeyPointLabel.Text = "控制图关键点文件" + TargetKeyPointPath;
                CanTrans += 1;
                if (CanTrans == 4)
                {
                    this.button1.Enabled = true;
                }
            }
            ofd.Dispose();
        }

        private void NearestCheckbox_Click(object sender, EventArgs e)
        {
            this.BilinearCheckbox.Checked = false;
            if (NearestCheckbox.Checked == true)
            {
                ChaZhiType = 1;
            }
        }

        private void BilinearCheckbox_Click(object sender, EventArgs e)
        {
            this.NearestCheckbox.Checked = false;
            if (BilinearCheckbox.Checked == true)
            {
                ChaZhiType = 2;
            }
            else
            {
                ChaZhiType = 1;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            string SaveFilePath = String.Empty;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "JPG图像(*jpg)|*.jpg|PNG图像(*png)|*.png|BMP图像(*bmp)|*.bmp";
            sfd.FilterIndex = 1;
            sfd.RestoreDirectory = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                SaveFilePath = sfd.FileName.ToString();
                Bitmap bitmap = (Bitmap)this.pictureBox3.Image;
                bitmap.Save(SaveFilePath);
            }
        }
    }
}
