using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class Barrier : Option
    {
        public Barrier(double[,] optionSimulatedStockPaths, double optionK, int optionSimNumber, int optionTimeSteps, bool optionCallOrPut, double barrier, string barrierType) : base(optionSimulatedStockPaths, optionK, optionSimNumber, optionTimeSteps, optionCallOrPut)
        {
            simulatedStockPaths = optionSimulatedStockPaths;
            K = optionK;
            simNumber = optionSimNumber;
            timeSteps = optionTimeSteps;
            callOrPut = optionCallOrPut;
            B = barrier;
            type = barrierType;
        }

        public double B { get; }

        public string type { get; }

        public override double[] terminalPayoff()
        {
            double[] terminalPayoffVector = new double[simNumber];

            for (int i = 0; i < simNumber; i++)
            {
                double[] singleSimulation = new double[timeSteps];
                for (int j = 0; j < timeSteps; j++)
                {
                    singleSimulation[j] = simulatedStockPaths[i, j];
                }

                if (callOrPut)
                {
                    if (type == "Up and In")
                    {
                        if (singleSimulation.Max() > B)
                        {
                            terminalPayoffVector[i] = Math.Max(simulatedStockPaths[i, timeSteps - 1] - K, 0);
                        }
                        else
                        {
                            terminalPayoffVector[i] = 0;
                        }
                    }
                    else if (type == "Up and Out")
                    {
                        if (singleSimulation.Max() > B)
                        {
                            terminalPayoffVector[i] = 0;
                        }
                        else
                        {
                            terminalPayoffVector[i] = Math.Max(simulatedStockPaths[i, timeSteps - 1] - K, 0);
                        }
                    }
                    else if (type == "Down and In")
                    {
                        if (singleSimulation.Min() < B)
                        {
                            terminalPayoffVector[i] = Math.Max(simulatedStockPaths[i, timeSteps - 1] - K, 0);
                        }
                        else
                        {
                            terminalPayoffVector[i] = 0;
                        }
                    }
                    else
                    {
                        if (singleSimulation.Min() < B)
                        {
                            terminalPayoffVector[i] = 0;
                        }
                        else
                        {
                            terminalPayoffVector[i] = Math.Max(simulatedStockPaths[i, timeSteps - 1] - K, 0);
                        }
                    }
                }

                else
                {
                    if (type == "Up and In")
                    {
                        if (singleSimulation.Max() > B)
                        {
                            terminalPayoffVector[i] = Math.Max(K - simulatedStockPaths[i, timeSteps - 1], 0);
                        }
                        else
                        {
                            terminalPayoffVector[i] = 0;
                        }
                    }
                    else if (type == "Up and Out")
                    {
                        if (singleSimulation.Max() > B)
                        {
                            terminalPayoffVector[i] = 0;
                        }
                        else
                        {
                            terminalPayoffVector[i] = Math.Max(K - simulatedStockPaths[i, timeSteps - 1], 0);
                        }
                    }
                    else if (type == "Down and In")
                    {
                        if (singleSimulation.Min() < B)
                        {
                            terminalPayoffVector[i] = Math.Max(K - simulatedStockPaths[i, timeSteps - 1], 0);
                        }
                        else
                        {
                            terminalPayoffVector[i] = 0;
                        }
                    }
                    else
                    {
                        if (singleSimulation.Min() < B)
                        {
                            terminalPayoffVector[i] = 0;
                        }
                        else
                        {
                            terminalPayoffVector[i] = Math.Max(K - simulatedStockPaths[i, timeSteps - 1], 0);
                        }
                    }
                }
            }
            return terminalPayoffVector;
        }
    }
}
