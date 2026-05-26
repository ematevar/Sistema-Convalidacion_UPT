using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TG01U2_Convalidacion_Atencio_Neciosup_A
{
    public class Curso
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int Creditos { get; set; }
        public double NotaExtranjera { get; set; }
        public double NotaPeruana { get; set; }

        public Curso() { }

        public Curso(string codigo, string nombre, int creditos)
        {
            Codigo = codigo;
            Nombre = nombre;
            Creditos = creditos;
        }
    }
}
