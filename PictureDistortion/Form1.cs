using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;

namespace PictureDistortion
{
    public partial class Form1 : Form
    {
        string SaveFilePath = String.Empty;
        public Form1()
        {
            InitializeComponent();
            this.Type.SelectedIndex = 0;
        }
        private static void RotationDistortion(int x_new, int y_new, double[] xy_old, double a_max, double r)
        {
            double a;
            a = a_max * ((r - Math.Sqrt((x_new - 255.5) * (x_new - 255.5) + (y_new - 255.5) * (y_new - 255.5))) / r);
            double x = x_new - 255.5;
            double y = y_new - 255.5;
            xy_old[0] = x * Math.Cos(a) + y * Math.Sin(a) + 255.5;
            xy_old[1] = -x * Math.Sin(a) + y * Math.Cos(a) + 255.5;
        }
        private static void ConvexDistortion(int x_new, int y_new, double[] xy_old, double r)
        {
            double d;
            d = Math.Sqrt((x_new - 255.5) * (x_new - 255.5) + (y_new - 255.5) * (y_new - 255.5));
            double x, y;
            x = x_new - 255.5;
            y = y_new - 255.5;
            xy_old[0] = x * (((3 * r) / (Math.PI * d)) * Math.Asin(d / r)) + 255.5;
            xy_old[1] = y * (((3 * r) / (Math.PI * d)) * Math.Asin(d / r)) + 255.5;
        }
        private static void ConcavoDistortion(int x_new, int y_new, double[] xy_old, double r)
        {
            double d;
            d = Math.Sqrt((x_new - 255.5) * (x_new - 255.5) + (y_new - 255.5) * (y_new - 255.5));
            double x, y;
            x = x_new - 255.5;
            y = y_new - 255.5;
            xy_old[0] = x / (((3 * r) / (Math.PI * d)) * Math.Asin(d / r)) + 255.5;
            xy_old[1] = y / (((3 * r) / (Math.PI * d)) * Math.Asin(d / r)) + 255.5;

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
            if (x_new < 0)
            {
                pic_new[0] = 0;
                pic_new[1] = 0;
                pic_new[2] = 0;
                return;
            }
            else if (x_new > 511)
            {
                pic_new[0] = 0;
                pic_new[1] = 0;
                pic_new[2] = 0;
                return;
            }

            if (y_new < 0)
            {
                pic_new[0] = 0;
                pic_new[1] = 0;
                pic_new[2] = 0;
                return;
            }
            else if (y_new > 511)
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
        static void Bilinear(double x, double y, Image image, int[] pic_new)
        {
            Bitmap bitmap = image as Bitmap;
            int i, j;
            double u, v;
            i = (int)Math.Floor(x);
            j = (int)Math.Floor(y);
            u = x - i;
            v = y - j;
            if (i == 511 || j == 511)
            {
                i = Math.Min(i, 510);
                j = Math.Min(j, 510);
            }
            else if (i > 511 || j > 511)
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
            pic_new[0] = (byte)(((1 - u) * bitmap.GetPixel(i, j).R + u * bitmap.GetPixel(i + 1, j).R) * (1 - v) + ((1 - u) * bitmap.GetPixel(i, j + 1).R + u * bitmap.GetPixel(i + 1, j + 1).R) * v);
            pic_new[1] = (byte)(((1 - u) * bitmap.GetPixel(i, j).G + u * bitmap.GetPixel(i + 1, j).G) * (1 - v) + ((1 - u) * bitmap.GetPixel(i, j + 1).G + u * bitmap.GetPixel(i + 1, j + 1).G) * v);
            pic_new[2] = (byte)(((1 - u) * bitmap.GetPixel(i, j).B + u * bitmap.GetPixel(i + 1, j).B) * (1 - v) + ((1 - u) * bitmap.GetPixel(i, j + 1).B + u * bitmap.GetPixel(i + 1, j + 1).B) * v);
        }
        static double S(double x)
        {
            x = Math.Abs(x);
            if (x <= 1)
            {
                return 1 - 2 * x * x + x * x * x;
            }
            else if (x <= 2)
            {
                return 4 - 8 * x + 5 * x * x - x * x * x;
            }
            else
            {
                return 0;
            }
        }
        static void Bicubic(double x, double y, Image image, int[] pic_new)
        {
            Bitmap bitmap = image as Bitmap;
            int i, j;
            double u, v;
            i = (int)Math.Floor(x);
            j = (int)Math.Floor(y);
            u = x - i;
            v = y - j;
            double[] A = new double[4];
            double[] C = new double[4];
            int[,,] B = new int[4, 4, 3];
            double[,] A_1 = new double[4, 3];
            A[0] = S(u + 1);
            A[1] = S(u);
            A[2] = S(u - 1);
            A[3] = S(u - 2);
            C[0] = S(v + 1);
            C[1] = S(v);
            C[2] = S(v - 1);
            C[3] = S(v - 2);
            if (i > 511 || j > 511)
            {
                pic_new[0] = 0;
                pic_new[1] = 0;
                pic_new[2] = 0;
                return;
            }
            else if (i > 509 || j > 509)
            {
                i = Math.Min(509, i);
                j = Math.Min(509, j);
            }

            if (i < 0 || j < 0)
            {
                pic_new[0] = 0;
                pic_new[1] = 0;
                pic_new[2] = 0;
                return;
            }
            else if (i == 0 || j == 0)
            {
                i = Math.Max(1, i);
                j = Math.Max(1, j);
            }
            for (int iter1 = 0; iter1 < 4; iter1++)
            {
                for (int iter2 = 0; iter2 < 4; iter2++)
                {
                    B[iter1, iter2, 0] = (int)bitmap.GetPixel(iter1 + i - 1, iter2 + j - 1).R;
                    B[iter1, iter2, 1] = (int)bitmap.GetPixel(iter1 + i - 1, iter2 + j - 1).G;
                    B[iter1, iter2, 2] = (int)bitmap.GetPixel(iter1 + i - 1, iter2 + j - 1).B;
                }
            }

            for (int iter1 = 0; iter1 < 4; iter1++)
            {
                A_1[iter1, 0] = A[0] * B[0, iter1, 0] + A[1] * B[1, iter1, 0] + A[2] * B[2, iter1, 0] + A[3] * B[3, iter1, 0];
                A_1[iter1, 1] = A[0] * B[0, iter1, 1] + A[1] * B[1, iter1, 1] + A[2] * B[2, iter1, 1] + A[3] * B[3, iter1, 1];
                A_1[iter1, 2] = A[0] * B[0, iter1, 2] + A[1] * B[1, iter1, 2] + A[2] * B[2, iter1, 2] + A[3] * B[3, iter1, 2];
            }

            pic_new[0] = (int)(A_1[0, 0] * C[0] + A_1[1, 0] * C[1] + A_1[2, 0] * C[2] + A_1[3, 0] * C[3]);
            pic_new[1] = (int)(A_1[0, 1] * C[0] + A_1[1, 1] * C[1] + A_1[2, 1] * C[2] + A_1[3, 1] * C[3]);
            pic_new[2] = (int)(A_1[0, 2] * C[0] + A_1[1, 2] * C[1] + A_1[2, 2] * C[2] + A_1[3, 2] * C[3]);
            pic_new[0] = (int)Math.Min(255, (double)pic_new[0]);
            pic_new[0] = (int)Math.Max(0, (double)pic_new[0]);
            pic_new[1] = (int)Math.Min(255, (double)pic_new[1]);
            pic_new[1] = (int)Math.Max(0, (double)pic_new[1]);
            pic_new[2] = (int)Math.Min(255, (double)pic_new[2]);
            pic_new[2] = (int)Math.Max(0, (double)pic_new[2]);
        }
        static Bitmap RotationDistortion_Mission(string InputPath, double angle, int type)
        {
            Image image = (Bitmap)Image.FromFile(InputPath);
            Image image1 = (Bitmap)Image.FromFile(InputPath);
            Bitmap bitmap = image1 as Bitmap;
            double[] xy_new = new double[2];
            int[] pic_new = new int[3];

            for (int i = 0; i < 512; i++)
            {
                for (int j = 0; j < 512; j++)
                {
                    if (Math.Sqrt((i - 255.5) * (i - 255.5) + (j - 255.5) * (j - 255.5)) > 255.5)
                    {
                        continue;
                    }
                    RotationDistortion(i, j, xy_new, angle, 255.5);
                    switch (type)
                    {
                        case 1:
                            Nearest(xy_new[0], xy_new[1], image, pic_new);
                            break;
                        case 2:
                            Bilinear(xy_new[0], xy_new[1], image, pic_new);
                            break;
                        case 3:
                            Bicubic(xy_new[0], xy_new[1], image, pic_new);
                            break;
                        default:
                            return bitmap;
                    }
                    bitmap.SetPixel(i, j, Color.FromArgb(pic_new[0], pic_new[1], pic_new[2]));
                }
            }
            return bitmap;
        }
        static Bitmap ConvexDistortion_Mission(string InputPath, double r, int type)
        {
            Image image = (Bitmap)Image.FromFile(InputPath);
            Image image1 = (Bitmap)Image.FromFile(InputPath);
            Bitmap bitmap = image1 as Bitmap;
            double[] xy_new = new double[2];
            int[] pic_new = new int[3];
            for (int i = 0; i < 512; i++)
            {
                for (int j = 0; j < 512; j++)
                {
                    ConvexDistortion(i, j, xy_new, r);
                    switch (type)
                    {
                        case 1:
                            Nearest(xy_new[0], xy_new[1], image, pic_new);
                            break;
                        case 2:
                            Bilinear(xy_new[0], xy_new[1], image, pic_new);
                            break;
                        case 3:
                            Bicubic(xy_new[0], xy_new[1], image, pic_new);
                            break;
                        default:
                            return bitmap;
                    }
                    bitmap.SetPixel(i, j, Color.FromArgb(pic_new[0], pic_new[1], pic_new[2]));
                }
            }
            return bitmap;
        }
        static Bitmap ConcavoDistortion_Mission(string InputPath, double r, int type)
        {
            Image image = (Bitmap)Image.FromFile(InputPath);
            Image image1 = (Bitmap)Image.FromFile(InputPath);
            Bitmap bitmap = image1 as Bitmap;
            double[] xy_new = new double[2];
            int[] pic_new = new int[3];
            for (int i = 0; i < 512; i++)
            {
                for (int j = 0; j < 512; j++)
                {
                    ConcavoDistortion(i, j, xy_new, r);
                    switch (type)
                    {
                        case 1:
                            Nearest(xy_new[0], xy_new[1], image, pic_new);
                            break;
                        case 2:
                            Bilinear(xy_new[0], xy_new[1], image, pic_new);
                            break;
                        case 3:
                            Bicubic(xy_new[0], xy_new[1], image, pic_new);
                            break;
                        default:
                            return bitmap;
                    }
                    bitmap.SetPixel(i, j, Color.FromArgb(pic_new[0], pic_new[1], pic_new[2]));
                }
            }
            return bitmap;
        }
        private void NewImage_Click(object sender, EventArgs e)
        {
            if (this.Rotation.Checked)
            {
                if (this.Nearest1.Checked)
                {
                    this.pictureBox1.Image = (Image)RotationDistortion_Mission("THU.jpg", 0.314 * (this.Angle.Value - 5), 1);
                }
                else if (this.Bilinear1.Checked)
                {
                    this.pictureBox1.Image = (Image)RotationDistortion_Mission("THU.jpg", 0.314 * (this.Angle.Value - 5), 2);
                }
                else if (this.Bicubic1.Checked)
                {
                    this.pictureBox1.Image = (Image)RotationDistortion_Mission("THU.jpg", 0.314 * (this.Angle.Value - 5), 3);
                }
                else
                {
                    MessageBox.Show("请选择插值方式！");
                }
            }
            else if (this.ConcavoConvex.Checked)
            {
                if (this.Type.SelectedIndex == 0)
                {
                    if (this.Nearest2.Checked)
                    {
                        this.pictureBox1.Image = (Image)ConvexDistortion_Mission("THU.jpg", this.Radius.Value * 15 + 362, 1);
                    }
                    else if (this.Bilinear2.Checked)
                    {
                        this.pictureBox1.Image = (Image)ConvexDistortion_Mission("THU.jpg", this.Radius.Value * 15 + 362, 2);
                    }
                    else if (this.Bicubic2.Checked)
                    {
                        this.pictureBox1.Image = (Image)ConvexDistortion_Mission("THU.jpg", this.Radius.Value * 15 + 362, 3);
                    }
                    else
                    {
                        MessageBox.Show("请选择插值方式！");
                    }
                }
                else
                {
                    if (this.Nearest2.Checked)
                    {
                        this.pictureBox1.Image = (Image)ConcavoDistortion_Mission("THU.jpg", this.Radius.Value * 15 + 362, 1);
                    }
                    else if (this.Bilinear2.Checked)
                    {
                        this.pictureBox1.Image = (Image)ConcavoDistortion_Mission("THU.jpg", this.Radius.Value * 15 + 362, 2);
                    }
                    else if (this.Bicubic2.Checked)
                    {
                        this.pictureBox1.Image = (Image)ConcavoDistortion_Mission("THU.jpg", this.Radius.Value * 15 + 362, 3);
                    }
                    else
                    {
                        MessageBox.Show("请选择插值方式！");
                    }
                }
            }
            else
            {
                MessageBox.Show("请选择要进行的变换！");
            }
        }

        private void OriginImage_Click(object sender, EventArgs e)
        {
            this.pictureBox1.Image = (Bitmap)Image.FromFile("THU.jpg");
        }

        private void Rotation_Click(object sender, EventArgs e)
        {
            if (this.Rotation.Checked)
            {
                this.pictureBox1.Image = (Bitmap)Image.FromFile("THU.jpg");
                this.ConcavoConvex.Checked = false;
                this.RotationGroup.Enabled = true;
                this.ConvexConcavoGroup.Enabled = false;
            }
            else
            {
                this.pictureBox1.Image = (Bitmap)Image.FromFile("THU.jpg");
                this.ConcavoConvex.Checked = false;
                this.RotationGroup.Enabled = false;
                this.ConvexConcavoGroup.Enabled = false;
            }
        }

        private void ConcavoConvex_Click(object sender, EventArgs e)
        {
            if (this.ConcavoConvex.Checked)
            {
                this.pictureBox1.Image = (Bitmap)Image.FromFile("THU.jpg");
                this.Rotation.Checked = false;
                this.ConvexConcavoGroup.Enabled = true;
                this.RotationGroup.Enabled = false;
            }
            else
            {
                this.pictureBox1.Image = (Bitmap)Image.FromFile("THU.jpg");
                this.Rotation.Checked = false;
                this.ConvexConcavoGroup.Enabled = false;
                this.RotationGroup.Enabled = false;
            }
        }

        private void RotationGroup_EnabledChanged(object sender, EventArgs e)
        {
            this.Nearest1.Checked = false;
            this.Bilinear1.Checked = false;
            this.Bicubic1.Checked = false;
            this.AngleLabel.Text = "扭曲角度：0";
            this.Angle.Value = 5;
        }

        private void ConvexConcavoGroup_EnabledChanged(object sender, EventArgs e)
        {
            this.Nearest2.Checked = false;
            this.Bilinear2.Checked = false;
            this.Bicubic2.Checked = false;
            this.Type.SelectedIndex = 0;
            this.RadiusLabel.Text = "球体半径：362";
            this.Radius.Value = 0;
        }

        private void Nearest1_Click(object sender, EventArgs e)
        {
            if (this.Nearest1.Checked)
            {
                this.Bilinear1.Checked = false;
                this.Bicubic1.Checked = false;
            }
        }

        private void Bilinear1_Click(object sender, EventArgs e)
        {
            if (this.Bilinear1.Checked)
            {
                this.Nearest1.Checked = false;
                this.Bicubic1.Checked = false;
            }
        }

        private void Bicubic1_Click(object sender, EventArgs e)
        {
            if (this.Bicubic1.Checked)
            {
                this.Nearest1.Checked = false;
                this.Bilinear1.Checked = false;
            }
        }

        private void Nearest2_Click(object sender, EventArgs e)
        {
            if (this.Nearest2.Checked)
            {
                this.Bilinear2.Checked = false;
                this.Bicubic2.Checked = false;
            }
        }

        private void Bilinear2_Click(object sender, EventArgs e)
        {
            if (this.Bilinear2.Checked)
            {
                this.Nearest2.Checked = false;
                this.Bicubic2.Checked = false;
            }
        }

        private void Bicubic2_Click(object sender, EventArgs e)
        {
            if (this.Bicubic2.Checked)
            {
                this.Nearest2.Checked = false;
                this.Bilinear2.Checked = false;
            }
        }

        private void Angle_Scroll(object sender, EventArgs e)
        {
            double angle = 0.314 * (this.Angle.Value - 5);
            this.AngleLabel.Text = "扭曲角度：" + angle.ToString();
        }

        private void Radius_Scroll(object sender, EventArgs e)
        {
            double r = 362 + this.Radius.Value * 15;
            this.RadiusLabel.Text = "球体半径：" + r.ToString();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "JPG图像(*jpg)|*.jpg|PNG图像(*png)|*.png|BMP图像(*bmp)|*.bmp";
            sfd.FilterIndex = 1;
            sfd.RestoreDirectory = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                SaveFilePath = sfd.FileName.ToString();
                string extension = SaveFilePath.Substring(SaveFilePath.LastIndexOf("\\") + 1);
                Bitmap bitmap = (Bitmap)this.pictureBox1.Image;
                bitmap.Save(SaveFilePath);
            }
        }
    }
}
