using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VariablesAleatorias.Soporte
{
    class ContadorFrecuenciaObservada
    {
        private int[] frecuenciaObservada;

        private int cantidadIntervalos;

        private double[] inicioIntervalos;
        private double[] finIntervalos;

        private Dictionary<int, int> frecuenciasPoisson;

        private int[] valoresEnterosPoisson;
        private int[] frecuenciasEnterasPoisson;

        public ContadorFrecuenciaObservada()
        {
            this.frecuenciasPoisson = new Dictionary<int, int>();
        }

        public ContadorFrecuenciaObservada(double[] inicioIntervalos, double[] finIntervalos)
        {
            this.cantidadIntervalos = inicioIntervalos.Length;
            this.frecuenciaObservada = new int[cantidadIntervalos];
            this.inicioIntervalos = inicioIntervalos;
            this.finIntervalos = finIntervalos;
        }
        public void contarNumero(double numero)
        {
            for (int i = 0; i < cantidadIntervalos; i++)
            {
                if (numero >= inicioIntervalos[i] && numero <= finIntervalos[i])
                {
                    frecuenciaObservada[i] += 1;
                }
            }
        }

        public void contarFrecuenciaSerie(DataTable numeros)
        {
            for (int i = 0; i < numeros.Rows.Count; i++)
            {
                double aleatorio = double.Parse(numeros.Rows[i][1].ToString());
                contarNumero(aleatorio);
            }
        }


        public int[] obtenerFrecuencias()
        {
            return frecuenciaObservada;
        }


        public string mostrarFrecuencias()
        {
            int acum = 0;
            string res = " ";
            for (int i = 0; i < cantidadIntervalos; i++)
            {
                acum += frecuenciaObservada[i];
                res += inicioIntervalos[i] + " " + finIntervalos[i] + "=" + frecuenciaObservada[i].ToString();
                res += "\n";
            }
            return res;
        }

        // desde aqui hasta abajo deberia ser otra clase
        public void contarPoisson(int numero)
        {
            if (!frecuenciasPoisson.ContainsKey(numero)) { frecuenciasPoisson.Add(numero, 0); } // Se fija en la hash table si existe el valor que pasamos como parámetro, si no existe lo agrega.
            int recuperado = frecuenciasPoisson[numero];
            recuperado += 1;
            frecuenciasPoisson[numero] = recuperado; // Suma uno en el contador uno.
        }

        public void ordenarSeriePoisson()
        {
            valoresEnterosPoisson = obtenerValoresPoisson();
            frecuenciasEnterasPoisson = obtenerFrecuenciasPoisson();
            Sort(valoresEnterosPoisson, frecuenciasEnterasPoisson, 0, valoresEnterosPoisson.Length - 1);
        }

        public int[] getValoresPoisson()
        {
            return valoresEnterosPoisson;
        }

        public int[] getFrecuenciasPoisson()
        {
            return frecuenciasEnterasPoisson;
        }

        public int[] obtenerFrecuenciasPoisson()
        {
            int[] resultado = new int[frecuenciasPoisson.Count];
            int i = 0;
            foreach (var entry in frecuenciasPoisson)
            {
                resultado[i] = entry.Value;
                i++;
            }
            return resultado;
        }

        public int[] obtenerValoresPoisson()
        {
            int[] valores = new int[frecuenciasPoisson.Count];
            int i = 0;

            foreach (var entry in frecuenciasPoisson)
            {
                valores[i] = entry.Key;
                i++;
            }
            return valores;
        }


        private int Partition(int[] numeros, int[] frecuencia, int low,
                                  int high)
        {
            //1. Select a pivot point.
            int pivot = numeros[high];

            int lowIndex = (low - 1);

            //2. Reorder the collection.
            for (int j = low; j < high; j++)
            {
                if (numeros[j] <= pivot)
                {
                    lowIndex++;

                    int temp = numeros[lowIndex];
                    int tempFrecuencia = frecuencia[lowIndex];

                    numeros[lowIndex] = numeros[j];
                    frecuencia[lowIndex] = frecuencia[j];

                    numeros[j] = temp;
                    frecuencia[j] = tempFrecuencia;
                }
            }

            int temp1 = numeros[lowIndex + 1];
            int temp1Frecuencia = frecuencia[lowIndex + 1];

            numeros[lowIndex + 1] = numeros[high];
            frecuencia[lowIndex + 1] = frecuencia[high];

            numeros[high] = temp1;
            frecuencia[high] = temp1Frecuencia;

            return lowIndex + 1;
        }

        private void Sort(int[] numeros, int[] frecuencias, int low, int high)
        {
            if (low < high)
            {
                int partitionIndex = Partition(numeros, frecuencias, low, high);

                //3. Recursively continue sorting the array
                Sort(numeros, frecuencias, low, partitionIndex - 1);
                Sort(numeros, frecuencias, partitionIndex + 1, high);
            }
        }

        private void mostrarValoresFrecuenciasPoisson()
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < valoresEnterosPoisson.Length; i++)
            {
                stringBuilder.Append(valoresEnterosPoisson[i].ToString()).Append(":").Append(frecuenciasEnterasPoisson[i].ToString());
                stringBuilder.Append("\n");
            }
            MessageBox.Show(stringBuilder.ToString());
        }
    }
}
