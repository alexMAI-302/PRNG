using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PseudoRandomNumbersGenerators
{
    sealed class ChiSquareDistributionPRNG : ContiniousNumberGenerator
    {
        /// <summary>
        /// Возвращает массив величин с Хи-квадрат распределением
        /// </summary>
        /// <param name="count">Размерность возвращаемого массива</param>
        /// <param name="k">Параметр Хи-квадрат распределения</param>
        /// <returns>массив величин с Хи-квадрат распределением</returns>
        public double[] Generate(int count, int k)
        {
            #region Проверки
            if (count < 1)
                throw new Exception("Параметр 'count' задан неверно. Проверьте count >= 1");
            if (k < 1)
                throw new Exception("Неверно задан параметр Хи-квадрат распределения. Проверьте k>0.");
            #endregion
            double sum;
            double[] CSA = new double[count];
            NormalDistributionPRNG ND = new NormalDistributionPRNG();
            for (int i = 0; i < count; i++)
            {
                sum = 0;
                for (int j = 0; j < k; j++)
                    sum += Math.Pow(ND.Generate(count * k, 0, 1)[i+k], 2);
                CSA[i] = sum;
            }
            return CSA;
        }
    }
}
