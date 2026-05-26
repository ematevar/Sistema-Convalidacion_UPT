using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TG01U2_Convalidacion_Atencio_Neciosup_A.Validaciones
{
    /// <summary>
    /// Clase de validación centralizada para todas las operaciones de convalidación
    /// Proporciona métodos estáticos para validar datos antes de guardar
    /// </summary>
    public static class ValidadorConvalidaciones
    {
        // Constantes de validación
        public const int LONGITUD_MINIMA_NOMBRE = 3;
        public const int LONGITUD_MAXIMA_NOMBRE = 100;
        public const int LONGITUD_MINIMA_UNIVERSIDAD = 3;
        public const int LONGITUD_MAXIMA_UNIVERSIDAD = 150;
        public const int AÑO_MINIMO = 1985;
        public const double NOTA_MINIMA = 0.0;

        /// <summary>
        /// Valida el nombre del estudiante
        /// </summary>
        public static (bool esValido, string mensaje) ValidarNombreEstudiante(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return (false, "El nombre del estudiante no puede estar vacío.");

            nombre = nombre.Trim();

            if (nombre.Length < LONGITUD_MINIMA_NOMBRE)
                return (false, $"El nombre debe tener al menos {LONGITUD_MINIMA_NOMBRE} caracteres.");

            if (nombre.Length > LONGITUD_MAXIMA_NOMBRE)
                return (false, $"El nombre no puede exceder {LONGITUD_MAXIMA_NOMBRE} caracteres.");

            // Validar que solo contenga letras, espacios y caracteres acentuados
            if (!Regex.IsMatch(nombre, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
                return (false, "El nombre solo puede contener letras y espacios.");

            return (true, "");
        }

        /// <summary>
        /// Valida la universidad de origen
        /// </summary>
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

        /// <summary>
        /// Valida el país seleccionado
        /// </summary>
        public static (bool esValido, string mensaje) ValidarPais(string pais)
        {
            string[] paisesValidos = { "Perú", "Argentina", "Bolivia", "Brasil", "Chile", "Colombia",
                                      "Ecuador", "Paraguay", "México", "España", "Francia", "Grecia", "Italia" };

            if (string.IsNullOrWhiteSpace(pais))
                return (false, "Debe seleccionar un país.");

            if (!paisesValidos.Contains(pais))
                return (false, $"'{pais}' no es un país válido.");

            return (true, "");
        }

        /// <summary>
        /// Valida el año académico
        /// </summary>
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
        /// Valida el semestre
        /// </summary>
        public static (bool esValido, string mensaje) ValidarSemestre(string semestre)
        {
            if (string.IsNullOrWhiteSpace(semestre))
                return (false, "El semestre no puede estar vacío.");

            semestre = semestre.Trim();

            // Aceptar números del 1 al 2 o texto como "I", "II", "Primero", "Segundo"
            if (!Regex.IsMatch(semestre, @"^([1-2]|I{1,2}|Primero|Segundo|primero|segundo)$", RegexOptions.IgnoreCase))
                return (false, "El semestre debe ser 1, 2, I, II, 'Primero' o 'Segundo'.");

            return (true, "");
        }

        /// <summary>
        /// Valida una nota en rango genérico
        /// </summary>
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

        /// <summary>
        /// Valida que un curso no esté duplicado en la lista
        /// </summary>
        public static (bool esValido, string mensaje) ValidarCursoDuplicado(List<Curso> cursos, Curso cursoNuevo)
        {
            if (cursos == null || cursos.Count == 0)
                return (true, "");

            if (cursos.Any(c => c.Codigo == cursoNuevo.Codigo))
                return (false, $"El curso '{cursoNuevo.Nombre}' ya ha sido agregado a esta convalidación.");

            return (true, "");
        }

        /// <summary>
        /// Valida que la convalidación tenga datos mínimos requeridos
        /// </summary>
        public static (bool esValido, string mensaje) ValidarConvalidacionCompleta(Convalidacion convalidacion)
        {
            if (convalidacion == null)
                return (false, "La convalidación no puede ser nula.");

            // Validar nombre
            var validacionNombre = ValidarNombreEstudiante(convalidacion.NombreEstudiante);
            if (!validacionNombre.esValido)
                return (false, validacionNombre.mensaje);

            // Validar país
            var validacionPais = ValidarPais(convalidacion.PaisOrigen);
            if (!validacionPais.esValido)
                return (false, validacionPais.mensaje);

            // Validar universidad
            var validacionUniversidad = ValidarUniversidad(convalidacion.UniversidadOrigen);
            if (!validacionUniversidad.esValido)
                return (false, validacionUniversidad.mensaje);

            // Validar año
            var validacionAnio = ValidarAnioAcademico(convalidacion.Anio.ToString());
            if (!validacionAnio.esValido)
                return (false, validacionAnio.mensaje);

            // Validar semestre
            var validacionSemestre = ValidarSemestre(convalidacion.Semestre);
            if (!validacionSemestre.esValido)
                return (false, validacionSemestre.mensaje);

            // Validar que tenga al menos un curso
            if (convalidacion.CursosConvalidados == null || convalidacion.CursosConvalidados.Count == 0)
                return (false, "La convalidación debe tener al menos un curso.");

            // Validar que cada curso tenga datos válidos
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

        /// <summary>
        /// Obtiene un resumen completo de validación
        /// </summary>
        public static string ObtenerResumenValidacion(Convalidacion convalidacion)
        {
            var resultado = ValidarConvalidacionCompleta(convalidacion);
            if (resultado.esValido)
            {
                return $"✓ Convalidación válida\n" +
                       $"  Estudiante: {convalidacion.NombreEstudiante}\n" +
                       $"  País: {convalidacion.PaisOrigen}\n" +
                       $"  Cursos: {convalidacion.CursosConvalidados.Count}\n" +
                       $"  Créditos totales: {convalidacion.TotalCreditos}";
            }
            return $"✗ Error de validación:\n{resultado.mensaje}";
        }
    }
}