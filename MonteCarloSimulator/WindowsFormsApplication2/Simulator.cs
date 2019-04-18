using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace WindowsFormsApplication2
{
    class Simulator
    {

        public double[,] PathSimulator(double s0, double vol, double r, double T, int simNumber, int timeSteps, double[,] randomMatrix, bool threading)
        {
            double deltaT = T / (Convert.ToDouble(timeSteps) - 1);
            double annoying1 = (r - (Math.Pow(vol, 2) / 2.0)) * deltaT;
            double annoying2 = vol * Math.Sqrt(deltaT);
            double[,] simulatedStockPaths;

            simulatedStockPaths = new double[simNumber, timeSteps];

            if (!threading)
            {
                for (int i = 0; i < simNumber; i++)
                {
                    simulatedStockPaths[i, 0] = s0;
                    for (int j = 1; j < timeSteps; j++)
                    {
                        simulatedStockPaths[i, j] = simulatedStockPaths[i, j - 1] * Math.Exp(annoying1 + (annoying2 * randomMatrix[i, j]));
                    }
                }

                return simulatedStockPaths;
            }

            else
            {
                int cores = Environment.ProcessorCount;
                int startIndexForThreading = 0;
                int simulationsForThread;

                if (simNumber % cores == 0)
                {
                    simulationsForThread = simNumber / cores;
                }
                else
                {
                    simulationsForThread = simNumber / cores + 1;
                }

                List<Thread> threadList = new List<Thread>();

                Action<object> FillMatrix = (o) =>
                {
                    int start = Convert.ToInt32(o);
                    int end = start + simulationsForThread;

                    if (end > simNumber)
                    {
                        end = simNumber;
                    }

                    Simulator sim = new Simulator();
                    for (int i = start; i < end; i++)
                    {
                        simulatedStockPaths[i, 0] = s0;
                        for (int j = 1; j < timeSteps; j++)
                        {
                            simulatedStockPaths[i, j] = simulatedStockPaths[i, j - 1] * Math.Exp(annoying1 + (annoying2 * randomMatrix[i, j]));
                        }
                    }
                };

                for (int k = 0; k < cores; k++)
                {
                    threadList.Add(new Thread(new ParameterizedThreadStart(FillMatrix)));
                    threadList[k].Start(startIndexForThreading);
                    startIndexForThreading += simulationsForThread;
                }
                foreach (Thread t in threadList)
                {
                    t.Join();
                }
                return simulatedStockPaths;
            }
        }
    }
}
