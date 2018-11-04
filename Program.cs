using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What is your correlation coefficient? Pick a number between -1 and 1. If you want uncorrelated pairs, enter 0.");
            double cor = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Type 1 for TwelveUniformRandom \n" +
                              "Type 2 for Box-Mueller \n" +
                              "Type 3 for Polar Rejection \n");
            int q = Convert.ToInt32(Console.ReadLine());
            if (q == 1)
            {
                Console.WriteLine("How many pairs of numbers would you like to generate?");
                int n = Convert.ToInt32(Console.ReadLine());
                TwelveUniformRandom(n, cor);
            }
            else if (q == 2)
            {
                Console.WriteLine("How many pairs of numbers would you like to generate?");
                int n = Convert.ToInt32(Console.ReadLine());
                BoxMueller(n, cor);
            }
            else if (q == 3)
            {
                Console.WriteLine("How many pairs of numbers would you like to generate?");
                int n = Convert.ToInt32(Console.ReadLine());
                PolarRejection(n, cor);
            }
            else
            {
                Console.WriteLine("Man, I said type 1, 2, or 3. Close the program and read a book about numbers.");
                Console.ReadLine();
            }
        }
        static void TwelveUniformRandom(int n, double cor)
        {
            Random rnd = new Random();
            for (int j = 0; j <= n; j++)
            {
                double randn1 = 0;
                double randn2 = 0;
                for (int i = 0; i <= 12; i++)
                {
                    randn1 += rnd.NextDouble();
                    randn2 += rnd.NextDouble();
                }
                double output1 = randn1 - 6;
                double output2 = randn2 - 6;
                double z1 = output1;
                double z2 = cor * output1 + Math.Sqrt(1 - (Math.Pow(cor, 2)) * output2);
                Console.WriteLine(z1);
                Console.WriteLine(z2);
            }
            Console.ReadLine();
        }
        static void BoxMueller(int n, double cor)
        {
            Random rnd = new Random();
            for (int i = 0; i <= n; i++)
            {
                double randn1 = 2 * (rnd.NextDouble() - 1);
                double randn2 = 2 * (rnd.NextDouble() - 1);
                double BMOne = Math.Sqrt(-2 * Math.Log(randn1)) * Math.Cos(2 * Math.PI * randn2);
                double BMTwo = Math.Sqrt(-2 * Math.Log(randn1)) * Math.Sin(2 * Math.PI * randn2);
                double z1 = BMOne;
                double z2 = cor * BMOne + Math.Sqrt(1 - (Math.Pow(cor, 2)) * BMTwo);
                Console.WriteLine(z1);
                Console.WriteLine(z2);
            }
            Console.ReadLine();
        }
        static void PolarRejection(int n, double cor)
        {
            Random rnd = new Random();
            double randn1;
            double randn2;
            double w;
            double c;
            double y1;
            double y2;
            for (int i = 0; i <= n; i++)
            {
                do
                {
                    randn1 = 2 * (rnd.NextDouble() - 1);
                    randn2 = 2 * (rnd.NextDouble() - 1);
                    w = Math.Pow(randn1, 2) + Math.Pow(randn2, 2);
                }
                while (w > 1);
                c = Math.Sqrt(-2 * Math.Log(w) / w);
                y1 = c * randn1;
                y2 = c * randn2;
                double z1 = y1;
                double z2 = cor * y1 + Math.Sqrt(1 - (Math.Pow(cor, 2)) * y2);
                Console.WriteLine(z1);
                Console.WriteLine(z2);
                Console.WriteLine(z1);
                Console.WriteLine(z2);
            }
            Console.ReadLine();
        }
    }
}

