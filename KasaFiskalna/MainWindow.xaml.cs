using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KasaFiskalna
{
    public partial class MainWindow : Window
    {
        public List<float> bill = new List<float>();
        public float sum;
        public float cash;
        public float change;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Print()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(("Start.txt"), true))
                {
                    //writer.WriteLine("12.55");
                    //writer.WriteLine("12.51");
                    //writer.WriteLine("13.55");
                    //writer.WriteLine("12.11");
                    //writer.WriteLine("0.55");
                    //writer.WriteLine("2.55");
                    //writer.WriteLine("1.55");
                }

                using (StreamReader reader = new StreamReader("Start.txt"))
                {
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        bill.Add(float.Parse(line));
                        //BillTextBox.Text += line;
                        //BillTextBox.Text += Environment.NewLine;
                    }

                    foreach (float price in line)
                    {
                        sum += price;
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("No paper");
                Console.WriteLine(e.Message);
            }
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            Print();
            Screen.Text += "Suma: " + sum;
            Screen.Text += Environment.NewLine;
            Screen.Text += "Gotówka: " + cash;
            Screen.Text += Environment.NewLine;
            Screen.Text += "-----------";
            Screen.Text += Environment.NewLine;
            Screen.Text += "Reszta: " + change;

            //Screen.Text = "";
        }

        private void Screen_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CashButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
