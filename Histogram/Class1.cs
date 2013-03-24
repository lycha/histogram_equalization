using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace histogramEqualization
{
    class ImageHandler
    {
        private Bitmap _currentBitmap;

        public int[] hist = new int[256];
        public int max;
        public int maxIntensity = 0;
        
        int[] LUT;
        int klasy = 256;

        public ImageHandler()
        {
        }

        public Bitmap CurrentBitmap
        {
            get
            {
                if (_currentBitmap == null)
                    _currentBitmap = new Bitmap(1, 1);
                return _currentBitmap;
            }
            set
            {
                _currentBitmap = value;
            }
        }

        public void ClearImage()
        {
            _currentBitmap = new Bitmap(1, 1);
        }
        public void argb2grey()
        {

            for (int i = 0; i < CurrentBitmap.Width; i++)
            {
                for (int j = 0; j < CurrentBitmap.Height; j++)
                {
                    Color oc = CurrentBitmap.GetPixel(i, j);
                    int grayScale = (int)((oc.R * 0.3) + (oc.G * 0.59) + (oc.B * 0.11));
                    Color nc = Color.FromArgb(oc.A, grayScale, grayScale, grayScale);
                    CurrentBitmap.SetPixel(i, j, nc);
                }
            }
        }

        public void histogram()
        {
            max = 0;
            Color cPixel;
            int value;

            for (int i = 0; i < CurrentBitmap.Height; i++)
            {
                for (int j = 0; j < CurrentBitmap.Width; j++)
                {
                    try
                    {
                        cPixel = CurrentBitmap.GetPixel(j, i);
                        value = (cPixel.B + cPixel.G + cPixel.R) / 3;
                        hist[value]++;
                    }
                    catch (ArgumentOutOfRangeException e)
                    {
                        throw (e);
                    }
                }
            }

            for (int i = 0; i < 256; i++)
            {
                if (hist[i] > max)
                {
                    max = hist[i];
                }
            }
        }

        public double[] empDist()
        {
            double[] dist = new double[maxIntensity + 1];
            double temp = 0;
            int pxAmount = CurrentBitmap.Width * CurrentBitmap.Height;

            for (int i = 0; i < maxIntensity; i++)
            {
                temp += ((double)hist[i] / (double)pxAmount);
                dist[i] = temp;
            }

            return dist;
        }
        
        public int[] LookUpTable(double[] dist)
        {
            double dystrybuantaNiezerowa = 0;
            LUT = new int[maxIntensity+1];

            for (int i = 0; i < (maxIntensity + 1); i++)
            {
                if (dist[i] > 0)
                {
                    dystrybuantaNiezerowa = dist[i];
                    break;
                }
            }

            for (int i = 0; i < (maxIntensity + 1); i++) 
            { 
                LUT[i]=(int)((dist[i]-dystrybuantaNiezerowa)/(1-dystrybuantaNiezerowa)*(double)(klasy-1)); 
            }

            return LUT;
        }

        public void maximum()
        {
            for (int i = 0; i < CurrentBitmap.Height; i++)
                for (int j = 0; j < CurrentBitmap.Width; j++)
                {
                    Color oc = CurrentBitmap.GetPixel(j, i);
                    int input = (int)((oc.R * 0.3) + (oc.G * 0.59) + (oc.B * 0.11)); ;
                    if (input > maxIntensity)
                    {
                        maxIntensity = input;
                    }
                }
        }

        public void histeq()
        {
            double[] dystrybuanta = empDist(); 
            LUT = LookUpTable(dystrybuanta);
      
            
            for (int i = 0; i < CurrentBitmap.Width; i++)
                for (int j = 0; j < CurrentBitmap.Height; j++)
                {
             
                        Color oc = CurrentBitmap.GetPixel(i, j);
                        int input = (int)((oc.R * 0.3) + (oc.G * 0.59) + (oc.B * 0.11));
                        int equalized = LUT[input * ((maxIntensity + 1) / klasy)];
                        Color nc = Color.FromArgb(oc.A, equalized, equalized, equalized);
                        CurrentBitmap.SetPixel(i, j, nc);
                  
                }
        }
    }
}