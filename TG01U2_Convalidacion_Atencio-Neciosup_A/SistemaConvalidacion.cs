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
            // 
        }

        private void txtSemestre_TextChanged(object sender, EventArgs e)
        {
            // 
        }

        

        private void AsignarEventosManuales()
        {
            this.btnAgregarCurso.Click += new System.EventHandler(this.btnAgregarCurso_Click);
            this.btnGuardarConvalidacion.Click += new System.EventHandler(this.btnGuardarConvalidacion_Click);
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
        }

        private void btnAgregarCurso_Click(object sender, EventArgs e)
        {
            if (cmbCursosUPT.SelectedItem is Curso cursoSeleccionado)
            {
                if (double.TryParse(txtNotaExtranjera.Text, out double notaExt))
                {
                    string pais = cmbPais.Text;

                    // Validar que la nota esté dentro del rango permitido para el país
                    double notaMaximaPais = ObtenerNotaMaximaPais(pais);
                    if (notaExt < 0 || notaExt > notaMaximaPais)
                    {
                        MessageBox.Show($"La nota debe estar entre 0 y {notaMaximaPais} para {pais}.", "Nota Fuera de Rango", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    double limInfExt = 0, limSupExt = 0, limInfPeru = 0, limSupPeru = 0;
                    bool rangoEncontrado = ObtenerLimitesEquivalencia(pais, notaExt, ref limInfExt, ref limSupExt, ref limInfPeru, ref limSupPeru);

                    if (!rangoEncontrado)
                    {
                        MessageBox.Show("La nota ingresada no coincide con los rangos.", "Error de Rango", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    Curso nuevoCurso = new Curso(cursoSeleccionado.Codigo, cursoSeleccionado.Nombre, cursoSeleccionado.Creditos);
                    nuevoCurso.NotaExtranjera = notaExt;
                    nuevoCurso.NotaPeruana = GestorEquivalencias.CalcularNotaPeru(notaExt, limInfExt, limSupExt, limInfPeru, limSupPeru);

                    convalidacionActual.AgregarCurso(nuevoCurso);
                    ActualizarFormulario();
                    txtNotaExtranjera.Clear();
                }
                else
                {
                    MessageBox.Show("Ingrese una nota válida.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
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

        private void ActualizarFormulario()
        {
            dgvCursos.DataSource = null;
            dgvCursos.DataSource = convalidacionActual.CursosConvalidados;

            if (this.Controls.ContainsKey("txtTotal"))
                this.Controls["txtTotal"].Text = convalidacionActual.TotalCreditos.ToString();

            // Renombrar columnas en español
            if (dgvCursos.Columns.Count > 0)
            {
                dgvCursos.Columns["Codigo"].HeaderText = "Código";
                dgvCursos.Columns["Nombre"].HeaderText = "Asignatura";
                dgvCursos.Columns["Creditos"].HeaderText = "Créditos";
                dgvCursos.Columns["NotaExtranjera"].HeaderText = "Nota extranjera";
                dgvCursos.Columns["NotaPeruana"].HeaderText = "Nota Perú";
            }
        }

        private void btnGuardarConvalidacion_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || convalidacionActual.CursosConvalidados.Count == 0)
            {
                MessageBox.Show("Complete el nombre y registre al menos un curso.", "Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            convalidacionActual.NombreEstudiante = txtNombre.Text;
            convalidacionActual.PaisOrigen = cmbPais.Text;
            convalidacionActual.UniversidadOrigen = txtUniversidad.Text;

            int.TryParse(txtAnio.Text, out int anio);
            convalidacionActual.Anio = anio == 0 ? 2026 : anio;
            convalidacionActual.Semestre = txtSemestre.Text;

            try
            {
                historialConvalidaciones.Add(convalidacionActual);
                _convalidacionService.GuardarConvalidaciones(historialConvalidaciones);

                MessageBox.Show("Convalidación guardada.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                convalidacionActual = new Convalidacion();
                txtNombre.Clear();
                txtUniversidad.Clear();
                txtAnio.Clear();
                txtSemestre.Clear();
                ActualizarFormulario();
            }
            catch (Exception ex)
            {
                // Revertimos la adición en caso de error
                historialConvalidaciones.Remove(convalidacionActual);
                MessageBox.Show(ex.Message, "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
