using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VariablesAleatorias.Soporte;
using VariablesAleatorias.Soporte.GeneradorAleatorios;
using VariablesAleatorias.Soporte.GeneradorIntervalos;
using VariablesAleatorias.Soporte.Probadores;
using VariablesAleatorias.Graficador;

namespace VariablesAleatorias
{
    class GestorExponencial
    {
        GeneradorUniformeLenguaje generadorLenguaje;
        Truncador truncador;
        GraficadorFrecuencias graficador;

        double[] inicioIntervalos;
        double[] finIntervalos;

        int[] frecuenciasObservadas;

        double lambda;
        double media;
        int cantidadIntervalos;
        int cantidadValores;
        double menor;
        double mayor;

        DataTable tablaAleatorios;
        Form1 pantalla;

        public GestorExponencial(Form1 pantalla)
        {
            this.truncador = new Truncador(4);
            this.generadorLenguaje = new GeneradorUniformeLenguaje(truncador);
            this.pantalla = pantalla;
        }

        private void crearTabla()
        {
            tablaAleatorios = new DataTable();
            tablaAleatorios.Columns.Add("iteracion");
            tablaAleatorios.Columns.Add("aleatorio");
        }

        public void generarExponencial(double lambda, double media, int cantidadValores, int cantidadIntervalos)
        {

            this.lambda = lambda;
            this.media = media;
            this.cantidadIntervalos = cantidadIntervalos;
            this.cantidadValores = cantidadValores;

            crearTabla();

            IGenerador generadorDistribucion = new GeneradorExponencialNegativa(tablaAleatorios, generadorLenguaje, truncador, lambda);
            generadorDistribucion.generarSerie(cantidadValores);

            this.menor = ((GeneradorExponencialNegativa)generadorDistribucion).getMenor();
            this.mayor = ((GeneradorExponencialNegativa)generadorDistribucion).getMayor();

            generarIntervalosExponencial();
            obtenerFrecuenciasObservadasExponencial();
            pantalla.mostrarResultados(tablaAleatorios);
            graficar();
        }

        private void generarIntervalosExponencial()
        {
            GeneradorIntervalosNormal generadorIntervalos = new GeneradorIntervalosNormal(truncador);
            generadorIntervalos.generarIntervalos(cantidadIntervalos, menor, mayor);

            this.inicioIntervalos = generadorIntervalos.obtenerInicioIntervalos();
            this.finIntervalos = generadorIntervalos.obtenerFinIntervalos();
        }

        private void obtenerFrecuenciasObservadasExponencial()
        {
            ContadorFrecuenciaObservada contadorFrecuencias = new ContadorFrecuenciaObservada(inicioIntervalos, finIntervalos);
            contadorFrecuencias.contarFrecuenciaSerie(tablaAleatorios);

            this.frecuenciasObservadas = contadorFrecuencias.obtenerFrecuencias();
        }

        public void probar()
        {
            IProbador probador = new ProbadorExponencialNegativa(truncador, tablaAleatorios, media, lambda, cantidadIntervalos, inicioIntervalos, finIntervalos, frecuenciasObservadas);
            PantallaPruebaChi pantallaPrueba = new PantallaPruebaChi();
            pantallaPrueba.probador = probador;
            pantallaPrueba.Show();
        }
        public void graficar()
        {
            GraficadorFrecuencias graficador = new GraficadorFrecuencias();
            graficador.frecuenciaObservada = this.frecuenciasObservadas;
            graficador.nombre = "Exponencial";
            graficador.inicioIntervalos = this.inicioIntervalos;
            graficador.finIntervalos = this.finIntervalos;
            pantalla.mostrarGrafico(graficador);
        }
    }
}
