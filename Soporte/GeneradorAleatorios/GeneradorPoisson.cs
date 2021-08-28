using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariablesAleatorias.Soporte.GeneradorAleatorios
{
    class GeneradorPoisson : IGenerador
    {
        private Truncador truncador;
        private GeneradorUniformeLenguaje generadorLenguaje;
        private DataTable dataTable;
        private DataRow dataRow;

        private double aleatorio01;
        private int aleatorio;

        // parametros
        private double lambda;

        private double p;
        private int X;
        private double A;

        public GeneradorPoisson(DataTable tabla, GeneradorUniformeLenguaje generadorLenguaje, Truncador truncador, double lambda)
        {
            this.truncador = truncador;
            this.lambda = lambda;

            this.generadorLenguaje = generadorLenguaje;

            this.dataTable = tabla;
        }

        // retorna un aleatorio
        public double siguienteAleatorio()
        {
            p = 1;
            X = -1;
            A = Math.Exp(-lambda);
            do
            {
                aleatorio01 = generadorLenguaje.siguienteAleatorio();
                p = p * aleatorio01;
                X = X + 1;
            } while (p >= A);

            return truncador.truncar(X);
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
                aleatorio = (int)siguienteAleatorio();

                dataRow = dataTable.NewRow();
                dataRow[0] = i + 1;
                dataRow[1] = aleatorio;
                dataTable.Rows.Add(dataRow);

                if (frecuenciaObservada != null) { frecuenciaObservada.contarPoisson(aleatorio); }
            }
            return dataTable;
        }
    }
}
