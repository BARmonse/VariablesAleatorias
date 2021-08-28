using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariablesAleatorias.Soporte.GeneradorAleatorios
{
    class GeneradorUniformeAB : IGenerador
    {
        private Truncador truncador;
        private GeneradorUniformeLenguaje generadorLenguaje;
        private DataTable dataTable;
        private DataRow dataRow;

        private double aleatorio01;
        private double aleatorio;

        // parametros
        private double b;
        private double a;

        public GeneradorUniformeAB(DataTable tabla, GeneradorUniformeLenguaje generadorLenguaje, Truncador truncador, double a, double b)
        {
            this.truncador = truncador;
            this.a = truncador.truncar(a);
            this.b = truncador.truncar(b);

            this.generadorLenguaje = generadorLenguaje;

            this.dataTable = tabla;
        }

        // retorna un aleatorio
        public double siguienteAleatorio()
        {
            aleatorio01 = generadorLenguaje.siguienteAleatorio();
            return truncador.truncar(a + aleatorio01 * (b - a));
        }

        public DataTable generarSerie(int cantidadAleatorios)
        {
            return this.generarSerie(cantidadAleatorios, null);
        }

        public DataTable generarSerie(int cantidadAleatorios, ContadorFrecuenciaObservada frecuenciaObservada)
        {
            dataTable.Rows.Clear();

            for (int i = 0; i < cantidadAleatorios; i++)
            {
                aleatorio = siguienteAleatorio();
                dataRow = dataTable.NewRow();
                dataRow[0] = i + 1;
                dataRow[1] = aleatorio;
                dataTable.Rows.Add(dataRow);

                if (frecuenciaObservada != null) { frecuenciaObservada.contarNumero(aleatorio); }
            }
            return dataTable;
        }
    }
}
