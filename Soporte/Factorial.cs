using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariablesAleatorias.Soporte
{
    class Factorial
    {
        public static double factorial(double numerador, int number)
        {
            int i;
            long fact = 1;

            for (i = 1; i <= number; i++)
            {
                numerador = numerador / i;
            }

            return numerador;
        }
    }
}
