using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariablesAleatorias.Soporte.Probadores
{
    class ProbadorNormal : IProbador
    {
        private DataTable numeros;
        private double[] inicioIntervalos;
        private double[] finIntervalos;
        private int[] frecuenciasObservadas;
        private double[] frecuenciasEsperadas;
        private double[] probabilidades;
        private DataTable resultado;
        private Truncador truncador;
        private double valorCritico;
        private double media;
        private double desviacion;

        public ProbadorNormal(Truncador truncador, DataTable numeros,
            double media, double desviacion, double[] inicioIntervalos, double[] finIntervalos, int[] frecuenciasObservadas)
        {
            this.numeros = numeros;
            this.media = media;
            this.desviacion = desviacion;
            this.inicioIntervalos = inicioIntervalos;
            this.finIntervalos = finIntervalos;
            this.frecuenciasObservadas = frecuenciasObservadas;
            this.truncador = truncador;
        }

        private void crearTabla(DataTable tabla)
        {
            tabla.Columns.Add("intervalo");
            tabla.Columns.Add("MC");
            tabla.Columns.Add("FO");
            tabla.Columns.Add("P(x)");
            tabla.Columns.Add("FE");
            tabla.Columns.Add("C");
            tabla.Columns.Add("C(AC)");
        }

        public void probar()
        {
            construirTablaInicial();
            reestructurarTabla();
            construirTablaFinal();
            agregarTotalObservada();
        }

        private void construirTablaInicial()
        {
            this.resultado = new DataTable();
            crearTabla(resultado);
            DataRow row;
            double marcaClase;
            double probabilidad;
            double cantidadNumeros = numeros.Rows.Count;
            double frecuenciaEsperada;

            for (int i = 0; i < inicioIntervalos.Length; i++)
            {
                row = resultado.NewRow();
                row[0] = "[" + inicioIntervalos[i] + ";" + finIntervalos[i] + "]";

                marcaClase = truncador.truncar((inicioIntervalos[i] + finIntervalos[i]) / 2.0f);
                row[1] = marcaClase;

                row[2] = frecuenciasObservadas[i];

                probabilidad = TablaNormal.normal((finIntervalos[i] - media) / desviacion) - TablaNormal.normal((inicioIntervalos[i] - media) / desviacion);
                row[3] = truncador.truncar(probabilidad);

                frecuenciaEsperada = (probabilidad * cantidadNumeros);
                row[4] = truncador.truncar(frecuenciaEsperada); // frecuenciaEsperada

                resultado.Rows.Add(row);
            }
        }

        private Boolean compararEstadisticoConAcumulado()
        {
            int gradosLibertad = calcularGradosLibertad();
            valorCritico = obtenerValorCritico(gradosLibertad);

            if (valorCritico > obtenerTotalAcumuladoEstadisticoPrueba())
            {
                return true;
            }
            return false;
        }

        private int calcularGradosLibertad()
        {
            return inicioIntervalos.Length - 1 - 2;
        }

        public bool esAceptado()
        {
            return compararEstadisticoConAcumulado();
        }

        private double obtenerValorCritico(int gradosLibertad)
        {
            return ValorCriticoChiCuadrado.obtenerValorCritico(gradosLibertad);
        }

        public DataTable obtenerTablaResultados()
        {
            return resultado;
        }

        public double obtenerTotalAcumuladoEstadisticoPrueba()
        {
            return double.Parse(resultado.Rows[resultado.Rows.Count - 2][6].ToString());
        }

        public double getValorCritico()
        {
            return valorCritico;
        }

        private void reestructurarTabla()
        {
            double esperadaTablaVieja;
            double esperadaAcumulada = 0;
            int observadaAcumulada = 0;
            double probabilidadTablaVieja;
            double probabilidadAcumulada = 0;
            List<double> nuevoInicioIntervalos = new List<double>();
            List<double> nuevoFinIntervalos = new List<double>();
            List<int> nuevaFrecuenciaObservada = new List<int>();
            List<double> nuevaFrecuenciaEsperada = new List<double>();
            List<double> nuevaProbabilidad = new List<double>();
            double nuevoInicioIntervalo = 0;
            double nuevoFinIntervalo = 0;

            for (int i = 0; i < inicioIntervalos.Length; i++)
            {
                if (esperadaAcumulada == 0) { nuevoInicioIntervalo = inicioIntervalos[i]; }
                esperadaTablaVieja = double.Parse(resultado.Rows[i][4].ToString());
                esperadaAcumulada += esperadaTablaVieja;
                probabilidadTablaVieja = double.Parse(resultado.Rows[i][3].ToString());
                probabilidadAcumulada += probabilidadTablaVieja;
                observadaAcumulada += frecuenciasObservadas[i];

                if (esperadaAcumulada > 5)
                {
                    nuevoFinIntervalo = finIntervalos[i];

                    nuevoInicioIntervalos.Add(nuevoInicioIntervalo);
                    nuevoFinIntervalos.Add(nuevoFinIntervalo);
                    nuevaFrecuenciaObservada.Add(observadaAcumulada);
                    nuevaFrecuenciaEsperada.Add(truncador.truncar(esperadaAcumulada));
                    nuevaProbabilidad.Add(truncador.truncar(probabilidadAcumulada));

                    probabilidadAcumulada = 0;
                    esperadaAcumulada = 0;
                    observadaAcumulada = 0;
                }
            }

            nuevoFinIntervalos[nuevoFinIntervalos.Count - 1] = finIntervalos[inicioIntervalos.Length - 1];
            nuevaFrecuenciaObservada[nuevoFinIntervalos.Count - 1] += observadaAcumulada;
            nuevaFrecuenciaEsperada[nuevoFinIntervalos.Count - 1] = truncador.truncar(esperadaAcumulada + nuevaFrecuenciaEsperada[nuevoFinIntervalos.Count - 1]);
            nuevaProbabilidad[nuevoFinIntervalos.Count - 1] = truncador.truncar(nuevaProbabilidad[nuevoFinIntervalos.Count - 1] + probabilidadAcumulada);

            this.inicioIntervalos = nuevoInicioIntervalos.ToArray();
            this.finIntervalos = nuevoFinIntervalos.ToArray();
            this.frecuenciasObservadas = nuevaFrecuenciaObservada.ToArray();
            this.frecuenciasEsperadas = nuevaFrecuenciaEsperada.ToArray();
            this.probabilidades = nuevaProbabilidad.ToArray();
        }


        private void construirTablaFinal()
        {
            this.resultado = new DataTable();
            crearTabla(resultado);
            DataRow row;
            double estadisticoPrueba;
            double estadisticoPruebaAcumuladoAnterior = 0;
            double marcaClase;
            double frecuenciaEsperada;

            for (int i = 0; i < inicioIntervalos.Length; i++)
            {
                row = resultado.NewRow();
                row[0] = "[" + inicioIntervalos[i] + ";" + finIntervalos[i] + "]";

                marcaClase = truncador.truncar((inicioIntervalos[i] + finIntervalos[i]) / 2.0f);
                row[1] = marcaClase;

                row[2] = frecuenciasObservadas[i];

                row[3] = probabilidades[i];  // probabilidad

                frecuenciaEsperada = frecuenciasEsperadas[i];
                row[4] = frecuenciaEsperada; // frecuenciaEsperada

                estadisticoPrueba = (Math.Pow((frecuenciaEsperada - frecuenciasObservadas[i]), 2) / frecuenciaEsperada);
                row[5] = truncador.truncar(estadisticoPrueba);
                row[6] = truncador.truncar(estadisticoPruebaAcumuladoAnterior + estadisticoPrueba);
                estadisticoPruebaAcumuladoAnterior += estadisticoPrueba;
                resultado.Rows.Add(row);
            }
        }

        private String mostrarNuevosIntervalos(List<double> inicio, List<double> fin)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < inicio.Count; i++)
            {
                stringBuilder.Append(inicio[i]).Append(" ").Append(fin[i]);
                stringBuilder.Append("\n");
            }
            return stringBuilder.ToString();
        }

        private void agregarTotalObservada()
        {
            int acum = 0;
            for (int i = 0; i < frecuenciasObservadas.Length; i++)
            {
                acum += frecuenciasObservadas[i];
            }
            DataRow row = resultado.NewRow();
            row[2] = acum;
            resultado.Rows.Add(row);
        }
    }
}
