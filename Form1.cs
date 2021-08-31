using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VariablesAleatorias.Graficador;

namespace VariablesAleatorias
{
    public partial class Form1 : Form
    {
        GestorUniforme gestorUniforme;
        GestorExponencial gestorExponencial;
        GestorNormal gestorNormalBoxMuller;
        GestorPoisson gestorPoisson;

        int cantidadValores;
        int cantidadIntervalos;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.cantidadValores = 1000;
            this.cantidadIntervalos = 10;
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            limpiarControles();
            tomarCantidadValores();
            tomarCantidadIntervalos();
            generarVariablesAleatorias();
        }

        private void limpiarControles()
        {
            gbGrafico.Controls.Clear();
            grdAleatorios.DataSource = null;
            gbGrafico.Controls.Clear();
        }

        private void tomarCantidadValores()
        {
            if (cantDatos.Text.Equals("")) { return; }
            cantidadValores = int.Parse(cantDatos.Text);
        }
        private void tomarCantidadIntervalos()
        {
            if (cantIntervalos.Text.Equals("")) { return; }
            cantidadIntervalos = int.Parse(cantIntervalos.Text);
        }

        private void generarVariablesAleatorias()
        {
            if (rbUniforme.Checked)
            {
                generarUniforme();
                return;
            }
            if (rbNormal.Checked)
            {
                generarNormalBoxMuller();
                return;
            }
            if (rbExponencialNegativa.Checked)
            {
                generarExponencialNegativa();
                return;
            }
            if (rbPoisson.Checked)
            {
                generarPoisson();
                return;
            }
        }

        private void generarUniforme()
        {
            if (txtA.Text.Equals("") || txtB.Text.Equals("")) { return; }
            gestorUniforme = new GestorUniforme(this);
            float a = float.Parse(txtA.Text);
            float b = float.Parse(txtB.Text);
            gestorUniforme.generarUniforme(a, b, cantidadValores, cantidadIntervalos);
        }

        private void generarNormalBoxMuller()
        {
            if (mediaNormal.Text.Equals("") || desviacionNormal.Text.Equals("")) { return; }
            gestorNormalBoxMuller = new GestorNormal(this);
            double desviacion = double.Parse(desviacionNormal.Text);
            double media = double.Parse(mediaNormal.Text);
            gestorNormalBoxMuller.generarNormalBoxMuller(media, desviacion, cantidadValores, cantidadIntervalos);
        }

        private void generarExponencialNegativa()
        {
            if (lambdaExponencial.Text.Equals("") && mediaExponencial.Text.Equals("")) { return; }
            gestorExponencial = new GestorExponencial(this);
            double[] exponencial = calcularLambdaExponencial();
            double lambda = exponencial[0];
            double media = exponencial[1];
            gestorExponencial.generarExponencial(lambda, media, cantidadValores, cantidadIntervalos);
        }
        private void generarPoisson()
        {
            if (lambdaPoisson.Text.Equals("") && mediaPoisson.Text.Equals("")) { return; }
            gestorPoisson = new GestorPoisson(this);
            double[] parametros = calcularLambdaPoisson();
            double lambda = parametros[0];
            double media = parametros[1];
            gestorPoisson.generarPoisson(lambda, media, cantidadValores);
        }

        private double[] calcularLambdaExponencial()
        {
            double lambda;
            double media;


            if (lambdaExponencial.Text.Equals(""))
            {
                media = double.Parse(mediaExponencial.Text);
                lambda = 1 / media;
                lambdaExponencial.Text = lambda.ToString();
            }

            lambda = double.Parse(lambdaExponencial.Text);
            media = 1 / lambda;
            mediaExponencial.Text = media.ToString();

            return new double[] { lambda, media };
        }

        public void mostrarResultados(DataTable resultados)
        {
            this.grdAleatorios.DataSource = resultados;
        }

        private double[] calcularLambdaPoisson()
        {
            double lambda;
            double media;

            if (lambdaPoisson.Text.Equals(""))
            {
                media = double.Parse(mediaPoisson.Text);
                lambda = media;
                lambdaPoisson.Text = lambda.ToString();
            }

            lambda = double.Parse(lambdaPoisson.Text);
            media = lambda;
            mediaPoisson.Text = media.ToString();

            return new double[] { lambda, media };
        }

        public void mostrarGrafico(GraficadorFrecuencias graficador)
        {
            gbGrafico.Controls.Clear();
            graficador.TopLevel = false;
            graficador.AutoScroll = true;
            graficador.FormBorderStyle = FormBorderStyle.None;
            graficador.Dock = DockStyle.Fill;
            gbGrafico.Controls.Add(graficador);
            graficador.Show();
        }

        private void limpiarCampos()
        {
            txtA.Text = "";
            txtB.Text = "";
            desviacionNormal.Text = "";
            mediaNormal.Text = "";
            mediaPoisson.Text = "";
            lambdaPoisson.Text = "";
            lambdaExponencial.Text = "";
            mediaExponencial.Text = "";
        }

        private void mostrarDistribucion()
        {
            limpiarCampos();
            if (rbUniforme.Checked)
            {
                activarIntervalos();
                gbUniforme.Visible = true;
                gbExponencialNegativa.Visible = false;
                gbNormal.Visible = false;
                gbPoisson.Visible = false;
                return;
            }
            if (rbNormal.Checked)
            {
                activarIntervalos();
                gbNormal.Visible = true;
                gbUniforme.Visible = false;
                gbExponencialNegativa.Visible = false;
                gbPoisson.Visible = false;
                return;
            }
            if (rbExponencialNegativa.Checked)
            {
                activarIntervalos();
                gbExponencialNegativa.Visible = true;
                gbUniforme.Visible = false;
                gbNormal.Visible = false;
                gbPoisson.Visible = false;
                return;
            }
            if (rbPoisson.Checked)
            {
                desactivarIntervalos();
                gbPoisson.Visible = true;
                gbExponencialNegativa.Visible = false;
                gbUniforme.Visible = false;
                gbNormal.Visible = false;
                return;
            }
        }

        private void activarIntervalos()
        {
            if (!cantIntervalos.Enabled) { cantIntervalos.Enabled = true; }
        }

        private void desactivarIntervalos()
        {
            cantIntervalos.Enabled = false;
        }

        private void probar()
        {
            if (rbUniforme.Checked)
            {
                gestorUniforme.probar();
                return;
            }
            if (rbNormal.Checked)
            {
                gestorNormalBoxMuller.probar();
                return;
            }
            if (rbExponencialNegativa.Checked)
            {
                gestorExponencial.probar();
                return;
            }
            if (rbPoisson.Checked)
            {
                gestorPoisson.probar();
                return;
            }
        }

        private void btnGraficar_Click(object sender, EventArgs e)
        {

        }

        private void rbUniforme_CheckedChanged(object sender, EventArgs e)
        {
            mostrarDistribucion();
        }

        private void rbNormal_CheckedChanged(object sender, EventArgs e)
        {
            mostrarDistribucion();
        }

        private void rbExponencialNegativa_CheckedChanged(object sender, EventArgs e)
        {
            mostrarDistribucion();
        }

        private void rbPoisson_CheckedChanged(object sender, EventArgs e)
        {
            mostrarDistribucion();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            probar();
        }
    }
}
