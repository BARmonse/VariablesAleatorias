using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VariablesAleatorias.Graficador;
using VariablesAleatorias.Soporte;
using VariablesAleatorias.Soporte.GeneradorAleatorios;
using VariablesAleatorias.Soporte.GeneradorIntervalos;
using VariablesAleatorias.Soporte.Probadores;

namespace VariablesAleatorias
{
    class GestorNormal
    {
        GeneradorUniformeLenguaje generadorLenguaje;
        Truncador truncador;
        GraficadorFrecuencias graficador;

        double[] inicioIntervalos;
        double[] finIntervalos;

        int[] frecuenciasObservadas;

        double desviacion;
        double media;
        int cantidadIntervalos;
        int cantidadValores;
        double menor;
        double mayor;

        DataTable tablaAleatorios;
        Form1 pantalla;

        public GestorNormal(Form1 pantalla)
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


        public void generarNormalBoxMuller(double media, double desviacion, int cantidadValores, int cantidadIntervalos)
        {

            this.media = media;
            this.desviacion = desviacion;
            this.cantidadValores = cantidadValores;
            this.cantidadIntervalos = cantidadIntervalos;
            crearTabla();

            IGenerador generadorDistribucion = new GeneradorNormalBoxMuller(tablaAleatorios, generadorLenguaje, truncador, desviacion, media);
            generadorDistribucion.generarSerie(cantidadValores);

            this.menor = ((GeneradorNormalBoxMuller)generadorDistribucion).getMenor();
            this.mayor = ((GeneradorNormalBoxMuller)generadorDistribucion).getMayor();

            generarIntervalosNormal();
            obtenerFrecuenciasObservadasNormal();
            pantalla.mostrarResultados(tablaAleatorios);
            graficar();
        }

        private void generarIntervalosNormal()
        {
            GeneradorIntervalosNormal generadorIntervalos = new GeneradorIntervalosNormal(truncador);
            generadorIntervalos.generarIntervalos(cantidadIntervalos, menor, mayor);

            this.inicioIntervalos = generadorIntervalos.obtenerInicioIntervalos();
            this.finIntervalos = generadorIntervalos.obtenerFinIntervalos();
        }

        private void obtenerFrecuenciasObservadasNormal()
        {
            ContadorFrecuenciaObservada contadorFrecuencias = new ContadorFrecuenciaObservada(inicioIntervalos, finIntervalos);
            contadorFrecuencias.contarFrecuenciaSerie(tablaAleatorios);

            this.frecuenciasObservadas = contadorFrecuencias.obtenerFrecuencias();
        }

        public void probar()
        {
            IProbador probador = new ProbadorNormal(truncador, tablaAleatorios, media, desviacion, inicioIntervalos, finIntervalos, frecuenciasObservadas);
            PantallaPruebaChi pantallaPrueba = new PantallaPruebaChi();
            pantallaPrueba.probador = probador;
            pantallaPrueba.Show();
        }
        public void graficar()
        {
            GraficadorFrecuencias graficador = new GraficadorFrecuencias();
            graficador.frecuenciaObservada = this.frecuenciasObservadas;
            graficador.nombre = "Normal por Box Muller";
            graficador.inicioIntervalos = this.inicioIntervalos;
            graficador.finIntervalos = this.finIntervalos;
            pantalla.mostrarGrafico(graficador);
        }
    }
}
