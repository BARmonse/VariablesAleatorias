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
    class GestorUniforme
    {
        GeneradorUniformeLenguaje generadorLenguaje;
        Truncador truncador;


        double[] inicioIntervalos;
        double[] finIntervalos;

        int[] frecuenciasObservadas;

        DataTable tablaAleatorios;
        Form1 pantalla;

        public GestorUniforme(Form1 pantalla)
        {
            this.truncador = new Truncador(4);
            this.generadorLenguaje = new GeneradorUniformeLenguaje(truncador);
            this.pantalla = pantalla;
        }

        public void generarUniforme(double a, double b, int cantidadValores, int cantidadIntervalos)
        {
            if (b < a) { return; }

            crearTabla();
            generarIntervalosUniforme(a, b, cantidadIntervalos);
            cargarTablaAleatorios(a, b, cantidadValores);

            pantalla.mostrarResultados(tablaAleatorios);
            graficar();
        }

        private void cargarTablaAleatorios(double a, double b, int cantidadValores)
        {
            ContadorFrecuenciaObservada contador = new ContadorFrecuenciaObservada(inicioIntervalos, finIntervalos);
            IGenerador generadorDistribucion = new GeneradorUniformeAB(tablaAleatorios, generadorLenguaje, truncador, a, b);
            generadorDistribucion.generarSerie(cantidadValores, contador);

            this.frecuenciasObservadas = contador.obtenerFrecuencias();
        }

        private void crearTabla()
        {
            tablaAleatorios = new DataTable();
            tablaAleatorios.Columns.Add("iteracion");
            tablaAleatorios.Columns.Add("aleatorio");
        }

        private void generarIntervalosUniforme(double a, double b, int cantidadIntervalos)
        {
            GeneradorIntervalosUniformeAB generadorIntervalos = new GeneradorIntervalosUniformeAB(truncador);
            generadorIntervalos.generarIntervalos(cantidadIntervalos, a, b);
            inicioIntervalos = generadorIntervalos.obtenerInicioIntervalos();
            finIntervalos = generadorIntervalos.obtenerFinIntervalos();
        }

        public void probar()
        {
            IProbador probador = new ProbadorUniforme(truncador, tablaAleatorios, inicioIntervalos, finIntervalos, frecuenciasObservadas);
            PantallaPruebaChi pantallaPrueba = new PantallaPruebaChi();
            pantallaPrueba.probador = probador;
            pantallaPrueba.Show();
        }

        public void graficar()
        {
            GraficadorFrecuencias graficador = new GraficadorFrecuencias();
            graficador.frecuenciaObservada = this.frecuenciasObservadas;
            graficador.nombre = "Uniforme";
            graficador.inicioIntervalos = this.inicioIntervalos;
            graficador.finIntervalos = this.finIntervalos;
            pantalla.mostrarGrafico(graficador);
        }
    }
}
