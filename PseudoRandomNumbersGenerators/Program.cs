using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PseudoRandomNumbersGenerators
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            int[] vec = new int[10];

            BinomialDistributionPRNG BD = new BinomialDistributionPRNG();
            vec = BD.Generate(10, 15, 0.35);

            for (int i = 0; i < 10; i++)
                Console.WriteLine(vec[i]);*/

            TriangleSimpsonDistributionPRNG gen = new TriangleSimpsonDistributionPRNG();
            double[] selection = new double[10000];
            selection = gen.Generate(10000, 5, 20, 15);
            int w = 0;
            FileStream stream = new FileStream(@"C:\Users\Alex\Desktop\r.txt", FileMode.Open, FileAccess.Write);
            StreamWriter sr = new StreamWriter(stream);
            while (w < 10000)
            {
                sr.WriteLine(selection[w]);
                w++;
            }


            Console.ReadKey();
        }
    }
}
