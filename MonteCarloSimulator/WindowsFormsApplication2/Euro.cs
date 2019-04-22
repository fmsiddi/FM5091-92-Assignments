using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    public class Euro : Option
    {

        public Euro(double[,] optionSimulatedStockPaths, double optionK, int optionSimNumber, int optionTimeSteps, bool optionCallOrPut) : base(optionSimulatedStockPaths, optionK, optionSimNumber, optionTimeSteps, optionCallOrPut)
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
                if (callOrPut)
                {
                    terminalPayoffVector[i] = Math.Max(simulatedStockPaths[i, timeSteps - 1] - K, 0);
                }
                else
                {
                    terminalPayoffVector[i] = Math.Max(K - simulatedStockPaths[i, timeSteps - 1], 0);
                }
            }
            return terminalPayoffVector;
        }
    }
}
