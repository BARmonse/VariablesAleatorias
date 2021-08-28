using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariablesAleatorias.Soporte.GeneradorAleatorios
{
    class GeneradorExponencialNegativa : IGenerador
    {
        private Truncador truncador;
        private GeneradorUniformeLenguaje generadorLenguaje;
        private DataTable dataTable;
        private DataRow dataRow;

        private double aleatorio01;
        private double aleatorio;

        private double menor;
        private double mayor;

        // parametros
        private double lambda;

        public GeneradorExponencialNegativa(DataTable tabla, GeneradorUniformeLenguaje generadorLenguaje, Truncador truncador, double lambda)
        {
            this.truncador = truncador;
            this.lambda = lambda;

            this.generadorLenguaje = generadorLenguaje;

            this.dataTable = tabla;
        }

        // retorna un aleatorio mayor a 0
        public double siguienteAleatorio()
        {
            aleatorio01 = generadorLenguaje.siguienteAleatorio();
            return truncador.truncar((-1 / lambda) * (Math.Log(1 - aleatorio01)));
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

                if (i == 0) { inicializarMenorMayor(aleatorio); }
                actualizarMayor(aleatorio);
                actualizarMenor(aleatorio);
                dataRow = dataTable.NewRow();
                dataRow[0] = i + 1;
                dataRow[1] = aleatorio;
                dataTable.Rows.Add(dataRow);

                if (frecuenciaObservada != null) { frecuenciaObservada.contarNumero(aleatorio); }
            }
            return dataTable;
        }
        private void inicializarMenorMayor(double numero)
        {
            menor = truncador.truncar(Math.Floor(numero));
            mayor = truncador.truncar(Math.Ceiling(numero));
        }
        private void actualizarMenor(double numero)
        {
            if (numero < menor)
            {
                menor = truncador.truncar(Math.Floor(numero));
            }
        }

        private void actualizarMayor(double numero)
        {
            if (numero > mayor)
            {
                mayor = truncador.truncar(Math.Ceiling(numero));
            }
        }

        public double getMayor()
        {
            return mayor;
        }

        public double getMenor()
        {
            return menor;
        }
    }
}
