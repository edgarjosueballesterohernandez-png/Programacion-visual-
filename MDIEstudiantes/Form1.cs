using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace MDIEstudiantes
{
    public class Form1 : Form
    {
        private List<Estudiante> estudiantes = new List<Estudiante>();

        public Form1()
        {
            // Configurar el formulario principal
            this.Text = "Sistema de Estudiantes MDI";
            this.Size = new Size(1000, 700);
            this.IsMdiContainer = true;
            this.WindowState = FormWindowState.Maximized;

            CrearMenuPrincipal();
        }

        private void CrearMenuPrincipal()
        {
            MenuStrip menuStrip = new MenuStrip();
            menuStrip.Dock = DockStyle.Top;

            // Menú Archivo
            ToolStripMenuItem archivoMenu = new ToolStripMenuItem("Archivo");

            ToolStripMenuItem ingresarMenu = new ToolStripMenuItem("Ingresar Estudiante");
            ingresarMenu.Click += (s, e) => MostrarFormularioIngreso();

            ToolStripMenuItem verMenu = new ToolStripMenuItem("Ver Estudiantes");
            verMenu.Click += (s, e) => MostrarFormularioVisualizacion();

            ToolStripMenuItem graficosMenu = new ToolStripMenuItem("Gráficos");
            graficosMenu.Click += (s, e) => MostrarFormularioGraficos();

            ToolStripMenuItem salirMenu = new ToolStripMenuItem("Salir");
            salirMenu.Click += (s, e) => Application.Exit();

            archivoMenu.DropDownItems.Add(ingresarMenu);
            archivoMenu.DropDownItems.Add(verMenu);
            archivoMenu.DropDownItems.Add(graficosMenu);
            archivoMenu.DropDownItems.Add(new ToolStripSeparator());
            archivoMenu.DropDownItems.Add(salirMenu);

            menuStrip.Items.Add(archivoMenu);
            this.Controls.Add(menuStrip);
            this.MainMenuStrip = menuStrip;
        }

        private void MostrarFormularioIngreso()
        {
            Form formIngreso = new Form();
            formIngreso.Text = "Ingresar Nuevo Estudiante";
            formIngreso.Size = new Size(500, 500);
            formIngreso.MdiParent = this;
            formIngreso.StartPosition = FormStartPosition.CenterScreen;

            // Crear controles
            Label lblTitulo = new Label()
            {
                Text = "INGRESAR DATOS DEL ESTUDIANTE",
                Location = new Point(150, 20),
                Size = new Size(200, 25),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };

            Label lblCarnet = new Label()
            {
                Text = "Carnet:",
                Location = new Point(50, 60),
                Size = new Size(80, 20)
            };

            TextBox txtCarnet = new TextBox()
            {
                Location = new Point(150, 60),
                Size = new Size(200, 20)
            };

            Label lblNombre = new Label()
            {
                Text = "Nombre:",
                Location = new Point(50, 90),
                Size = new Size(80, 20)
            };

            TextBox txtNombre = new TextBox()
            {
                Location = new Point(150, 90),
                Size = new Size(200, 20)
            };

            Label lblAsignaturas = new Label()
            {
                Text = "Asignaturas y Notas:",
                Location = new Point(50, 130),
                Size = new Size(150, 20),
                Font = new Font("Arial", 9, FontStyle.Bold)
            };

            // DataGridView para asignaturas y notas
            DataGridView dgvAsignaturas = new DataGridView()
            {
                Location = new Point(50, 160),
                Size = new Size(400, 200),
                AllowUserToAddRows = true,
                AllowUserToDeleteRows = true
            };

            // Configurar columnas
            dgvAsignaturas.Columns.Add("Asignatura", "Asignatura");
            dgvAsignaturas.Columns.Add("Nota", "Nota");
            dgvAsignaturas.Columns[0].Width = 250;
            dgvAsignaturas.Columns[1].Width = 100;

            // Botones para manejar asignaturas
            Button btnAgregarFila = new Button()
            {
                Text = "➕ Agregar Fila",
                Location = new Point(50, 370),
                Size = new Size(100, 30)
            };

            Button btnEliminarFila = new Button()
            {
                Text = "➖ Eliminar Fila",
                Location = new Point(160, 370),
                Size = new Size(100, 30)
            };

            Button btnGuardar = new Button()
            {
                Text = "💾 GUARDAR",
                Location = new Point(150, 420),
                Size = new Size(100, 35),
                BackColor = Color.LightGreen
            };

            Button btnLimpiar = new Button()
            {
                Text = "🗑️ LIMPIAR",
                Location = new Point(260, 420),
                Size = new Size(100, 35),
                BackColor = Color.LightCoral
            };

            // Agregar filas de ejemplo
            dgvAsignaturas.Rows.Add("Matemáticas", "8.5");
            dgvAsignaturas.Rows.Add("Programación", "9.0");
            dgvAsignaturas.Rows.Add("Física", "7.5");

            // Eventos
            btnAgregarFila.Click += (s, e) =>
            {
                dgvAsignaturas.Rows.Add();
            };

            btnEliminarFila.Click += (s, e) =>
            {
                if (dgvAsignaturas.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow row in dgvAsignaturas.SelectedRows)
                    {
                        if (!row.IsNewRow)
                            dgvAsignaturas.Rows.Remove(row);
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione una fila para eliminar", "Advertencia",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            };

            btnGuardar.Click += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtCarnet.Text) || string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    MessageBox.Show("❌ Debe ingresar carnet y nombre del estudiante", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Estudiante nuevoEstudiante = new Estudiante
                {
                    Carnet = txtCarnet.Text.Trim(),
                    Nombre = txtNombre.Text.Trim()
                };

                // Procesar asignaturas
                bool tieneAsignaturas = false;
                bool errorEnNotas = false;
                string errorMensaje = "";

                foreach (DataGridViewRow fila in dgvAsignaturas.Rows)
                {
                    if (!fila.IsNewRow && fila.Cells[0].Value != null)
                    {
                        string nombreAsig = fila.Cells[0].Value.ToString();
                        if (!string.IsNullOrWhiteSpace(nombreAsig))
                        {
                            double nota = 0;
                            if (fila.Cells[1].Value != null && double.TryParse(fila.Cells[1].Value.ToString(), out nota))
                            {
                                if (nota >= 0 && nota <= 10) // Validar rango de notas
                                {
                                    nuevoEstudiante.Asignaturas.Add(new Asignatura
                                    {
                                        Nombre = nombreAsig,
                                        Nota = nota
                                    });
                                    tieneAsignaturas = true;
                                }
                                else
                                {
                                    errorEnNotas = true;
                                    errorMensaje = $"La nota de '{nombreAsig}' debe estar entre 0 y 10";
                                    break;
                                }
                            }
                            else
                            {
                                errorEnNotas = true;
                                errorMensaje = $"La nota de '{nombreAsig}' no es válida";
                                break;
                            }
                        }
                    }
                }

                if (errorEnNotas)
                {
                    MessageBox.Show($"❌ {errorMensaje}", "Error en notas",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!tieneAsignaturas)
                {
                    MessageBox.Show("❌ Debe ingresar al menos una asignatura con nota válida", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Verificar si ya existe
                var existente = estudiantes.Find(est => est.Carnet == nuevoEstudiante.Carnet);
                if (existente != null)
                {
                    var resultado = MessageBox.Show($"⚠️ El estudiante con carnet {nuevoEstudiante.Carnet} ya existe.\n¿Desea reemplazarlo?",
                                                  "Estudiante Existente",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);

                    if (resultado == DialogResult.Yes)
                    {
                        estudiantes.Remove(existente);
                    }
                    else
                    {
                        return;
                    }
                }

                estudiantes.Add(nuevoEstudiante);

                MessageBox.Show($"✅ Estudiante guardado exitosamente!\n\n" +
                              $"📝 Carnet: {nuevoEstudiante.Carnet}\n" +
                              $"👤 Nombre: {nuevoEstudiante.Nombre}\n" +
                              $"📚 Asignaturas: {nuevoEstudiante.Asignaturas.Count}\n" +
                              $"📊 Promedio: {nuevoEstudiante.Promedio:F2}",
                              "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarFormularioIngreso();
            };

            btnLimpiar.Click += (s, e) =>
            {
                LimpiarFormularioIngreso();
            };

            void LimpiarFormularioIngreso()
            {
                txtCarnet.Clear();
                txtNombre.Clear();
                dgvAsignaturas.Rows.Clear();
                dgvAsignaturas.Rows.Add("Matemáticas", "8.5");
                dgvAsignaturas.Rows.Add("Programación", "9.0");
                dgvAsignaturas.Rows.Add("Física", "7.5");
                txtCarnet.Focus();
            }

            // Agregar controles al formulario
            formIngreso.Controls.Add(lblTitulo);
            formIngreso.Controls.Add(lblCarnet);
            formIngreso.Controls.Add(txtCarnet);
            formIngreso.Controls.Add(lblNombre);
            formIngreso.Controls.Add(txtNombre);
            formIngreso.Controls.Add(lblAsignaturas);
            formIngreso.Controls.Add(dgvAsignaturas);
            formIngreso.Controls.Add(btnAgregarFila);
            formIngreso.Controls.Add(btnEliminarFila);
            formIngreso.Controls.Add(btnGuardar);
            formIngreso.Controls.Add(btnLimpiar);

            formIngreso.Show();
        }

        private void MostrarFormularioVisualizacion()
        {
            Form formVisualizacion = new Form();
            formVisualizacion.Text = "Visualización de Estudiantes";
            formVisualizacion.Size = new Size(600, 500);
            formVisualizacion.MdiParent = this;
            formVisualizacion.StartPosition = FormStartPosition.CenterScreen;

            // Controles
            Label lblSeleccionar = new Label()
            {
                Text = "Seleccionar Estudiante:",
                Location = new Point(20, 20),
                Size = new Size(150, 20),
                Font = new Font("Arial", 9, FontStyle.Bold)
            };

            ComboBox cmbEstudiantes = new ComboBox()
            {
                Location = new Point(180, 20),
                Size = new Size(300, 20),
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            GroupBox grpInfo = new GroupBox()
            {
                Text = "Información del Estudiante",
                Location = new Point(20, 60),
                Size = new Size(550, 120),
                Font = new Font("Arial", 9, FontStyle.Bold)
            };

            Label lblCarnet = new Label() { Text = "Carnet:", Location = new Point(20, 30), Size = new Size(80, 20) };
            TextBox txtCarnet = new TextBox() { Location = new Point(100, 30), Size = new Size(150, 20), ReadOnly = true };

            Label lblNombre = new Label() { Text = "Nombre:", Location = new Point(20, 60), Size = new Size(80, 20) };
            TextBox txtNombre = new TextBox() { Location = new Point(100, 60), Size = new Size(300, 20), ReadOnly = true };

            Label lblPromedio = new Label() { Text = "Promedio:", Location = new Point(270, 30), Size = new Size(80, 20) };
            TextBox txtPromedio = new TextBox() { Location = new Point(360, 30), Size = new Size(80, 20), ReadOnly = true };

            Label lblAsignaturasCount = new Label() { Text = "Total Asignaturas:", Location = new Point(20, 90), Size = new Size(100, 20) };
            TextBox txtAsignaturasCount = new TextBox() { Location = new Point(130, 90), Size = new Size(50, 20), ReadOnly = true };

            GroupBox grpAsignaturas = new GroupBox()
            {
                Text = "Asignaturas y Notas",
                Location = new Point(20, 200),
                Size = new Size(550, 200),
                Font = new Font("Arial", 9, FontStyle.Bold)
            };

            DataGridView dgvAsignaturas = new DataGridView()
            {
                Location = new Point(20, 25),
                Size = new Size(510, 160),
                ReadOnly = true
            };
            dgvAsignaturas.Columns.Add("Asignatura", "Asignatura");
            dgvAsignaturas.Columns.Add("Nota", "Nota");
            dgvAsignaturas.Columns.Add("Estado", "Estado");
            dgvAsignaturas.Columns[0].Width = 250;
            dgvAsignaturas.Columns[1].Width = 80;
            dgvAsignaturas.Columns[2].Width = 100;

            // Llenar ComboBox
            ActualizarComboEstudiantes();

            void ActualizarComboEstudiantes()
            {
                cmbEstudiantes.Items.Clear();
                foreach (var est in estudiantes)
                {
                    cmbEstudiantes.Items.Add($"{est.Carnet} - {est.Nombre} (Prom: {est.Promedio:F2})");
                }

                if (cmbEstudiantes.Items.Count > 0)
                    cmbEstudiantes.SelectedIndex = 0;
                else
                    LimpiarDatos();
            }

            void LimpiarDatos()
            {
                txtCarnet.Clear();
                txtNombre.Clear();
                txtPromedio.Clear();
                txtAsignaturasCount.Clear();
                dgvAsignaturas.Rows.Clear();
            }

            // Evento cambio de selección
            cmbEstudiantes.SelectedIndexChanged += (s, e) =>
            {
                if (cmbEstudiantes.SelectedIndex >= 0 && cmbEstudiantes.SelectedIndex < estudiantes.Count)
                {
                    var estudiante = estudiantes[cmbEstudiantes.SelectedIndex];
                    txtCarnet.Text = estudiante.Carnet;
                    txtNombre.Text = estudiante.Nombre;
                    txtPromedio.Text = estudiante.Promedio.ToString("F2");
                    txtAsignaturasCount.Text = estudiante.Asignaturas.Count.ToString();

                    dgvAsignaturas.Rows.Clear();
                    foreach (var asig in estudiante.Asignaturas)
                    {
                        string estado = asig.Nota >= 6 ? "Aprobado" : "Reprobado";
                        dgvAsignaturas.Rows.Add(asig.Nombre, asig.Nota.ToString("F2"), estado);
                    }
                }
            };

            // Agregar controles a los GroupBox
            grpInfo.Controls.Add(lblCarnet);
            grpInfo.Controls.Add(txtCarnet);
            grpInfo.Controls.Add(lblNombre);
            grpInfo.Controls.Add(txtNombre);
            grpInfo.Controls.Add(lblPromedio);
            grpInfo.Controls.Add(txtPromedio);
            grpInfo.Controls.Add(lblAsignaturasCount);
            grpInfo.Controls.Add(txtAsignaturasCount);

            grpAsignaturas.Controls.Add(dgvAsignaturas);

            // Agregar controles al formulario
            formVisualizacion.Controls.Add(lblSeleccionar);
            formVisualizacion.Controls.Add(cmbEstudiantes);
            formVisualizacion.Controls.Add(grpInfo);
            formVisualizacion.Controls.Add(grpAsignaturas);

            // Cargar primer estudiante si existe
            if (cmbEstudiantes.Items.Count > 0)
                cmbEstudiantes.SelectedIndex = 0;

            formVisualizacion.Show();
        }

        private void MostrarFormularioGraficos()
        {
            Form formGraficos = new Form();
            formGraficos.Text = "Gráficos de Promedios - Mejores Estudiantes";
            formGraficos.Size = new Size(800, 600);
            formGraficos.MdiParent = this;
            formGraficos.StartPosition = FormStartPosition.CenterScreen;

            Label lblTitulo = new Label()
            {
                Text = "MEJORES ESTUDIANTES - GRÁFICO DE BARRAS",
                Location = new Point(250, 20),
                Size = new Size(300, 25),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 12, FontStyle.Bold)
            };

            // Panel para el gráfico
            Panel panelGrafico = new Panel()
            {
                Location = new Point(50, 60),
                Size = new Size(700, 400),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White
            };

            // Información de estadísticas
            TextBox txtEstadisticas = new TextBox()
            {
                Location = new Point(50, 470),
                Size = new Size(700, 80),
                Multiline = true,
                ReadOnly = true,
                Font = new Font("Consolas", 9),
                BackColor = Color.LightGray
            };

            Button btnActualizar = new Button()
            {
                Text = "🔄 Actualizar Gráfico",
                Location = new Point(50, 420),
                Size = new Size(150, 35)
            };

            Button btnCerrar = new Button()
            {
                Text = "Cerrar",
                Location = new Point(220, 420),
                Size = new Size(100, 35)
            };

            // Evento Paint del panel para dibujar el gráfico
            panelGrafico.Paint += (s, e) =>
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                if (estudiantes.Count == 0)
                {
                    string mensaje = "NO HAY ESTUDIANTES REGISTRADOS";
                    Font font = new Font("Arial", 14, FontStyle.Bold);
                    SizeF textSize = g.MeasureString(mensaje, font);
                    g.DrawString(mensaje, font, Brushes.Red,
                        (panelGrafico.Width - textSize.Width) / 2,
                        (panelGrafico.Height - textSize.Height) / 2);
                    return;
                }

                var mejores = estudiantes
                    .OrderByDescending(est => est.Promedio)
                    .Take(3) // Mostrar top 3
                    .ToList();

                // Configuración del gráfico
                int marginLeft = 80;
                int marginBottom = 50;
                int chartWidth = panelGrafico.Width - marginLeft - 50;
                int chartHeight = panelGrafico.Height - marginBottom - 50;
                int barWidth = (chartWidth - 100) / mejores.Count;
                int maxBarHeight = chartHeight - 100;

                // Dibujar ejes
                g.DrawLine(Pens.Black, marginLeft, 30, marginLeft, 30 + maxBarHeight);
                g.DrawLine(Pens.Black, marginLeft, 30 + maxBarHeight, marginLeft + chartWidth, 30 + maxBarHeight);

                // Encontrar el promedio máximo para escalar
                double maxPromedio = mejores.Max(est => est.Promedio);
                if (maxPromedio == 0) maxPromedio = 1;

                // Colores para las barras
                Color[] colores = { Color.SteelBlue, Color.LightSeaGreen, Color.MediumPurple, Color.Coral, Color.Gold };

                // Dibujar barras
                for (int i = 0; i < mejores.Count; i++)
                {
                    var estudiante = mejores[i];
                    int barHeight = (int)((estudiante.Promedio / maxPromedio) * maxBarHeight);
                    int x = marginLeft + 50 + (i * (barWidth + 20));
                    int y = 30 + (maxBarHeight - barHeight);

                    // Dibujar barra
                    using (SolidBrush brush = new SolidBrush(colores[i % colores.Length]))
                    {
                        g.FillRectangle(brush, x, y, barWidth, barHeight);
                    }
                    g.DrawRectangle(Pens.Black, x, y, barWidth, barHeight);

                    // Dibujar valor encima de la barra
                    string valor = estudiante.Promedio.ToString("F1");
                    SizeF valorSize = g.MeasureString(valor, SystemFonts.DefaultFont);
                    g.DrawString(valor, SystemFonts.DefaultFont, Brushes.Black,
                        x + (barWidth - valorSize.Width) / 2, y - 20);

                    // Dibujar nombre del estudiante debajo
                    string nombre = estudiante.Nombre.Length > 10 ?
                        estudiante.Nombre.Substring(0, 8) + "..." : estudiante.Nombre;
                    SizeF nombreSize = g.MeasureString(nombre, SystemFonts.DefaultFont);
                    g.DrawString(nombre, SystemFonts.DefaultFont, Brushes.Black,
                        x + (barWidth - nombreSize.Width) / 2, 30 + maxBarHeight + 5);

                    // Dibujar carnet
                    string carnet = $"({estudiante.Carnet})";
                    SizeF carnetSize = g.MeasureString(carnet, SystemFonts.DefaultFont);
                    g.DrawString(carnet, SystemFonts.DefaultFont, Brushes.DarkBlue,
                        x + (barWidth - carnetSize.Width) / 2, 30 + maxBarHeight + 25);
                }

                // Dibujar título del gráfico
                g.DrawString("Top 3 Mejores Promedios",
                    new Font("Arial", 11, FontStyle.Bold), Brushes.Black,
                    marginLeft + 50, 10);

                // Dibujar escala del eje Y
                for (int i = 0; i <= 10; i += 2)
                {
                    int yPos = 30 + maxBarHeight - (int)((i / maxPromedio) * maxBarHeight);
                    g.DrawLine(Pens.Gray, marginLeft - 5, yPos, marginLeft, yPos);
                    g.DrawString(i.ToString(), SystemFonts.DefaultFont, Brushes.Black,
                        marginLeft - 25, yPos - 8);
                }
            };

            // Evento Actualizar
            btnActualizar.Click += (s, e) =>
            {
                panelGrafico.Invalidate(); // Redibuja el gráfico
                ActualizarEstadisticas();
            };

            // Evento Cerrar
            btnCerrar.Click += (s, e) => formGraficos.Close();

            void ActualizarEstadisticas()
            {
                if (estudiantes.Count == 0)
                {
                    txtEstadisticas.Text = "No hay datos disponibles";
                    return;
                }

                var mejores = estudiantes
                    .OrderByDescending(est => est.Promedio)
                    .Take(3)
                    .ToList();

                string estadisticas = "ESTADÍSTICAS:\n";
                estadisticas += $"Total estudiantes: {estudiantes.Count}\n";
                estadisticas += $"Mejor promedio: {mejores.First().Promedio:F2} - {mejores.First().Nombre}\n";
                estadisticas += $"Promedio general: {estudiantes.Average(est => est.Promedio):F2}\n";
                estadisticas += $"Total asignaturas registradas: {estudiantes.Sum(est => est.Asignaturas.Count)}";

                txtEstadisticas.Text = estadisticas;
            }

            // Agregar controles
            formGraficos.Controls.Add(lblTitulo);
            formGraficos.Controls.Add(panelGrafico);
            formGraficos.Controls.Add(txtEstadisticas);
            formGraficos.Controls.Add(btnActualizar);
            formGraficos.Controls.Add(btnCerrar);

            // Actualizar inmediatamente
            panelGrafico.Invalidate();
            ActualizarEstadisticas();

            formGraficos.Show();
        }
    }

    public class Estudiante
    {
        public string Carnet { get; set; }
        public string Nombre { get; set; }
        public List<Asignatura> Asignaturas { get; set; } = new List<Asignatura>();

        public double Promedio
        {
            get
            {
                if (Asignaturas == null || Asignaturas.Count == 0)
                    return 0.0;
                return Asignaturas.Average(a => a.Nota);
            }
        }
    }

    public class Asignatura
    {
        public string Nombre { get; set; }
        public double Nota { get; set; }
    }
}