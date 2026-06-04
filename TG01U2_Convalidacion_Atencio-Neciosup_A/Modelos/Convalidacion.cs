// ============================================================
// ARCHIVO: Modelos/Convalidacion.cs
// CAMBIO:  Se agrega la propiedad CodigoEstudiante
// ============================================================

using System;
using System.Collections.Generic;
using System.Linq;

namespace TG01U2_Convalidacion_Atencio_Neciosup_A
{
    public class Convalidacion
    {
        public string IdConvalidacion  { get; set; } = Guid.NewGuid().ToString().Substring(0, 8);

        // ─── NUEVO CAMPO ───────────────────────────────────────────────────────────
        public string CodigoEstudiante { get; set; } = "";

        public string NombreEstudiante  { get; set; }
        public string PaisOrigen        { get; set; }
        public string UniversidadOrigen { get; set; }
        public int    Anio              { get; set; }
        public string Semestre          { get; set; }

        public List<Curso> CursosConvalidados { get; set; } = new List<Curso>();

        public int TotalCreditos => CursosConvalidados.Sum(c => c.Creditos);

        public void AgregarCurso(Curso curso) => CursosConvalidados.Add(curso);
    }
}
