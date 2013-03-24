using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Histogram
{
    class Histogram
    {
        int klasa=0;
        int maxInt;//maksymalna intensywność
        int minInt=256;//minimalna intensywność
        int zakres = 0;
        public Histogram()
        {
        }

//jest to metoda któą należy wywołać aby zrealizować operacje wyrównania histogramu na obrazie
        public Bitmap wyrownajHistogram(Bitmap ob, int kl)
        {
            Bitmap wynik = new Bitmap(ob.Width, ob.Height);
            try
            {
                klasa = kl;
                maximum(ob); //obliczamy minimum i maximum intensywność w obrazie
                minimum(ob);

                zakres = maxInt - minInt+1;
                
                //inicjalizacja potrzebnych tablic oraz ich wypełnienie za pomocą odpowiednich metod
                int[,] histogram = stworzHistogram(ob);

                double[,] dyst = dystrybuanta(histogram, ob);

                int[,] LUT = LookUpTable(dyst);

                //pobieranie pikseli oraz ich modyfikcja za pomocą tablicy LUT
                for (int i = 0; i < ob.Width; i++)
                {
                    for (int j = 0; j < ob.Height; j++)
                    {

                        Color kol = ob.GetPixel(i, j);
                        int czerw = kol.R;
                        int ziel = kol.G;
                        int nieb = kol.B;
                        int czerwWyr=0;
                        int zielwWyr=0;
                        int niebWyr=0;

                        if (czerw <= maxInt && czerw >= minInt)
                        {
                            czerwWyr = LUT[czerw - minInt, 0] * (maxInt + 1) / klasa;
                        }
                        if (ziel <= maxInt && ziel >= minInt)
                        {
                            zielwWyr = LUT[ziel - minInt, 1] * (maxInt + 1) / klasa;
                        }
                        if (nieb <= maxInt && nieb >= minInt)
                        {
                            niebWyr = LUT[nieb - minInt, 2] * (maxInt + 1) / klasa;
                        }
                        Color nc = Color.FromArgb(kol.A, czerwWyr, zielwWyr, niebWyr);
                        wynik.SetPixel(i, j, nc);

                    }
                }
                return wynik; //zwracany jest obraz z wyrównanym histogramem
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return wynik;
            }
        }

//metoda tworząca histagram obrazu
        public int[,] stworzHistogram(Bitmap ob)
        {
            int[,] hist = new int[zakres, 3]; //inicjalizacja tablicy z histogramem
            try
            {
                int[, ,] tab = new int[ob.Height, ob.Width, 3];//inicjalizacja i wypełnienie 
                tab = czytajPixele(ob);                        //tablicy trójwymiarowej zawierającej wartości pikseli obrazka na każdym kanale koloru

                int value;

                for (int k = 0; k < 3; k++)
                {
                    for (int i = 0; i < ob.Height; i++)
                    {
                        for (int j = 0; j < ob.Width; j++)
                        {
                            value = tab[i, j, k];

                            if (value <= maxInt && value >= minInt)
                            {
                                hist[value-minInt, k]++; //tworzenie histogramu poprzez zliczanie warości pikseli na każdym kanale
                            }
                        }
                    }
                }
                return hist; //zwracana jest tablica dwuwymiarowa zawierająca histogram obrazu na każdym kanale
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return hist;
            }

        }

//metoda pobierająca piksele z obrazu i wstawiająca ich wartości do trójwymiarowej tablicy
        public int[, ,] czytajPixele(Bitmap ob)
        {
            int[, ,] tab = new int[ob.Height, ob.Width, 3];
            try
            {
                for (int i = 0; i < ob.Width; i++)
                {
                    for (int j = 0; j < ob.Height; j++)
                    {
                        Color cPixel = ob.GetPixel(i, j);
                        tab[i, j, 0] = cPixel.R;
                        tab[i, j, 1] = cPixel.G;
                        tab[i, j, 2] = cPixel.B;
                    }
                }
                return tab;//zwracana jest tablica z wartościami pikseli na każdym kanale obrazu 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return tab;
            }
        }

//metoda licząca dystrybuantę histogramu potrzebną do stworzenia tablicy LUT
        public double[,] dystrybuanta(int[,] hist, Bitmap ob)
        {
            double[,] dist = new double[zakres, 3];
            try
            {
                int iloscPX = ob.Width * ob.Height;
                
                for (int j = 0; j < 3; j++)
                {
                    double temp = 0;
                    for (int i = 0; i < zakres; i++)
                    {
                        temp += hist[i, j];
                        dist[i, j] = temp/iloscPX;
                    }
                }

                return dist; //zwracana jest tablica dystrybuant z każdego poziomu koloru
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return dist;
            }
        }

//metoda tworząca tablicę LUT na podstawie dystrybuanty histogramu
        public int[,] LookUpTable(double[,] dist)
        {
            int[,] LUT = new int[zakres, 3];
            try
            {

                double[] distNiezero = new double[3];

                for (int i = 0; i < zakres; i++)
                {
                    if (dist[i, 0] > 0)
                    {
                        distNiezero[0] = dist[i, 0];
                        break;
                    }
                }
                for (int i = 0; i < zakres; i++)
                {
                    if (dist[i, 1] > 0)
                    {
                        distNiezero[1] = dist[i, 1];
                        break;
                    }
                }
                for (int i = 0; i < zakres; i++)
                {
                    if (dist[i, 2] > 0)
                    {
                        distNiezero[2] = dist[i, 2];
                        break;
                    }
                }

                for (int j = 0; j < 3; j++)
                {
                    for (int i = 0; i < zakres; i++)
                    {
                        LUT[i, j] = (int)(((dist[i, j] - distNiezero[j]) / (1 - distNiezero[j])) * (klasa-1));
                    }
                }

                return LUT;//zwracana jest dwuwymiarowa tablica LUT z wartościami odpowiednimi dla każdego kanału RGB
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return LUT;
            }
        }
//metoda licząca maksymalną intensywność w obrazie
        public void maximum(Bitmap ob)
        {
            try
            {
                for (int i = 0; i < ob.Height; i++)
                {
                    for (int j = 0; j < ob.Width; j++)
                    {
                        Color kol = ob.GetPixel(i, j);
                        int czerw = kol.R;
                        int ziel = kol.G;
                        int nieb = kol.B;

                        if (czerw > maxInt)
                        {
                            maxInt = czerw;
                        }
                        else if (ziel > maxInt)
                        {
                            maxInt = ziel;
                        }
                        else if (nieb > maxInt)
                        {
                            maxInt = nieb;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

//metoda licząca minimalną intensywność w obrazie
        public void minimum(Bitmap ob)
        {
            try
            {
                for (int i = 0; i < ob.Height; i++)
                {
                    for (int j = 0; j < ob.Width; j++)
                    {
                        Color kol = ob.GetPixel(i, j);
                        int czerw = kol.R;
                        int ziel = kol.G;
                        int nieb = kol.B;

                        if (czerw < minInt)
                        {
                            minInt = czerw;
                        }
                        else if (ziel < minInt)
                        {
                            minInt = ziel;
                        }
                        else if (nieb < minInt)
                        {
                            minInt = nieb;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
