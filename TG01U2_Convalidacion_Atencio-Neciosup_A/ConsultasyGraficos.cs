using System;
using System.Windows.Forms;

namespace TG01U2_Convalidacion_Atencio_Neciosup_A
{
    public partial class ConsultasyGraficos : Form
    {
        public ConsultasyGraficos()
        {
            InitializeComponent();
            ConfigurarMenu();
        }

        private void ConfigurarMenu()
        {
            btnConvalidaciones.Click += (s, e) => AbrirFormulario(new SistemaConvalidacion());
            btnEstadisticas.Click += (s, e) => AbrirFormulario(new FormEstadisticas());
            btnBusqueda.Click += (s, e) => AbrirFormulario(new FormBusquedaConvalidaciones());
            btnSalir.Click += (s, e) => this.Close();
        }

        private void AbrirFormulario(Form formularioHijo)
        {
            this.Hide(); // Ocultamos el menú principal

            formularioHijo.StartPosition = FormStartPosition.CenterScreen;
            formularioHijo.FormClosed += (s, args) => this.Show(); // Mostramos el menú cuando se cierre el hijo
            formularioHijo.Show();
        }
    }
}
