﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Histogram
{
    public partial class Form1 : Form
    {
        string NazwaObr;
        Bitmap obraz;

        public Form1()
        {
            InitializeComponent();
        }

//wczytanie obrazu z pliku do PictureBox
        void wczytajObraz()
        {
            try
            {
                openFileDialog1.Filter = "Pliki obrazu|*.jpg; *.jpeg; *.png; *.gif; *.bmp";
                DialogResult result = openFileDialog1.ShowDialog();

                if (result == DialogResult.OK)
                {
                    NazwaObr = openFileDialog1.FileName.ToString();
                    if (NazwaObr != null)
                    {
                        obraz = new Bitmap(NazwaObr);
                        obraz = new Bitmap(obraz, 256, 256);
                        ObrazWejscie.Image = obraz;
                    }
                }
                //NazwaObr=openFileDialog1.FileName;
                obrazToolStripMenuItem.Enabled = true;
                ObrazWyjscie.Image = new Bitmap(1, 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            BGamma.Visible = false;
            nUDGamma.Visible = false;
            lGamma.Visible = false;
            zapisz.Visible = false;
            
        }

//stworznie z obrazu wejściowego skali szarości
        public static Bitmap SkalaSzarosci(Bitmap original) 
        {
            //konwertuje obecny obraz do skali szarosci
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);

            for (int i = 0; i < original.Width; i++)
            {
                for (int j = 0; j < original.Height; j++)
                {
                    Color originalColor = original.GetPixel(i, j);

                    int grayScale = (int)((originalColor.R * .3) + (originalColor.G * .59)
                        + (originalColor.B * .11));

                    Color Kolor = Color.FromArgb(grayScale, grayScale, grayScale);

                    newBitmap.SetPixel(i, j, Kolor);
                }
            }

            return newBitmap;
        }

//wywołanie metod z klasy Histogram do operacji na globalnym obrazie
        public void histogramGlobalny(Bitmap ob, int klasa)
        {
            Histogram hist = new Histogram();
            ObrazWyjscie.Image = hist.wyrownajHistogram(ob,klasa);
            
        }

//metoda wykonująca korekcję gamma na obrazie wejściowym
        public void korekcjaGamma(Bitmap ob)
        {
            Bitmap wyjscie = new Bitmap(ob.Width,ob.Height);
            int[,] LUT = new int[256, 3];
            double y=(double)nUDGamma.Value;//pobranie współczynnika gamma z komponentu numericUpDown

            for (int i = 0; i < ob.Width; i++)
            {
                for (int j = 0; j < ob.Height; j++)
                {
                    Color kol = ob.GetPixel(i, j);
                    double czerw = kol.R;
                    double ziel = kol.G;
                    double nieb = kol.B;

                    czerw = czerw / 255;
                    ziel = ziel / 255;
                    nieb = nieb / 255;
                    
                    czerw = (Math.Pow(czerw,(y)))*255;
                    ziel = (Math.Pow(ziel, (y))) * 255;
                    nieb = (Math.Pow(nieb, (y))) * 255; 

                    int czerwWyr = (int) czerw;
                    int zielwWyr = (int) ziel;
                    int niebWyr = (int) nieb;

                    Color nc = Color.FromArgb(kol.A, czerwWyr, zielwWyr, niebWyr);
                    wyjscie.SetPixel(i, j, nc);
                }
            }
            ObrazWyjscie.Image=wyjscie;
        }

        //*************************obsluga menu******************************//
        private void otwórzObrazToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wczytajObraz();
        }

        private void skalaSzarościToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap obrazSzary = SkalaSzarosci(obraz);
                ObrazWejscie.Image = obrazSzary;
                ObrazWyjscie.Image = new Bitmap(1, 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            zapisz.Visible = false;
            BGamma.Visible = false;
            nUDGamma.Visible = false;
            lGamma.Visible = false;
        }

        private void wyjścieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void globalnyToolStripMenuItem_Click(object sender, EventArgs e)
        {
             try
             {
                 histogramGlobalny((Bitmap)ObrazWejscie.Image, 256);
                 //ObrazWyjscie.Image = WyrownajHistogram((Bitmap)ObrazWejscie.Image);
                 zapisz.Visible = true;
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.ToString());
             }
             BGamma.Visible = false;
             nUDGamma.Visible = false;
             lGamma.Visible = false;
        }

        private void x16ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap ob = new Bitmap(ObrazWejscie.Image.Width, ObrazWejscie.Image.Height);
            ob = (Bitmap)ObrazWejscie.Image;
            Bitmap[,] tab = new Bitmap[16, 16];
            Histogram hist = new Histogram();
            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    Rectangle rect = new Rectangle(i * 16, j * 16, 16, 16);
                    Bitmap cropped = ob.Clone(rect, ob.PixelFormat);
                    tab[i, j] = hist.wyrownajHistogram(cropped, 256);
                }
            }

            Bitmap nowy = new Bitmap(ObrazWejscie.Image.Width, ObrazWejscie.Image.Height);
            Color Kolor;

            int x, y;

            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    for (int ii = 0; ii < 16; ii++)
                    {
                        for (int jj = 0; jj < 16; jj++)
                        {
                            Kolor = tab[i, j].GetPixel(ii, jj);
                            x = i * 16 + ii;
                            y = j * 16 + jj;
                            nowy.SetPixel(x, y, Kolor);
                        }
                    }
                }
            }
            ObrazWyjscie.Image = nowy;
            zapisz.Visible = true;
            BGamma.Visible = false;
            nUDGamma.Visible = false;
            lGamma.Visible = false;
        }

        private void x32ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap ob = new Bitmap(ObrazWejscie.Image.Width, ObrazWejscie.Image.Height);
            ob = (Bitmap)ObrazWejscie.Image;
            Bitmap[,] tab = new Bitmap[8,8];
            Histogram hist = new Histogram();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Rectangle rect = new Rectangle(i*32, j*32, 32, 32);
                    Bitmap cropped = ob.Clone(rect, ob.PixelFormat);
                    tab[i, j] = hist.wyrownajHistogram(cropped, 256);
                }
            }

            Bitmap nowy = new Bitmap(ObrazWejscie.Image.Width, ObrazWejscie.Image.Height);
            Color Kolor;

            int x, y;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    for (int ii = 0; ii < 32; ii++)
                    {
                        for (int jj = 0; jj < 32; jj++)
                        {
                            Kolor = tab[i, j].GetPixel(ii, jj);
                            x = i * 32 + ii;
                            y = j * 32 + jj;
                            nowy.SetPixel(x, y, Kolor);
                        }
                    }
                }
            }
            ObrazWyjscie.Image = nowy;
            zapisz.Visible = true;
            BGamma.Visible = false;
            nUDGamma.Visible = false;
            lGamma.Visible = false;
        }

        private void BGamma_Click(object sender, EventArgs e)
        {
            korekcjaGamma((Bitmap)ObrazWejscie.Image);
            zapisz.Visible = true;

        }

        private void korekcjaGammaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lGamma.Visible = true;
            nUDGamma.Visible = true;
            BGamma.Visible = true;
            ObrazWyjscie.Image = new Bitmap(1, 1);
            zapisz.Visible = false;
        }

        private void zapisz_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "Save an Image File";
            saveFileDialog1.Filter = "JPeg Image|*.jpg";
            saveFileDialog1.ShowDialog();
            System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile();

            ObrazWyjscie.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
    }
}
