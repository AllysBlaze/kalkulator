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

        private float nr1 = 0;
        private float nr2 = 0;
        private string znak="";
        System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
       
        public MainWindow()
        {
            customCulture.NumberFormat.NumberDecimalSeparator = ".";

            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;

            InitializeComponent();
            
        }
        private void buttonLiczba_Click(object sender, RoutedEventArgs  e)
        {
            var button = (Button)sender;
            var tmp = button.Content.ToString();
            labelOut.Content += tmp;
            if (znak=="")
                nr1 = float.Parse(labelOut.Content.ToString());
            else
                nr2 = float.Parse(labelOut.Content.ToString());



        }

        private void buttonOperator_Click (object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var tmp = button.Content.ToString();
            znak = tmp;
            labelOut.Content = "";
        }

        private void buttonEquals_Click(object sender, RoutedEventArgs e)
        {
            float temp=0;
            if (znak == "+")
            {
                temp = (nr1 + nr2);
                labelOut.Content = temp.ToString();
            }
            else if (znak == "-")
            {
                temp = (nr1 - nr2);
                labelOut.Content = temp.ToString();
            }
            else if (znak == "x")
            {
                temp = (nr1 * nr2);
                labelOut.Content = temp.ToString();
            }
            else if (znak == "/")
                if (nr2 != 0)
                {
                    temp = (nr1 / nr2);
                    labelOut.Content = temp.ToString();
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
            labelOut.Content += tmp;
        }

        

        private void ButtonCE_Click(object sender, RoutedEventArgs e)
        {
            if (znak == "")
            {
                nr1 = 0;
            }
            else
                nr2 = 0;
            labelOut.Content = "";

        }

        private void ButtonC_Click(object sender, RoutedEventArgs e)
        {
            labelOut.Content = "";
            nr1 = 0;
            nr2 = 0;
            znak = "";
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
