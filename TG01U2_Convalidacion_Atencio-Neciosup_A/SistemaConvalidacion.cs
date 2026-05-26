using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TG01U2_Convalidacion_Atencio_Neciosup_A.Servicios;

namespace TG01U2_Convalidacion_Atencio_Neciosup_A
{
    public partial class SistemaConvalidacion : Form
    {
        private Convalidacion convalidacionActual;
        private List<Convalidacion> historialConvalidaciones;
        private List<Curso> planDeEstudios;

        private ConvalidacionService _convalidacionService;

        // Variables para rastrear ediciones
        private int filaEnEdicion = -1;
        private string cursoEnEdicion = "";

        public SistemaConvalidacion()
        {
            InitializeComponent();
            var repositorio = new Repositorios.RepositorioFicherosCsv(
                Configuracion.ConstantesApp.ArchivoConvalidaciones,
                Configuracion.ConstantesApp.ArchivoCursosConvalidados,
                Configuracion.ConstantesApp.ArchivoPlanEstudios
            );
            _convalidacionService = new Servicios.ConvalidacionService(repositorio);

            AsignarEventosManuales();
            InicializarDatos();
        }

        private void cmbCursosUPT_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Evento vacío para no generar errores
        }

        private void txtSemestre_TextChanged(object sender, EventArgs e)
        {
            // Evento vacío para no generar errores
        }

        private void AsignarEventosManuales()
        {
            this.btnAgregarCurso.Click += new System.EventHandler(this.btnAgregarCurso_Click);
            this.btnGuardarConvalidacion.Click += new System.EventHandler(this.btnGuardarConvalidacion_Click);
            this.btnEliminarCurso.Click += new System.EventHandler(this.btnEliminarCurso_Click);
            this.btnLimpiarFormulario.Click += new System.EventHandler(this.btnLimpiarFormulario_Click);
        }

        private void InicializarDatos()
        {
            convalidacionActual = new Convalidacion();
            historialConvalidaciones = _convalidacionService.ObtenerConvalidaciones();

            // AHORA LEE DESDE EL OBTENEDOR
            planDeEstudios = _convalidacionService.ObtenerPlanEstudios();

            cmbCursosUPT.DataSource = planDeEstudios;
            cmbCursosUPT.DisplayMember = "Nombre";

            if (cmbPais.Items.Count > 0) cmbPais.SelectedIndex = 0;

            if (this.Controls.ContainsKey("txtTotal"))
            {
                TextBox txtT = (TextBox)this.Controls["txtTotal"];
                txtT.ReadOnly = true;
                txtT.Text = "0";
            }

            ConfigurarDataGridView();
        }

        /// <summary>
        /// Configura el DataGridView para permitir edición y mostrar datos de manera adecuada
        /// </summary>
        private void ConfigurarDataGridView()
        {
            dgvCursos.AllowUserToAddRows = false;
            dgvCursos.AllowUserToDeleteRows = false;
            dgvCursos.EditMode = DataGridViewEditMode.EditOnKeystroke;
            dgvCursos.AutoGenerateColumns = false;
            dgvCursos.Columns.Clear();

            // Agregar columnas manualmente
            dgvCursos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Codigo",
                HeaderText = "Código",
                DataPropertyName = "Codigo",
                ReadOnly = true
            });

            dgvCursos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Nombre",
                HeaderText = "Asignatura",
                DataPropertyName = "Nombre",
                ReadOnly = true,
                Width = 250
            });

            dgvCursos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Creditos",
                HeaderText = "Créditos",
                DataPropertyName = "Creditos",
                ReadOnly = true
            });

            dgvCursos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NotaExtranjera",
                HeaderText = "Nota Extranjera",
                DataPropertyName = "NotaExtranjera"
            });

            dgvCursos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NotaPeruana",
                HeaderText = "Nota Perú",
                DataPropertyName = "NotaPeruana",
                ReadOnly = true
            });

            dgvCursos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        /// <summary>
        /// Valida que todos los datos requeridos del estudiante estén completos
        /// </summary>
        private bool ValidarDatosEstudiante()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingrese el nombre del estudiante.", "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtUniversidad.Text))
            {
                MessageBox.Show("Ingrese la universidad de origen.", "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUniversidad.Focus();
                return false;
            }

            if (cmbPais.SelectedIndex <= 0)
            {
                MessageBox.Show("Seleccione el país de origen.", "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbPais.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAnio.Text))
            {
                MessageBox.Show("Ingrese el año académico.", "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAnio.Focus();
                return false;
            }

            if (!int.TryParse(txtAnio.Text, out int anio) || anio < 2000 || anio > DateTime.Now.Year)
            {
                MessageBox.Show("Ingrese un año válido (entre 2000 y " + DateTime.Now.Year + ").", "Año Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAnio.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSemestre.Text))
            {
                MessageBox.Show("Ingrese el semestre.", "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSemestre.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Valida que la nota ingresada esté dentro del rango permitido para el país seleccionado
        /// </summary>
        private bool ValidarNotaPais(string pais, double nota, out double limInfExt, out double limSupExt, out double limInfPeru, out double limSupPeru)
        {
            limInfExt = 0;
            limSupExt = 0;
            limInfPeru = 0;
            limSupPeru = 0;

            double notaMaximaPais = ObtenerNotaMaximaPais(pais);
            if (nota < 0 || nota > notaMaximaPais)
            {
                MessageBox.Show($"La nota debe estar entre 0 y {notaMaximaPais} para {pais}.", "Nota Fuera de Rango", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return ObtenerLimitesEquivalencia(pais, nota, ref limInfExt, ref limSupExt, ref limInfPeru, ref limSupPeru);
        }

        /// <summary>
        /// Valida que el curso no esté duplicado en la lista actual
        /// </summary>
        private bool ValidarCursoDuplicado(Curso curso)
        {
            foreach (var cursoExistente in convalidacionActual.CursosConvalidados)
            {
                if (cursoExistente.Codigo == curso.Codigo)
                {
                    MessageBox.Show($"El curso '{curso.Nombre}' ya ha sido agregado a esta convalidación.", "Curso Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }

        private void btnAgregarCurso_Click(object sender, EventArgs e)
        {
            // Validar que haya datos del estudiante
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Primero ingrese el nombre del estudiante.", "Información Incompleta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            if (cmbCursosUPT.SelectedItem is Curso cursoSeleccionado)
            {
                // Validar nota
                if (string.IsNullOrWhiteSpace(txtNotaExtranjera.Text))
                {
                    MessageBox.Show("Ingrese la nota obtenida.", "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNotaExtranjera.Focus();
                    return;
                }

                if (!double.TryParse(txtNotaExtranjera.Text, out double notaExt))
                {
                    MessageBox.Show("Ingrese una nota válida (número decimal).", "Nota Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNotaExtranjera.Focus();
                    return;
                }

                string pais = cmbPais.Text;

                // Validar rango de nota para el país
                if (!ValidarNotaPais(pais, notaExt, out double limInfExt, out double limSupExt, out double limInfPeru, out double limSupPeru))
                {
                    MessageBox.Show($"La nota ingresada no coincide con los rangos de equivalencia para {pais}.", "Error de Rango", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNotaExtranjera.Focus();
                    return;
                }

                // Validar que no sea duplicado
                if (!ValidarCursoDuplicado(cursoSeleccionado))
                {
                    cmbCursosUPT.Focus();
                    return;
                }

                // Crear el nuevo curso con equivalencia de nota
                Curso nuevoCurso = new Curso(cursoSeleccionado.Codigo, cursoSeleccionado.Nombre, cursoSeleccionado.Creditos);
                nuevoCurso.NotaExtranjera = notaExt;
                nuevoCurso.NotaPeruana = GestorEquivalencias.CalcularNotaPeru(notaExt, limInfExt, limSupExt, limInfPeru, limSupPeru);

                convalidacionActual.AgregarCurso(nuevoCurso);
                ActualizarFormulario();
                txtNotaExtranjera.Clear();

                MessageBox.Show("Asignatura agregada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Seleccione un curso válido.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Elimina el curso seleccionado del DataGridView
        /// </summary>
        private void btnEliminarCurso_Click(object sender, EventArgs e)
        {
            if (dgvCursos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un curso para eliminar.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int indiceSeleccionado = dgvCursos.SelectedRows[0].Index;

            if (indiceSeleccionado >= 0 && indiceSeleccionado < convalidacionActual.CursosConvalidados.Count)
            {
                var cursoAEliminar = convalidacionActual.CursosConvalidados[indiceSeleccionado];

                DialogResult resultado = MessageBox.Show(
                    $"¿Está seguro de que desea eliminar el curso '{cursoAEliminar.Nombre}'?",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    convalidacionActual.CursosConvalidados.RemoveAt(indiceSeleccionado);
                    ActualizarFormulario();
                    MessageBox.Show("Curso eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        /// <summary>
        /// Limpia el formulario para registrar una nueva convalidación
        /// </summary>
        private void btnLimpiarFormulario_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "¿Desea limpiar el formulario para registrar un nuevo estudiante?",
                "Confirmar Limpieza",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                convalidacionActual = new Convalidacion();
                txtNombre.Clear();
                txtUniversidad.Clear();
                txtAnio.Clear();
                txtSemestre.Clear();
                txtNotaExtranjera.Clear();
                if (cmbPais.Items.Count > 0) cmbPais.SelectedIndex = 0;
                ActualizarFormulario();
                txtNombre.Focus();
            }
        }

        /// <summary>
        /// Maneja la finalización de edición en las celdas del DataGridView
        /// </summary>
        private void dgvCursos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Si se está editando la columna de NotaExtranjera
            if (e.ColumnIndex == dgvCursos.Columns["NotaExtranjera"].Index && e.RowIndex >= 0)
            {
                try
                {
                    var celda = dgvCursos[e.ColumnIndex, e.RowIndex];

                    if (celda.Value != null && double.TryParse(celda.Value.ToString(), out double nuevaNota))
                    {
                        string pais = cmbPais.Text;

                        // Validar nota
                        if (!ValidarNotaPais(pais, nuevaNota, out double limInfExt, out double limSupExt, out double limInfPeru, out double limSupPeru))
                        {
                            MessageBox.Show($"La nota no es válida para {pais}. Se revertirá al valor anterior.", "Nota Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ActualizarFormulario();
                            return;
                        }

                        // Actualizar la nota en el curso
                        convalidacionActual.CursosConvalidados[e.RowIndex].NotaExtranjera = nuevaNota;
                        convalidacionActual.CursosConvalidados[e.RowIndex].NotaPeruana = GestorEquivalencias.CalcularNotaPeru(
                            nuevaNota, limInfExt, limSupExt, limInfPeru, limSupPeru);

                        ActualizarFormulario();
                        MessageBox.Show("Nota actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Ingrese un valor numérico válido.", "Entrada Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ActualizarFormulario();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar la nota: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ActualizarFormulario();
                }
            }
        }

        private void ActualizarFormulario()
        {
            dgvCursos.DataSource = null;
            dgvCursos.DataSource = convalidacionActual.CursosConvalidados;

            if (this.Controls.ContainsKey("txtTotal"))
                this.Controls["txtTotal"].Text = convalidacionActual.TotalCreditos.ToString();

            // Renombrar columnas en español si es necesario
            if (dgvCursos.Columns.Count > 0)
            {
                if (dgvCursos.Columns.Contains("Codigo"))
                    dgvCursos.Columns["Codigo"].HeaderText = "Código";
                if (dgvCursos.Columns.Contains("Nombre"))
                    dgvCursos.Columns["Nombre"].HeaderText = "Asignatura";
                if (dgvCursos.Columns.Contains("Creditos"))
                    dgvCursos.Columns["Creditos"].HeaderText = "Créditos";
                if (dgvCursos.Columns.Contains("NotaExtranjera"))
                    dgvCursos.Columns["NotaExtranjera"].HeaderText = "Nota Extranjera";
                if (dgvCursos.Columns.Contains("NotaPeruana"))
                    dgvCursos.Columns["NotaPeruana"].HeaderText = "Nota Perú";
            }
        }

        private void btnGuardarConvalidacion_Click(object sender, EventArgs e)
        {
            // Validar datos del estudiante
            if (!ValidarDatosEstudiante())
                return;

            // Validar que al menos haya un curso
            if (convalidacionActual.CursosConvalidados.Count == 0)
            {
                MessageBox.Show("Agregue al menos un curso antes de guardar.", "Información Incompleta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar que el nombre no tenga caracteres inválidos
            if (txtNombre.Text.Length > 100)
            {
                MessageBox.Show("El nombre del estudiante es demasiado largo (máximo 100 caracteres).", "Nombre Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                convalidacionActual.NombreEstudiante = txtNombre.Text.Trim();
                convalidacionActual.PaisOrigen = cmbPais.Text;
                convalidacionActual.UniversidadOrigen = txtUniversidad.Text.Trim();

                if (int.TryParse(txtAnio.Text, out int anio))
                    convalidacionActual.Anio = anio;
                else
                    convalidacionActual.Anio = DateTime.Now.Year;

                convalidacionActual.Semestre = txtSemestre.Text.Trim();

                historialConvalidaciones.Add(convalidacionActual);
                _convalidacionService.GuardarConvalidaciones(historialConvalidaciones);

                MessageBox.Show(
                    $"Convalidación guardada exitosamente.\n\nID: {convalidacionActual.IdConvalidacion}\n" +
                    $"Estudiante: {convalidacionActual.NombreEstudiante}\n" +
                    $"Créditos: {convalidacionActual.TotalCreditos}",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Limpiar formulario para nuevo registro
                convalidacionActual = new Convalidacion();
                txtNombre.Clear();
                txtUniversidad.Clear();
                txtAnio.Clear();
                txtSemestre.Clear();
                txtNotaExtranjera.Clear();
                if (cmbPais.Items.Count > 0) cmbPais.SelectedIndex = 0;
                ActualizarFormulario();
                txtNombre.Focus();
            }
            catch (Exception ex)
            {
                // Revertir la adición en caso de error
                historialConvalidaciones.Remove(convalidacionActual);
                MessageBox.Show($"Error al guardar: {ex.Message}\n\nDetalles: {ex.InnerException?.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private double ObtenerNotaMaximaPais(string pais)
        {
            return EquivalenciasNotaManager.ObtenerNotaMaximaPais(pais);
        }

        private bool ObtenerLimitesEquivalencia(string pais, double nota, ref double lIE, ref double lSE, ref double lIP, ref double lSP)
        {
            return EquivalenciasNotaManager.ObtenerLimitesEquivalencia(pais, nota, ref lIE, ref lSE, ref lIP, ref lSP);
        }
    }
}