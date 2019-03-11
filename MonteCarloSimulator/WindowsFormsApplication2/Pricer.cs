using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class Pricer
    {
        public double Price(double K, double r, double T, double vol, int simNumber, int timeSteps, int callOrPut, double[,] simulatedStockPaths, bool CV, bool antithetic, out double SE, out double forGreeks)
        {
            double p;
            double CT;
            double sum = 0;
            double sum2 = 0;
            double forGreeksSum = 0;
            double SD = 0;
            double sumForSD = 0;
            double[] terminalPayoffVector;
            double[] discountedPayoffVector;

            terminalPayoffVector = new double[simNumber];
            discountedPayoffVector = new double[simNumber];

            for (int i = 0; i < simNumber; i++)
            {
                if (callOrPut == 1)
                {
                    terminalPayoffVector[i] = Math.Max(simulatedStockPaths[i, timeSteps - 1] - K, 0);
                }
                else if (callOrPut == 0)
                {
                    terminalPayoffVector[i] = Math.Max(K - simulatedStockPaths[i, timeSteps - 1], 0);
                }
                else
                {
                    throw new System.ArgumentException("You must type 1 for Call or 0 for Put.");
                }

                if (!CV)
                {
                    sum += terminalPayoffVector[i];
                    discountedPayoffVector[i] = terminalPayoffVector[i] * Math.Exp(-r * T);
                    forGreeksSum = sum;
                }
                else
                {
                    if (!antithetic)
                    {
                        CT = terminalPayoffVector[i] - ControlVariate.CVDelta(K, vol, r, T, i, simNumber, timeSteps, antithetic, simulatedStockPaths);
                    }
                    else
                    {
                        CT = (terminalPayoffVector[i] + terminalPayoffVector[i + (simNumber/2)] - ControlVariate.CVDelta(K, vol, r, T, i, simNumber/2, timeSteps, antithetic, simulatedStockPaths)) / 2;
                    }
                    sum += CT;
                    sum2 += CT * CT;
                    forGreeksSum += terminalPayoffVector[i];
                }
            }

            forGreeks = forGreeksSum / Convert.ToDouble(simNumber) * Math.Exp(-r * T);
            p = sum / Convert.ToDouble(simNumber) * Math.Exp(-r * T);

            if (!CV)
            {
                for (int i = 0; i < simNumber; i++)
                {
                    sumForSD += Math.Pow(discountedPayoffVector[i] - p, 2);
                }

                SD = Math.Sqrt(sumForSD / (Convert.ToDouble(simNumber) - 1));
            }

            else
            {
                SD = Math.Sqrt((sum2 - ((sum * sum)/Convert.ToDouble(simNumber))) * Math.Exp(-2*r*T) / (Convert.ToDouble(simNumber) - 1));
            }

            SE = SD / Math.Sqrt(Convert.ToDouble(simNumber));

            return p;
        }
    }
}
