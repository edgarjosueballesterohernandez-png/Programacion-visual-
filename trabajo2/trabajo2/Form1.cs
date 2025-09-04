using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GestorTareas
{
    public partial class Form1 : Form
    {
        private List<Tarea> listaTareas = new List<Tarea>();

        public Form1()
        {
            InitializeComponent();
            ConfigurarEventos();
            ConfigurarValoresIniciales();
        }

        private void ConfigurarEventos()
        {
            btnAgregar.Click += btnAgregar_Click;
            btnEditar.Click += btnEditar_Click;
            btnEliminar.Click += btnEliminar_Click;
            btnBuscar.Click += btnBuscar_Click;
            btnMostrarTodas.Click += btnMostrarTodas_Click;
            dgvTareas.CellClick += dgvTareas_CellClick;
        }

        private void ConfigurarValoresIniciales()
        {
            // Establecer valores iniciales para los controles
            cmbEstado.SelectedIndex = 0;
            cmbBuscarEstado.SelectedIndex = 0;
            dtpFechaInicio.Value = DateTime.Today.AddMonths(-1);
            dtpFechaFin.Value = DateTime.Today.AddMonths(1);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                MessageBox.Show("El código es obligatorio.");
                return;
            }

            if (listaTareas.Any(t => t.Codigo == txtCodigo.Text))
            {
                MessageBox.Show("Ya existe una tarea con este código.");
                return;
            }

            Tarea nueva = new Tarea()
            {
                Codigo = txtCodigo.Text,
                Nombre = txtNombre.Text,
                Descripcion = txtDescripcion.Text,
                Fecha = dtpFecha.Value,
                Lugar = txtLugar.Text,
                Estado = cmbEstado.SelectedItem?.ToString() ?? "No realizada"
            };

            listaTareas.Add(nueva);
            ActualizarGrid();
            LimpiarCampos();
            MessageBox.Show("Tarea agregada correctamente.");
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvTareas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una tarea para editar.");
                return;
            }

            string codigoOriginal = dgvTareas.SelectedRows[0].Cells["Codigo"].Value.ToString();
            Tarea tarea = listaTareas.First(t => t.Codigo == codigoOriginal);

            // Verificar si el código fue modificado y si ya existe
            if (txtCodigo.Text != codigoOriginal && listaTareas.Any(t => t.Codigo == txtCodigo.Text))
            {
                MessageBox.Show("Ya existe una tarea con este código.");
                return;
            }

            tarea.Codigo = txtCodigo.Text;
            tarea.Nombre = txtNombre.Text;
            tarea.Descripcion = txtDescripcion.Text;
            tarea.Fecha = dtpFecha.Value;
            tarea.Lugar = txtLugar.Text;
            tarea.Estado = cmbEstado.SelectedItem?.ToString() ?? "No realizada";

            ActualizarGrid();
            MessageBox.Show("Tarea editada correctamente.");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvTareas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una tarea para eliminar.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "¿Está seguro de que desea eliminar esta tarea?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string codigo = dgvTareas.SelectedRows[0].Cells["Codigo"].Value.ToString();
                listaTareas.RemoveAll(t => t.Codigo == codigo);
                ActualizarGrid();
                LimpiarCampos();
                MessageBox.Show("Tarea eliminada correctamente.");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            IEnumerable<Tarea> resultado = listaTareas;

            // Búsqueda por código
            if (!string.IsNullOrWhiteSpace(txtBuscarCodigo.Text))
            {
                resultado = resultado.Where(t => t.Codigo.Contains(txtBuscarCodigo.Text));
            }

            // Búsqueda por estado
            if (cmbBuscarEstado.SelectedIndex > 0)
            {
                resultado = resultado.Where(t => t.Estado == cmbBuscarEstado.SelectedItem.ToString());
            }

            // Búsqueda por rango de fechas
            resultado = resultado.Where(t => t.Fecha.Date >= dtpFechaInicio.Value.Date &&
                                           t.Fecha.Date <= dtpFechaFin.Value.Date);

            dgvTareas.DataSource = resultado.ToList();
        }

        private void btnMostrarTodas_Click(object sender, EventArgs e)
        {
            ActualizarGrid();
            txtBuscarCodigo.Text = "";
            cmbBuscarEstado.SelectedIndex = 0;
        }

        private void dgvTareas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtCodigo.Text = dgvTareas.Rows[e.RowIndex].Cells["Codigo"].Value.ToString();
                txtNombre.Text = dgvTareas.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                txtDescripcion.Text = dgvTareas.Rows[e.RowIndex].Cells["Descripcion"].Value.ToString();
                dtpFecha.Value = (DateTime)dgvTareas.Rows[e.RowIndex].Cells["Fecha"].Value;
                txtLugar.Text = dgvTareas.Rows[e.RowIndex].Cells["Lugar"].Value.ToString();

                string estado = dgvTareas.Rows[e.RowIndex].Cells["Estado"].Value.ToString();
                cmbEstado.SelectedItem = estado;
            }
        }

        private void ActualizarGrid()
        {
            dgvTareas.DataSource = null;
            dgvTareas.DataSource = listaTareas;
        }

        private void LimpiarCampos()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            dtpFecha.Value = DateTime.Now;
            txtLugar.Text = "";
            cmbEstado.SelectedIndex = 0;
        }
    }

    public class Tarea
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public string Lugar { get; set; }
        public string Estado { get; set; }
    }
}