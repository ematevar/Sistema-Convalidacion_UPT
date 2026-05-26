using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using TG01U2_Convalidacion_Atencio_Neciosup_A.Repositorios;
using TG01U2_Convalidacion_Atencio_Neciosup_A.Servicios;

namespace TG01U2_Convalidacion_Atencio_Neciosup_A
{
    public partial class FormEstadisticas : Form
    {
        private List<Convalidacion> historialDatos;
        private ConvalidacionService _convalidacionService;

        public FormEstadisticas()
        {
            InitializeComponent();
            var repositorio = new RepositorioFicherosCsv(
                Configuracion.ConstantesApp.ArchivoConvalidaciones,
                Configuracion.ConstantesApp.ArchivoCursosConvalidados,
                Configuracion.ConstantesApp.ArchivoPlanEstudios
            );
            _convalidacionService = new ConvalidacionService(repositorio);

            ConfigurarEventos();
            CargarDatos();
        }

        private void ConfigurarEventos()
        {
            cmbFiltro.SelectedIndex = 0;
            cmbFiltro.SelectedIndexChanged += CmbFiltro_SelectedIndexChanged;
        }

        private void CargarDatos()
        {
            historialDatos = _convalidacionService.ObtenerConvalidaciones();
            lblTotal.Text = $"Total Convalidaciones Históricas: {historialDatos.Count}";
            GenerarReporte(cmbFiltro.Text);
        }

        private void CmbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            GenerarReporte(cmbFiltro.Text);
        }

        private void GenerarReporte(string filtro)
        {
            if (historialDatos == null || historialDatos.Count == 0) return;

            // Agrupa la información según lo que pida el usuario
            var query = historialDatos.GroupBy(c => c.PaisOrigen)
                                      .Select(g => new { Criterio = g.Key, Cantidad = g.Count() }).ToList();

            if (filtro == "Por País")
                query = historialDatos.GroupBy(c => c.PaisOrigen).Select(g => new { Criterio = g.Key, Cantidad = g.Count() }).ToList();
            else if (filtro == "Por Universidad")
                query = historialDatos.GroupBy(c => c.UniversidadOrigen).Select(g => new { Criterio = g.Key, Cantidad = g.Count() }).ToList();
            else if (filtro == "Por Año")
                query = historialDatos.GroupBy(c => c.Anio.ToString()).Select(g => new { Criterio = g.Key, Cantidad = g.Count() }).ToList();
            else if (filtro == "Por Semestre")
                query = historialDatos.GroupBy(c => c.Semestre).Select(g => new { Criterio = g.Key, Cantidad = g.Count() }).ToList();
            else if (filtro == "Por Estudiante")
                query = historialDatos.GroupBy(c => c.NombreEstudiante).Select(g => new { Criterio = g.Key, Cantidad = g.Count() }).ToList();

            // Llena la tabla
            dgvConsultas.DataSource = query;
            dgvConsultas.Columns["Criterio"].HeaderText = filtro.Replace("Por ", "");

            // Dibuja el gráfico con OxyPlot
            var plotModel = new PlotModel { Title = $"Estadísticas {filtro}" };

            var categoryAxis = new OxyPlot.Axes.CategoryAxis { Position = OxyPlot.Axes.AxisPosition.Left };
            var valueAxis = new OxyPlot.Axes.LinearAxis { Position = OxyPlot.Axes.AxisPosition.Bottom };

            plotModel.Axes.Add(categoryAxis);
            plotModel.Axes.Add(valueAxis);

            var series = new OxyPlot.Series.BarSeries { Title = "Cantidad" };

            foreach (var item in query)
            {
                categoryAxis.Labels.Add(item.Criterio);
                series.Items.Add(new BarItem { Value = item.Cantidad });
            }

            plotModel.Series.Add(series);
            graficoEstadistico.Model = plotModel;
        }
    }
}