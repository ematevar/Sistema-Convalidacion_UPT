// ============================================================
// ARCHIVO: Repositorios/RepositorioFicherosCsv.cs
// CAMBIO:  Se agrega CodigoEstudiante en lectura/escritura CSV.
//          Nuevo orden de columnas:
//          IdConvalidacion, CodigoEstudiante, NombreEstudiante,
//          PaisOrigen, UniversidadOrigen, Anio, Semestre
// ============================================================

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace TG01U2_Convalidacion_Atencio_Neciosup_A.Repositorios
{
    public class RepositorioFicherosCsv : IRepositorioConvalidaciones
    {
        private readonly string _rutaConvalidaciones;
        private readonly string _rutaCursos;
        private readonly string _rutaPlanEstudios;

        public RepositorioFicherosCsv(string rutaConvalidaciones,
                                      string rutaCursos,
                                      string rutaPlanEstudios)
        {
            _rutaConvalidaciones = rutaConvalidaciones;
            _rutaCursos          = rutaCursos;
            _rutaPlanEstudios    = rutaPlanEstudios;
        }

        // ─── Guardar ──────────────────────────────────────────────────────────────

        public void GuardarConvalidaciones(List<Convalidacion> lista)
        {
            // ── Cabecera con CodigoEstudiante ──────────────────────────────────
            var lineasConv = new List<string>
            {
                "IdConvalidacion,CodigoEstudiante,NombreEstudiante,PaisOrigen,UniversidadOrigen,Anio,Semestre"
            };

            foreach (var c in lista)
            {
                lineasConv.Add(string.Join(",",
                    Escapar(c.IdConvalidacion),
                    Escapar(c.CodigoEstudiante),   // ← NUEVO
                    Escapar(c.NombreEstudiante),
                    Escapar(c.PaisOrigen),
                    Escapar(c.UniversidadOrigen),
                    c.Anio,
                    Escapar(c.Semestre)
                ));
            }
            File.WriteAllLines(_rutaConvalidaciones, lineasConv, Encoding.UTF8);

            // ── Cursos (sin cambios) ───────────────────────────────────────────
            var lineasCursos = new List<string>
            {
                "IdConvalidacion,Codigo,Nombre,Creditos,NotaExtranjera,NotaPeruana"
            };

            foreach (var c in lista)
            {
                foreach (var curso in c.CursosConvalidados)
                {
                    lineasCursos.Add(string.Join(",",
                        Escapar(c.IdConvalidacion),
                        Escapar(curso.Codigo),
                        Escapar(curso.Nombre),
                        curso.Creditos,
                        curso.NotaExtranjera.ToString("F2", CultureInfo.InvariantCulture),
                        curso.NotaPeruana.ToString("F2", CultureInfo.InvariantCulture)
                    ));
                }
            }
            File.WriteAllLines(_rutaCursos, lineasCursos, Encoding.UTF8);
        }

        // ─── Leer ─────────────────────────────────────────────────────────────────

        public List<Convalidacion> LeerConvalidaciones()
        {
            var lista = new List<Convalidacion>();
            if (!File.Exists(_rutaConvalidaciones)) return lista;

            string[] lineasConv = File.ReadAllLines(_rutaConvalidaciones, Encoding.UTF8);

            foreach (string linea in lineasConv.Skip(1))
            {
                if (string.IsNullOrWhiteSpace(linea)) continue;
                string[] p = ParsearLineaCsv(linea);

                // ── Soporte para CSV antiguo (6 columnas) y nuevo (7 columnas) ──
                bool esFormatoNuevo = p.Length >= 7;

                string idConvalidacion;
                string codigoEstudiante;
                string nombreEstudiante;
                string paisOrigen;
                string universidadOrigen;
                string anioStr;
                string semestre;

                if (esFormatoNuevo)
                {
                    // Nuevo: IdConvalidacion, CodigoEstudiante, Nombre, País, Universidad, Año, Semestre
                    idConvalidacion   = p[0];
                    codigoEstudiante  = p[1];
                    nombreEstudiante  = p[2];
                    paisOrigen        = p[3];
                    universidadOrigen = p[4];
                    anioStr           = p[5];
                    semestre          = p[6];
                }
                else if (p.Length >= 6)
                {
                    // Formato antiguo: IdConvalidacion, Nombre, País, Universidad, Año, Semestre
                    idConvalidacion   = p[0];
                    codigoEstudiante  = "";          // campo vacío en datos viejos
                    nombreEstudiante  = p[1];
                    paisOrigen        = p[2];
                    universidadOrigen = p[3];
                    anioStr           = p[4];
                    semestre          = p[5];
                }
                else continue;

                int.TryParse(anioStr, out int anio);

                lista.Add(new Convalidacion
                {
                    IdConvalidacion   = idConvalidacion,
                    CodigoEstudiante  = codigoEstudiante,
                    NombreEstudiante  = nombreEstudiante,
                    PaisOrigen        = paisOrigen,
                    UniversidadOrigen = universidadOrigen,
                    Anio              = anio,
                    Semestre          = semestre
                });
            }

            // ── Cargar cursos asociados ────────────────────────────────────────
            if (File.Exists(_rutaCursos))
            {
                string[] lineasCursos = File.ReadAllLines(_rutaCursos, Encoding.UTF8);
                foreach (string linea in lineasCursos.Skip(1))
                {
                    if (string.IsNullOrWhiteSpace(linea)) continue;
                    string[] p = ParsearLineaCsv(linea);
                    if (p.Length < 6) continue;

                    var padre = lista.FirstOrDefault(c => c.IdConvalidacion == p[0]);
                    if (padre == null) continue;

                    int.TryParse(p[3], out int creditos);
                    double.TryParse(p[4], NumberStyles.Number,
                        CultureInfo.InvariantCulture, out double notaExt);
                    double.TryParse(p[5], NumberStyles.Number,
                        CultureInfo.InvariantCulture, out double notaPeru);

                    padre.CursosConvalidados.Add(new Curso
                    {
                        Codigo         = p[1],
                        Nombre         = p[2],
                        Creditos       = creditos,
                        NotaExtranjera = notaExt,
                        NotaPeruana    = notaPeru
                    });
                }
            }

            return lista;
        }

        // ─── Plan de estudios (sin cambios) ──────────────────────────────────────

        public List<Curso> LeerPlanEstudios()
        {
            var plan = new List<Curso>();
            if (!File.Exists(_rutaPlanEstudios)) return plan;

            string[] lineas = File.ReadAllLines(_rutaPlanEstudios, Encoding.UTF8);
            foreach (string linea in lineas.Skip(1))
            {
                if (string.IsNullOrWhiteSpace(linea)) continue;
                string[] partes = ParsearLineaCsv(linea);
                if (partes.Length < 7) continue;

                string codigo = partes[0].Trim();
                string nombre = partes[2].Trim();
                if (int.TryParse(partes[6].Trim(), out int creditos))
                    plan.Add(new Curso(codigo, nombre, creditos));
            }
            return plan;
        }

        // ─── Helpers privados ─────────────────────────────────────────────────────

        private string Escapar(string campo)
        {
            if (string.IsNullOrEmpty(campo)) return "";
            if (campo.Contains(",") || campo.Contains("\""))
                return "\"" + campo.Replace("\"", "\"\"") + "\"";
            return campo;
        }

        private string[] ParsearLineaCsv(string linea)
        {
            var campos      = new List<string>();
            bool enComillas = false;
            var campoActual = new System.Text.StringBuilder();

            for (int i = 0; i < linea.Length; i++)
            {
                char c = linea[i];
                if (c == '"')
                {
                    if (enComillas && i + 1 < linea.Length && linea[i + 1] == '"')
                    { campoActual.Append('"'); i++; }
                    else enComillas = !enComillas;
                }
                else if (c == ',' && !enComillas)
                { campos.Add(campoActual.ToString()); campoActual.Clear(); }
                else campoActual.Append(c);
            }
            campos.Add(campoActual.ToString());
            return campos.ToArray();
        }
    }
}
