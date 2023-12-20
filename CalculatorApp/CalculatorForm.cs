using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorApp
{
    public partial class CalculatorForm : Form
    {
        double result = 0;
        string operation = "";
        bool isOperationPerformed = false;


        public CalculatorForm()
        {
            InitializeComponent();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Exit Application ?","warning",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void numberBtn_Click(object sender, EventArgs e)
        {
            if(displayResultTb.Text == "0" || isOperationPerformed)
            {
                displayResultTb.Clear();
            }
            isOperationPerformed = false;
            Button button = (Button)sender; //Button button = sender as Button
            if(button.Text == ".")
            {
                if (!displayResultTb.Text.Contains(".")) //if (displayResultTb.Text.Contains(".") == false)
                {
                    displayResultTb.Text += button.Text; //displayResultTb.Text = displayResultTb.Text + ".";
                }
            }
            else
            {
                displayResultTb.Text += button.Text;
            }
        }

        private void operationBtn_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            operation = button.Text;
            result = Convert.ToDouble(displayResultTb.Text);
            currentOpTb.Text = result + " " + operation;
            isOperationPerformed = true;
        }

        private void cBtn_Click(object sender, EventArgs e)
        {
            displayResultTb.Text = "0";
            currentOpTb.Clear();
        }

        private void ceBtn_Click(object sender, EventArgs e)
        {
            displayResultTb.Text = "0";
            currentOpTb.Clear();
            result = 0;
        }

        private void equalBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (operation == "+")
                {
                    displayResultTb.Text = (result + Convert.ToDouble(displayResultTb.Text)).ToString();
                }
                else if (operation == "-")
                {
                    displayResultTb.Text = (result - Convert.ToDouble(displayResultTb.Text)).ToString();
                }
                else if (operation == "x")
                {
                    displayResultTb.Text = (result * Convert.ToDouble(displayResultTb.Text)).ToString();
                }
                else if (operation == "/")
                {
                    displayResultTb.Text = (result / Convert.ToDouble(displayResultTb.Text)).ToString();
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void backspaceBtn_Click(object sender, EventArgs e)
        {
            if(displayResultTb.Text.Length > 0)
            {
                displayResultTb.Text = displayResultTb.Text.Remove(displayResultTb.Text.Length - 1 , 1);
            }
            if(displayResultTb.Text == "0" || displayResultTb.Text.Length == 0)
            {
                displayResultTb.Text = "0";
                currentOpTb.Clear();
            }
        }
    }
}
