using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PseudoRandomNumbersGenerators
{
    sealed class ExponentialDistributionPRNG : ContiniousNumberGenerator
    {
        /// <summary>
        /// Возвращает массив величин с экспоненциальным распределением
        /// </summary>
        /// <param name="count">Размерность возвращаемого массива</param>
        /// <param name="lambda">Параметр экспоненциального распределения</param>
        /// <returns>массив величин с экспоненциальным распределением</returns>
        public double[] Generate(int count, double lambda)
        {
            #region Проверки
            if (count < 1)
                throw new Exception("Параметр 'count' задан неверно. Проверьте count >= 1");
            if (lambda <= 0)
                throw new Exception("Неверно задан параметр экспоненциального распределения. Проверьте: lambda > 0");
            #endregion
            double[] EDA = new double[count];
            Random rnd = new Random();
            for (int i = 0; i < count; i++)
                EDA[i] = (-1.0 / lambda) * Math.Log(1.0 - rnd.NextDouble());
            return EDA;
        }
    }
}
