using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PseudoRandomNumbersGenerators
{
    sealed class PoissonDistributionPRNG : DiscreteNumberGenerator
    {
        /// <summary>
        /// Возвращает массив величин с законом распределения Пуассона
        /// </summary>
        /// <param name="count">Размерность возвращаемого массива</param>
        /// <param name="a">Параметр закона Пуассона</param>
        /// <returns>массив величин с законом распределения Пуассона</returns>
        public int[] Generate(int count, double a)
        {
            #region Проверки
            if (count < 1)
                throw new Exception("Параметр 'count' задан неверно. Проверьте count >= 1");
            if (a < 0)
                throw new Exception("Параметр 'a' закона Пуассона должен быть больше нуля.");
            #endregion
            int[] PDA = new int[count];
            Random rnd = new Random();
            int m = 0;
            double p0 = Math.Exp(-1.0 * a);
            for (int i = 0; i < count; i++)
            {
                for (double ksi = rnd.NextDouble(); ksi >= p0; ksi *= rnd.NextDouble())
                    m++;
                PDA[i] = m;
            }
            return PDA;
        }
    }
}
