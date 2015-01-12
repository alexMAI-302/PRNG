using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PseudoRandomNumbersGenerators
{
    sealed class TriangleSimpsonDistributionPRNG : ContiniousNumberGenerator
    {
        /// <summary>
        /// Возвращает массив величин с треугольным распределением Симпсона
        /// </summary>
        /// <param name="count">Размерность возвращаемого массива</param>
        /// <param name="a">Левая граница - параметр ЗР</param>
        /// <param name="b">Правая граница - параметр ЗР</param>
        /// <param name="mu">МО - параметр ЗР</param>
        /// <returns>массив величин с треугольным распределением Симпсона</returns>
        public double[] Generate(int count, double a, double b, double mu)
        {
            #region Проверки
            if (count < 1)
                throw new Exception("Параметр 'count' задан неверно. Проверьте count >= 1");
            if (!((a < b) && (a <= mu) && (b >= mu)))
                throw new Exception("Неверно заданы параметры закона Симпсона. Проверьте: a < b, a <= mu <= b");
            #endregion
            double[] TSDA = new double[count];
            Random rnd = new Random();
            double ksi;
            for (int i = 0; i < count; i++)
            {
                ksi = rnd.NextDouble();
                if (ksi <= (mu - a) / (b - a))
                {
                    TSDA[i] = a + Math.Sqrt(ksi) * Math.Sqrt((mu - a) * (b - a));
                    continue;
                }
                TSDA[i] = b - Math.Sqrt((1 - ksi) * (b - a) * (b - mu));
            }
            return TSDA;
        }
    }
}
