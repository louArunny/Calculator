using Calculator.Models;
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
using System.Data;
using StringMath;
using Calculator.Models;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Models.Calculator Calculator { get; set; } = new Models.Calculator();

        public MainWindow()
        {
            InitializeComponent();
            Calculator.resetComplete();
            showLabel();
        }



        private void showLabel()
        {
            lbl_Calculation.Content = Calculator.getStringCalculation();
        }

        private void btn_number_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender; 
            try
            {
                double number = double.Parse(btn.Content.ToString());
                Calculator.AddToCalculation(number);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            showLabel();
        }

        private void btn_operand_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (btn != null)
                Calculator.AddOperand(btn.Content.ToString());
            showLabel();
                
        }

        private void btn_euqals_Click(object sender, RoutedEventArgs e)
        {
  
            string result = "";
            try
            {

                double value = Calculator.getCalculationBrackets().Eval();
                result = value.ToString();
                Calculator.EnteredOptions.Clear();
                Calculator.fillList(result);
            }
            catch(Exception ex)
            {
                result = "Syntax Error";
                Calculator.resetComplete();
                
            }
            lbl_Calculation.Content = result;


        }

        private void btn_CA_Click(object sender, RoutedEventArgs e)
        {
            Calculator.resetComplete();
            showLabel();
        }

        private void btn_CE_Click(object sender, RoutedEventArgs e)
        {
            Calculator.deleteLast();
            showLabel();      
        }
    }
}
