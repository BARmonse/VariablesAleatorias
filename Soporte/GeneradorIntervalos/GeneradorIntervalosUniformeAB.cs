using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariablesAleatorias.Soporte.GeneradorIntervalos
{
    class GeneradorIntervalosUniformeAB
    {
        private int cantidadIntervalos;

        private double[] inicioIntervalos; // inicio de cada intervalo
        private double[] finIntervalos; // inicio de cada intervalo

        Truncador truncador;

        public GeneradorIntervalosUniformeAB(Truncador truncador)
        {
            this.truncador = truncador;
        }

        public void generarIntervalos(int cantidadIntervalos, double a, double b)
        {
            this.cantidadIntervalos = cantidadIntervalos;
            inicioIntervalos = new double[cantidadIntervalos];
            finIntervalos = new double[cantidadIntervalos];

            decimal rangoIntervalo = calcularRangoIntervalos(a, b);

            for (int i = 0; i < cantidadIntervalos; i++)
            {
                decimal inicio = (decimal)a + rangoIntervalo * i;
                decimal fin = (decimal)a + rangoIntervalo * (i + 1);
                fin -= (decimal)0.0001;
                inicioIntervalos[i] = truncador.truncarDecimal(inicio);
                finIntervalos[i] = truncador.truncarDecimal(fin);
            }
        }


        // calcula el rango de cada intervalo, de acuerdo a la cantidad de contador
        private decimal calcularRangoIntervalos(double a, double b)
        {
            return ((decimal)(b - a) / cantidadIntervalos);
        }

        public double[] obtenerInicioIntervalos()
        {
            return inicioIntervalos;
        }

        public double[] obtenerFinIntervalos()
        {
            return finIntervalos;
        }

        public string mostrarIntervalos()
        {
            string res = " ";
            for (int i = 0; i < cantidadIntervalos; i++)
            {
                res += inicioIntervalos[i].ToString() + " " + finIntervalos[i].ToString();
                res += "\n";
            }
            return res;
        }
    }
}
