using System;
using System.Collections.Generic;
using System.Linq;

namespace TG01U2_Convalidacion_Atencio_Neciosup_A.Servicios
{
    public static class ConvalidacionExtensions
    {
        public static IEnumerable<Convalidacion> FiltrarPorEstudiante(this IEnumerable<Convalidacion> convalidaciones, string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre)) return convalidaciones;
            return convalidaciones.Where(c => c.NombreEstudiante.Contains(nombre, StringComparison.OrdinalIgnoreCase));
        }

        public static IEnumerable<Convalidacion> FiltrarPorPais(this IEnumerable<Convalidacion> convalidaciones, int paisIndex, string paisText)
        {
            if (paisIndex <= 0 || string.IsNullOrWhiteSpace(paisText)) return convalidaciones;
            return convalidaciones.Where(c => c.PaisOrigen == paisText);
        }

        public static IEnumerable<Convalidacion> FiltrarPorUniversidad(this IEnumerable<Convalidacion> convalidaciones, string universidad)
        {
            if (string.IsNullOrWhiteSpace(universidad)) return convalidaciones;
            return convalidaciones.Where(c => c.UniversidadOrigen.Contains(universidad, StringComparison.OrdinalIgnoreCase));
        }

        public static IEnumerable<Convalidacion> FiltrarPorId(this IEnumerable<Convalidacion> convalidaciones, string idConvalidacion)
        {
            if (string.IsNullOrWhiteSpace(idConvalidacion)) return convalidaciones;
            return convalidaciones.Where(c => c.IdConvalidacion.Contains(idConvalidacion, StringComparison.OrdinalIgnoreCase));
        }

        public static IEnumerable<Convalidacion> FiltrarPorAnio(this IEnumerable<Convalidacion> convalidaciones, int anioIndex, string anioText)
        {
            if (anioIndex == 0 || !int.TryParse(anioText, out int anio)) return convalidaciones;
            return convalidaciones.Where(c => c.Anio == anio);
        }
    }
}