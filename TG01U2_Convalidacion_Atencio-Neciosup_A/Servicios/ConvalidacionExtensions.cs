using System;
using System.Collections.Generic;
using System.Linq;

namespace TG01U2_Convalidacion_Atencio_Neciosup_A.Servicios
{
    /// <summary>
    /// Métodos de extensión para filtrar convalidaciones de manera eficiente y segura
    /// </summary>
    public static class ConvalidacionExtensions
    {
        /// <summary>
        /// Filtra por nombre del estudiante (búsqueda parcial, case-insensitive)
        /// </summary>
        public static IEnumerable<Convalidacion> FiltrarPorEstudiante(this IEnumerable<Convalidacion> convalidaciones, string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return convalidaciones;

            nombre = nombre.Trim().ToLower();
            return convalidaciones.Where(c => !string.IsNullOrEmpty(c.NombreEstudiante) &&
                                             c.NombreEstudiante.ToLower().Contains(nombre));
        }

        /// <summary>
        /// Filtra por país exacto
        /// </summary>
        public static IEnumerable<Convalidacion> FiltrarPorPais(this IEnumerable<Convalidacion> convalidaciones, int paisIndex, string paisText)
        {
            if (paisIndex <= 0 || string.IsNullOrWhiteSpace(paisText))
                return convalidaciones;

            return convalidaciones.Where(c => !string.IsNullOrEmpty(c.PaisOrigen) &&
                                             c.PaisOrigen.Equals(paisText, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Filtra por universidad (búsqueda parcial, case-insensitive)
        /// </summary>
        public static IEnumerable<Convalidacion> FiltrarPorUniversidad(this IEnumerable<Convalidacion> convalidaciones, string universidad)
        {
            if (string.IsNullOrWhiteSpace(universidad))
                return convalidaciones;

            universidad = universidad.Trim().ToLower();
            return convalidaciones.Where(c => !string.IsNullOrEmpty(c.UniversidadOrigen) &&
                                             c.UniversidadOrigen.ToLower().Contains(universidad));
        }

        /// <summary>
        /// Filtra por ID de convalidación (búsqueda parcial)
        /// </summary>
        public static IEnumerable<Convalidacion> FiltrarPorId(this IEnumerable<Convalidacion> convalidaciones, string idConvalidacion)
        {
            if (string.IsNullOrWhiteSpace(idConvalidacion))
                return convalidaciones;

            idConvalidacion = idConvalidacion.Trim().ToUpper();
            return convalidaciones.Where(c => !string.IsNullOrEmpty(c.IdConvalidacion) &&
                                             c.IdConvalidacion.ToUpper().Contains(idConvalidacion));
        }

        /// <summary>
        /// Filtra por año académico exacto
        /// </summary>
        public static IEnumerable<Convalidacion> FiltrarPorAnio(this IEnumerable<Convalidacion> convalidaciones, int anioIndex, string anioText)
        {
            if (anioIndex == 0 || !int.TryParse(anioText, out int anio))
                return convalidaciones;

            return convalidaciones.Where(c => c.Anio == anio);
        }

        /// <summary>
        /// Filtra por semestre exacto
        /// </summary>
        public static IEnumerable<Convalidacion> FiltrarPorSemestre(this IEnumerable<Convalidacion> convalidaciones, string semestre)
        {
            if (string.IsNullOrWhiteSpace(semestre))
                return convalidaciones;

            return convalidaciones.Where(c => !string.IsNullOrEmpty(c.Semestre) &&
                                             c.Semestre.Equals(semestre, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Obtiene estadísticas por criterio especificado
        /// </summary>
        public static List<(string Criterio, int Cantidad)> ObtenerEstadisticasPor(
            this IEnumerable<Convalidacion> convalidaciones,
            string tipoCriterio)
        {
            switch (tipoCriterio.ToLower())
            {
                case "país":
                case "pais":
                    return convalidaciones
                        .GroupBy(c => c.PaisOrigen ?? "No especificado")
                        .Select(g => (Criterio: g.Key, Cantidad: g.Count()))
                        .OrderByDescending(x => x.Cantidad)
                        .ToList();

                case "universidad":
                    return convalidaciones
                        .GroupBy(c => c.UniversidadOrigen ?? "No especificada")
                        .Select(g => (Criterio: g.Key, Cantidad: g.Count()))
                        .OrderByDescending(x => x.Cantidad)
                        .ToList();

                case "año":
                case "anio":
                    return convalidaciones
                        .GroupBy(c => c.Anio.ToString())
                        .Select(g => (Criterio: g.Key, Cantidad: g.Count()))
                        .OrderByDescending(x => x.Cantidad)
                        .ToList();

                case "semestre":
                    return convalidaciones
                        .GroupBy(c => c.Semestre ?? "No especificado")
                        .Select(g => (Criterio: g.Key, Cantidad: g.Count()))
                        .OrderByDescending(x => x.Cantidad)
                        .ToList();

                case "estudiante":
                    return convalidaciones
                        .GroupBy(c => c.NombreEstudiante ?? "No especificado")
                        .Select(g => (Criterio: g.Key, Cantidad: g.Count()))
                        .OrderByDescending(x => x.Cantidad)
                        .ToList();

                default:
                    return new List<(string, int)>();
            }
        }

        /// <summary>
        /// Calcula estadísticas generales de convalidaciones
        /// </summary>
        public static (int Total, int CreditosTotales, int UniversidadesUnicas, int PaisesUnicos)
            ObtenerEstadisticasGenerales(this IEnumerable<Convalidacion> convalidaciones)
        {
            var lista = convalidaciones.ToList();
            return (
                Total: lista.Count,
                CreditosTotales: lista.Sum(c => c.TotalCreditos),
                UniversidadesUnicas: lista.Select(c => c.UniversidadOrigen).Distinct().Count(),
                PaisesUnicos: lista.Select(c => c.PaisOrigen).Distinct().Count()
            );
        }

        /// <summary>
        /// Obtiene convalidaciones ordenadas por fecha (usando el ID que contiene información temporal)
        /// </summary>
        public static IEnumerable<Convalidacion> ObtenerOrdenadas(
            this IEnumerable<Convalidacion> convalidaciones,
            string ordenPor = "estudiante")
        {
            switch (ordenPor.ToLower())
            {
                case "estudiante":
                    return convalidaciones.OrderBy(c => c.NombreEstudiante);
                case "pais":
                    return convalidaciones.OrderBy(c => c.PaisOrigen).ThenBy(c => c.NombreEstudiante);
                case "año":
                    return convalidaciones.OrderByDescending(c => c.Anio).ThenBy(c => c.NombreEstudiante);
                case "creditos":
                    return convalidaciones.OrderByDescending(c => c.TotalCreditos);
                default:
                    return convalidaciones;
            }
        }
    }
}