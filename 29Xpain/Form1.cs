﻿using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _29Xpain
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }


        void sortowanie(int n, int[] tab)
        {
            int pom, j;
            for (int i = 1; i < n; i++)
            {
                pom = tab[i];
                j = i - 1;

                while (j >= 0 && tab[j] > pom)
                {
                    tab[j + 1] = tab[j]; //przesuwanie elementów
                    --j;
                }
                tab[j + 1] = pom; //wstawienie pom w odpowiednie miejsce
            }
        }


        void sortowane_bobelkowe(int[] tab)
        {
            int b = tab.Length;
            do
            {
                for (int i = 0; i < b - 1; i++)
                {
                    if (tab[i] > tab[i + 1])
                    {
                        int tmp = tab[i];
                        tab[i] = tab[i + 1];
                        tab[i + 1] = tmp;
                    }
                }
                b--;
            }
            while (b > 1);
        }


        void szybkie_sortowanie(int[] tab, int lewy, int prawy)
        {
            if (prawy <= lewy) return;

            int i = lewy -1, j = prawy +1 ,
            pivot = tab[(lewy + prawy) / 2];

            while (true)
            {
                while (pivot > tab[i++]) ;
                while (pivot < tab[j-=1]) ;
                if (i <= j)
                {
                    int it = i;
                    tab[i] = tab[j];
                    tab[j] = tab[it];
                }
                else
                    break;
            }

            if (j > lewy)
                szybkie_sortowanie(tab, lewy, j);
            if (i < prawy)
                szybkie_sortowanie(tab, i, prawy);
        }

        public void sortowanie_kopcowe(int[] tab)
        {
            int n = tab.Length;
            for (int i = n / 2 - 1; i >= 0; i--)
                kopcowanie(tab, n, i);

            for (int i = n - 1; i > 0; i--)
            {
               
                int temp = tab[0];
                tab[0] = tab[i];
                tab[i] = temp;

          
                kopcowanie(tab, i, 0);
            }
        }
        void kopcowanie(int[] arr, int n, int i)
        {
            int largest = i; 
            int l = 2 * i + 1; 
            int r = 2 * i + 2; 

          
            if (l < n && arr[l] > arr[largest])
                largest = l;

         
            if (r < n && arr[r] > arr[largest])
                largest = r;

          
            if (largest != i)
            {
                int swap = arr[i];
                arr[i] = arr[largest];
                arr[largest] = swap;

               
                kopcowanie(arr, n, largest);
            }
        }





        private void srtwbtn_Click(object sender, EventArgs e)
          {
              //wczytanie pliku
              string fileContent = File.ReadAllText("somefile.txt");
              string[] integerStrings = fileContent.Split(new char[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
              int[] integers = new int[integerStrings.Length];
              
              for (int n = 0; n < integerStrings.Length; n++)
              {
                  integers[n] = int.Parse(integerStrings[n]);
              }
                int indx = integers.Length;
            // 
            // Sortowanie przez wstawianie
            Lwstaw.Text = "";
              sortowanie(indx, integers);
              for (int i = 0; i < indx; i++)
              {
                  Lwstaw.Text += integers[i] + "\n";
              }
          }

          private void srtbbtn_Click(object sender, EventArgs e)
          {
              //wczytanie pliku
              string fileContent = File.ReadAllText("somefile.txt");
              string[] integerStrings = fileContent.Split(new char[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
              int[] integers = new int[integerStrings.Length];
             
              for (int n = 0; n < integerStrings.Length; n++)
              {
                  integers[n] = int.Parse(integerStrings[n]);
                  
              }
            int indx = integers.Length;
            // 
            // Sortowanie bąbelkowe
            Lbabel.Text = "";
              sortowane_bobelkowe(integers);
              for (int i = 0; i < indx; i++)
              {
                  Lbabel.Text += integers[i] + "\n";
              }
          }

        private void srtsbtn_Click(object sender, EventArgs e)
        {
            //wczytanie pliku
            string fileContent = File.ReadAllText("somefile.txt");
            string[] integerStrings = fileContent.Split(new char[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            int[] integers = new int[integerStrings.Length];
            for (int n = 0; n < integerStrings.Length; n++)
            {
                integers[n] = int.Parse(integerStrings[n]);
            }
            int indx = integers.Length;
            // 
            // Szybkie sortowanie
            Lszybkie.Text = "";
            szybkie_sortowanie(integers, 0, indx-1);
            for (int i = 0; i < indx; i++)
            {
                Lszybkie.Text += integers[i] + "\n";
            }



        }

        private void Lbabel_Click(object sender, EventArgs e)
        {

        }

        private void srthbtn_Click(object sender, EventArgs e)
        {
            //wczytanie pliku
            string fileContent = File.ReadAllText("somefile.txt");
            string[] integerStrings = fileContent.Split(new char[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            int[] integers = new int[integerStrings.Length];
            for (int n = 0; n < integerStrings.Length; n++)
            {
                integers[n] = int.Parse(integerStrings[n]);
            }
            int indx = integers.Length;
            //
           Lkopcowanie.Text = "";
           sortowanie_kopcowe(integers);
            for (int i = 0; i < indx; i++)
            {
                Lkopcowanie.Text += integers[i] + "\n";
            }
        }
    }
}

