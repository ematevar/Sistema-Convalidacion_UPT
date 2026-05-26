using System;
using System.Collections.Generic;
using System.Linq;

namespace TG01U2_Convalidacion_Atencio_Neciosup_A.Servicios
{
    /// <summary>
    /// Métodos de extensión para filtrar convalidaciones de forma fluida y encadenable.
    /// Se usan en FormBusquedaConvalidaciones para aplicar múltiples filtros en cadena.
    /// </summary>
    public static class ConvalidacionExtensions
    {
        /// <summary>Filtra por nombre del estudiante (búsqueda parcial, sin distinción de mayúsculas).</summary>
        public static IEnumerable<Convalidacion> FiltrarPorEstudiante(
            this IEnumerable<Convalidacion> convalidaciones, string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre)) return convalidaciones;

            string filtro = nombre.Trim().ToLower();
            return convalidaciones.Where(c =>
                !string.IsNullOrEmpty(c.NombreEstudiante) &&
                c.NombreEstudiante.ToLower().Contains(filtro));
        }

        /// <summary>Filtra por país exacto.</summary>
        public static IEnumerable<Convalidacion> FiltrarPorPais(
            this IEnumerable<Convalidacion> convalidaciones, int paisIndex, string paisText)
        {
            if (paisIndex <= 0 || string.IsNullOrWhiteSpace(paisText)) return convalidaciones;

            return convalidaciones.Where(c =>
                !string.IsNullOrEmpty(c.PaisOrigen) &&
                c.PaisOrigen.Equals(paisText, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>Filtra por universidad (búsqueda parcial, sin distinción de mayúsculas).</summary>
        public static IEnumerable<Convalidacion> FiltrarPorUniversidad(
            this IEnumerable<Convalidacion> convalidaciones, string universidad)
        {
            if (string.IsNullOrWhiteSpace(universidad)) return convalidaciones;

            string filtro = universidad.Trim().ToLower();
            return convalidaciones.Where(c =>
                !string.IsNullOrEmpty(c.UniversidadOrigen) &&
                c.UniversidadOrigen.ToLower().Contains(filtro));
        }

        /// <summary>Filtra por ID de convalidación (búsqueda parcial).</summary>
        public static IEnumerable<Convalidacion> FiltrarPorId(
            this IEnumerable<Convalidacion> convalidaciones, string idConvalidacion)
        {
            if (string.IsNullOrWhiteSpace(idConvalidacion)) return convalidaciones;

            string filtro = idConvalidacion.Trim().ToUpper();
            return convalidaciones.Where(c =>
                !string.IsNullOrEmpty(c.IdConvalidacion) &&
                c.IdConvalidacion.ToUpper().Contains(filtro));
        }

        /// <summary>Filtra por año académico exacto.</summary>
        public static IEnumerable<Convalidacion> FiltrarPorAnio(
            this IEnumerable<Convalidacion> convalidaciones, int anioIndex, string anioText)
        {
            if (anioIndex == 0 || !int.TryParse(anioText, out int anio)) return convalidaciones;

            return convalidaciones.Where(c => c.Anio == anio);
        }
    }
}