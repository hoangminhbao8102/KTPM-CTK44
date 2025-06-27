using CalLib;

namespace CalculatorTest
{
    public partial class Form1 : Form
    {
        private double result = 0;
        private string operation = "";
        private bool isOperationPerformed = false;
        private Operations op = new Operations(); // dùng class bạn đã viết

        public Form1()
        {
            InitializeComponent();
        }

        private void btnNumber_Click(object sender, EventArgs e)
        {
            if ((txtNumber.Text == "0") || isOperationPerformed)
                txtNumber.Clear();

            isOperationPerformed = false;
            Button button = (Button)sender;

            if (button.Text == ".")
            {
                if (!txtNumber.Text.Contains("."))
                    txtNumber.Text += ".";
            }
            else
            {
                txtNumber.Text += button.Text;
            }
        }

        private void btnOperator_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtNumber.Text, out result))
            {
                Button button = (Button)sender;
                operation = button.Text;
                isOperationPerformed = true;
            }
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            try
            {
                double secondValue = double.Parse(txtNumber.Text);
                double resultValue = 0;

                switch (operation)
                {
                    case "+":
                        resultValue = op.Summation(result, secondValue);
                        break;
                    case "-":
                        resultValue = op.Subtraction(result, secondValue);
                        break;
                    case "*":
                        resultValue = op.Multiplication(result, secondValue);
                        break;
                    case ":":
                        resultValue = op.Division(result, secondValue);
                        break;
                }

                txtNumber.Text = resultValue.ToString();
                result = resultValue;
                isOperationPerformed = false;
            }
            catch (DivideByZeroException ex)
            {
                MessageBox.Show(ex.Message, "Lỗi chia cho 0", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtNumber.Text = "0";
            result = 0;
            operation = "";
        }
    }
}
