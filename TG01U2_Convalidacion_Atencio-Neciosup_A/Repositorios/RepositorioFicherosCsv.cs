using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TG01U2_Convalidacion_Atencio_Neciosup_A.Repositorios;

namespace TG01U2_Convalidacion_Atencio_Neciosup_A.Repositorios
{
    public class RepositorioFicherosCsv : IRepositorioConvalidaciones
    {
        private readonly string _rutaConvalidaciones;
        private readonly string _rutaCursos;
        private readonly string _rutaPlanEstudios;

        public RepositorioFicherosCsv(string rutaConvalidaciones, string rutaCursos, string rutaPlanEstudios)
        {
            _rutaConvalidaciones = rutaConvalidaciones;
            _rutaCursos = rutaCursos;
            _rutaPlanEstudios = rutaPlanEstudios;
        }

        public void GuardarConvalidaciones(List<Convalidacion> lista)
        {
            var lineasConv = new List<string>
            {
                "IdConvalidacion,NombreEstudiante,PaisOrigen,UniversidadOrigen,Anio,Semestre"
            };
            foreach (var c in lista)
            {
                lineasConv.Add(string.Join(",",
                    Escapar(c.IdConvalidacion),
                    Escapar(c.NombreEstudiante),
                    Escapar(c.PaisOrigen),
                    Escapar(c.UniversidadOrigen),
                    c.Anio,
                    Escapar(c.Semestre)
                ));
            }
            File.WriteAllLines(_rutaConvalidaciones, lineasConv, Encoding.UTF8);

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
                        curso.NotaExtranjera.ToString("F2"),
                        curso.NotaPeruana.ToString("F2")
                    ));
                }
            }
            File.WriteAllLines(_rutaCursos, lineasCursos, Encoding.UTF8);
        }

        public List<Convalidacion> LeerConvalidaciones()
        {
            var lista = new List<Convalidacion>();

            if (!File.Exists(_rutaConvalidaciones))
                return lista;

            string[] lineasConv = File.ReadAllLines(_rutaConvalidaciones, Encoding.UTF8);
            foreach (string linea in lineasConv.Skip(1))
            {
                if (string.IsNullOrWhiteSpace(linea)) continue;
                string[] p = ParsearLineaCsv(linea);
                if (p.Length < 6) continue;

                int.TryParse(p[4], out int anio);
                var conv = new Convalidacion
                {
                    IdConvalidacion = p[0],
                    NombreEstudiante = p[1],
                    PaisOrigen = p[2],
                    UniversidadOrigen = p[3],
                    Anio = anio,
                    Semestre = p[5]
                };
                lista.Add(conv);
            }

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
                    double.TryParse(p[4], out double notaExt);
                    double.TryParse(p[5], out double notaPeru);

                    padre.CursosConvalidados.Add(new Curso
                    {
                        Codigo = p[1],
                        Nombre = p[2],
                        Creditos = creditos,
                        NotaExtranjera = notaExt,
                        NotaPeruana = notaPeru
                    });
                }
            }

            return lista;
        }

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

        private string Escapar(string campo)
        {
            if (string.IsNullOrEmpty(campo)) return "";
            if (campo.Contains(",") || campo.Contains("\""))
            {
                return "\"" + campo.Replace("\"", "\"\"") + "\"";
            }
            return campo;
        }

        private string[] ParsearLineaCsv(string linea)
        {
            var campos = new List<string>();
            bool enComillas = false;
            StringBuilder campoActual = new StringBuilder();

            for (int i = 0; i < linea.Length; i++)
            {
                char c = linea[i];

                if (c == '"')
                {
                    if (enComillas && i + 1 < linea.Length && linea[i + 1] == '"')
                    {
                        campoActual.Append('"');
                        i++; // Saltar siguiente comilla
                    }
                    else
                    {
                        enComillas = !enComillas;
                    }
                }
                else if (c == ',' && !enComillas)
                {
                    campos.Add(campoActual.ToString());
                    campoActual.Clear();
                }
                else
                {
                    campoActual.Append(c);
                }
            }
            campos.Add(campoActual.ToString());
            return campos.ToArray();
        }
    }
}