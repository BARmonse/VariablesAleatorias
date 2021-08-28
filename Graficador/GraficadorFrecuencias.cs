using ScottPlot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VariablesAleatorias.Graficador
{
    public partial class GraficadorFrecuencias : Form
    {
        public int[] frecuenciaObservada { get; set; }
        public double[] inicioIntervalos { get; set; }
        public double[] finIntervalos { get; set; }
        public int[] frecuenciaEsperada { get; set; }

        public int[] valoresDiscretos { get; set; }

        public string nombre { get; set; }

        DataTable dataTable;
        DataRow dataRow;

        public GraficadorFrecuencias()
        {
            InitializeComponent();
        }

        private void GraficadorFrecuencias_Load(object sender, EventArgs e)
        {
            dataTable = new DataTable();
            dataTable.Columns.Add("int.");
            dataTable.Columns.Add("FO");
            //dataTable.Columns.Add("FE");

            List<double> tempObservada = new List<double>();
            List<double> tempEsperada = new List<double>();
            List<string> tempLabels = new List<string>();

            var plt = new Plot(600, 400);


            for (int i = 0; i < frecuenciaObservada.Length; i++)
            {
                List<object> temp = new List<object>();
                dataRow = dataTable.NewRow();

                tempLabels.Add((i + 1).ToString());
                if (inicioIntervalos != null)
                {
                    string intervalo = "[" + inicioIntervalos[i] + ";" + finIntervalos[i] + "]";
                    dataRow[0] = intervalo;
                }
                if (valoresDiscretos != null)
                {

                    string intervalo = valoresDiscretos[i] + ";";
                    dataRow[0] = intervalo;
                }

                double observado = frecuenciaObservada[i];
                dataRow[1] = observado;
                tempObservada.Add(observado);

                if (frecuenciaEsperada != null)
                {
                    double esperado = frecuenciaEsperada[i];
                    dataRow[2] = esperado;
                    tempEsperada.Add(esperado);
                }
                dataTable.Rows.Add(dataRow);
            }
            grdFrecuencias.DataSource = dataTable;

            // generate random data to plot
            int pointCount = frecuenciaObservada.Length;
            double[] xs = DataGen.Consecutive(pointCount);
            double[] y1 = tempObservada.ToArray();
            double[] y2 = tempEsperada.ToArray();
            double[] yError = new double[pointCount];

            // make the bar plot
            plt.PlotBar(xs, y1, yError, "Observado", barWidth: .3, xOffset: -.2);
            //plt.PlotBar(xs, y2, yError, "Esperado", barWidth: .3, xOffset: .2);
            plt.XLabel("Intervalos");
            plt.YLabel("Cantidad");
            plt.Legend(location: Alignment.LowerRight);
            // customize the plot to make it look nicer
            plt.AxisAutoY();
            plt.Grid(false, lineStyle: ScottPlot.LineStyle.Dot);

            // apply custom axis tick labels
            string[] labels = tempLabels.ToArray();
            plt.XTicks(xs, labels);

            //string imagePath = "C:\\\\Users\\" + Environment.UserName.ToString() + "\\histograma" + ".png";
            //plt.SaveFig(imagePath);
            //pictureBox1.Image = new Bitmap(imagePath);

            Random random = new Random();
            string rand = random.Next().ToString();
            string imagePath = "C:\\\\Users\\" + Environment.UserName.ToString() + "\\histograma" + rand + ".png";
            plt.SaveFig(imagePath);
            pictureBox1.Image = new Bitmap(imagePath);
        }
    }
}
