using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariablesAleatorias.Soporte
{
    class Truncador
    {
        private int CANTIDAD_DECIMALES;

        public Truncador(int cantidadDecimales)
        {
            this.CANTIDAD_DECIMALES = cantidadDecimales;
        }

        public double truncar(double numero)
        {
            int factor = (int)Math.Pow(10, CANTIDAD_DECIMALES);
            return Math.Truncate(factor * numero) / factor;
        }
        public double truncarDecimal(decimal numero)
        {
            int factor = (int)Math.Pow(10, CANTIDAD_DECIMALES);
            return (double)(Math.Truncate(factor * numero) / factor);
        }
    }
}
