using System;
using System.Collections.Generic;

namespace TG01U2_Convalidacion_Atencio_Neciosup_A
{
    /// <summary>
    /// Gestor centralizado para equivalencias de notas entre países.
    /// Proporciona métodos para obtener la nota máxima de un país y los rangos de equivalencia.
    /// </summary>
    public static class EquivalenciasNotaManager
    {
        // Tabla de equivalencias de notas por país (MIN, MAX, MIN_PERÚ, MAX_PERÚ)
        private static readonly Dictionary<string, List<(double MinNota, double MaxNota, double MinNotaPeru, double MaxNotaPeru)>> EquivalenciasNota = 
            new()
            {
                { "Perú", new()
                    {
                        (0, 10.4, 0, 10.4),
                        (10.5, 13.4, 10.5, 13.4),
                        (13.5, 16.4, 13.5, 16.4),
                        (16.5, 19.4, 16.5, 19.4),
                        (19.5, 20, 19.5, 20)
                    }
                },
                { "Colombia", new()
                    {
                        (0, 2.9, 0, 10.4),
                        (3.0, 3.6, 10.5, 13.4),
                        (3.7, 4.3, 13.5, 16.4),
                        (4.4, 4.7, 16.5, 19.4),
                        (4.8, 5.0, 19.5, 20)
                    }
                },
                { "Bolivia", new()
                    {
                        (0, 50.4, 0, 10.4),
                        (50.5, 51.4, 10.5, 13.4),
                        (51.5, 71.4, 13.5, 16.4),
                        (71.5, 90.4, 16.5, 19.4),
                        (90.5, 100, 19.5, 20)
                    }
                },
                { "Argentina", new()
                    {
                        (0, 3.4, 0, 10.4),
                        (3.5, 4.4, 10.5, 13.4),
                        (4.5, 5.4, 13.5, 16.4),
                        (5.5, 9.4, 16.5, 19.4),
                        (9.5, 10.0, 19.5, 20)
                    }
                },
                { "Chile", new()
                    {
                        (0, 3.4, 0, 10.4),
                        (3.5, 4.4, 10.5, 13.4),
                        (4.5, 5.4, 13.5, 16.4),
                        (5.5, 6.4, 16.5, 19.4),
                        (6.5, 7.0, 19.5, 20)
                    }
                },
                { "España", new()
                    {
                        (0, 4.9, 0, 10.4),
                        (5.0, 6.9, 10.5, 13.4),
                        (7.0, 8.9, 13.5, 16.4),
                        (9.0, 9.9, 16.5, 19.4),
                        (10.0, 10.0, 19.5, 20.0)
                    }
                },
                { "México", new()
                    {
                        (0, 4.9, 0, 10.4),
                        (5.0, 6.9, 10.5, 13.4),
                        (7.0, 8.9, 13.5, 16.4),
                        (9.0, 9.9, 16.5, 19.4),
                        (10.0, 10.0, 19.5, 20.0)
                    }
                },
                { "Ecuador", new()
                    {
                        (0, 4.9, 0, 10.4),
                        (5.0, 6.9, 10.5, 13.4),
                        (7.0, 8.9, 13.5, 16.4),
                        (9.0, 9.9, 16.5, 19.4),
                        (10.0, 10.0, 19.5, 20.0)
                    }
                },
                { "Brasil", new()
                    {
                        (0, 4.9, 0, 10.4),
                        (5.0, 6.9, 10.5, 13.4),
                        (7.0, 8.9, 13.5, 16.4),
                        (9.0, 9.9, 16.5, 19.4),
                        (10.0, 10.0, 19.5, 20.0)
                    }
                },
                { "Francia", new()
                    {
                        (0, 9.9, 0, 10.4),
                        (10.0, 11.9, 10.5, 13.4),
                        (12.0, 13.9, 13.5, 16.4),
                        (14.0, 15.9, 16.5, 19.4),
                        (16.0, 20.0, 19.5, 20)
                    }
                },
                { "Italia", new()
                    {
                        (0, 17, 0, 10.4),
                        (18, 23, 10.5, 13.4),
                        (24, 27, 13.5, 16.4),
                        (28, 29, 16.5, 19.4),
                        (30, 30, 19.5, 20)
                    }
                },
                { "Paraguay", new()
                    {
                        (0, 1.4, 0, 10.4),
                        (1.5, 2.4, 10.5, 13.4),
                        (2.5, 3.4, 13.5, 16.4),
                        (3.5, 4.4, 16.5, 19.4),
                        (4.5, 5.0, 19.5, 20.0)
                    }
                },
                { "Grecia", new()
                    {
                        (0, 4.5, 0, 10.4),
                        (5.0, 6.5, 10.5, 13.4),
                        (6.6, 8.0, 13.5, 16.4),
                        (8.1, 9.4, 16.5, 19.4),
                        (9.5, 10.0, 19.5, 20.0)
                    }
                }
            };

        /// <summary>
        /// Obtiene la nota máxima permitida para un país específico.
        /// </summary>
        public static double ObtenerNotaMaximaPais(string pais)
        {
            return pais switch
            {
                "Perú" => 20.0,
                "Colombia" => 5.0,
                "Bolivia" => 100.0,
                "Argentina" => 10.0,
                "Chile" => 7.0,
                "España" => 10.0,
                "México" => 10.0,
                "Ecuador" => 10.0,
                "Brasil" => 10.0,
                "Francia" => 20.0,
                "Italia" => 30.0,
                "Paraguay" => 5.0,
                "Grecia" => 10.0,
                _ => 10.0
            };
        }

        /// <summary>
        /// Obtiene los límites de equivalencia de notas para un país y una nota específica.
        /// </summary>
        /// <returns>true si la nota se encuentra en los rangos; false en caso contrario.</returns>
        public static bool ObtenerLimitesEquivalencia(string pais, double nota, 
            ref double limiteInferiorExtranjero, ref double limiteSuperiorExtranjero, 
            ref double limiteInferiorPeru, ref double limiteSuperiorPeru)
        {
            if (!EquivalenciasNota.TryGetValue(pais, out var rangos))
                return false;

            foreach (var (minNota, maxNota, minPeru, maxPeru) in rangos)
            {
                if (nota >= minNota && nota <= maxNota)
                {
                    limiteInferiorExtranjero = minNota;
                    limiteSuperiorExtranjero = maxNota;
                    limiteInferiorPeru = minPeru;
                    limiteSuperiorPeru = maxPeru;
                    return true;
                }
            }

            return false;
        }
    }
}
