using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;
using Emgu.CV;
using Emgu.CV.Cvb;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace TPRV
{
    public partial class Form1 : Form
    {
        private string FilePath;
        int scale = 1;
        int delta = 0;
        private DepthType ddepth = DepthType.Cv16S;

        float[,] filtreSharpen = {
                {-1, -1, -1},
                { -1, 9, -1 },
                {-1, -1, -1 }

            };
        float[,] filtreEmboss = {
                {-1, -1, -1, -1,  0},
                {-1, -1, -1,  0,  1},
                {-1, -1,  0,  1,  1 },
                {-1,  0,  1,  1,  1 },
                {0,  1,  1,  1,  1 }
            };
        float[,] filtreCustom = {
            {12, 8, -12},
            {-16, -4, 19},
            { 16, -6,  -14}
        };

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Mat img = CvInvoke.Imread(FilePath, ImreadModes.AnyColor);
            Mat ImgDest = new Mat();
            string ImgDestString = textBox1.Text;
            Point point = new Point(0, 0);
            Size size = new Size(10, 10);
            if (!img.IsEmpty)
            {
                CvInvoke.Blur(img, ImgDest, size, point);
                if (ImgDestString != "")
                {
                    CvInvoke.Imwrite(ImgDestString, ImgDest);
                    pictureBox2.ImageLocation = textBox1.Text;
                }
                else
                {
                    CvInvoke.Imwrite("NoName.jpg", ImgDest);
                    pictureBox2.ImageLocation = "NoName.jpg";
                }
                CvInvoke.WaitKey(0);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.png) | *.jpg; *.jpeg; *.jpe; *.png";
            if (DialogResult.OK == openFileDialog1.ShowDialog())
            {
                FilePath = openFileDialog1.FileName;
                pictureBox1.ImageLocation = FilePath;
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Mat img = CvInvoke.Imread(FilePath, ImreadModes.AnyColor);
            Mat ImgDest = new Mat();
            string ImgDestString = textBox1.Text;
            Point point = new Point(0, 0);
            Size size = new Size(9, 9);
            if (!img.IsEmpty)
            {
                CvInvoke.Sobel(img, ImgDest, ddepth, 0, 1, 3, scale, delta, BorderType.Default);
                if (ImgDestString != "")
                {
                    CvInvoke.Imwrite(ImgDestString, ImgDest);
                    pictureBox2.ImageLocation = textBox1.Text;
                }
                else
                {
                    CvInvoke.Imwrite("NoName.jpg", ImgDest);
                    pictureBox2.ImageLocation = "NoName.jpg";
                }
                CvInvoke.WaitKey(0);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Mat img = CvInvoke.Imread(FilePath, ImreadModes.AnyColor);
            Mat ImgDest = new Mat();
            string ImgDestString = textBox1.Text;
            Point point = new Point(0, 0);
            Size size = new Size(9, 9);
            if (!img.IsEmpty)
            {
                CvInvoke.Sobel(img, ImgDest, ddepth, 1, 0, 3, scale, delta, BorderType.Default);

                if (ImgDestString != "")
                {
                    CvInvoke.Imwrite(ImgDestString, ImgDest);
                    pictureBox2.ImageLocation = textBox1.Text;
                }
                else
                {
                    CvInvoke.Imwrite("NoName.jpg", ImgDest);
                    pictureBox2.ImageLocation = "NoName.jpg";
                }
                CvInvoke.WaitKey(0);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Mat img = CvInvoke.Imread(FilePath, ImreadModes.AnyColor);
            Mat ImgDest = new Mat();
            string ImgDestString = textBox1.Text;
            Point point = new Point(0, 0);
            Size size = new Size(9, 9);
            if (!img.IsEmpty)
            {
                ConvolutionKernelF kernel = new ConvolutionKernelF(filtreSharpen);
                ImgDest = img;
                CvInvoke.Filter2D(img, ImgDest, kernel, point);


                if (ImgDestString != "")
                {
                    CvInvoke.Imwrite(ImgDestString, ImgDest);
                    pictureBox2.ImageLocation = textBox1.Text;
                }
                else
                {
                    CvInvoke.Imwrite("NoName.jpg", ImgDest);
                    pictureBox2.ImageLocation = "NoName.jpg";
                }
                CvInvoke.WaitKey(0);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Mat img = CvInvoke.Imread(FilePath, ImreadModes.AnyColor);
            Mat ImgDest = new Mat();
            string ImgDestString = textBox1.Text;
            Point point = new Point(0, 0);
            Size size = new Size(9, 9);
            if (!img.IsEmpty)
            {
                ConvolutionKernelF kernel = new ConvolutionKernelF(filtreEmboss);
                ImgDest = img;
                CvInvoke.Filter2D(img, ImgDest, kernel, point);


                if (ImgDestString != "")
                {
                    CvInvoke.Imwrite(ImgDestString, ImgDest);
                    pictureBox2.ImageLocation = textBox1.Text;
                }
                else
                {
                    CvInvoke.Imwrite("NoName.jpg", ImgDest);
                    pictureBox2.ImageLocation = "NoName.jpg";
                }

                CvInvoke.WaitKey(0);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Mat img = CvInvoke.Imread(FilePath, ImreadModes.AnyColor);
            Mat ImgDest = new Mat();
            string ImgDestString = textBox1.Text;
            Point point = new Point(0, 0);
            Size size = new Size(9, 9);
            if (!img.IsEmpty)
            {
                ConvolutionKernelF kernel = new ConvolutionKernelF(filtreCustom);
                ImgDest = img;
                CvInvoke.Filter2D(img, ImgDest, kernel, point);

                if (ImgDestString != "")
                {
                    CvInvoke.Imwrite(ImgDestString, ImgDest);
                    pictureBox2.ImageLocation = textBox1.Text;
                }
                else
                {
                    CvInvoke.Imwrite("NoName.jpg", ImgDest);
                    pictureBox2.ImageLocation = "NoName.jpg";
                }

                CvInvoke.WaitKey(0);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            float[,] filtreHomemade = {
                {(float) numericUpDown1.Value, (float) numericUpDown2.Value, (float) numericUpDown3.Value},
                {(float) numericUpDown6.Value, (float) numericUpDown5.Value, (float) numericUpDown4.Value},
                {(float) numericUpDown9.Value, (float) numericUpDown8.Value, (float) numericUpDown7.Value}
            };
            Mat img = CvInvoke.Imread(FilePath, ImreadModes.AnyColor);
            Mat ImgDest = new Mat();
            string ImgDestString = textBox1.Text;
            Point point = new Point(0, 0);
            Size size = new Size(9, 9);
            if (!img.IsEmpty)
            {
                ConvolutionKernelF kernel = new ConvolutionKernelF(filtreHomemade);
                ImgDest = img;
                CvInvoke.Filter2D(img, ImgDest, kernel, point);

                if (ImgDestString != "")
                {
                    CvInvoke.Imwrite(ImgDestString, ImgDest);
                    pictureBox2.ImageLocation = textBox1.Text;
                }
                else
                {
                    CvInvoke.Imwrite("NoName.jpg", ImgDest);
                    pictureBox2.ImageLocation = "NoName.jpg";
                }

                CvInvoke.WaitKey(0);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            float Nombre1 = rnd.Next(-20, 20);
            float Nombre2 = rnd.Next(-20, 20);
            float Nombre3 = rnd.Next(-20, 20);
            float Nombre4 = rnd.Next(-20, 20);
            float Nombre5 = rnd.Next(-20, 20);
            float Nombre6 = rnd.Next(-20, 20);
            float Nombre7 = rnd.Next(-20, 20);
            float Nombre8 = rnd.Next(-20, 20);
            float Nombre9 = rnd.Next(-20, 20);
            numericUpDown1.Value = (decimal)Nombre1;
            numericUpDown2.Value = (decimal)Nombre2;
            numericUpDown3.Value = (decimal)Nombre3;
            numericUpDown4.Value = (decimal)Nombre6;
            numericUpDown5.Value = (decimal)Nombre5;
            numericUpDown6.Value = (decimal)Nombre4;
            numericUpDown7.Value = (decimal)Nombre9;
            numericUpDown8.Value = (decimal)Nombre8;
            numericUpDown9.Value = (decimal)Nombre7;

            float[,] filtreRandom = {
                {Nombre1, Nombre2, Nombre3},
                {Nombre4, Nombre5, Nombre6},
                {Nombre7, Nombre8, Nombre9}
            };
            Mat img = CvInvoke.Imread(FilePath, ImreadModes.AnyColor);
            Mat ImgDest = new Mat();
            string ImgDestString = textBox1.Text;
            Point point = new Point(0, 0);
            Size size = new Size(9, 9);
            if (!img.IsEmpty)
            {
                ConvolutionKernelF kernel = new ConvolutionKernelF(filtreRandom);
                ImgDest = img;
                CvInvoke.Filter2D(img, ImgDest, kernel, point);

                if (ImgDestString != "")
                {
                    CvInvoke.Imwrite(ImgDestString, ImgDest);
                    pictureBox2.ImageLocation = textBox1.Text;
                }
                else
                {
                    CvInvoke.Imwrite("NoName.jpg", ImgDest);
                    pictureBox2.ImageLocation = "NoName.jpg";
                }

                CvInvoke.WaitKey(0);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Mat mat = CvInvoke.Imread(pictureBox2.ImageLocation, ImreadModes.AnyColor);
            CvInvoke.Imshow("Picture", mat);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Mat img = CvInvoke.Imread(FilePath, ImreadModes.AnyColor);
            Mat ImgDest = new Mat();
            string ImgDestString = textBox1.Text;
            if (!img.IsEmpty)
            {
                Image<Bgr, byte> imgInput = new Image<Bgr, byte>(FilePath);
                Image<Gray, byte> imgOutput = imgInput.Convert<Gray, byte>().ThresholdBinary(new Gray(140), new Gray(255));
                VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
                Mat hier = new Mat();
                
                Image<Gray, byte> imgout = new Image<Gray, byte>(imgInput.Width, imgInput.Height, new Gray(0));

                CvInvoke.FindContours(imgOutput, contours, hier, RetrType.External, ChainApproxMethod.ChainApproxSimple);
                CvInvoke.DrawContours(imgout, contours, -1, new MCvScalar(255, 0, 0));
                double Perimetre = 0;
                double Aire = 0;
                for (int i = 0; i < contours.Size; i++)
                {
                    Perimetre = CvInvoke.ArcLength(contours[i], true);
                    Aire = CvInvoke.ContourArea(contours[i]);
                }

                MCvMoments lesMoments = imgout.GetMoments(true);

                Point gravityCenter = new Point((int)(lesMoments.M10 / lesMoments.M00), (int)(lesMoments.M01 / lesMoments.M00));

                pictureBox2.Image = imgout.Bitmap;

                string Forme;
                if (contours[0].Size == 3)
                {
                    Forme = "triangle";
                }
                else if (contours[0].Size == 4)
                {
                    Forme = "carre";
                }
                else 
                {
                    Forme = "cercle";
                }

                if (Forme != "triangle")
                {
                    MessageBox.Show("Le périmètre est de " + Perimetre + "\n" +
                                    "L'aire est de " + Aire + "\n" +
                                    "Le centre est a (" + gravityCenter.X + "," + gravityCenter.Y + ")" + "\n" +
                                    "La forme est un " + Forme);
                }
                else
                {
                    MessageBox.Show("Le périmètre est de " + Perimetre + "\n" +
                                    "L'aire est de " + Aire + "\n" +
                                    "La forme est un " + Forme);
                }

                if (ImgDestString != "")
                {
                    CvInvoke.Imwrite(ImgDestString, imgout);
                    pictureBox2.ImageLocation = textBox1.Text;
                }
                else
                {
                    CvInvoke.Imwrite("NoName.jpg", imgout);
                    pictureBox2.ImageLocation = "NoName.jpg";
                }
                CvInvoke.WaitKey(0);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string DossierImage = @"C:\Users\201563814\Desktop\ImageTp2\"; //Votre dossier d'image
            string list = "";
            for (int i = 0; i < 40; i++)
            {
                Mat img = CvInvoke.Imread(DossierImage + i + ".jpg", ImreadModes.AnyColor);
                string ImgDestString = textBox1.Text;
                if (!img.IsEmpty)
                {
                    Image<Bgr, byte> imgInput = new Image<Bgr, byte>(DossierImage + i + ".jpg");
                    Image<Gray, byte> imgOutput = imgInput.Convert<Gray, byte>().ThresholdBinary(new Gray(140), new Gray(255));
                    VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
                    Mat hier = new Mat();

                    Image<Gray, byte> imgout = new Image<Gray, byte>(imgInput.Width, imgInput.Height, new Gray(0));

                    CvInvoke.FindContours(imgOutput, contours, hier, RetrType.External, ChainApproxMethod.ChainApproxSimple);
                    CvInvoke.DrawContours(imgout, contours, -1, new MCvScalar(255, 0, 0));
                    double Perimetre = 0;
                    double Aire = 0;
                    for (int j = 0; j < contours.Size; j++)
                    {
                        Perimetre = CvInvoke.ArcLength(contours[j], true);
                        Aire = CvInvoke.ContourArea(contours[j]);
                    }

                    MCvMoments lesMoments = imgout.GetMoments(true);

                    Point gravityCenter = new Point((int)(lesMoments.M10 / lesMoments.M00), (int)(lesMoments.M01 / lesMoments.M00));

                    pictureBox2.Image = imgout.Bitmap;

                    string Forme;
                    if (contours[0].Size == 3)
                    {
                        Forme = "triangle";
                    }
                    else if (contours[0].Size == 4)
                    {
                        Forme = "carre";
                    }
                    else
                    {
                        Forme = "cercle";
                    }

                    if (Forme != "triangle")
                    {
                        list += "La forme #" + i + ": " + "\r\n" +
                                        "Le périmètre est de " + Perimetre + "\r\n" +
                                        "L'aire est de " + Aire + "\r\n" +
                                        "Le centre est a (" + gravityCenter.X + "," + gravityCenter.Y + ")" + "\r\n" +
                                        "La forme est un " + Forme + "\r\n" + "\r\n";
                    }
                    else
                    {
                        list += "La forme #" + i + ": " + "\r\n" +
                                "Le périmètre est de " + Perimetre + "\r\n" +
                                "L'aire est de " + Aire + "\r\n" +
                                "La forme est un " + Forme + "\r\n" + "\r\n";
                    }

                    if (ImgDestString != "")
                    {
                        CvInvoke.Imwrite(ImgDestString, imgout);
                        pictureBox2.ImageLocation = textBox1.Text;
                    }
                    else
                    {
                        CvInvoke.Imwrite("NoName.jpg", imgout);
                        pictureBox2.ImageLocation = "NoName.jpg";
                    }
                    CvInvoke.WaitKey(0);
                }
            }
            System.IO.File.WriteAllText(DossierImage + "Resultat.txt", list);
            MessageBox.Show("Veuillez vous assurez d'avoir changé DossierImage dans button10_Click pour le nom de votre dossier."+ "\n" + "Resultat écrit dans " +DossierImage +"Resultat.txt\"");

        }
    }
}
