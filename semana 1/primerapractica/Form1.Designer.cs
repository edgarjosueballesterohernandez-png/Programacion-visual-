namespace AplicacionCompleta
{
    partial class MainForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageLogin = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.tabPageAplicaciones = new System.Windows.Forms.TabPage();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.tabControlAplicaciones = new System.Windows.Forms.TabControl();
            this.tabPageTemperatura = new System.Windows.Forms.TabPage();
            this.btnLimpiarTemperatura = new System.Windows.Forms.Button();
            this.lblResultadoTemperatura = new System.Windows.Forms.Label();
            this.btnConvertirTemperatura = new System.Windows.Forms.Button();
            this.rbFahrenheitACelsius = new System.Windows.Forms.RadioButton();
            this.rbCelsiusAFahrenheit = new System.Windows.Forms.RadioButton();
            this.txtTemperatura = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPageContador = new System.Windows.Forms.TabPage();
            this.btnResetContador = new System.Windows.Forms.Button();
            this.lblContador = new System.Windows.Forms.Label();
            this.btnContador = new System.Windows.Forms.Button();
            this.tabPageIMC = new System.Windows.Forms.TabPage();
            this.btnLimpiarIMC = new System.Windows.Forms.Button();
            this.lblResultadoIMC = new System.Windows.Forms.Label();
            this.btnCalcularIMC = new System.Windows.Forms.Button();
            this.txtAltura = new System.Windows.Forms.TextBox();
            this.txtPeso = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPageLogin.SuspendLayout();
            this.tabPageAplicaciones.SuspendLayout();
            this.tabControlAplicaciones.SuspendLayout();
            this.tabPageTemperatura.SuspendLayout();
            this.tabPageContador.SuspendLayout();
            this.tabPageIMC.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageLogin);
            this.tabControl1.Controls.Add(this.tabPageAplicaciones);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(484, 361);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageLogin
            // 
            this.tabPageLogin.Controls.Add(this.label2);
            this.tabPageLogin.Controls.Add(this.label1);
            this.tabPageLogin.Controls.Add(this.btnLogin);
            this.tabPageLogin.Controls.Add(this.txtContraseña);
            this.tabPageLogin.Controls.Add(this.txtUsuario);
            this.tabPageLogin.Location = new System.Drawing.Point(4, 22);
            this.tabPageLogin.Name = "tabPageLogin";
            this.tabPageLogin.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLogin.Size = new System.Drawing.Size(476, 335);
            this.tabPageLogin.TabIndex = 0;
            this.tabPageLogin.Text = "Login";
            this.tabPageLogin.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(107, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Contraseña:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(125, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Usuario:";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(196, 175);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(120, 30);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Iniciar Sesión";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtContraseña
            // 
            this.txtContraseña.Location = new System.Drawing.Point(181, 130);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.PasswordChar = '*';
            this.txtContraseña.Size = new System.Drawing.Size(150, 20);
            this.txtContraseña.TabIndex = 1;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(181, 85);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(150, 20);
            this.txtUsuario.TabIndex = 0;
            // 
            // tabPageAplicaciones
            // 
            this.tabPageAplicaciones.Controls.Add(this.btnCerrarSesion);
            this.tabPageAplicaciones.Controls.Add(this.tabControlAplicaciones);
            this.tabPageAplicaciones.Location = new System.Drawing.Point(4, 22);
            this.tabPageAplicaciones.Name = "tabPageAplicaciones";
            this.tabPageAplicaciones.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAplicaciones.Size = new System.Drawing.Size(476, 335);
            this.tabPageAplicaciones.TabIndex = 1;
            this.tabPageAplicaciones.Text = "Aplicaciones";
            this.tabPageAplicaciones.UseVisualStyleBackColor = true;
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrarSesion.Location = new System.Drawing.Point(350, 290);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(120, 30);
            this.btnCerrarSesion.TabIndex = 1;
            this.btnCerrarSesion.Text = "Cerrar Sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // tabControlAplicaciones
            // 
            this.tabControlAplicaciones.Controls.Add(this.tabPageTemperatura);
            this.tabControlAplicaciones.Controls.Add(this.tabPageContador);
            this.tabControlAplicaciones.Controls.Add(this.tabPageIMC);
            this.tabControlAplicaciones.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControlAplicaciones.Location = new System.Drawing.Point(3, 3);
            this.tabControlAplicaciones.Name = "tabControlAplicaciones";
            this.tabControlAplicaciones.SelectedIndex = 0;
            this.tabControlAplicaciones.Size = new System.Drawing.Size(470, 280);
            this.tabControlAplicaciones.TabIndex = 0;
            // 
            // tabPageTemperatura
            // 
            this.tabPageTemperatura.Controls.Add(this.btnLimpiarTemperatura);
            this.tabPageTemperatura.Controls.Add(this.lblResultadoTemperatura);
            this.tabPageTemperatura.Controls.Add(this.btnConvertirTemperatura);
            this.tabPageTemperatura.Controls.Add(this.rbFahrenheitACelsius);
            this.tabPageTemperatura.Controls.Add(this.rbCelsiusAFahrenheit);
            this.tabPageTemperatura.Controls.Add(this.txtTemperatura);
            this.tabPageTemperatura.Controls.Add(this.label3);
            this.tabPageTemperatura.Location = new System.Drawing.Point(4, 22);
            this.tabPageTemperatura.Name = "tabPageTemperatura";
            this.tabPageTemperatura.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTemperatura.Size = new System.Drawing.Size(462, 254);
            this.tabPageTemperatura.TabIndex = 0;
            this.tabPageTemperatura.Text = "Temperatura";
            this.tabPageTemperatura.UseVisualStyleBackColor = true;
            // 
            // btnLimpiarTemperatura
            // 
            this.btnLimpiarTemperatura.Location = new System.Drawing.Point(250, 160);
            this.btnLimpiarTemperatura.Name = "btnLimpiarTemperatura";
            this.btnLimpiarTemperatura.Size = new System.Drawing.Size(100, 30);
            this.btnLimpiarTemperatura.TabIndex = 6;
            this.btnLimpiarTemperatura.Text = "Limpiar";
            this.btnLimpiarTemperatura.UseVisualStyleBackColor = true;
            this.btnLimpiarTemperatura.Click += new System.EventHandler(this.btnLimpiarTemperatura_Click);
            // 
            // lblResultadoTemperatura
            // 
            this.lblResultadoTemperatura.AutoSize = true;
            this.lblResultadoTemperatura.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultadoTemperatura.Location = new System.Drawing.Point(100, 120);
            this.lblResultadoTemperatura.Name = "lblResultadoTemperatura";
            this.lblResultadoTemperatura.Size = new System.Drawing.Size(86, 17);
            this.lblResultadoTemperatura.TabIndex = 5;
            this.lblResultadoTemperatura.Text = "Resultado:";
            // 
            // btnConvertirTemperatura
            // 
            this.btnConvertirTemperatura.Location = new System.Drawing.Point(100, 160);
            this.btnConvertirTemperatura.Name = "btnConvertirTemperatura";
            this.btnConvertirTemperatura.Size = new System.Drawing.Size(100, 30);
            this.btnConvertirTemperatura.TabIndex = 4;
            this.btnConvertirTemperatura.Text = "Convertir";
            this.btnConvertirTemperatura.UseVisualStyleBackColor = true;
            this.btnConvertirTemperatura.Click += new System.EventHandler(this.btnConvertirTemperatura_Click);
            // 
            // rbFahrenheitACelsius
            // 
            this.rbFahrenheitACelsius.AutoSize = true;
            this.rbFahrenheitACelsius.Location = new System.Drawing.Point(250, 70);
            this.rbFahrenheitACelsius.Name = "rbFahrenheitACelsius";
            this.rbFahrenheitACelsius.Size = new System.Drawing.Size(122, 17);
            this.rbFahrenheitACelsius.TabIndex = 3;
            this.rbFahrenheitACelsius.TabStop = true;
            this.rbFahrenheitACelsius.Text = "Fahrenheit a Celsius";
            this.rbFahrenheitACelsius.UseVisualStyleBackColor = true;
            // 
            // rbCelsiusAFahrenheit
            // 
            this.rbCelsiusAFahrenheit.AutoSize = true;
            this.rbCelsiusAFahrenheit.Checked = true;
            this.rbCelsiusAFahrenheit.Location = new System.Drawing.Point(100, 70);
            this.rbCelsiusAFahrenheit.Name = "rbCelsiusAFahrenheit";
            this.rbCelsiusAFahrenheit.Size = new System.Drawing.Size(122, 17);
            this.rbCelsiusAFahrenheit.TabIndex = 2;
            this.rbCelsiusAFahrenheit.TabStop = true;
            this.rbCelsiusAFahrenheit.Text = "Celsius a Fahrenheit";
            this.rbCelsiusAFahrenheit.UseVisualStyleBackColor = true;
            // 
            // txtTemperatura
            // 
            this.txtTemperatura.Location = new System.Drawing.Point(175, 30);
            this.txtTemperatura.Name = "txtTemperatura";
            this.txtTemperatura.Size = new System.Drawing.Size(100, 20);
            this.txtTemperatura.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(100, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Temperatura:";
            // 
            // tabPageContador
            // 
            this.tabPageContador.Controls.Add(this.btnResetContador);
            this.tabPageContador.Controls.Add(this.lblContador);
            this.tabPageContador.Controls.Add(this.btnContador);
            this.tabPageContador.Location = new System.Drawing.Point(4, 22);
            this.tabPageContador.Name = "tabPageContador";
            this.tabPageContador.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageContador.Size = new System.Drawing.Size(462, 254);
            this.tabPageContador.TabIndex = 1;
            this.tabPageContador.Text = "Contador de Clics";
            this.tabPageContador.UseVisualStyleBackColor = true;
            // 
            // btnResetContador
            // 
            this.btnResetContador.Location = new System.Drawing.Point(250, 120);
            this.btnResetContador.Name = "btnResetContador";
            this.btnResetContador.Size = new System.Drawing.Size(100, 30);
            this.btnResetContador.TabIndex = 2;
            this.btnResetContador.Text = "Reiniciar";
            this.btnResetContador.UseVisualStyleBackColor = true;
            this.btnResetContador.Click += new System.EventHandler(this.btnResetContador_Click);
            // 
            // lblContador
            // 
            this.lblContador.AutoSize = true;
            this.lblContador.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContador.Location = new System.Drawing.Point(200, 60);
            this.lblContador.Name = "lblContador";
            this.lblContador.Size = new System.Drawing.Size(125, 31);
            this.lblContador.TabIndex = 1;
            this.lblContador.Text = "Clics: 0";
            // 
            // btnContador
            // 
            this.btnContador.Location = new System.Drawing.Point(100, 120);
            this.btnContador.Name = "btnContador";
            this.btnContador.Size = new System.Drawing.Size(100, 30);
            this.btnContador.TabIndex = 0;
            this.btnContador.Text = "Hacer Clic";
            this.btnContador.UseVisualStyleBackColor = true;
            this.btnContador.Click += new System.EventHandler(this.btnContador_Click);
            // 
            // tabPageIMC
            // 
            this.tabPageIMC.Controls.Add(this.btnLimpiarIMC);
            this.tabPageIMC.Controls.Add(this.lblResultadoIMC);
            this.tabPageIMC.Controls.Add(this.btnCalcularIMC);
            this.tabPageIMC.Controls.Add(this.txtAltura);
            this.tabPageIMC.Controls.Add(this.txtPeso);
            this.tabPageIMC.Controls.Add(this.label5);
            this.tabPageIMC.Controls.Add(this.label4);
            this.tabPageIMC.Location = new System.Drawing.Point(4, 22);
            this.tabPageIMC.Name = "tabPageIMC";
            this.tabPageIMC.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageIMC.Size = new System.Drawing.Size(462, 254);
            this.tabPageIMC.TabIndex = 2;
            this.tabPageIMC.Text = "Calculadora IMC";
            this.tabPageIMC.UseVisualStyleBackColor = true;
            // 
            // btnLimpiarIMC
            // 
            this.btnLimpiarIMC.Location = new System.Drawing.Point(250, 160);
            this.btnLimpiarIMC.Name = "btnLimpiarIMC";
            this.btnLimpiarIMC.Size = new System.Drawing.Size(100, 30);
            this.btnLimpiarIMC.TabIndex = 6;
            this.btnLimpiarIMC.Text = "Limpiar";
            this.btnLimpiarIMC.UseVisualStyleBackColor = true;
            this.btnLimpiarIMC.Click += new System.EventHandler(this.btnLimpiarIMC_Click);
            // 
            // lblResultadoIMC
            // 
            this.lblResultadoIMC.AutoSize = true;
            this.lblResultadoIMC.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultadoIMC.Location = new System.Drawing.Point(100, 120);
            this.lblResultadoIMC.Name = "lblResultadoIMC";
            this.lblResultadoIMC.Size = new System.Drawing.Size(47, 17);
            this.lblResultadoIMC.TabIndex = 5;
            this.lblResultadoIMC.Text = "IMC: ";
            // 
            // btnCalcularIMC
            // 
            this.btnCalcularIMC.Location = new System.Drawing.Point(100, 160);
            this.btnCalcularIMC.Name = "btnCalcularIMC";
            this.btnCalcularIMC.Size = new System.Drawing.Size(100, 30);
            this.btnCalcularIMC.TabIndex = 4;
            this.btnCalcularIMC.Text = "Calcular IMC";
            this.btnCalcularIMC.UseVisualStyleBackColor = true;
            this.btnCalcularIMC.Click += new System.EventHandler(this.btnCalcularIMC_Click);
            // 
            // txtAltura
            // 
            this.txtAltura.Location = new System.Drawing.Point(175, 70);
            this.txtAltura.Name = "txtAltura";
            this.txtAltura.Size = new System.Drawing.Size(100, 20);
            this.txtAltura.TabIndex = 3;
            // 
            // txtPeso
            // 
            this.txtPeso.Location = new System.Drawing.Point(175, 30);
            this.txtPeso.Name = "txtPeso";
            this.txtPeso.Size = new System.Drawing.Size(100, 20);
            this.txtPeso.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(100, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Altura:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(100, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Peso:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "Aplicación Completa";
            this.tabControl1.ResumeLayout(false);
            this.tabPageLogin.ResumeLayout(false);
            this.tabPageLogin.PerformLayout();
            this.tabPageAplicaciones.ResumeLayout(false);
            this.tabControlAplicaciones.ResumeLayout(false);
            this.tabPageTemperatura.ResumeLayout(false);
            this.tabPageTemperatura.PerformLayout();
            this.tabPageContador.ResumeLayout(false);
            this.tabPageContador.PerformLayout();
            this.tabPageIMC.ResumeLayout(false);
            this.tabPageIMC.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageLogin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TabPage tabPageAplicaciones;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.TabControl tabControlAplicaciones;
        private System.Windows.Forms.TabPage tabPageTemperatura;
        private System.Windows.Forms.Button btnLimpiarTemperatura;
        private System.Windows.Forms.Label lblResultadoTemperatura;
        private System.Windows.Forms.Button btnConvertirTemperatura;
        private System.Windows.Forms.RadioButton rbFahrenheitACelsius;
        private System.Windows.Forms.RadioButton rbCelsiusAFahrenheit;
        private System.Windows.Forms.TextBox txtTemperatura;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPageContador;
        private System.Windows.Forms.Button btnResetContador;
        private System.Windows.Forms.Label lblContador;
        private System.Windows.Forms.Button btnContador;
        private System.Windows.Forms.TabPage tabPageIMC;
        private System.Windows.Forms.Button btnLimpiarIMC;
        private System.Windows.Forms.Label lblResultadoIMC;
        private System.Windows.Forms.Button btnCalcularIMC;
        private System.Windows.Forms.TextBox txtAltura;
        private System.Windows.Forms.TextBox txtPeso;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}