using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calculator
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private decimal firstNumber;
        private string operatorName;
        private bool isOperatorClicked;

      
        private void btnClear_Clicked(object sender, EventArgs e)
        {
            lableResult.Text = "0";
            isOperatorClicked = false;
            firstNumber = 0;
        }

       

        private void btnPercentage_Clicked(object sender, EventArgs e)
        {
            try
            {
                string number = lableResult.Text;
                if (number != "0")
                {
                    decimal pecentValue = Convert.ToDecimal(number);
                    string result = (pecentValue / 100).ToString("0.##");
                    lableResult.Text = result;
                }
            }
            catch (Exception ex)
            {
                 DisplayAlert("Error!", ex.Message, "OK");
            }
        }

        private void btnDel_Clicked(object sender, EventArgs e)
        {
            string number = lableResult.Text;
            if (number != "0")
            {
                number = number.Remove(number.Length - 1, 1);
                if (string.IsNullOrEmpty(number))
                {
                    lableResult.Text = "0";
                }
                else
                {
                    lableResult.Text = number;
                }
            }
        }

        private void btnOperation_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            isOperatorClicked = true;
            operatorName = button.Text;
            firstNumber = Convert.ToDecimal(lableResult.Text);
        }

        private void btnNumber_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (lableResult.Text == "0" || isOperatorClicked)
            {
                isOperatorClicked = false;
                lableResult.Text = button.Text;
            }
            else
            {
                lableResult.Text += button.Text;
            }
        }

        private void btnEqual_Clicked(object sender, EventArgs e)
        {
            try
            {
                decimal secondNumber = Convert.ToDecimal(lableResult.Text);
                string finalResult = Calculate(firstNumber, secondNumber).ToString("0.##");
                lableResult.Text = finalResult;
            }
            catch (Exception ex)
            {
                DisplayAlert("Error!", ex.Message, "OK");
            }
        }


        public decimal Calculate(decimal firstNumber, decimal secondNumber)
        {
            decimal result = 0;
            if (operatorName=="+")
            {
                result = firstNumber + secondNumber;
            }
            else if (operatorName=="-")
            {
                result = firstNumber - secondNumber;

            }
            else if (operatorName == "*")
            {
                result = firstNumber * secondNumber;

            }
            else if (operatorName == "/")
            {
                result = firstNumber / secondNumber;
            }

            return result;
        }
    }
}
