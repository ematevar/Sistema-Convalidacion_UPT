using System;
using System.Collections.Generic;
using System.Linq;

namespace TG01U2_Convalidacion_Atencio_Neciosup_A.Servicios
{
    public class ConvalidacionService
    {
        private readonly Repositorios.IRepositorioConvalidaciones _repositorio;

        public ConvalidacionService(Repositorios.IRepositorioConvalidaciones repositorio)
        {
            _repositorio = repositorio;
        }

        public List<Convalidacion> ObtenerConvalidaciones()
        {
            try
            {
                return _repositorio.LeerConvalidaciones();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al cargar las convalidaciones desde la fuente de datos.", ex);
            }
        }

        public void GuardarConvalidaciones(List<Convalidacion> convalidaciones)
        {
            try
            {
                // Validación de integridad
                if (convalidaciones == null || convalidaciones.Any(c => string.IsNullOrWhiteSpace(c.NombreEstudiante) || c.CursosConvalidados.Count == 0))
                {
                    throw new ArgumentException("Existen datos incompletos en la convalidación. Cada estudiante debe tener cursos y nombre.");
                }

                _repositorio.GuardarConvalidaciones(convalidaciones);
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al guardar los datos de convalidación.", ex);
            }
        }

        public List<Curso> ObtenerPlanEstudios()
        {
            try
            {
                return _repositorio.LeerPlanEstudios();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al cargar el plan de estudios.", ex);
            }
        }
    }
}