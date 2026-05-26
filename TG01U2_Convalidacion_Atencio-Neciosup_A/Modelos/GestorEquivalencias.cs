using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TG01U2_Convalidacion_Atencio_Neciosup_A
{
    public static class GestorEquivalencias
    {
        // Fórmula de interpolación lineal
        public static double CalcularNotaPeru(double notaExt, double limInfExt, double limSupExt, double limInfPeru, double limSupPeru)
        {
            double resultado = limInfPeru + ((notaExt - limInfExt) / (limSupExt - limInfExt)) * (limSupPeru - limInfPeru);
            return Math.Round(resultado, 2);
        }
    }
}
