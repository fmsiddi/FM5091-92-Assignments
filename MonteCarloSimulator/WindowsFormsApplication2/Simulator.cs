using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class Simulator
    {
        public void PathSimulator(double s0, double vol, double r, double T, int simNumber, int timeSteps, double[,] randomMatrix, out double [,] simulatedStockPaths)
        {
            double deltaT = T / (Convert.ToDouble(timeSteps) - 1);
            double annoying1 = (r - (Math.Pow(vol, 2) / 2.0)) * deltaT;
            double annoying2 = vol * Math.Sqrt(deltaT);

            simulatedStockPaths = new double[simNumber, timeSteps];

            for (int i = 0; i < simNumber; i++)
            {
                simulatedStockPaths[i, 0] = s0;
                for (int j = 1; j < timeSteps; j++)
                {
                    simulatedStockPaths[i, j] = simulatedStockPaths[i, j - 1] * Math.Exp(annoying1 + (annoying2 * randomMatrix[i, j]));
                }
            }
        }
    }
}
