using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trinomial_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number associated with the desired option: \n" +
                              "Euro Call = 1 \n" +
                              "Euro Put = 2 \n" +
                              "American Call = 3 \n" +
                              "American Put = 4 \n");
            int type = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please provide initial stock price:");
            double S0 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please provide strike price:");
            double K = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please provide volatility in decimal form:");
            double vol = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please provide risk-free interest rate in decimal form:");
            double r = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please provide dividend rate in decimal form:");
            double q = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please provide length of time period in years in decimal form:");
            double T = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please provide number of steps desired:");
            int N = Convert.ToInt32(Console.ReadLine());
            double dvol = 0.0001;
            double dr = 0.0001;
            double price = 0;
            double delta = 0;
            double gamma = 0;
            double theta = 0;
            Trinomial_Tree(type, S0, K, vol, r, q, T, N, out price, out delta, out gamma, out theta);
            Console.WriteLine("Price: {0} ", price);
            Console.WriteLine("Delta: {0} ", delta);
            Console.WriteLine("Gamma: {0} ", gamma);
            Console.WriteLine("Theta: {0} ", theta);
            double vega = (Trinomial_Tree(type, S0, K, vol + vol * dvol, r, q, T, N, out price, out delta, out gamma, out theta) - Trinomial_Tree(type, S0, K, vol - vol * dvol, r, q, T, N, out price, out delta, out gamma, out theta)) / (2 * vol * dvol);
            Console.WriteLine("Vega: {0} ", vega);
            double rho = (Trinomial_Tree(type, S0, K, vol, r + r * dr, q, T, N, out price, out delta, out gamma, out theta) - Trinomial_Tree(type, S0, K, vol, r - r * dr, q, T, N, out price, out delta, out gamma, out theta)) / (2 * r * dr);
            Console.WriteLine("Rho: {0} ", rho);
            Console.ReadLine();
        }

        static double Trinomial_Tree(int type, double S0, double K, double vol, double r, double q, double T, int N, out double price, out double delta, out double gamma, out double theta)
        {
            double deltaT = T / N; 
            double deltax = vol * Math.Sqrt(3 * deltaT);
            double v = r - q - (0.5 * Math.Pow(vol,2)) ;
            double u = Math.Exp(deltax);
            double d = 1 / u;
            double pu = 0.5 * ((((Math.Pow(vol, 2) * deltaT) + (Math.Pow(v,2) * Math.Pow(deltaT,2))) / Math.Pow(deltax,2)) + ((v * deltaT) / deltax));
            double pd = 0.5 * ((((Math.Pow(vol, 2) * deltaT) + (Math.Pow(v,2) * Math.Pow(deltaT,2))) / Math.Pow(deltax,2)) - ((v * deltaT) / deltax));
            double pm = 1 - pu - pd;
            double disc = Math.Exp(-r * deltaT);
            double[,] SVals = new double[(2*N) + 2, N + 1];
            double[,] OVals = new double[(2*N) + 2, N + 1];
            SVals[0, 0] = S0;

            for (int j = 0; j <= N; j++) //Build stock lattice
            {
                for (int i = 0; i <= (2*j); i++)
                {
                    SVals[i, j] = SVals[0,0] * (Math.Pow(u,i) * Math.Pow(d,j));
                }
            }

            for (int i = 0; i <= (2*N); i++) //Calculate option price at final timestep of the tree
            {
                if (type == 1 || type == 3) //Calls
                {
                    OVals[i, N] = Math.Max(SVals[i, N] - K, 0);
                }
                else if (type == 2 || type == 4) //Puts
                {
                    OVals[i, N] = Math.Max(K - SVals[i, N], 0);
                }
            }

            for (int j = N-1; j >= 0; j--) //Working backwards from the terminal option prices to get initial option price
            {
                for (int i = 0; i <= (2*j); i++)
                {
                    if (type == 1 || type == 2) //Euro Call or Put
                    {
                        OVals[i, j] = disc * (pu * OVals[i + 2, j + 1] + pd * OVals[i, j + 1] + pm * OVals[i + 1, j + 1]);
                    }
                    else if (type == 3 || type == 4)
                    {
                        OVals[i, j] = disc * (pu * OVals[i + 2, j + 1] + pd * OVals[i, j + 1] + pm * OVals[i + 1, j + 1]);
                        if (type == 3) //American Call
                        {
                            OVals[i, j] = Math.Max(OVals[i, j], SVals[i, j] - K);
                        }
                        else if (type == 4) //American Put
                        {
                            OVals[i, j] = Math.Max(OVals[i, j], K - SVals[i, j]);
                        }
                    }
                }
            }
            price = OVals[0, 0];
            delta = (OVals[2, 1] - OVals[0, 1]) / (SVals[2, 1] - SVals[0, 1]);
            gamma = (((OVals[2, 1] - OVals[1, 1]) / (SVals[2, 1] - SVals[1, 1])) - ((OVals[1, 1] - OVals[0, 1]) / (SVals[1, 1] - SVals[0, 1]))) / (0.5 * (SVals[2, 1] - SVals[0, 1]));
            theta = (OVals[2, 2] - OVals[0, 0]) / (2 * deltaT);
            return price;
        }
    }
}
