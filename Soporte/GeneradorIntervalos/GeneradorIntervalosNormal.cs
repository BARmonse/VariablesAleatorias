using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariablesAleatorias.Soporte.GeneradorIntervalos
{
    class GeneradorIntervalosNormal
    {
        private double[] inicioIntervalos;
        private double[] finIntervalos;

        Truncador truncador;
        GeneradorIntervalosUniformeAB generadorIntervalos;

        public GeneradorIntervalosNormal(Truncador truncador)
        {
            this.truncador = truncador;
            this.generadorIntervalos = new GeneradorIntervalosUniformeAB(truncador);
        }

        public void generarIntervalos(int cantidadIntervalos, double menor, double mayor)
        {
            generadorIntervalos.generarIntervalos(cantidadIntervalos, menor, mayor);
            this.inicioIntervalos = generadorIntervalos.obtenerInicioIntervalos();
            this.finIntervalos = generadorIntervalos.obtenerFinIntervalos();
            //MessageBox.Show(generadorIntervalos.mostrarIntervalos());
        }

        public double[] obtenerInicioIntervalos()
        {
            return inicioIntervalos;
        }

        public double[] obtenerFinIntervalos()
        {
            return finIntervalos;
        }
    }
}
