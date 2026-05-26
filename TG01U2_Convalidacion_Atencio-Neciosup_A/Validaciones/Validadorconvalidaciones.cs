using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TG01U2_Convalidacion_Atencio_Neciosup_A.Validaciones
{
    /// <summary>
    /// Validaciones centralizadas para todas las operaciones de convalidación.
    /// Único punto de verdad para reglas de negocio de entrada de datos.
    /// </summary>
    public static class ValidadorConvalidaciones
    {
        public const int LONGITUD_MINIMA_NOMBRE = 3;
        public const int LONGITUD_MAXIMA_NOMBRE = 100;
        public const int LONGITUD_MINIMA_UNIVERSIDAD = 3;
        public const int LONGITUD_MAXIMA_UNIVERSIDAD = 150;
        public const int AÑO_MINIMO = 1985;
        public const double NOTA_MINIMA = 0.0;

        private static readonly string[] PaisesValidos =
        {
            "Argentina", "Bolivia", "Brasil", "Chile", "Colombia",
            "Ecuador", "España", "Francia", "Grecia", "Italia",
            "México", "Paraguay", "Perú"
        };

        public static (bool esValido, string mensaje) ValidarNombreEstudiante(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return (false, "El nombre del estudiante no puede estar vacío.");

            nombre = nombre.Trim();

            if (nombre.Length < LONGITUD_MINIMA_NOMBRE)
                return (false, $"El nombre debe tener al menos {LONGITUD_MINIMA_NOMBRE} caracteres.");

            if (nombre.Length > LONGITUD_MAXIMA_NOMBRE)
                return (false, $"El nombre no puede exceder {LONGITUD_MAXIMA_NOMBRE} caracteres.");

            if (!Regex.IsMatch(nombre, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
                return (false, "El nombre solo puede contener letras y espacios.");

            return (true, "");
        }

        public static (bool esValido, string mensaje) ValidarUniversidad(string universidad)
        {
            if (string.IsNullOrWhiteSpace(universidad))
                return (false, "La universidad de origen no puede estar vacía.");

            universidad = universidad.Trim();

            if (universidad.Length < LONGITUD_MINIMA_UNIVERSIDAD)
                return (false, $"La universidad debe tener al menos {LONGITUD_MINIMA_UNIVERSIDAD} caracteres.");

            if (universidad.Length > LONGITUD_MAXIMA_UNIVERSIDAD)
                return (false, $"La universidad no puede exceder {LONGITUD_MAXIMA_UNIVERSIDAD} caracteres.");

            return (true, "");
        }

        public static (bool esValido, string mensaje) ValidarPais(string pais)
        {
            if (string.IsNullOrWhiteSpace(pais) || !PaisesValidos.Contains(pais))
                return (false, "Debe seleccionar un país válido.");

            return (true, "");
        }

        public static (bool esValido, string mensaje) ValidarAnioAcademico(string anioTexto)
        {
            if (string.IsNullOrWhiteSpace(anioTexto))
                return (false, "El año académico no puede estar vacío.");

            if (!int.TryParse(anioTexto, out int anio))
                return (false, "El año debe ser un número válido.");

            if (anio < AÑO_MINIMO)
                return (false, $"El año no puede ser anterior a {AÑO_MINIMO}.");

            if (anio > DateTime.Now.Year)
                return (false, $"El año no puede ser posterior a {DateTime.Now.Year}.");

            return (true, "");
        }

        /// <summary>
        /// Valida el semestre. Acepta "1" o "2" (valores del ComboBox).
        /// </summary>
        public static (bool esValido, string mensaje) ValidarSemestre(string semestre)
        {
            if (semestre != "1" && semestre != "2")
                return (false, "El semestre debe ser 1 o 2.");

            return (true, "");
        }

        public static (bool esValido, string mensaje) ValidarNota(string notaTexto, double notaMaxima)
        {
            if (string.IsNullOrWhiteSpace(notaTexto))
                return (false, "La nota no puede estar vacía.");

            if (!double.TryParse(notaTexto, out double nota))
                return (false, "La nota debe ser un número válido.");

            if (nota < NOTA_MINIMA)
                return (false, $"La nota no puede ser menor a {NOTA_MINIMA}.");

            if (nota > notaMaxima)
                return (false, $"La nota no puede ser mayor a {notaMaxima}.");

            return (true, "");
        }

        public static (bool esValido, string mensaje) ValidarCursoDuplicado(List<Curso> cursos, Curso cursoNuevo)
        {
            if (cursos == null || cursos.Count == 0)
                return (true, "");

            if (cursos.Any(c => c.Codigo == cursoNuevo.Codigo))
                return (false, $"El curso '{cursoNuevo.Nombre}' ya ha sido agregado a esta convalidación.");

            return (true, "");
        }

        public static (bool esValido, string mensaje) ValidarConvalidacionCompleta(Convalidacion convalidacion)
        {
            if (convalidacion == null)
                return (false, "La convalidación no puede ser nula.");

            var checks = new[]
            {
                ValidarNombreEstudiante(convalidacion.NombreEstudiante),
                ValidarPais(convalidacion.PaisOrigen),
                ValidarUniversidad(convalidacion.UniversidadOrigen),
                ValidarAnioAcademico(convalidacion.Anio.ToString()),
                ValidarSemestre(convalidacion.Semestre)
            };

            foreach (var (esValido, mensaje) in checks)
                if (!esValido) return (false, mensaje);

            if (convalidacion.CursosConvalidados == null || convalidacion.CursosConvalidados.Count == 0)
                return (false, "La convalidación debe tener al menos un curso.");

            foreach (var curso in convalidacion.CursosConvalidados)
            {
                if (string.IsNullOrWhiteSpace(curso.Codigo) || string.IsNullOrWhiteSpace(curso.Nombre))
                    return (false, "Todos los cursos deben tener código y nombre.");

                if (curso.Creditos <= 0)
                    return (false, $"El curso '{curso.Nombre}' debe tener créditos válidos.");

                if (curso.NotaExtranjera < 0 || curso.NotaPeruana < 0)
                    return (false, $"El curso '{curso.Nombre}' tiene notas inválidas.");
            }

            return (true, "");
        }
    }
}