using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net.Http.Headers;
using System.Text;
using System.Windows;
using System.Windows.Controls;

/*
 *Procedura:
 * 1. rozpoczęcie handlu z lientem przyciskiem "Start"
 * 2. przyciskiem "*skanuje produkt*" zostają dodane do rachunku produkty
 * (niestety wczytywanie z pliku nie zadziałało i są dodane statycznie 4 produkty)
 * 3. przycisk zatwierdź podlicza sumę do zapłącenia
 * 4a. przycisk "Gotówka" pozwala na wprowadzienie kwoty od klienta w celu wyliczenia reszty
 * 4b. jeśli nie zostanie naciśnięty przcisk "Gotówka" kasa uzna że klient dał wyliczoną kwotę
 * 5. przycisk "OK" drukuje paragon
 */

namespace KasaFiskalna
{
    public partial class MainWindow : Window
    {
        private List<float> BillList = new List<float>();

        private float sum;
        private float cash;
        private float change;
        private string cashString;
        private bool cashIsClicked;
        private DateTime localDate;
        private float sumOfCash;
        private bool inProgress;

        public class Product
        {
            public int number;
            public string name;
            public float price;


            public Product() {}

            public Product(int number, string name, float price)
            {
                this.number = number;
                this.name = name;
                this.price = price;
            }
        }

        public List<Product> listOfPruducts = new List<Product>();

        public List<Product> ListOfPruducts
        {
            get => listOfPruducts;
            set => listOfPruducts = value;
        }

        public MainWindow()
        {
            ListOfPruducts.Add(new Product(0, "Keczup", 3.89f));
            ListOfPruducts.Add(new Product(0, "Masło", 5.23f));
            ListOfPruducts.Add(new Product(0, "Chleb", 1.99f));
            ListOfPruducts.Add(new Product(0, "Mleko", 2.20f));
            BillTextBlock = new TextBlock();
            Scan();
            InitializeComponent();
        }


        private void Start_Click(object sender, RoutedEventArgs e)
        {
            inProgress = true;
            BillList.Clear();
            //header
            BillTextBlock.Text = "";
            BillTextBlock.Text += "Sklep Branżowy";
            BillTextBlock.Text += Environment.NewLine;
            BillTextBlock.Text += "20-234 Lublin ul. Bursztynowa 2";
            BillTextBlock.Text += Environment.NewLine;
            BillTextBlock.Text += localDate = DateTime.Now;
            BillTextBlock.Text += Environment.NewLine;
            BillTextBlock.Text += "PARAGON FISKALNY";
            BillTextBlock.Text += Environment.NewLine;
        }

        private void Scan()
        {

            //BillTextBlock.Text += "błąd odczytu0";
            //try
            //{
            //    BillTextBlock.Text += "błąd odczytu1";
            //    using (StreamReader reader = new StreamReader(@"TenisStolowy.csv"))
            //    {
            //        BillTextBlock.Text += "błąd odczytu2";
            //        if (File.Exists(@"TenisStolowy.csv"))
            //        {
            //            BillTextBlock.Text += "błąd odczytu4";
            //            var lines = File.ReadAllLines(@"TenisStolowy.csv", Encoding.UTF8);
            //            BillTextBlock.Text += "błąd odczytu5";
            //            float tempPrice;
            //            int i = 0;
            //            while ((lines[i] = reader.ReadLine()) != null)
            //            {
            //                var actualLine = lines[i].Split(';');
            //                var culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            //                culture.NumberFormat.NumberDecimalSeparator = ".";
            //                tempPrice = float.Parse(actualLine[2], culture);

            //                listOfPruducts.Add(new Product (int.Parse(actualLine[0]), actualLine[1], tempPrice));
            //                BillTextBlock.Text += "błąd odczytu6";
            //                i++;
            //            }
            //        }
            //    }
            //}
            //catch (Exception)
            //{
            //    BillTextBlock.Text += "błąd odczytu7";
            //}

            
        }

        private void Skan_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            int i = rnd.Next(0, 3);
            BillTextBlock.Text += String.Format( "{0}    {1}", listOfPruducts[i].name, listOfPruducts[i].price);
            BillList.Add(listOfPruducts[i].price);
            BillTextBlock.Text += Environment.NewLine;
        }

        private void accept_Click(object sender, RoutedEventArgs e)
        {
            for (var i = 0; i < BillList.Count; i++)
            {
                var price = BillList[i];
                BillList[i] += price;
                sum += price;
            }

            Screen.Text += "Suma: " + sum;
            Screen.Text += Environment.NewLine;
            sumOfCash += sum;
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
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

                Screen.Text += "Gotówka: " + cash;
                Screen.Text += Environment.NewLine;
                Screen.Text += "-----------";
                Screen.Text += Environment.NewLine;
                Screen.Text += "Reszta: " + change;
            }

            else
            {
                Screen.Text += "Gotówka: " + sum;
                Screen.Text += Environment.NewLine;
                Screen.Text += "-----------";
                Screen.Text += Environment.NewLine;
                Screen.Text += "Reszta: 0.00";
            }

            cashIsClicked = false;
            PrintBill();
            inProgress = false;
        }

        private void PrintBill()
        { 
            BillTextBlock.Text += "Suma PLN: " + sum;
            BillTextBlock.Text += Environment.NewLine;
            BillTextBlock.Text += "Kasa 3 Kasjer nr 0";
            BillTextBlock.Text += Environment.NewLine;
            BillTextBlock.Text += "Dziękujemy i zapraszamy ponownie";
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

        private void SumButton_Click(object sender, RoutedEventArgs e)
        {
            if (inProgress != true)
            {
                BillTextBlock.Text = "Suma pieniędzy w kasetce";
                BillTextBlock.Text += Environment.NewLine;
                BillTextBlock.Text += sumOfCash;
            }
        }

        private void FButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
