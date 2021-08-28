using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariablesAleatorias.Soporte.GeneradorAleatorios
{
    class GeneradorUniformeLenguaje : IGenerador
    {
        Random random;
        Truncador truncador;
        private DataTable dataTable;
        private DataRow dataRow;

        private double aleatorio;

        public GeneradorUniformeLenguaje(DataTable tabla, Truncador truncador)
        {
            this.random = new Random();
            this.truncador = truncador;
            this.dataTable = tabla;
        }

        public GeneradorUniformeLenguaje(Truncador truncador)
        {
            this.truncador = truncador;
            this.random = new Random();
        }

        public double siguienteAleatorio()
        {
            return truncador.truncar(random.NextDouble());
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
