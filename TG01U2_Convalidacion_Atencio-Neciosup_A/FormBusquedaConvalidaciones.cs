// ============================================================
// ARCHIVO: FormBusquedaConvalidaciones.cs
// CAMBIOS:
//  1. Columna CodigoEstudiante agregada a la grilla
//  2. Filtro por CodigoEstudiante (txtCodigoEstudiante)
//  3. TotalCreditos ahora se muestra correctamente
//  4. Botones de Exportar a Excel y a PDF
// ============================================================

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

            // ─── NUEVO: Filtrar solo números en código de estudiante ────────
            txtCodigoEstudiante.KeyPress += (s, e) =>
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                    e.Handled = true;
            };

            ConfigurarColumnas();
            CargarConvalidaciones();
        }

        // ─── Configurar grilla ────────────────────────────────────────────────────

        private void ConfigurarColumnas()
        {
            dgvResultados.Columns.Clear();
            dgvResultados.Columns.Add("IdConvalidacion",   "ID");
            dgvResultados.Columns.Add("CodigoEstudiante",  "Código");   // ← NUEVO
            dgvResultados.Columns.Add("NombreEstudiante",  "Estudiante");
            dgvResultados.Columns.Add("PaisOrigen",        "País");
            dgvResultados.Columns.Add("UniversidadOrigen", "Universidad");
            dgvResultados.Columns.Add("Anio",              "Año");
            dgvResultados.Columns.Add("Semestre",          "Semestre");
            dgvResultados.Columns.Add("TotalCreditos",     "Créditos");  // ← siempre visible
        }

        // ─── Carga inicial ────────────────────────────────────────────────────────

        private void CargarConvalidaciones()
        {
            try
            {
                todasLasConvalidaciones = _convalidacionService.ObtenerConvalidaciones()
                                         ?? new List<Convalidacion>();
                CargarAniosComboBox();
                MostrarResultados(todasLasConvalidaciones);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar convalidaciones: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarAniosComboBox()
        {
            if (cmbAnio == null) return;
            cmbAnio.Items.Clear();
            cmbAnio.Items.Add("Todos");

            if (todasLasConvalidaciones?.Count > 0)
            {
                foreach (var a in todasLasConvalidaciones
                    .Select(c => c.Anio).Distinct()
                    .OrderByDescending(a => a))
                {
                    cmbAnio.Items.Add(a.ToString());
                }
            }
            if (cmbAnio.Items.Count > 0) cmbAnio.SelectedIndex = 0;
        }

        // ─── Búsqueda ─────────────────────────────────────────────────────────────

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                var resultados = todasLasConvalidaciones
                    .FiltrarPorCodigoEstudiante(txtCodigoEstudiante.Text)  // ← NUEVO
                    .FiltrarPorEstudiante(txtNombreEstudiante.Text)
                    .FiltrarPorPais(cmbPais.SelectedIndex, cmbPais.Text)
                    .FiltrarPorUniversidad(txtUniversidad.Text)
                    .FiltrarPorId(txtIdConvalidacion.Text)
                    .FiltrarPorAnio(cmbAnio.SelectedIndex, cmbAnio.Text)
                    .ToList();

                MostrarResultados(resultados);
                lblResultados.Text =
                    $"Resultados de la Búsqueda ({resultados.Count} registros encontrados)";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la búsqueda: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            txtCodigoEstudiante.Clear();   // ← NUEVO
            txtNombreEstudiante.Clear();
            txtUniversidad.Clear();
            txtIdConvalidacion.Clear();
            cmbPais.SelectedIndex = 0;
            cmbAnio.SelectedIndex = 0;
            MostrarResultados(todasLasConvalidaciones);
            lblResultados.Text = "Resultados de la Búsqueda:";
        }

        // ─── Mostrar resultados ───────────────────────────────────────────────────

        private void MostrarResultados(List<Convalidacion> convalidaciones)
        {
            dgvResultados.Rows.Clear();
            foreach (var conv in convalidaciones)
            {
                dgvResultados.Rows.Add(
                    conv.IdConvalidacion,
                    conv.CodigoEstudiante,   // ← NUEVO
                    conv.NombreEstudiante,
                    conv.PaisOrigen,
                    conv.UniversidadOrigen,
                    conv.Anio,
                    conv.Semestre,
                    conv.TotalCreditos       // ← siempre visible con cursos cargados
                );
            }
        }

        // ─── Exportar ─────────────────────────────────────────────────────────────

        private void BtnExportarExcel_Click(object sender, EventArgs e)
        {
            try
            {
                var filas = ObtenerFilasActuales();
                string ruta = ExportService.ExportarListaExcel(filas);
                MessageBox.Show($"Excel exportado en:\n{ruta}", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar a Excel: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnExportarPdf_Click(object sender, EventArgs e)
        {
            try
            {
                // Si hay una fila seleccionada, exporta la ficha individual;
                // de lo contrario exporta la lista completa visible.
                if (dgvResultados.SelectedRows.Count == 1)
                {
                    string id = dgvResultados.SelectedRows[0]
                                    .Cells["IdConvalidacion"].Value?.ToString();
                    var conv = todasLasConvalidaciones
                                   .FirstOrDefault(c => c.IdConvalidacion == id);
                    if (conv != null)
                    {
                        string ruta = ExportService.ExportarFichaPdf(conv);
                        MessageBox.Show($"PDF de ficha exportado en:\n{ruta}", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                // Lista completa
                var filas = ObtenerFilasActuales();
                string rutaLista = ExportService.ExportarListaPdf(filas);
                MessageBox.Show($"PDF exportado en:\n{rutaLista}", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar a PDF: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Obtiene las filas actualmente visibles en la grilla como lista de Convalidacion.
        /// </summary>
        private List<Convalidacion> ObtenerFilasActuales()
        {
            var ids = new List<string>();
            foreach (DataGridViewRow row in dgvResultados.Rows)
            {
                var id = row.Cells["IdConvalidacion"].Value?.ToString();
                if (!string.IsNullOrEmpty(id)) ids.Add(id);
            }
            return todasLasConvalidaciones
                .Where(c => ids.Contains(c.IdConvalidacion))
                .ToList();
        }
    }
}
