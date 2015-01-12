using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PseudoRandomNumbersGenerators
{
    sealed class BinomialDistributionPRNG : DiscreteNumberGenerator
    {
        /// <summary>
        /// Возвращает массив величин с БЗР
        /// </summary>
        /// <param name="count">Размерность возвращаемого массива</param>
        /// <param name="n">Параметр БЗР</param>
        /// <param name="p">Параметр БЗР</param>
        /// <returns>массив величин с БЗР</returns>
        public int[] Generate(int count, int n, double p)
        {
            #region Проверки
            if (count < 1)
                throw new Exception("Параметр 'count' задан неверно. Проверьте count >= 1");
            if (n < 0)
                throw new Exception("Параметр 'n' задан неверно. n должно быть >= 0");
            if ((p < 0) || (p > 1))
                throw new Exception("Вероятность 'p' должна лежать в интервале [0; 1]");
            #endregion
            Random rnd = new Random();
            int m;
            int[] BDA = new int[count];
            for (int i = 0; i < count; i++)
            {
                m = 0;
                for (int j = 0; j < n; j++)
                {
                    if (rnd.NextDouble() < p)
                        m++;
                }
                BDA[i] = m;
            }
            return BDA;
        }
    }
}
