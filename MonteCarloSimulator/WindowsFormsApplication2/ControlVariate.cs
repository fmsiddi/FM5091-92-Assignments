using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class ControlVariate
    {
        public static double CVDelta(double K, double vol, double r, double T, int index, int simNumber, int timeSteps, bool antithetic, double[,] simulatedStockPaths)
        {
            double deltaT = T / Convert.ToDouble(timeSteps);
            double cvDeltaT = T / (Convert.ToDouble(timeSteps) - 1);
            double cv = 0;
            double cv1 = 0;
            double cv2 = 0;
            for (int k = 0; k < timeSteps - 1; k++)
            {
                double t = k * deltaT;
                double delta = BlackScholes.BSDelta(simulatedStockPaths[index, k], K, vol, r, T, t);

                if (!antithetic)
                {
                    cv1 += delta * (simulatedStockPaths[index, k + 1] - (simulatedStockPaths[index, k] * Math.Exp(r * cvDeltaT)));
                }
                else
                {
                    double antiDelta = BlackScholes.BSDelta(simulatedStockPaths[index + simNumber, k], K, vol, r, T, t);
                    cv1 += delta * (simulatedStockPaths[index, k + 1] - (simulatedStockPaths[index, k] * Math.Exp(r * cvDeltaT)));
                    cv2 += antiDelta * (simulatedStockPaths[index + simNumber, k + 1] - (simulatedStockPaths[index + simNumber, k] * Math.Exp(r * cvDeltaT)));
                }
            }
            cv = cv1 + cv2;
            return cv;
        }
    }
}
