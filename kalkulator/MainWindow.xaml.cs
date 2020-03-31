using System;
using System.Collections.Generic;
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

namespace kalkulator
{
    public partial class MainWindow : Window
    {
        private int kropka = 0;
        private float nr1 = 0;
        private float nr2 = 0;
        private string znak="";
        private int rowna = 0;
        private float wynik = 0;
        System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
       
        public MainWindow()
        {
            customCulture.NumberFormat.NumberDecimalSeparator = ".";

            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;

            InitializeComponent();
            
        }
        private void buttonLiczba_Click(object sender, RoutedEventArgs  e)
        {
            if (rowna==1)
            {
                labelOut.Content = "0";
                rowna = 0;
            }
            var button = (Button)sender;
            var tmp = button.Content.ToString();
            if (labelOut.Content.ToString() == "0")
            {
                labelOut.Content = tmp;
            }

            else
                labelOut.Content += tmp;
            if (znak=="")
                nr1 = float.Parse(labelOut.Content.ToString());
            else
                nr2 = float.Parse(labelOut.Content.ToString());

        }

        private void buttonOperator_Click (object sender, RoutedEventArgs e)
        {
            if (rowna==1)
            {
                nr1 = wynik;
            }
            var button = (Button)sender;
            var tmp = button.Content.ToString();
            znak = tmp;
            labelOut.Content = "0";
            kropka = 0;
        }

        private void buttonEquals_Click(object sender, RoutedEventArgs e)
        {
            rowna = 1;
            if (znak == "+")
            {
                wynik = (nr1 + nr2);
                labelOut.Content = wynik.ToString();
            }
            else if (znak == "-")
            {
                wynik = (nr1 - nr2);
                labelOut.Content = wynik.ToString();
            }
            else if (znak == "x")
            {
                wynik = (nr1 * nr2);
                labelOut.Content = wynik.ToString();
            }
            else if (znak == "/")
                if (nr2 != 0)
                {
                    wynik = (nr1 / nr2);
                    labelOut.Content = wynik.ToString();
                }
                else
                    labelOut.Content = "Error";
            nr1 = 0;
            nr2 = 0;
            znak = "";
            
        }

        private void ButtonDot_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var tmp = button.Content.ToString();
            if (kropka == 0)
            {
                labelOut.Content += tmp;
                kropka++;
            }
            
        }

        

        private void ButtonCE_Click(object sender, RoutedEventArgs e)
        {
            if (znak == "")
            {
                nr1 = 0;
            }
            else
                nr2 = 0;
            labelOut.Content = "0";
            kropka = 0;
        }

        private void ButtonC_Click(object sender, RoutedEventArgs e)
        {
            labelOut.Content = "0";
            nr1 = 0;
            nr2 = 0;
            znak = "";
            kropka = 0;
        }

        private void ButtonUjemne_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var str = labelOut.Content.ToString();

                var temp = float.Parse(labelOut.Content.ToString());
                if (znak == "")
                    nr1 = nr1 * (-1);
                else
                    nr2 = nr2 * (-1);
                labelOut.Content = temp * (-1);
            }
            catch
            {
                labelOut.Content = "-";
            }
        }
    }
}
