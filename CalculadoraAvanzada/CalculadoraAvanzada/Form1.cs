using System;
using System.Globalization;
using System.Windows.Forms;

namespace CalculatorApp
{
    public partial class Calculator : Form
    {
        private double currentValue = 0;
        private double memoryValue = 0;
        private string currentOperation = "";
        private bool newOperation = true;
        private bool operationPending = false;

        public Calculator()
        {
            InitializeComponent();
            AttachEventHandlers();
        }

        private void AttachEventHandlers()
        {
            // Botones numéricos
            btn0.Click += (s, e) => AppendNumber("0");
            btn1.Click += (s, e) => AppendNumber("1");
            btn2.Click += (s, e) => AppendNumber("2");
            btn3.Click += (s, e) => AppendNumber("3");
            btn4.Click += (s, e) => AppendNumber("4");
            btn5.Click += (s, e) => AppendNumber("5");
            btn6.Click += (s, e) => AppendNumber("6");
            btn7.Click += (s, e) => AppendNumber("7");
            btn8.Click += (s, e) => AppendNumber("8");
            btn9.Click += (s, e) => AppendNumber("9");

            // Operaciones básicas
            btnAdd.Click += (s, e) => SetOperation("+");
            btnSubtract.Click += (s, e) => SetOperation("-");
            btnMultiply.Click += (s, e) => SetOperation("*");
            btnDivide.Click += (s, e) => SetOperation("/");

            // Botones especiales
            btnEquals.Click += (s, e) => PerformCalculation();
            btnDecimal.Click += (s, e) => AddDecimalPoint();
            btnClear.Click += (s, e) => ClearCalculator();
            btnBack.Click += (s, e) => Backspace();
            btnSign.Click += (s, e) => ChangeSign();
            btnPercent.Click += (s, e) => CalculatePercentage();

            // Memoria
            btnMplus.Click += (s, e) => MemoryAdd();
            btnMminus.Click += (s, e) => MemorySubtract();
            btnMC.Click += (s, e) => MemoryClear();
            btnMR.Click += (s, e) => MemoryRecall();

            // Funciones avanzadas
            btnExp.Click += (s, e) => SetOperation("^");
            btnSqrt.Click += (s, e) => CalculateSquareRoot();
            btnPi.Click += (s, e) => ShowPi();
            btnLog.Click += (s, e) => CalculateLog();
            btnReciprocal.Click += (s, e) => CalculateReciprocal();
            btnSquare.Click += (s, e) => CalculateSquare();
        }

        private void AppendNumber(string number)
        {
            if (newOperation)
            {
                txtDisplay.Text = "";
                newOperation = false;
            }

            // Evitar múltiples ceros a la izquierda
            if (txtDisplay.Text == "0" && number != ".")
                txtDisplay.Text = "";

            txtDisplay.Text += number;
        }

        private void SetOperation(string op)
        {
            if (operationPending)
            {
                PerformCalculation();
            }
            else
            {
                currentValue = double.Parse(txtDisplay.Text, CultureInfo.InvariantCulture);
            }

            currentOperation = op;
            operationPending = true;
            newOperation = true;
        }

        private void PerformCalculation()
        {
            if (!operationPending) return;

            double newValue = double.Parse(txtDisplay.Text, CultureInfo.InvariantCulture);

            switch (currentOperation)
            {
                case "+": currentValue += newValue; break;
                case "-": currentValue -= newValue; break;
                case "*": currentValue *= newValue; break;
                case "/":
                    if (newValue != 0)
                        currentValue /= newValue;
                    else
                        MessageBox.Show("No se puede dividir por cero");
                    break;
                case "^": currentValue = Math.Pow(currentValue, newValue); break;
            }

            txtDisplay.Text = currentValue.ToString(CultureInfo.InvariantCulture);
            operationPending = false;
            newOperation = true;
        }

        private void AddDecimalPoint()
        {
            if (newOperation)
            {
                txtDisplay.Text = "0.";
                newOperation = false;
            }
            else if (!txtDisplay.Text.Contains("."))
            {
                txtDisplay.Text += ".";
            }
        }

        private void ClearCalculator()
        {
            txtDisplay.Text = "0";
            currentValue = 0;
            currentOperation = "";
            newOperation = true;
            operationPending = false;
        }

        private void Backspace()
        {
            if (txtDisplay.Text.Length > 1)
            {
                txtDisplay.Text = txtDisplay.Text.Substring(0, txtDisplay.Text.Length - 1);
            }
            else
            {
                txtDisplay.Text = "0";
                newOperation = true;
            }
        }

        private void ChangeSign()
        {
            if (txtDisplay.Text != "0")
            {
                double value = double.Parse(txtDisplay.Text, CultureInfo.InvariantCulture);
                txtDisplay.Text = (-value).ToString(CultureInfo.InvariantCulture);
            }
        }

        private void CalculatePercentage()
        {
            double value = double.Parse(txtDisplay.Text, CultureInfo.InvariantCulture);
            txtDisplay.Text = (value / 100).ToString(CultureInfo.InvariantCulture);
        }

        private void MemoryAdd() => memoryValue += double.Parse(txtDisplay.Text, CultureInfo.InvariantCulture);
        private void MemorySubtract() => memoryValue -= double.Parse(txtDisplay.Text, CultureInfo.InvariantCulture);
        private void MemoryClear() => memoryValue = 0;
        private void MemoryRecall() => txtDisplay.Text = memoryValue.ToString(CultureInfo.InvariantCulture);

        private void CalculateSquareRoot()
        {
            double value = double.Parse(txtDisplay.Text, CultureInfo.InvariantCulture);
            if (value >= 0)
                txtDisplay.Text = Math.Sqrt(value).ToString(CultureInfo.InvariantCulture);
            else
                MessageBox.Show("No se puede calcular la raíz de un número negativo");
        }

        private void ShowPi() => txtDisplay.Text = Math.PI.ToString(CultureInfo.InvariantCulture);

        private void CalculateLog()
        {
            double value = double.Parse(txtDisplay.Text, CultureInfo.InvariantCulture);
            if (value > 0)
                txtDisplay.Text = Math.Log10(value).ToString(CultureInfo.InvariantCulture);
            else
                MessageBox.Show("No se puede calcular el logaritmo de un número menor o igual a cero");
        }

        private void CalculateReciprocal()
        {
            double value = double.Parse(txtDisplay.Text, CultureInfo.InvariantCulture);
            if (value != 0)
                txtDisplay.Text = (1 / value).ToString(CultureInfo.InvariantCulture);
            else
                MessageBox.Show("No se puede dividir por cero");
        }

        private void CalculateSquare()
        {
            double value = double.Parse(txtDisplay.Text, CultureInfo.InvariantCulture);
            txtDisplay.Text = (value * value).ToString(CultureInfo.InvariantCulture);
        }
    }
}