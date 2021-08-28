using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VariablesAleatorias.Soporte.GeneradorAleatorios
{
    class GeneradorNormalBoxMuller : IGenerador
    {
        private Truncador truncador;
        private GeneradorUniformeLenguaje generadorLenguaje;
        private DataTable dataTable;
        private DataRow dataRow;

        private double aleatorio01_1;
        private double aleatorio01_2;
        private double aleatorio;

        // parametros
        private double desviacion;
        private double media;

        private Boolean esNecesarioGenerar;

        private double menor;
        private double mayor;

        public GeneradorNormalBoxMuller(DataTable tabla, GeneradorUniformeLenguaje generadorLenguaje, Truncador truncador, double desviacion, double media)
        {
            this.truncador = truncador;
            this.desviacion = desviacion;
            this.media = media;
            this.generadorLenguaje = generadorLenguaje;
            this.dataTable = tabla;
        }

        // retorna un aleatorio
        public double siguienteAleatorio()
        {
            if (esNecesarioGenerar)
            {
                aleatorio01_1 = generadorLenguaje.siguienteAleatorio();
                if (aleatorio01_1 == 0) { aleatorio01_1 = 0.0001f; }
                aleatorio01_2 = generadorLenguaje.siguienteAleatorio();
                if (aleatorio01_2 == 0) { aleatorio01_2 = 0.0001f; }

                return truncador.truncar((Math.Sqrt(-2 * Math.Log(aleatorio01_1)) * Math.Cos(2 * Math.PI * aleatorio01_2)) * desviacion + media);
            }
            return truncador.truncar((Math.Sqrt(-2 * Math.Log(aleatorio01_1)) * Math.Sin(2 * Math.PI * aleatorio01_2)) * desviacion + media);
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
                if (i % 2 == 0) { esNecesarioGenerar = true; }
                else { esNecesarioGenerar = false; }
                aleatorio = siguienteAleatorio();

                if (double.IsInfinity(aleatorio)) { MessageBox.Show("error " + i); }

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
