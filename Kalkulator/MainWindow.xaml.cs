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

namespace Kalkulator
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public enum Operations
        {

        }
        private double result =0;
        private double a;
        private double b;
        private string c;
        private double i =0;
        private string choose;
        private string operations;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string liczba = button.Content.ToString();
           // this.Screen.Text += liczba;
            if (liczba == ",")
            {
                if (Screen.Text.Contains(","))
                {
                    this.Screen.Text = Screen.Text;
                }
                else
                {
                    this.Screen.Text += liczba;
                }
            }
            else
            {
                this.Screen.Text += liczba;
            }


        }
        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            if (this.Screen.Text == "")
            {
                return;
            }
            if (this.Screen.Text.Length <= 1)
            {
                this.Screen.Text = "";
            }
            else
            {
                this.Screen.Text = this.Screen.Text.Remove(this.Screen.Text.Length - 1);
            }

        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            this.Screen.Text = "";
            this.BackScreen.Text = "";
            result = 0;
        }
        private void Operation_Click(object sender, RoutedEventArgs e)
        {
            Button operation = sender as Button;
            choose = operation.Content.ToString();
            switch (choose)
            {
                
                case "+":
                    operations = "add";
                    if (i == 0)
                    {
                        if (BackScreen.Text != "")
                        {
                            if (BackScreen.Text.EndsWith("+"))
                            {
                                this.BackScreen.Text = this.BackScreen.Text.Remove(this.BackScreen.Text.Length - 1);
                                result = Double.Parse(BackScreen.Text);
                                result += Double.Parse(Screen.Text);

                            }
                            else
                            {
                                result = Double.Parse(BackScreen.Text);
                                result += Double.Parse(Screen.Text);
                            }
                        }
                        else { result = Double.Parse(Screen.Text); }
                    }
                    else
                    {
                        i = 0;
                    }
                    break;
                case "-":
                    operations = "sub";
                    if (i == 0)
                    {
                        if (BackScreen.Text != "")
                        {
                            if (BackScreen.Text.EndsWith("-"))
                            {
                                this.BackScreen.Text = this.BackScreen.Text.Remove(this.BackScreen.Text.Length - 1);
                                result = Double.Parse(BackScreen.Text);
                                result -= Double.Parse(Screen.Text);

                            }
                            else
                            {
                                result = Double.Parse(BackScreen.Text);
                                result -= Double.Parse(Screen.Text);
                            }
                        }
                        else { result -= Double.Parse(Screen.Text); }
                    }
                    else
                    {
                        i = 0;
                    }
                    break;
                case "x":
                    operations = "mul";
                    if (i == 0)
                    {
                        if (BackScreen.Text != "")
                        {
                            if (BackScreen.Text.EndsWith("x"))
                            {
                                this.BackScreen.Text = this.BackScreen.Text.Remove(this.BackScreen.Text.Length - 1);
                                result = Double.Parse(BackScreen.Text);
                                result *= Double.Parse(Screen.Text);

                            }
                            else
                            {
                                result = Double.Parse(BackScreen.Text);
                                result *= Double.Parse(Screen.Text);
                            }
                        }
                        else { result *= Double.Parse(Screen.Text); }
                    }
                    else
                    {
                        i = 0;
                    }
                    break;
                case "/":
                    operations = "div";
                    if (i == 0)
                    {
                        if (BackScreen.Text != "")
                        {
                            if (BackScreen.Text.EndsWith("/"))
                            {
                                if (b != 0)
                                {
                                    this.BackScreen.Text = this.BackScreen.Text.Remove(this.BackScreen.Text.Length - 1);
                                    result = Double.Parse(BackScreen.Text);
                                    result /= Double.Parse(Screen.Text);
                                }
                                else
                                {
                                    this.Screen.Text = "Nie dzieli się przez zero";
                                    this.BackScreen.Text = "";

                                }
                             
                            }
                            else
                            {
                                if (b != 0)
                                {
                                    result = Double.Parse(BackScreen.Text);
                                    result /= Double.Parse(Screen.Text);
                                }
                                else
                                {
                                    this.Screen.Text = "Nie dzieli się przez zero";
                                    this.BackScreen.Text = "";

                                }
                             
                            }
                        }
                        else { result /= Double.Parse(Screen.Text); }
                    }
                    else
                    {
                        i = 0;
                    }
                    break;
            }
            if (this.Screen.Text != "")
            {
                    if (this.BackScreen.Text == "")
                    {
                        this.BackScreen.Text = Screen.Text + " " + choose;
                        //result = double.Parse(BackScreen.Text.Remove(this.BackScreen.Text.Length - 1));
                        c = Screen.Text;
                        this.Screen.Text = "";
                    }
                    else
                    {
                        this.BackScreen.Text = result.ToString() + " " + choose;
                        //result = double.Parse(BackScreen.Text.Remove(this.BackScreen.Text.Length - 1));
                        c = Screen.Text;
                        this.Screen.Text = "";
                 }
                
            } 
        }
        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            if (this.Screen.Text != "")
            {
                b = Double.Parse(Screen.Text);
                a = Double.Parse(c);
                switch (operations)
                {
                    case "add":
                        if (BackScreen.Text.EndsWith("+"))
                        {
                            this.BackScreen.Text = this.BackScreen.Text.Remove(this.BackScreen.Text.Length - 1);
                            result = Double.Parse(BackScreen.Text);
                            result += b;
                        }
                        else
                        {
                            result = Double.Parse(BackScreen.Text);
                            result += b;
                        }
                        this.Screen.Text = result.ToString();
                        this.BackScreen.Text = result.ToString();
                        i = 1;
                        break;
                    case "sub":
                        if (BackScreen.Text.EndsWith("-"))
                        {
                            this.BackScreen.Text = this.BackScreen.Text.Remove(this.BackScreen.Text.Length - 1);
                            result = Double.Parse(BackScreen.Text);
                            result -= b;
                        }
                        else
                        {
                            result = Double.Parse(BackScreen.Text);
                            result -= b;
                        }
                        this.Screen.Text = result.ToString();
                        this.BackScreen.Text = result.ToString();
                        i = 1;
                        break;
                    case "mul":
                        if (BackScreen.Text.EndsWith("x"))
                        {
                            this.BackScreen.Text = this.BackScreen.Text.Remove(this.BackScreen.Text.Length - 1);
                            result = Double.Parse(BackScreen.Text);
                            result *= b;
                        }
                        else
                        {
                            result = Double.Parse(BackScreen.Text);
                            result *= b;
                        }
                        this.Screen.Text = result.ToString();
                        this.BackScreen.Text = result.ToString();
                        i = 1;
                        break;
                    case "div":
                        if (BackScreen.Text.EndsWith("/"))
                        {
                            this.BackScreen.Text = this.BackScreen.Text.Remove(this.BackScreen.Text.Length - 1);
                            result = Double.Parse(BackScreen.Text);
                            if (b != 0)
                            {
                                result /= b;
                                this.Screen.Text = result.ToString();
                                this.BackScreen.Text = result.ToString();
                            }
                            else
                            {
                                this.Screen.Text = "Nie dzieli się przez zero";
                                this.BackScreen.Text = "";
                                
                            }
                             
                        }
                        else
                        {
                            result = Double.Parse(BackScreen.Text);
                            result /= b;
                            this.Screen.Text = result.ToString();
                            this.BackScreen.Text = result.ToString();
                        }
                        i = 1;
                        break;
                        
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

        }

        private void Square_Click(object sender, RoutedEventArgs e)
        {
           
            if (this.Screen.Text != "")
            {
                b = Double.Parse(Screen.Text);
                double g = b * b;
                /*if (this.Screen.Text.EndsWith(operations))
                {
                    this.Screen.Text = Screen.Text;
                }*/
                //else

                if (this.BackScreen.Text == "")
                {
                    result = g;
                    //this.BackScreen.Text = result.ToString() ;
                    this.Screen.Text = result.ToString();
                   /* c = Screen.Text;
                    this.Screen.Text = "";*/
                }
                else
                {
                    if (BackScreen.Text.EndsWith(choose))
                    {
                        this.Screen.Text = g.ToString();
                        a = Double.Parse(this.BackScreen.Text.Remove(this.BackScreen.Text.Length - 1));
                        if (BackScreen.Text.Contains("+"))
                            result = a + g;
                        else if (BackScreen.Text.Contains("-"))
                            result = a - g;
                        else if (BackScreen.Text.Contains("x"))
                            result = a * g;
                        else if (BackScreen.Text.Contains("/"))
                            result = a / g;
                        else
                            result = g;
                    }
                    else {
                        a = Double.Parse(BackScreen.Text);
                        if (BackScreen.Text.Contains("+"))
                            result = a + g;
                        else if (BackScreen.Text.Contains("-"))
                            result = a - g;
                        else if (BackScreen.Text.Contains("x"))
                            result = a * g;
                        else if (BackScreen.Text.Contains("/"))
                            result = a / g;
                        else
                            result = g;
                    }
                    //this.BackScreen.Text = result.ToString();
                    //this.Screen.Text = result.ToString();
                }
            }

          /*
            this.Screen.Text = result.ToString();
            this.BackScreen.Text = result.ToString();
            */
        }

        private void Fraction_Click(object sender, RoutedEventArgs e)
        {
            if (this.Screen.Text != "")
            {
                b = Double.Parse(Screen.Text);
                if (b == 0)
                {
                    result = b;
                }
                else
                {
                    double g = 1 / b;
                    result = g;

                    if (this.BackScreen.Text == "")
                    {
                        result = g;
                        this.BackScreen.Text = result.ToString();
                        this.Screen.Text = result.ToString();
                    }
                    else
                    {
                        if (BackScreen.Text.EndsWith(choose))
                        {
                            a = Double.Parse(this.BackScreen.Text.Remove(this.BackScreen.Text.Length - 1));
                            if (BackScreen.Text.Contains("+"))
                                result = a + g;
                            else if (BackScreen.Text.Contains("-"))
                                result = a - g;
                            else if (BackScreen.Text.Contains("x"))
                                result = a * g;
                            else if (BackScreen.Text.Contains("/"))
                                result = a / g;
                            else
                                result = g;
                        }
                        else
                        {
                            a = Double.Parse(BackScreen.Text);
                            if (BackScreen.Text.Contains("+"))
                                result = a + g;
                            else if (BackScreen.Text.Contains("-"))
                                result = a - g;
                            else if (BackScreen.Text.Contains("x"))
                                result = a * g;
                            else if (BackScreen.Text.Contains("/"))
                                result = a / g;
                            else
                                result = g;
                        }


                        this.Screen.Text = result.ToString();
                        this.BackScreen.Text = result.ToString();
                    }
                }
            }
        }

        private void Negation_Click(object sender, RoutedEventArgs e)
        {
            if (this.Screen.Text != "")
            {
                b = Double.Parse(Screen.Text);
                double g = - b;
                result = g;
                if (this.BackScreen.Text == "")
                {
                    result = g;
                    //this.BackScreen.Text = result.ToString();
                    this.Screen.Text = result.ToString();
                }
                /*else
                {
                    if (BackScreen.Text.EndsWith(choose))
                    {
                        a = Double.Parse(this.BackScreen.Text.Remove(this.BackScreen.Text.Length - 1));
                        if (BackScreen.Text.Contains("+"))
                            result = a + g;
                        else if (BackScreen.Text.Contains("-"))
                            result = a - g;
                        else if (BackScreen.Text.Contains("x"))
                            result = a * g;
                        else if (BackScreen.Text.Contains("/"))
                            result = a / g;
                        else
                            result = g;
                    }
                    else
                    {
                        a = Double.Parse(BackScreen.Text);
                        if (BackScreen.Text.Contains("+"))
                            result = a + g;
                        else if (BackScreen.Text.Contains("-"))
                            result = a - g;
                        else if (BackScreen.Text.Contains("x"))
                            result = a * g;
                        else if (BackScreen.Text.Contains("/"))
                            result = a / g;
                        else
                            result = g;
                    }*/


                    this.Screen.Text = result.ToString();
                    //this.BackScreen.Text = result.ToString();
              //  }
            }

            this.Screen.Text = result.ToString();
            //this.BackScreen.Text = result.ToString();
        }
    } 
}
