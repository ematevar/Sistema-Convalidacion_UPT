using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TG01U2_Convalidacion_Atencio_Neciosup_A.Servicios;
using TG01U2_Convalidacion_Atencio_Neciosup_A.Validaciones;

namespace TG01U2_Convalidacion_Atencio_Neciosup_A
{
    public partial class SistemaConvalidacion : Form
    {
        private Convalidacion _convalidacionActual;
        private List<Convalidacion> _historialConvalidaciones;
        private readonly ConvalidacionService _convalidacionService;

        public SistemaConvalidacion()
        {
            InitializeComponent();
            var repositorio = new Repositorios.RepositorioFicherosCsv(
                Configuracion.ConstantesApp.ArchivoConvalidaciones,
                Configuracion.ConstantesApp.ArchivoCursosConvalidados,
                Configuracion.ConstantesApp.ArchivoPlanEstudios
            );
            _convalidacionService = new ConvalidacionService(repositorio);

            AsignarEventos();
            InicializarDatos();
        }

        // ─── Inicialización ───────────────────────────────────────────────────────

        private void AsignarEventos()
        {
            btnAgregarCurso.Click += btnAgregarCurso_Click;
            btnGuardarConvalidacion.Click += btnGuardarConvalidacion_Click;
            btnEliminarCurso.Click += btnEliminarCurso_Click;
            btnLimpiarFormulario.Click += btnLimpiarFormulario_Click;
            dgvCursos.CellEndEdit += dgvCursos_CellEndEdit;
        }

        private void InicializarDatos()
        {
            _convalidacionActual = new Convalidacion();
            _historialConvalidaciones = _convalidacionService.ObtenerConvalidaciones();

            var planDeEstudios = _convalidacionService.ObtenerPlanEstudios();
            cmbCursosUPT.DataSource = planDeEstudios;
            cmbCursosUPT.DisplayMember = "Nombre";

            ConfigurarDataGridView();
            ActualizarTotalCreditos();
        }

        private void ConfigurarDataGridView()
        {
            dgvCursos.AllowUserToAddRows = false;
            dgvCursos.AllowUserToDeleteRows = false;
            dgvCursos.AutoGenerateColumns = false;
            dgvCursos.EditMode = DataGridViewEditMode.EditOnKeystroke;
            dgvCursos.Columns.Clear();

            dgvCursos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Codigo", HeaderText = "Código", DataPropertyName = "Codigo", ReadOnly = true });
            dgvCursos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Nombre", HeaderText = "Asignatura", DataPropertyName = "Nombre", ReadOnly = true, Width = 250 });
            dgvCursos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Creditos", HeaderText = "Créditos", DataPropertyName = "Creditos", ReadOnly = true });
            dgvCursos.Columns.Add(new DataGridViewTextBoxColumn { Name = "NotaExtranjera", HeaderText = "Nota Extranjera", DataPropertyName = "NotaExtranjera" });
            dgvCursos.Columns.Add(new DataGridViewTextBoxColumn { Name = "NotaPeruana", HeaderText = "Nota Perú", DataPropertyName = "NotaPeruana", ReadOnly = true });

            dgvCursos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // ─── Validaciones ─────────────────────────────────────────────────────────

        private bool ValidarDatosEstudiante()
        {
            var validNombre = ValidadorConvalidaciones.ValidarNombreEstudiante(txtNombre.Text);
            if (!validNombre.esValido)
            {
                MostrarAdvertencia(validNombre.mensaje);
                txtNombre.Focus();
                return false;
            }

            var validUniversidad = ValidadorConvalidaciones.ValidarUniversidad(txtUniversidad.Text);
            if (!validUniversidad.esValido)
            {
                MostrarAdvertencia(validUniversidad.mensaje);
                txtUniversidad.Focus();
                return false;
            }

            var validPais = ValidadorConvalidaciones.ValidarPais(cmbPais.Text);
            if (!validPais.esValido)
            {
                MostrarAdvertencia(validPais.mensaje);
                cmbPais.Focus();
                return false;
            }

            var validAnio = ValidadorConvalidaciones.ValidarAnioAcademico(txtAnio.Text);
            if (!validAnio.esValido)
            {
                MostrarAdvertencia(validAnio.mensaje);
                txtAnio.Focus();
                return false;
            }

            if (cmbSemestre.SelectedIndex < 0)
            {
                MostrarAdvertencia("Seleccione el semestre.");
                cmbSemestre.Focus();
                return false;
            }

            return true;
        }

        private bool ObtenerEquivalencia(string pais, double notaExt,
            out double limInfExt, out double limSupExt,
            out double limInfPeru, out double limSupPeru)
        {
            limInfExt = limSupExt = limInfPeru = limSupPeru = 0;

            double notaMax = EquivalenciasNotaManager.ObtenerNotaMaximaPais(pais);
            var validNota = ValidadorConvalidaciones.ValidarNota(notaExt.ToString(), notaMax);
            if (!validNota.esValido)
            {
                MostrarAdvertencia(validNota.mensaje);
                return false;
            }

            return EquivalenciasNotaManager.ObtenerLimitesEquivalencia(
                pais, notaExt,
                ref limInfExt, ref limSupExt,
                ref limInfPeru, ref limSupPeru);
        }

        // ─── Eventos de botones ───────────────────────────────────────────────────

        private void btnAgregarCurso_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MostrarAdvertencia("Primero ingrese el nombre del estudiante.");
                txtNombre.Focus();
                return;
            }

            if (cmbCursosUPT.SelectedItem is not Curso cursoSeleccionado)
            {
                MostrarAdvertencia("Seleccione un curso válido.");
                return;
            }

            if (!double.TryParse(txtNotaExtranjera.Text, out double notaExt))
            {
                MostrarAdvertencia("Ingrese una nota válida (número decimal).");
                txtNotaExtranjera.Focus();
                return;
            }

            if (!ObtenerEquivalencia(cmbPais.Text, notaExt,
                out double limInfExt, out double limSupExt,
                out double limInfPeru, out double limSupPeru))
                return;

            var validDuplicado = ValidadorConvalidaciones.ValidarCursoDuplicado(
                _convalidacionActual.CursosConvalidados, cursoSeleccionado);
            if (!validDuplicado.esValido)
            {
                MostrarAdvertencia(validDuplicado.mensaje);
                return;
            }

            var nuevoCurso = new Curso(cursoSeleccionado.Codigo, cursoSeleccionado.Nombre, cursoSeleccionado.Creditos)
            {
                NotaExtranjera = notaExt,
                NotaPeruana = GestorEquivalencias.CalcularNotaPeru(notaExt, limInfExt, limSupExt, limInfPeru, limSupPeru)
            };

            _convalidacionActual.AgregarCurso(nuevoCurso);
            ActualizarVistaCursos();
            txtNotaExtranjera.Clear();
            MostrarInfo("Asignatura agregada correctamente.");
        }

        private void btnEliminarCurso_Click(object sender, EventArgs e)
        {
            if (dgvCursos.SelectedRows.Count == 0)
            {
                MostrarAdvertencia("Seleccione un curso para eliminar.");
                return;
            }

            int indice = dgvCursos.SelectedRows[0].Index;
            if (indice < 0 || indice >= _convalidacionActual.CursosConvalidados.Count) return;

            var curso = _convalidacionActual.CursosConvalidados[indice];
            if (ConfirmarAccion($"¿Está seguro de que desea eliminar el curso '{curso.Nombre}'?"))
            {
                _convalidacionActual.CursosConvalidados.RemoveAt(indice);
                ActualizarVistaCursos();
                MostrarInfo("Curso eliminado correctamente.");
            }
        }

        private void btnLimpiarFormulario_Click(object sender, EventArgs e)
        {
            if (ConfirmarAccion("¿Desea limpiar el formulario para registrar un nuevo estudiante?"))
                LimpiarFormulario();
        }

        private void btnGuardarConvalidacion_Click(object sender, EventArgs e)
        {
            if (!ValidarDatosEstudiante()) return;

            if (_convalidacionActual.CursosConvalidados.Count == 0)
            {
                MostrarAdvertencia("Agregue al menos un curso antes de guardar.");
                return;
            }

            try
            {
                _convalidacionActual.NombreEstudiante = txtNombre.Text.Trim();
                _convalidacionActual.PaisOrigen = cmbPais.Text;
                _convalidacionActual.UniversidadOrigen = txtUniversidad.Text.Trim();
                _convalidacionActual.Anio = int.Parse(txtAnio.Text);
                _convalidacionActual.Semestre = cmbSemestre.Text;

                _historialConvalidaciones.Add(_convalidacionActual);
                _convalidacionService.GuardarConvalidaciones(_historialConvalidaciones);

                MostrarInfo(
                    $"Convalidación guardada exitosamente.\n\n" +
                    $"ID: {_convalidacionActual.IdConvalidacion}\n" +
                    $"Estudiante: {_convalidacionActual.NombreEstudiante}\n" +
                    $"Créditos: {_convalidacionActual.TotalCreditos}");

                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                _historialConvalidaciones.Remove(_convalidacionActual);
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─── Edición en grilla ────────────────────────────────────────────────────

        private void dgvCursos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCursos.Columns[e.ColumnIndex].Name != "NotaExtranjera" || e.RowIndex < 0)
                return;

            var celda = dgvCursos[e.ColumnIndex, e.RowIndex];
            if (celda.Value == null || !double.TryParse(celda.Value.ToString(), out double nuevaNota))
            {
                MostrarAdvertencia("Ingrese un valor numérico válido.");
                ActualizarVistaCursos();
                return;
            }

            if (!ObtenerEquivalencia(cmbPais.Text, nuevaNota,
                out double limInfExt, out double limSupExt,
                out double limInfPeru, out double limSupPeru))
            {
                ActualizarVistaCursos();
                return;
            }

            _convalidacionActual.CursosConvalidados[e.RowIndex].NotaExtranjera = nuevaNota;
            _convalidacionActual.CursosConvalidados[e.RowIndex].NotaPeruana =
                GestorEquivalencias.CalcularNotaPeru(nuevaNota, limInfExt, limSupExt, limInfPeru, limSupPeru);

            ActualizarVistaCursos();
            MostrarInfo("Nota actualizada correctamente.");
        }

        // ─── Helpers de UI ────────────────────────────────────────────────────────

        private void ActualizarVistaCursos()
        {
            dgvCursos.DataSource = null;
            dgvCursos.DataSource = _convalidacionActual.CursosConvalidados;
            ActualizarTotalCreditos();
        }

        private void ActualizarTotalCreditos() =>
            txtTotal.Text = _convalidacionActual.TotalCreditos.ToString();

        private void LimpiarFormulario()
        {
            _convalidacionActual = new Convalidacion();
            txtNombre.Clear();
            txtUniversidad.Clear();
            txtAnio.Clear();
            txtNotaExtranjera.Clear();
            cmbSemestre.SelectedIndex = -1;
            if (cmbPais.Items.Count > 0) cmbPais.SelectedIndex = 0;
            ActualizarVistaCursos();
            txtNombre.Focus();
        }

        private static void MostrarAdvertencia(string mensaje) =>
            MessageBox.Show(mensaje, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        private static void MostrarInfo(string mensaje) =>
            MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

        private static bool ConfirmarAccion(string pregunta) =>
            MessageBox.Show(pregunta, "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            == DialogResult.Yes;
    }
}