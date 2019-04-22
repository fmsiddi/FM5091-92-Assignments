using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class Digital : Option
    {
        public Digital(double[,] optionSimulatedStockPaths, double optionK, int optionSimNumber, int optionTimeSteps, bool optionCallOrPut, double digitalRebate) : base(optionSimulatedStockPaths, optionK, optionSimNumber, optionTimeSteps, optionCallOrPut)
        {
            simulatedStockPaths = optionSimulatedStockPaths;
            K = optionK;
            simNumber = optionSimNumber;
            timeSteps = optionTimeSteps;
            callOrPut = optionCallOrPut;
            rebate = digitalRebate;
        }

        public double rebate { get; }

        public override double[] terminalPayoff()
        {
            double[] terminalPayoffVector = new double[simNumber];

            for (int i = 0; i < simNumber; i++)
            {
                if (callOrPut)
                {
                    if (simulatedStockPaths[i, timeSteps - 1] > K)
                    {
                        terminalPayoffVector[i] = rebate;
                    }
                    else
                    {
                        terminalPayoffVector[i] = 0;
                    }
                }
                else
                {
                    if (simulatedStockPaths[i, timeSteps - 1] < K)
                    {
                        terminalPayoffVector[i] = rebate;
                    }
                    else
                    {
                        terminalPayoffVector[i] = 0;
                    }
                }
            }
            return terminalPayoffVector;
        }
    }
}
