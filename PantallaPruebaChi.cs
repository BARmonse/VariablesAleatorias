using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VariablesAleatorias.Soporte.Probadores;

namespace VariablesAleatorias
{
    public partial class PantallaPruebaChi : Form
    {
        private DataTable dataTable;

        public IProbador probador;
        public PantallaPruebaChi()
        {
            InitializeComponent();
        }

        private void PantallaPruebaChi_Load(object sender, EventArgs e)
        {
            probador.probar();
            if (probador.esAceptado()) { lblResultado.Text = "No se rechaza la hipotesis nula"; }
            else { lblResultado.Text = "Se rechaza la hipotesis nula"; }

            txtValorCritico.Text = probador.getValorCritico().ToString();
            txtEstadisticoPruebaAcumulado.Text = probador.obtenerTotalAcumuladoEstadisticoPrueba().ToString();
            dataTable = probador.obtenerTablaResultados();
            grdResultados.DataSource = dataTable;
        }
    }
}
