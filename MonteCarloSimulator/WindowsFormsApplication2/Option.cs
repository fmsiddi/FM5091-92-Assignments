using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    public abstract class Option
    {
        protected double[,] simulatedStockPaths;
        protected double K;
        protected int simNumber, timeSteps;
        protected bool callOrPut;

        public Option(double[,] optionSimulatedStockPaths, double optionK, int optionSimNumber, int optionTimeSteps, bool optionCallOrPut)
        {
            simulatedStockPaths = optionSimulatedStockPaths;
            K = optionK;
            simNumber = optionSimNumber;
            timeSteps = optionTimeSteps;
            callOrPut = optionCallOrPut;
        }

        public abstract double[] terminalPayoff();
    }
}
