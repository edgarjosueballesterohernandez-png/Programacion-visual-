using System;
using System.Windows.Forms;

namespace AplicacionCompleta
{
    public partial class MainForm : Form
    {
        // Variables para Login
        private int intentosLogin = 0;
        private const int maxIntentos = 4;
        private const string usuarioCorrecto = "admin";
        private const string contraseñaCorrecta = "1234";

        // Variables para Contador de Clics
        private int contadorClics = 0;

        public MainForm()
        {
            InitializeComponent();
            tabControl1.SelectedIndex = 0; // Empezar en la pestaña de Login
        }

        // ==================== LOGIN ====================
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contraseña = txtContraseña.Text;

            if (usuario == usuarioCorrecto && contraseña == contraseñaCorrecta)
            {
                MessageBox.Show("¡Login exitoso! Bienvenido al sistema.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                tabControl1.SelectedIndex = 1; // Ir a la primera pestaña de aplicaciones
            }
            else
            {
                intentosLogin++;
                int intentosRestantes = maxIntentos - intentosLogin;

                if (intentosLogin >= maxIntentos)
                {
                    MessageBox.Show("Demasiados intentos fallidos. La aplicación se cerrará.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show($"Credenciales incorrectas. Intentos restantes: {intentosRestantes}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsuario.Clear();
                    txtContraseña.Clear();
                    txtUsuario.Focus();
                }
            }
        }

        // ==================== TEMPERATURA ====================
        private void btnConvertirTemperatura_Click(object sender, EventArgs e)
        {
            if (!ValidarEntradaTemperatura())
                return;

            double temperatura = Convert.ToDouble(txtTemperatura.Text);

            if (rbCelsiusAFahrenheit.Checked)
            {
                double fahrenheit = (temperatura * 9 / 5) + 32;
                lblResultadoTemperatura.Text = $"{temperatura}°C = {fahrenheit:F2}°F";
            }
            else
            {
                double celsius = (temperatura - 32) * 5 / 9;
                lblResultadoTemperatura.Text = $"{temperatura}°F = {celsius:F2}°C";
            }
        }

        private bool ValidarEntradaTemperatura()
        {
            if (string.IsNullOrWhiteSpace(txtTemperatura.Text))
            {
                MessageBox.Show("Por favor ingrese una temperatura.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!double.TryParse(txtTemperatura.Text, out _))
            {
                MessageBox.Show("Por favor ingrese un valor numérico válido.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnLimpiarTemperatura_Click(object sender, EventArgs e)
        {
            txtTemperatura.Clear();
            lblResultadoTemperatura.Text = "Resultado:";
        }

        // ==================== CONTADOR DE CLICS ====================
        private void btnContador_Click(object sender, EventArgs e)
        {
            contadorClics++;
            lblContador.Text = $"Clics: {contadorClics}";
        }

        private void btnResetContador_Click(object sender, EventArgs e)
        {
            contadorClics = 0;
            lblContador.Text = $"Clics: {contadorClics}";
            MessageBox.Show("Contador reiniciado a 0.", "Reset",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ==================== IMC ====================
        private void btnCalcularIMC_Click(object sender, EventArgs e)
        {
            if (!ValidarEntradasIMC())
                return;

            double peso = Convert.ToDouble(txtPeso.Text);
            double altura = Convert.ToDouble(txtAltura.Text);

            // Convertir altura de centímetros a metros
            double alturaMetros = altura / 100;

            double imc = CalcularIMC(peso, alturaMetros);
            string categoria = ObtenerCategoriaIMC(imc);

            lblResultadoIMC.Text = $"IMC: {imc:F2} - {categoria}";
        }

        private double CalcularIMC(double peso, double altura)
        {
            return peso / (altura * altura);
        }

        private string ObtenerCategoriaIMC(double imc)
        {
            if (imc < 18.5) return "Bajo peso";
            if (imc < 25) return "Peso normal";
            if (imc < 30) return "Sobrepeso";
            if (imc < 35) return "Obesidad Grado I";
            if (imc < 40) return "Obesidad Grado II";
            return "Obesidad Grado III";
        }

        private bool ValidarEntradasIMC()
        {
            if (string.IsNullOrWhiteSpace(txtPeso.Text) || string.IsNullOrWhiteSpace(txtAltura.Text))
            {
                MessageBox.Show("Por favor complete todos los campos.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!double.TryParse(txtPeso.Text, out double peso) || peso <= 0)
            {
                MessageBox.Show("Por favor ingrese un peso válido.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!double.TryParse(txtAltura.Text, out double altura) || altura <= 0)
            {
                MessageBox.Show("Por favor ingrese una altura válida.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validar que la altura esté en un rango razonable (entre 50 y 250 cm)
            if (altura < 50 || altura > 250)
            {
                MessageBox.Show("Por favor ingrese una altura válida entre 50 y 250 cm.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnLimpiarIMC_Click(object sender, EventArgs e)
        {
            txtPeso.Clear();
            txtAltura.Clear();
            lblResultadoIMC.Text = "IMC: ";
        }

        // ==================== CERRAR SESIÓN ====================
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0; // Volver al login
            intentosLogin = 0;
            txtUsuario.Clear();
            txtContraseña.Clear();
        }
    }
}