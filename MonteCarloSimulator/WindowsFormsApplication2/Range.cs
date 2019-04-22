using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class Range : Option
    {
        public Range(double[,] optionSimulatedStockPaths, double optionK, int optionSimNumber, int optionTimeSteps, bool optionCallOrPut) : base(optionSimulatedStockPaths, optionK, optionSimNumber, optionTimeSteps, optionCallOrPut)
        {
            simulatedStockPaths = optionSimulatedStockPaths;
            K = optionK;
            simNumber = optionSimNumber;
            timeSteps = optionTimeSteps;
            callOrPut = optionCallOrPut;
        }

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

                terminalPayoffVector[i] = Math.Max(singleSimulation.Max() - singleSimulation.Min(), 0);
            }
            return terminalPayoffVector;
        }
    }
}
