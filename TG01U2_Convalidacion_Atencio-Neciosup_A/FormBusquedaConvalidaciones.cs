using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TG01U2_Convalidacion_Atencio_Neciosup_A.Repositorios;
using TG01U2_Convalidacion_Atencio_Neciosup_A.Servicios;

namespace TG01U2_Convalidacion_Atencio_Neciosup_A
{
    public partial class FormBusquedaConvalidaciones : Form
    {
        private List<Convalidacion> todasLasConvalidaciones;

        private ConvalidacionService _convalidacionService;

        public FormBusquedaConvalidaciones()
        {
            InitializeComponent();
            var repositorio = new RepositorioFicherosCsv(
                Configuracion.ConstantesApp.ArchivoConvalidaciones,
                Configuracion.ConstantesApp.ArchivoCursosConvalidados,
                Configuracion.ConstantesApp.ArchivoPlanEstudios
            );
            _convalidacionService = new ConvalidacionService(repositorio);

            // Definir columnas del DataGridView
            dgvResultados.Columns.Add("IdConvalidacion", "ID");
            dgvResultados.Columns.Add("NombreEstudiante", "Estudiante");
            dgvResultados.Columns.Add("PaisOrigen", "País");
            dgvResultados.Columns.Add("UniversidadOrigen", "Universidad");
            dgvResultados.Columns.Add("Anio", "Año");
            dgvResultados.Columns.Add("Semestre", "Semestre");
            dgvResultados.Columns.Add("TotalCreditos", "Créditos");
            CargarConvalidaciones();
        }

        private void CargarConvalidaciones()
        {
            try
            {
                todasLasConvalidaciones = _convalidacionService.ObtenerConvalidaciones();
                if (todasLasConvalidaciones == null)
                {
                    todasLasConvalidaciones = new List<Convalidacion>();
                }
                CargarAniosComboBox();
                MostrarResultados(todasLasConvalidaciones);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar convalidaciones: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarAniosComboBox()
        {
            if (cmbAnio == null) return;

            cmbAnio.Items.Clear();
            cmbAnio.Items.Add("Todos");

            if (todasLasConvalidaciones != null && todasLasConvalidaciones.Count > 0)
            {
                var anios = todasLasConvalidaciones
                    .Select(c => c.Anio)
                    .Distinct()
                    .OrderByDescending(a => a)
                    .ToList();

                foreach (var a in anios)
                {
                    cmbAnio.Items.Add(a.ToString());
                }
            }

            if (cmbAnio.Items.Count > 0)
            {
                cmbAnio.SelectedIndex = 0;
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                List<Convalidacion> resultados = todasLasConvalidaciones
                    .FiltrarPorEstudiante(txtNombreEstudiante.Text)
                    .FiltrarPorPais(cmbPais.SelectedIndex, cmbPais.Text)
                    .FiltrarPorUniversidad(txtUniversidad.Text)
                    .FiltrarPorId(txtIdConvalidacion.Text)
                    .FiltrarPorAnio(cmbAnio.SelectedIndex, cmbAnio.Text)
                    .ToList();

                MostrarResultados(resultados);
                lblResultados.Text = $"Resultados de la Búsqueda ({resultados.Count} registros encontrados)";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la búsqueda: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombreEstudiante.Clear();
            txtUniversidad.Clear();
            txtIdConvalidacion.Clear();
            cmbPais.SelectedIndex = 0;
            cmbAnio.SelectedIndex = 0;
            MostrarResultados(todasLasConvalidaciones);
            lblResultados.Text = "Resultados de la Búsqueda:";
        }

        private void MostrarResultados(List<Convalidacion> convalidaciones)
        {
            dgvResultados.Rows.Clear();
            foreach (var conv in convalidaciones)
            {
                dgvResultados.Rows.Add(
                    conv.IdConvalidacion,
                    conv.NombreEstudiante,
                    conv.PaisOrigen,
                    conv.UniversidadOrigen,
                    conv.Anio,
                    conv.Semestre,
                    conv.TotalCreditos
                );
            }
        }
    }
}
