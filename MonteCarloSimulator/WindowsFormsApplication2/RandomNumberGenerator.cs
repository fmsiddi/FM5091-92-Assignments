using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    public class RandomNumberGenerator
    {
        public void PolarRejection(int simulations, int timeSteps, bool antithetic, out double [,] randomMatrix)
        {
            Random rnd = new Random();
            double randn1;
            double randn2;
            double w;
            double c;
            double y1;
            double y2;

            if (!antithetic)
            {
                randomMatrix = new double[simulations, timeSteps];

                for (int i = 0; i < simulations; i += 2)
                {
                    for (int j = 0; j < timeSteps; j++)
                    {
                        do
                        {
                            randn1 = 2 * rnd.NextDouble() - 1;
                            randn2 = 2 * rnd.NextDouble() - 1;
                            w = Math.Pow(randn1, 2) + Math.Pow(randn2, 2);
                        }
                        while (w > 1);
                        c = Math.Sqrt(-2 * (Math.Log(w) / w));
                        y1 = c * randn1;
                        y2 = c * randn2;

                        randomMatrix[i, j] = y1;

                        if (i + 1 < simulations)
                        {
                            randomMatrix[i + 1, j] = y2;
                        }
                    }
                }
            }

            else
            {
                randomMatrix = new double[2 * simulations, timeSteps];

                for (int i = 0; i < simulations; i += 2)
                {
                    for (int j = 0; j < timeSteps; j++)
                    {
                        do
                        {
                            randn1 = 2 * rnd.NextDouble() - 1;
                            randn2 = 2 * rnd.NextDouble() - 1;
                            w = Math.Pow(randn1, 2) + Math.Pow(randn2, 2);
                        }
                        while (w > 1);
                        c = Math.Sqrt(-2 * (Math.Log(w) / w));
                        y1 = c * randn1;
                        y2 = c * randn2;
                        //double z1 = y1;
                        //double z2 = (cor * y1) + (Math.Sqrt(1 - (Math.Pow(cor, 2))) * y2);

                        randomMatrix[i, j] = y1;
                        randomMatrix[i + simulations, j] = -y1;

                        if (i + 1 < simulations)
                        {
                            randomMatrix[i + 1, j] = y2;
                            randomMatrix[i + 1 + simulations, j] = -y2;
                        }
                    }
                }
            }
        }
    }
}
