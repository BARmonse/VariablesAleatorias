using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariablesAleatorias.Soporte.Probadores
{
    public interface IProbador
    {
        void probar();
        Boolean esAceptado();
        DataTable obtenerTablaResultados();
        double obtenerTotalAcumuladoEstadisticoPrueba();
        double getValorCritico();
    }
}
