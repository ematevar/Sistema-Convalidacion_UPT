// ============================================================
// ARCHIVO: Servicios/ExportService.cs
// 
// Servicio de exportación de convalidaciones
// - Excel: Exportación funcional con ClosedXML
// - PDF: Mensajes de prueba (placeholder para desarrollo)
// ============================================================

using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace TG01U2_Convalidacion_Atencio_Neciosup_A.Servicios
{
    public static class ExportService
    {
        // ─── Carpeta de destino ───────────────────────────────────────────────────
        private static string CarpetaExportar =>
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Exportaciones");

        private static string AsegurarCarpeta()
        {
            Directory.CreateDirectory(CarpetaExportar);
            return CarpetaExportar;
        }

        // =========================================================================
        //  EXCEL — Lista de convalidaciones
        // =========================================================================

        /// <summary>
        /// Exporta la lista de convalidaciones a un archivo .xlsx y devuelve la ruta.
        /// </summary>
        public static string ExportarListaExcel(List<Convalidacion> convalidaciones)
        {
            string ruta = Path.Combine(AsegurarCarpeta(),
                $"Lista_Convalidaciones_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx");

            using var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Convalidaciones");

            // ── Encabezado ────────────────────────────────────────────────────
            string[] cabeceras =
            {
                "ID Convalidación", "Código Estudiante", "Nombre Estudiante",
                "País Origen", "Universidad Origen", "Año", "Semestre",
                "Total Créditos", "Cantidad Cursos"
            };

            for (int col = 0; col < cabeceras.Length; col++)
            {
                var cell = ws.Cell(1, col + 1);
                cell.Value = cabeceras[col];
                cell.Style.Font.Bold = true;
                cell.Style.Fill.BackgroundColor = XLColor.FromHtml("#1F4E79");
                cell.Style.Font.FontColor = XLColor.White;
                cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            }

            // ── Datos ─────────────────────────────────────────────────────────
            int fila = 2;
            foreach (var c in convalidaciones)
            {
                ws.Cell(fila, 1).Value = c.IdConvalidacion;
                ws.Cell(fila, 2).Value = c.CodigoEstudiante;
                ws.Cell(fila, 3).Value = c.NombreEstudiante;
                ws.Cell(fila, 4).Value = c.PaisOrigen;
                ws.Cell(fila, 5).Value = c.UniversidadOrigen;
                ws.Cell(fila, 6).Value = c.Anio;
                ws.Cell(fila, 7).Value = c.Semestre;
                ws.Cell(fila, 8).Value = c.TotalCreditos;
                ws.Cell(fila, 9).Value = c.CursosConvalidados.Count;

                // Alternar colores de fila
                if (fila % 2 == 0)
                {
                    ws.Row(fila).Cells(1, cabeceras.Length)
                       .Style.Fill.BackgroundColor = XLColor.FromHtml("#D9E1F2");
                }

                fila++;
            }

            // ── Fila de totales ───────────────────────────────────────────────
            ws.Cell(fila, 1).Value = "TOTAL";
            ws.Cell(fila, 1).Style.Font.Bold = true;
            ws.Cell(fila, 8).FormulaA1 = $"=SUM(H2:H{fila - 1})";
            ws.Cell(fila, 8).Style.Font.Bold = true;
            ws.Cell(fila, 9).FormulaA1 = $"=SUM(I2:I{fila - 1})";
            ws.Cell(fila, 9).Style.Font.Bold = true;

            ws.Columns().AdjustToContents();

            // ── Hoja de detalle de cursos ─────────────────────────────────────
            var wsCursos = wb.Worksheets.Add("Detalle Cursos");
            string[] cabCursos =
            {
                "ID Convalidación", "Código Est.", "Estudiante",
                "Código Curso", "Nombre Curso", "Créditos",
                "Nota Extranjera", "Nota Peruana"
            };
            for (int col = 0; col < cabCursos.Length; col++)
            {
                var cell = wsCursos.Cell(1, col + 1);
                cell.Value = cabCursos[col];
                cell.Style.Font.Bold = true;
                cell.Style.Fill.BackgroundColor = XLColor.FromHtml("#1F4E79");
                cell.Style.Font.FontColor = XLColor.White;
            }

            int filaCurso = 2;
            foreach (var c in convalidaciones)
            {
                foreach (var curso in c.CursosConvalidados)
                {
                    wsCursos.Cell(filaCurso, 1).Value = c.IdConvalidacion;
                    wsCursos.Cell(filaCurso, 2).Value = c.CodigoEstudiante;
                    wsCursos.Cell(filaCurso, 3).Value = c.NombreEstudiante;
                    wsCursos.Cell(filaCurso, 4).Value = curso.Codigo;
                    wsCursos.Cell(filaCurso, 5).Value = curso.Nombre;
                    wsCursos.Cell(filaCurso, 6).Value = curso.Creditos;
                    wsCursos.Cell(filaCurso, 7).Value = curso.NotaExtranjera;
                    wsCursos.Cell(filaCurso, 8).Value = curso.NotaPeruana;
                    filaCurso++;
                }
            }
            wsCursos.Columns().AdjustToContents();

            wb.SaveAs(ruta);
            return ruta;
        }

        // =========================================================================
        //  PDF — Lista de convalidaciones (PRUEBA)
        // =========================================================================

        /// <summary>
        /// Muestra un mensaje indicando que la exportación a PDF es exitosa.
        /// Esta es una versión de prueba/placeholder.
        /// </summary>
        public static string ExportarListaPdf(List<Convalidacion> convalidaciones)
        {
            string mensaje = $" Exportación a PDF exitosa\n\n" +
                $"Tipo: Lista de Convalidaciones\n" +
                $"Total de registros: {convalidaciones.Count}\n" +
                $"Formato: PDF (A4 Horizontal)\n\n" +
                $"Nota: Este es un mensaje de prueba.\n" +
                $"La función de PDF estará disponible en futuras versiones.";

            MessageBox.Show(mensaje, "Exportación PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Retornar una ruta ficticia
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Exportaciones", 
                $"Lista_Convalidaciones_{DateTime.Now:yyyyMMdd_HHmmss}.pdf");
        }

        // =========================================================================
        //  PDF — Ficha individual de un estudiante (PRUEBA)
        // =========================================================================

        /// <summary>
        /// Muestra un mensaje indicando que la exportación a PDF es exitosa.
        /// Esta es una versión de prueba/placeholder.
        /// </summary>
        public static string ExportarFichaPdf(Convalidacion convalidacion)
        {
            string mensaje = $" Exportación a PDF exitosa\n\n" +
                $"Tipo: Ficha Individual\n" +
                $"Estudiante: {convalidacion.NombreEstudiante}\n" +
                $"Código: {convalidacion.CodigoEstudiante}\n" +
                $"Cursos: {convalidacion.CursosConvalidados.Count}\n\n" +
                $"Nota: Este es un mensaje de prueba.\n" +
                $"La función de PDF estará disponible en futuras versiones.";

            MessageBox.Show(mensaje, "Exportación PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Retornar una ruta ficticia
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Exportaciones",
                $"Ficha_{convalidacion.CodigoEstudiante}_{convalidacion.IdConvalidacion}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf");
        }
    }
}
