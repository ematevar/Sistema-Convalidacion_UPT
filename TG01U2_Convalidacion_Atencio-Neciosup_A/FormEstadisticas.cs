using System;
using System.Collections.Generic;
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
        private List<Convalidacion> _historialDatos;
        private readonly ConvalidacionService _convalidacionService;

        public FormEstadisticas()
        {
            InitializeComponent();
            var repositorio = new RepositorioFicherosCsv(
                Configuracion.ConstantesApp.ArchivoConvalidaciones,
                Configuracion.ConstantesApp.ArchivoCursosConvalidados,
                Configuracion.ConstantesApp.ArchivoPlanEstudios
            );
            _convalidacionService = new ConvalidacionService(repositorio);

            cmbFiltro.SelectedIndex = 0;
            cmbFiltro.SelectedIndexChanged += (s, e) => GenerarReporte(cmbFiltro.Text);

            CargarDatos();
        }

        // ─── Carga ────────────────────────────────────────────────────────────────

        private void CargarDatos()
        {
            _historialDatos = _convalidacionService.ObtenerConvalidaciones();
            lblTotal.Text = $"Total Convalidaciones: {_historialDatos.Count}";
            GenerarReporte(cmbFiltro.Text);
        }

        // ─── Reporte ──────────────────────────────────────────────────────────────

        private void GenerarReporte(string filtro)
        {
            if (_historialDatos == null || _historialDatos.Count == 0) return;

            var datos = AgruparPorFiltro(filtro);

            dgvConsultas.DataSource = datos;
            if (dgvConsultas.Columns.Contains("Criterio"))
                dgvConsultas.Columns["Criterio"].HeaderText = filtro.Replace("Por ", "");

            DibujarGrafico(filtro, datos);
        }

        private List<ResumenFiltro> AgruparPorFiltro(string filtro) => filtro switch
        {
            "Por Universidad" => Agrupar(c => c.UniversidadOrigen),
            "Por Año" => Agrupar(c => c.Anio.ToString()),
            "Por Semestre" => Agrupar(c => c.Semestre),
            "Por Estudiante" => Agrupar(c => c.NombreEstudiante),
            _ => Agrupar(c => c.PaisOrigen)          // "Por País" es el default
        };

        private List<ResumenFiltro> Agrupar(Func<Convalidacion, string> selector) =>
            _historialDatos
                .GroupBy(selector)
                .Select(g => new ResumenFiltro { Criterio = g.Key ?? "No especificado", Cantidad = g.Count() })
                .OrderByDescending(x => x.Cantidad)
                .ToList();

        private void DibujarGrafico(string titulo, List<ResumenFiltro> datos)
        {
            var modelo = new PlotModel { Title = $"Estadísticas {titulo}" };

            var ejeCategoria = new OxyPlot.Axes.CategoryAxis { Position = OxyPlot.Axes.AxisPosition.Left };
            var ejeValor = new OxyPlot.Axes.LinearAxis { Position = OxyPlot.Axes.AxisPosition.Bottom };
            modelo.Axes.Add(ejeCategoria);
            modelo.Axes.Add(ejeValor);

            var serie = new BarSeries { Title = "Cantidad" };
            foreach (var item in datos)
            {
                ejeCategoria.Labels.Add(item.Criterio);
                serie.Items.Add(new BarItem { Value = item.Cantidad });
            }

            modelo.Series.Add(serie);
            graficoEstadistico.Model = modelo;
        }

        // ─── DTO interno ──────────────────────────────────────────────────────────

        private class ResumenFiltro
        {
            public string Criterio { get; set; }
            public int Cantidad { get; set; }
        }
    }
}