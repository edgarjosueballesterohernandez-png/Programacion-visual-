using System;
using System.Windows.Forms;

namespace CalculatorApp
{
    public partial class Form1 : Form
    {
        private double currentValue = 0;
        private double memoryValue = 0;
        private string currentOperation = "";
        private bool newOperation = true;
        private bool operationPressed = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void NumberButton_Click(object sender, EventArgs e)
        {
            if (newOperation || operationPressed)
            {
                txtDisplay.Text = "";
                newOperation = false;
                operationPressed = false;
            }

            Button button = (Button)sender;

            // Manejar el punto decimal
            if (button.Text == ".")
            {
                if (txtDisplay.Text.Contains("."))
                    return;
                if (txtDisplay.Text == "")
                    txtDisplay.Text = "0";
            }

            // Evitar múltiples ceros al inicio
            if (txtDisplay.Text == "0" && button.Text != ".")
                txtDisplay.Text = button.Text;
            else
                txtDisplay.Text += button.Text;
        }

        private void OperationButton_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text != "" && txtDisplay.Text != "Error")
            {
                Button button = (Button)sender;
                currentOperation = button.Text;

                if (!operationPressed)
                {
                    currentValue = double.Parse(txtDisplay.Text);
                }

                operationPressed = true;
                newOperation = false;
            }
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text != "" && txtDisplay.Text != "Error" && currentOperation != "")
            {
                double secondValue = double.Parse(txtDisplay.Text);
                double result = 0;
                bool error = false;

                switch (currentOperation)
                {
                    case "+":
                        result = currentValue + secondValue;
                        break;
                    case "-":
                        result = currentValue - secondValue;
                        break;
                    case "×":
                        result = currentValue * secondValue;
                        break;
                    case "÷":
                        if (secondValue != 0)
                            result = currentValue / secondValue;
                        else
                            error = true;
                        break;
                    case "^":
                        result = Math.Pow(currentValue, secondValue);
                        break;
                }

                if (error)
                    txtDisplay.Text = "Error";
                else
                    txtDisplay.Text = result.ToString();

                currentValue = result;
                newOperation = true;
                operationPressed = false;
                currentOperation = "";
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            currentValue = 0;
            currentOperation = "";
            newOperation = true;
            operationPressed = false;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text.Length > 1 && txtDisplay.Text != "Error")
                txtDisplay.Text = txtDisplay.Text.Substring(0, txtDisplay.Text.Length - 1);
            else
                txtDisplay.Text = "0";
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text != "0" && txtDisplay.Text != "Error")
            {
                if (txtDisplay.Text.StartsWith("-"))
                    txtDisplay.Text = txtDisplay.Text.Substring(1);
                else
                    txtDisplay.Text = "-" + txtDisplay.Text;
            }
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text != "Error")
            {
                double value = double.Parse(txtDisplay.Text);
                txtDisplay.Text = (value / 100).ToString();
                newOperation = true;
            }
        }

        private void btnSquare_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text != "Error")
            {
                double value = double.Parse(txtDisplay.Text);
                txtDisplay.Text = (value * value).ToString();
                newOperation = true;
            }
        }

        private void btnSqrt_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text != "Error")
            {
                double value = double.Parse(txtDisplay.Text);
                if (value >= 0)
                    txtDisplay.Text = Math.Sqrt(value).ToString();
                else
                    txtDisplay.Text = "Error";
                newOperation = true;
            }
        }

        private void btnReciprocal_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text != "Error")
            {
                double value = double.Parse(txtDisplay.Text);
                if (value != 0)
                    txtDisplay.Text = (1 / value).ToString();
                else
                    txtDisplay.Text = "Error";
                newOperation = true;
            }
        }

        private void btnPi_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = Math.PI.ToString();
            newOperation = true;
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text != "Error")
            {
                double value = double.Parse(txtDisplay.Text);
                if (value > 0)
                    txtDisplay.Text = Math.Log10(value).ToString();
                else
                    txtDisplay.Text = "Error";
                newOperation = true;
            }
        }

        // Funciones de memoria
        private void btnMplus_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text != "Error")
                memoryValue += double.Parse(txtDisplay.Text);
        }

        private void btnMminus_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text != "Error")
                memoryValue -= double.Parse(txtDisplay.Text);
        }

        private void btnMC_Click(object sender, EventArgs e)
        {
            memoryValue = 0;
        }

        private void btnMR_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = memoryValue.ToString();
            newOperation = true;
        }

        // Funciones personalizadas (botones rojos)
        private void btnSin_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text != "Error")
            {
                double value = double.Parse(txtDisplay.Text);
                txtDisplay.Text = Math.Sin(value * Math.PI / 180).ToString("F6");
                newOperation = true;
            }
        }

        private void btnCos_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text != "Error")
            {
                double value = double.Parse(txtDisplay.Text);
                txtDisplay.Text = Math.Cos(value * Math.PI / 180).ToString("F6");
                newOperation = true;
            }
        }

        private void btnTan_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text != "Error")
            {
                double value = double.Parse(txtDisplay.Text);
                txtDisplay.Text = Math.Tan(value * Math.PI / 180).ToString("F6");
                newOperation = true;
            }
        }

        private void btnFactorial_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text != "Error")
            {
                int value;
                if (int.TryParse(txtDisplay.Text, out value) && value >= 0 && value <= 20)
                {
                    long result = 1;
                    for (int i = 2; i <= value; i++)
                        result *= i;
                    txtDisplay.Text = result.ToString();
                }
                else
                {
                    txtDisplay.Text = "Error";
                }
                newOperation = true;
            }
        }

        private void btnExp_Click(object sender, EventArgs e)
        {
            OperationButton_Click(sender, e);
        }

        // Conectar eventos de los botones
        private void Form1_Load(object sender, EventArgs e)
        {
            // Conectar eventos de números
            btn0.Click += NumberButton_Click;
            btn1.Click += NumberButton_Click;
            btn2.Click += NumberButton_Click;
            btn3.Click += NumberButton_Click;
            btn4.Click += NumberButton_Click;
            btn5.Click += NumberButton_Click;
            btn6.Click += NumberButton_Click;
            btn7.Click += NumberButton_Click;
            btn8.Click += NumberButton_Click;
            btn9.Click += NumberButton_Click;
            btnDecimal.Click += NumberButton_Click;

            // Conectar eventos de operaciones básicas
            btnAdd.Click += OperationButton_Click;
            btnSubtract.Click += OperationButton_Click;
            btnMultiply.Click += OperationButton_Click;
            btnDivide.Click += OperationButton_Click;
            btnExp.Click += OperationButton_Click;

            // Conectar eventos de los botones personalizados
            btnSin.Click += btnSin_Click;
            btnCos.Click += btnCos_Click;
            btnTan.Click += btnTan_Click;
            btnFactorial.Click += btnFactorial_Click;

            // Conectar eventos de funciones especiales
            btnClear.Click += btnClear_Click;
            btnBack.Click += btnBack_Click;
            btnEquals.Click += btnEquals_Click;
            btnSign.Click += btnSign_Click;
            btnPercent.Click += btnPercent_Click;
            btnSquare.Click += btnSquare_Click;
            btnSqrt.Click += btnSqrt_Click;
            btnReciprocal.Click += btnReciprocal_Click;
            btnPi.Click += btnPi_Click;
            btnLog.Click += btnLog_Click;

            // Conectar eventos de memoria
            btnMplus.Click += btnMplus_Click;
            btnMminus.Click += btnMminus_Click;
            btnMC.Click += btnMC_Click;
            btnMR.Click += btnMR_Click;
        }
    }
}