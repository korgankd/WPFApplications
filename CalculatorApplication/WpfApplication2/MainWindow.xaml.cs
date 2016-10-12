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

namespace WpfApplication2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void one_Click(object sender, RoutedEventArgs e)
        {
            if (newNumber())
                display.Text = display.Text + " 1";
            else
                display.Text = display.Text + "1";
        }

        private void two_Click(object sender, RoutedEventArgs e)
        {
            if (newNumber())
                display.Text = display.Text + " 2";
            else
                display.Text = display.Text + "2";
        }

        private void three_Click(object sender, RoutedEventArgs e)
        {
            if (newNumber())
                display.Text = display.Text + " 3";
            else
                display.Text = display.Text + "3";
        }

        private void four_Click(object sender, RoutedEventArgs e)
        {
            if (newNumber())
                display.Text = display.Text + " 4";
            else
                display.Text = display.Text + "4";
        }

        private void five_Click(object sender, RoutedEventArgs e)
        {
            if (newNumber())
                display.Text = display.Text + " 5";
            else
                display.Text = display.Text + "5";
        }

        private void six_Click(object sender, RoutedEventArgs e)
        {
            if (newNumber())
                display.Text = display.Text + " 6";
            else
                display.Text = display.Text + "6";
        }

        private void seven_Click(object sender, RoutedEventArgs e)
        {
            if (newNumber())
                display.Text = display.Text + " 7";
            else
                display.Text = display.Text + "7";
        }

        private void eight_Click(object sender, RoutedEventArgs e)
        {
            if (newNumber())
                display.Text = display.Text + " 8";
            else
                display.Text = display.Text + "8";
        }

        private void nine_Click(object sender, RoutedEventArgs e)
        {
            if (newNumber())
                display.Text = display.Text + " 9";
            else
                display.Text = display.Text + "9";
        }

        private void decimal_Click(object sender, RoutedEventArgs e)
        {
            if (newNumber())
                display.Text = display.Text + " 0.";
            else if(!containsDecimal())
                display.Text = display.Text + ".";
        }

        private void zero_Click(object sender, RoutedEventArgs e)
        {
            if (newNumber())
                display.Text = display.Text + " 0";
            else
                display.Text = display.Text + "0";
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            display.Text = "=";
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            if (display.Text.EndsWith("="))
            {

            }
            else if (newNumber())
            {
                display.Text = display.Text.Substring(0, display.Text.Length - 2);
                display.Text = display.Text + " +";
            }
            else
                display.Text = display.Text + " +";
        }

        private void subtract_Click(object sender, RoutedEventArgs e)
        {
            if (display.Text.EndsWith("="))
            {

            }
            else if (newNumber())
            {
                display.Text = display.Text.Substring(0, display.Text.Length - 2);
                display.Text = display.Text + " -";
            }
            else
                display.Text = display.Text + " -";
        }

        private void multiply_Click(object sender, RoutedEventArgs e)
        {
            if (display.Text.EndsWith("="))
            {

            }
            else if (newNumber())
            {
                display.Text = display.Text.Substring(0, display.Text.Length - 2);
                display.Text = display.Text + " x";
            }
            else
                display.Text = display.Text + " x";
        }

        private void divide_Click(object sender, RoutedEventArgs e)
        {
            if (display.Text.EndsWith("="))
            {

            }
            else if (newNumber())
            {
                display.Text = display.Text.Substring(0, display.Text.Length - 2);
                display.Text = display.Text + " /";
            }
            else
                display.Text = display.Text + " /";
        }

        private void equals_Click(object sender, RoutedEventArgs e)
        {
            display.Text = "= " + evaluate(display.Text);
        }

        private double evaluate(string equation)
        {
            double equals = 0.0;
            if (equation.Length < 2)
                return equals;
            equation = equation.Substring(2); //remove beginning ' = '
            string[] args = equation.Split(' ');
            
            //evaluate an equation as 'number operator number' only
            switch (args[1])
            {
                case "x":
                    equals = Convert.ToDouble(args[0]) * Convert.ToDouble(args[2]);
                    break;
                case "/":
                    equals = Convert.ToDouble(args[0]) / Convert.ToDouble(args[2]);
                    break;
                case "+":
                    equals = Convert.ToDouble(args[0]) + Convert.ToDouble(args[2]);
                    break;
                case "-":
                    equals = Convert.ToDouble(args[0]) - Convert.ToDouble(args[2]);
                    break;
            }
            return equals;
        }

        //beginning a new number input or continue typing one
        private Boolean newNumber()
        {
            if (display.Text.EndsWith("x")|| display.Text.EndsWith("/")|| display.Text.EndsWith("+")|| display.Text.EndsWith("-") || display.Text.EndsWith("="))
            {
                return true;
            }
            else
                return false;
        }

        //number has decimal in it already
        private Boolean containsDecimal()
        {
            string[] args = display.Text.Split(' ');
            string lastNumber = args.Last();
            if (lastNumber.Contains('.'))
                return true;
            else
                return false;
        }
    }
}
