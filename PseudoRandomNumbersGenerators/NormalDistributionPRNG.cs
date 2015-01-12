using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PseudoRandomNumbersGenerators
{
    sealed class NormalDistributionPRNG : ContiniousNumberGenerator
    {
        /// <summary>
        /// Возвращает массив величин с нормальным распределением
        /// </summary>
        /// <param name="count">Размерность возвращаемого массива</param>
        /// <param name="M">Парметр нормального закона распределения</param>
        /// <param name="sigma">Парметр нормального закона распределения</param>
        /// <returns>Возвращает массив величин с нормальным распределением</returns>
        public double[] Generate(int count, double M, double sigma)
        {
            #region Проверки
            if (count < 1)
                throw new Exception("Параметр 'count' задан неверно. Проверьте count >= 1");
            if (sigma <= 0)
                throw new Exception("Неверно задан параметр нормального распределения. Проверьте sigma > 0");
            if (double.IsNaN(M))
                throw new Exception("Неверно задан параметр нормального распределения.");
            #endregion
            Random rnd = new Random();
            double[] NDA = new double[count];
            bool flag;
            for (int i = 0; i < count; i++)
            {
                flag = true;
                while (flag)
                {
                    double v = 2.0 * rnd.NextDouble() - 1.0;
                    double u = 2.0 * rnd.NextDouble() - 1.0;
                    double z = Math.Pow(v, 2) + Math.Pow(u, 2);
                    if (z > 1)
                        continue;
                    double y = Math.Sqrt(-2.0 * Math.Log(z) / z) * sigma;
                    int helper = rnd.Next(2);
                    if (helper == 0)
                    { 
                        NDA[i] = v * y + M;
                        flag = false; 
                    }
                    if (helper == 1)
                    {
                        NDA[i] = u * y + M;
                        flag = false;
                    }
                }
            }
            return NDA;
        }
    }
}
