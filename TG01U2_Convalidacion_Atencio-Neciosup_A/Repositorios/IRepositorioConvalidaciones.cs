using System.Collections.Generic;

namespace TG01U2_Convalidacion_Atencio_Neciosup_A.Repositorios
{
    public interface IRepositorioConvalidaciones
    {
        List<Convalidacion> LeerConvalidaciones();
        void GuardarConvalidaciones(List<Convalidacion> convalidaciones);
        List<Curso> LeerPlanEstudios();
    }
}