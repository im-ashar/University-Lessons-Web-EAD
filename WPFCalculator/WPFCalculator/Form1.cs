using Microsoft.VisualBasic.Devices;
using System.Data;

namespace WPFCalculator
{
    public partial class Form1 : Form
    {
        private string currentCalculation = "";
        public Form1()
        {
            InitializeComponent();
        }
        private void button_Click(object sender, EventArgs e)
        {
            currentCalculation += (sender as Button).Text;
            textBoxOutput.Text = currentCalculation;
        }

        

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            try
            {
                textBoxOutput.Text = new DataTable().Compute(currentCalculation.ToString(), null).ToString();
                currentCalculation = textBoxOutput.Text;
            }
            catch (Exception ex)
            {
                textBoxOutput.Text = "0";
                currentCalculation = "";
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxOutput.Text = "0";
            currentCalculation = "";
        }
    }
}