using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VariablesAleatorias.Graficador;
using VariablesAleatorias.Soporte;
using VariablesAleatorias.Soporte.GeneradorAleatorios;
using VariablesAleatorias.Soporte.Probadores;

namespace VariablesAleatorias
{
    class GestorPoisson
    {
        GeneradorUniformeLenguaje generadorLenguaje;
        Truncador truncador;

        int[] valoresDiscretos;
        int[] frecuenciasObservadas;

        double lambda;
        int cantidadValores;
        float menor;
        float mayor;

        DataTable tablaAleatorios;
        Form1 pantalla;

        public GestorPoisson(Form1 pantalla)
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

        public void generarPoisson(double lambda, double media, int cantidadValores)
        {
            this.cantidadValores = cantidadValores;
            this.lambda = lambda;

            crearTabla();
            ContadorFrecuenciaObservada contador = new ContadorFrecuenciaObservada();// Crea un objeto de la clase ContadorFrecuenciaObservada
            IGenerador generadorDistribucion = new GeneradorPoisson(tablaAleatorios, generadorLenguaje, truncador, lambda);
            generadorDistribucion.generarSerie(cantidadValores, contador);

            contador.ordenarSeriePoisson();
            frecuenciasObservadas = contador.getFrecuenciasPoisson();
            valoresDiscretos = contador.getValoresPoisson();

            pantalla.mostrarResultados(tablaAleatorios);
            graficar();
        }

        public void probar()
        {
            //double[] temp = valoresDiscretos.Select(l => (double)l - 0.00001).ToArray();
            IProbador probador;
            probador = new ProbadorPoisson(truncador, tablaAleatorios, lambda, valoresDiscretos, frecuenciasObservadas);

            PantallaPruebaChi pantallaPrueba = new PantallaPruebaChi();
            pantallaPrueba.probador = probador;
            pantallaPrueba.Show();
        }
        public void graficar()
        {
            GraficadorFrecuencias graficador = new GraficadorFrecuencias();
            graficador.frecuenciaObservada = this.frecuenciasObservadas;
            graficador.nombre = "Poisson";
            graficador.valoresDiscretos = this.valoresDiscretos;
            pantalla.mostrarGrafico(graficador);
        }
    }
}
