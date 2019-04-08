using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace WindowsFormsApplication2
{
    public class RandomNumberGenerator
    {
        Random rnd = new Random();
        public RandomNumberGenerator()
        {
            rnd = new Random(GetHashCode());
        }

        public double PolarRejectionPure()
        {
            double randn1;
            double randn2;
            double w;
            double c;

            do
            {
                randn1 = 2 * rnd.NextDouble() - 1;
                randn2 = 2 * rnd.NextDouble() - 1;
                w = Math.Pow(randn1, 2) + Math.Pow(randn2, 2);
            }
            while (w > 1);
            c = Math.Sqrt(-2 * (Math.Log(w) / w));
            return c * randn1;
        }

        public double [,] PolarRejection(int simulations, int timeSteps, bool antithetic, bool threading)
        {
            double randn1;
            double randn2;
            double w;
            double c;
            double y1;
            double y2;
            double[,] randomMatrix;

            if (!antithetic)
            {
                randomMatrix = new double[simulations, timeSteps];

                if (!threading)
                {
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

                    return randomMatrix;
                }

                else //if antithetic is FALSE and multithreading is TRUE
                {
                    int cores = Environment.ProcessorCount;
                    int count = 0;
                    int simulationsForThread;

                    if (simulations % cores == 0)
                    {
                        simulationsForThread = simulations / cores;
                    }
                    else
                    {
                        simulationsForThread = simulations / cores + 1;
                    }

                    List<Thread> threadList = new List<Thread>();

                    Action<object> FillMatrix = (o) =>
                    {
                        int start = Convert.ToInt32(o);
                        int end = start + simulationsForThread;

                        if (end > simulations)
                        {
                            end = simulations;
                        }

                        RandomNumberGenerator gen = new RandomNumberGenerator();
                        for (int i = start; i < end; i++)
                        {
                            for (int j = 0; j < timeSteps; j++)
                            {
                                randomMatrix[i, j] = gen.PolarRejectionPure();
                            }
                        }
                    };


                    for (int k = 0; k < cores; k++)
                    {
                        threadList.Add(new Thread(new ParameterizedThreadStart(FillMatrix)));
                        threadList[k].Start(count);
                        count += simulationsForThread;
                    }
                    foreach (Thread t in threadList)
                    {
                        t.Join();
                    }
                    return randomMatrix;
                }
            }





            else //if antithetic is TRUE
            {
                randomMatrix = new double[2 * simulations, timeSteps];

                if (!threading)
                {
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

                    return randomMatrix;
                }

                else //if antithreading is TRUE and multithreading is TRUE
                {
                    int cores = Environment.ProcessorCount;
                    int count = 0;
                    int simulationsForThread;

                    if (simulations % cores == 0)
                    {
                        simulationsForThread = simulations / cores;
                    }
                    else
                    {
                        simulationsForThread = simulations / cores + 1;
                    }

                    List<Thread> threadList = new List<Thread>();

                    Action<object> FillMatrix = (o) =>
                    {
                        int start = Convert.ToInt32(o);
                        int end = start + simulationsForThread;

                        if (end > simulations)
                        {
                            end = simulations;
                        }

                        RandomNumberGenerator gen = new RandomNumberGenerator();
                        for (int i = start; i < end; i++)
                        {
                            for (int j = 0; j < timeSteps; j++)
                            {
                                double entry = gen.PolarRejectionPure();
                                randomMatrix[i, j] = entry;
                                randomMatrix[i + simulations, j] = -entry;
                            }
                        }
                    };

                    for (int k = 0; k < cores; k++)
                    {
                        threadList.Add(new Thread(new ParameterizedThreadStart(FillMatrix)));
                        threadList[k].Start(count);
                        count += simulationsForThread;
                    }
                    foreach (Thread t in threadList)
                    {
                        t.Join();
                    }
                    return randomMatrix;
                }
            }
        }
    }
}
