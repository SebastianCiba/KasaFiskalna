using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
/*
 *Procedura:
 * 1. wczytanie listy cen z pliku skanera
 * 2. przycisk zatwierdź podlicza sumę do zapłącenia
 * 3a. przycisk "Gotówka" pozwala na wprowadzienie kwoty od klienta w celu wyliczenia reszty
 * 3b. jeśli nie zostanie naciśnięty przcisk "Gotówka" kasa uzna że klient dał wyliczoną kwotę
 * 4. przycisk "OK" drukuje paragon
 */

namespace KasaFiskalna
{
    public partial class MainWindow : Window
    {
        public List<float> bill = new List<float>();
        public float sum;
        public float cash;
        public float change;
        public string cashString;
        public bool cashIsClicked;

        

        public MainWindow()
        {
            BillTextBlock = new TextBlock();
            Screen = new TextBox();
            Print();
            InitializeComponent();
        }

        private void FButton_Click(object sender, RoutedEventArgs e)
        {
            //BillTextBlock.Text += "duba";
            //Screen.Text += "duba";

            //var culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            //culture.NumberFormat.NumberDecimalSeparator = ".";
            //float number = float.Parse("0.54", culture);
            //float n = 5;
            //Screen.Text += n;
            //Screen.Text += float.Parse("0,99");
            ////BillTextBlock.Text += float.Parse("0.99");
            //Screen.Text += float.Parse("99");
            ////BillTextBlock.Text += float.Parse("0.99");
            ////BillTextBlock.Text += float.Parse("0,99f");
            //Screen.Text += number;
            //BillTextBlock.Text += number;
            //BillTextBlock.Text += Environment.NewLine;



            //for (int i = 0; i < bill.Count; i++)
            //{
            //    BillTextBlock.Text += bill[i];
            //    BillTextBlock.Text += Environment.NewLine;
            //    sum += bill[i];
            //}

        }


        private void Print()
        {


            try
            {
                using (StreamReader reader = new StreamReader(@"Skaner/Start.txt"))
                {
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {

                        bill.Add(float.Parse(line));
                        BillTextBlock.Text += line;
                        BillTextBlock.Text += Environment.NewLine;
                    }
                }
            }
            catch (Exception e)
            {
                BillTextBlock.Text += "błąd odczytu";
                BillTextBlock.Text += Environment.NewLine;
            }

            foreach (float price in bill)
            {
                BillTextBlock.Text += price;
                BillTextBlock.Text += Environment.NewLine;
                sum += price;
            }
        }

        private void accept_Click(object sender, RoutedEventArgs e)
        {
            Screen.Text += "Suma: " + sum;
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            Screen.Text = "";
            if (cashIsClicked)
            {
                try
                {
                    cash = float.Parse(cashString);
                    change = cash - sum;
                }
                catch (Exception)
                {
                    BillTextBlock.Text += sum;
                }


                Screen.Text += "Suma: " + sum;
                Screen.Text += Environment.NewLine;
                Screen.Text += "Gotówka: " + cash;
                Screen.Text += Environment.NewLine;
                Screen.Text += "-----------";
                Screen.Text += Environment.NewLine;
                Screen.Text += "Reszta: " + change;
            }

            else
            {
                Screen.Text += "Suma: " + sum;
                Screen.Text += Environment.NewLine;
                Screen.Text += "Gotówka: " + sum;
                Screen.Text += Environment.NewLine;
                Screen.Text += "-----------";
                Screen.Text += Environment.NewLine;
                Screen.Text += "Reszta: 0.00";
            }

            cashIsClicked = false;

        }

        private void Screen_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void CashButton_Click(object sender, RoutedEventArgs e)
        {
            cashString = "";
            cashIsClicked = true;
        }

        private void number0Button_Click(object sender, RoutedEventArgs e)
        {
            if (cashIsClicked)
                cashString += "0";
        }

        private void number1Button_Click(object sender, RoutedEventArgs e)
        {
            if (cashIsClicked)
                cashString += "1";
        }

        private void number2Button_OnClick(object sender, RoutedEventArgs e)
        {
            if (cashIsClicked)
                cashString += "2";
        }

        private void number3Button_OnClick(object sender, RoutedEventArgs e)
        {
            if (cashIsClicked)
                cashString += "3";
        }

        private void number4Button_OnClick(object sender, RoutedEventArgs e)
        {
            if (cashIsClicked)
                cashString += "4";
        }

        private void number5Button_OnClick(object sender, RoutedEventArgs e)
        {
            if (cashIsClicked)
                cashString += "5";
        }

        private void number6Button_OnClick(object sender, RoutedEventArgs e)
        {
            if (cashIsClicked)
                cashString += "6";
        }

        private void number7Button_OnClick(object sender, RoutedEventArgs e)
        {
            if (cashIsClicked)
                cashString += "7";
        }

        private void number8Button_OnClick(object sender, RoutedEventArgs e)
        {
            if (cashIsClicked)
                cashString += "8";
        }

        private void number9Button_OnClick(object sender, RoutedEventArgs e)
        {
            if (cashIsClicked)
                cashString += "9";
        }

        private void dotButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (cashIsClicked)
                cashString += ".";
        }

        
    }
}
