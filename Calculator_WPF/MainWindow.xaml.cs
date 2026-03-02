using Microsoft.VisualBasic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator_WPF
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

        double lastNumber;
        double result;
        string selectedOperator;
        bool flag;

        private void Button_Click(Object sender, RoutedEventArgs e)
        {
            Button clicked_button = (Button)sender;
            string text = clicked_button.Content.ToString();
            if (Display.Text == "AFISAJ" || Display.Text == "0")
            {
                Display.Text = "" + text;
            }
            else if (flag = true)
            { 
                 
            }
            else 
            {
                Display.Text += text;
            }
        }

        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            Button clicked_button = (Button)sender;
            selectedOperator = clicked_button.Content.ToString();
            lastNumber = double.Parse(Display.Text);
            flag = true;
        }


        

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            double currentNumber = double.Parse(Display.Text);
            result = lastNumber;
            switch (selectedOperator)
            {
                case "+":
                    result = lastNumber + currentNumber;
                    break;
                case "-":
                    result = lastNumber - currentNumber;
                    break;
                case "*":
                    result = lastNumber * currentNumber;
                    break;
                case "/":
                    result = lastNumber / currentNumber;
                    break;
            }
            Display.Text = result.ToString(); 
        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = "0";
            lastNumber = 0;
            selectedOperator = "";
        }
    }
}