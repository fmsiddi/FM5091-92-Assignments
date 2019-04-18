using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class Pricer
    {
        public double Price(double K, double r, double T, double vol, int simNumber, int timeSteps, bool callOrPut, double[,] simulatedStockPaths, bool CV, bool antithetic, out double SE, out double forGreeks)
        {
            double p;
            double CT;
            double sum = 0;
            double sum2 = 0;
            double forGreeksSum = 0;
            double SD;
            double sumForSD = 0;
            double[] terminalPayoffVector;
            double[] discountedPayoffVector;

            terminalPayoffVector = new double[simNumber];
            discountedPayoffVector = new double[simNumber];

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

            if (!CV)
            {
                for (int i = 0; i < simNumber; i++)
                {
                    sum += terminalPayoffVector[i];
                    discountedPayoffVector[i] = terminalPayoffVector[i] * Math.Exp(-r * T);
                    forGreeksSum = sum;
                }

                forGreeks = forGreeksSum / Convert.ToDouble(simNumber) * Math.Exp(-r * T);
                p = sum / Convert.ToDouble(simNumber) * Math.Exp(-r * T);

                for (int i = 0; i < simNumber; i++)
                {
                    sumForSD += Math.Pow(discountedPayoffVector[i] - p, 2);
                }

                SD = Math.Sqrt(sumForSD / (Convert.ToDouble(simNumber) - 1));
                SE = SD / Math.Sqrt(Convert.ToDouble(simNumber));

                return p;
            }

            else
            {
                if (!antithetic)
                {
                    for (int i = 0; i < simNumber; i++)
                    {
                        CT = terminalPayoffVector[i] - ControlVariate.CVDelta(K, vol, r, T, i, simNumber, timeSteps, antithetic, simulatedStockPaths);
                        sum += CT;
                        sum2 += CT * CT;
                        forGreeksSum += terminalPayoffVector[i];
                    }

                    forGreeks = forGreeksSum / Convert.ToDouble(simNumber) * Math.Exp(-r * T);
                    p = sum / Convert.ToDouble(simNumber) * Math.Exp(-r * T);

                    SD = Math.Sqrt((sum2 - ((sum * sum) / Convert.ToDouble(simNumber))) * Math.Exp(-2 * r * T) / (Convert.ToDouble(simNumber) - 1));
                    SE = SD / Math.Sqrt(Convert.ToDouble(simNumber));

                    return p;
                }

                else
                {
                    int trueSimNumber = simNumber / 2;
                    for (int i = 0; i < trueSimNumber; i++)
                    {
                        CT = 0.5 * (terminalPayoffVector[i] + terminalPayoffVector[i + trueSimNumber] - ControlVariate.CVDelta(K, vol, r, T, i, trueSimNumber, timeSteps, antithetic, simulatedStockPaths));
                        sum += CT;
                        sum2 += CT * CT;
                    }
                    for (int i = 0; i < simNumber; i++)
                    {
                        forGreeksSum += terminalPayoffVector[i];
                    }

                    forGreeks = forGreeksSum / Convert.ToDouble(simNumber) * Math.Exp(-r * T);
                    p = sum / Convert.ToDouble(trueSimNumber) * Math.Exp(-r * T);

                    SD = Math.Sqrt((sum2 - ((sum * sum) / Convert.ToDouble(trueSimNumber))) * Math.Exp(-2 * r * T) / (Convert.ToDouble(trueSimNumber) - 1));
                    SE = SD / Math.Sqrt(Convert.ToDouble(trueSimNumber));

                    return p;
                }
            }
        }
    }
}
