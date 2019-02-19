using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1() { InitializeComponent(); }
        private void Form1_Load(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void stockInput_TextChanged(object sender, EventArgs e) { }
        private void strikeInput_TextChanged(object sender, EventArgs e) { }
        private void volInput_TextChanged(object sender, EventArgs e) { }
        private void IRInput_TextChanged(object sender, EventArgs e) { }
        private void dividendInput_TextChanged(object sender, EventArgs e) { }
        private void timeInput_TextChanged(object sender, EventArgs e) { }
        private void label7_Click(object sender, EventArgs e) { }
        private void numberOfSimulations_TextChanged(object sender, EventArgs e) { }
        private void simulationTimeStep_TextChanged(object sender, EventArgs e) { }
        private void callOrPut_TextChanged(object sender, EventArgs e) { }
        private void priceOutput_TextChanged(object sender, EventArgs e) { }
        private void seOutput_TextChanged(object sender, EventArgs e) { }
        private void deltaOutput_TextChanged(object sender, EventArgs e) { }
        private void gammaOutput_TextChanged(object sender, EventArgs e) { }
        private void thetaOutput_TextChanged(object sender, EventArgs e) { }
        private void vegaOutput_TextChanged(object sender, EventArgs e) { }
        private void rhoOutput_TextChanged(object sender, EventArgs e) { }

        private void Calculate_Click(object sender, EventArgs e)
        {
            double s0, K, vol, r, T;
            int simNumber, timeSteps, callOrPut;

            try
            {
                s0 = Double.Parse(stockInput.Text);
                K = Double.Parse(strikeInput.Text);
                vol = Double.Parse(volInput.Text);
                r = Double.Parse(IRInput.Text);
                T = Double.Parse(timeInput.Text);
                simNumber = Int32.Parse(numberOfSimulations.Text);
                timeSteps = Int32.Parse(simulationTimeStep.Text);
                callOrPut = Int32.Parse(callOrPutInput.Text);
            }
            catch(Exception xc)
            {
                MessageBox.Show(xc.Message);
            }

            s0 = Convert.ToDouble(stockInput.Text);
            K = Convert.ToDouble(strikeInput.Text);
            vol = Convert.ToDouble(volInput.Text);
            r = Convert.ToDouble(IRInput.Text);
            T = Convert.ToDouble(timeInput.Text);
            simNumber = Convert.ToInt32(numberOfSimulations.Text);
            timeSteps = Convert.ToInt32(simulationTimeStep.Text);
            callOrPut = Convert.ToInt32(callOrPutInput.Text);

            double deltaVol = 0.001 * vol;
            double deltaS = 0.001 * s0;
            double deltaR = 0.001 * r;
            double deltaTheta = 0.001 * T;

            double Price, SE, deltaUp, deltaDown, vegaUp, vegaDown, thetaUp, rhoUp, rhoDown, Delta, Gamma, Vega, Theta, Rho;  

            RandomNumberGenerator randomComponentMatrix = new RandomNumberGenerator();

            double[,] randomMatrix;

            randomComponentMatrix.PolarRejection(simNumber, timeSteps, out randomMatrix);

            CalculateMethod(s0, K, vol, r, T, simNumber, timeSteps, callOrPut, randomMatrix, out Price, out SE);
            CalculateMethodJustPrice(s0 + deltaS, K, vol, r, T, simNumber, timeSteps, callOrPut, randomMatrix, out deltaUp);
            CalculateMethodJustPrice(s0 - deltaS, K, vol, r, T, simNumber, timeSteps, callOrPut, randomMatrix, out deltaDown);
            CalculateMethodJustPrice(s0, K, vol + deltaVol, r, T, simNumber, timeSteps, callOrPut, randomMatrix, out vegaUp);
            CalculateMethodJustPrice(s0, K, vol - deltaVol, r, T, simNumber, timeSteps, callOrPut, randomMatrix, out vegaDown);
            CalculateMethodJustPrice(s0, K, vol, r, T + deltaTheta, simNumber, timeSteps, callOrPut, randomMatrix, out thetaUp);
            CalculateMethodJustPrice(s0, K, vol, r + deltaR, T, simNumber, timeSteps, callOrPut, randomMatrix, out rhoUp);
            CalculateMethodJustPrice(s0, K, vol, r - deltaR, T, simNumber, timeSteps, callOrPut, randomMatrix, out rhoDown);

            Delta = (deltaUp - deltaDown) / (2 * deltaS);
            Gamma = (deltaUp - (2 * Price) + deltaDown) / (deltaS * deltaS);
            Vega = (vegaUp - vegaDown) / (2 * deltaVol);
            Theta = (Price - thetaUp) / deltaTheta;
            Rho = (rhoUp - rhoDown) / (2 * deltaR);

            priceOutput.Text = Price.ToString();
            seOutput.Text = SE.ToString();
            deltaOutput.Text = Delta.ToString();
            gammaOutput.Text = Gamma.ToString();
            vegaOutput.Text = Vega.ToString();
            thetaOutput.Text = Theta.ToString();
            rhoOutput.Text = Rho.ToString();
        }
        public void CalculateMethod(double s0, double K, double vol, double r, double T, int simNumber, int timeSteps, int callOrPut, double[,] randomMatrix, out double Price, out double SE)
        {
            double deltaT = T / (Convert.ToDouble(timeSteps - 1));
            double sum = 0;
            double SD = 0;
            double sumForSD = 0;
            double[,] simulatedStockPaths = new double[simNumber,timeSteps];
            double[] terminalPayoffVector = new double[simNumber];
            double[] discountedPayoffVector = new double[simNumber];
            double annoying1 = (r - (Math.Pow(vol, 2) / 2) * deltaT);
            double annoying2 = vol * Math.Sqrt(deltaT);

            for (int i = 0; i < simNumber; i++)
            {
                simulatedStockPaths[i, 0] = s0;
                for (int j = 1; j < timeSteps; j++)
                {
                    simulatedStockPaths[i, j] = simulatedStockPaths[i, j - 1] * Math.Exp(annoying1 + (annoying2 * randomMatrix[i, j]));
                }
            }

            for (int i = 0; i < simNumber; i++)
            {
                if (callOrPut == 1)
                {
                    terminalPayoffVector[i] = Math.Max(simulatedStockPaths[i, timeSteps - 1] - K, 0);
                    sum += terminalPayoffVector[i];
                    discountedPayoffVector[i] = terminalPayoffVector[i] * Math.Exp(-r * T);
                }
                else if (callOrPut == 0)
                {
                    terminalPayoffVector[i] = Math.Max(K - simulatedStockPaths[i, timeSteps - 1], 0);
                    sum += terminalPayoffVector[i];
                    discountedPayoffVector[i] = terminalPayoffVector[i] * Math.Exp(-r * T);
                }
                else
                {
                    throw new System.ArgumentException("You must type 1 for Call or 0 for Put.");
                }
            }

            Price = (sum / simNumber) * Math.Exp(-r * T);

            for (int i = 0; i < simNumber; i++)
            {
                sumForSD += Math.Pow(discountedPayoffVector[i] - Price, 2);
            }

            SD = Math.Sqrt(sumForSD / (simNumber - 1));
            SE = SD / Math.Sqrt(simNumber);
        }

        public void CalculateMethodJustPrice(double s0, double K, double vol, double r, double T, int simNumber, int timeSteps, int callOrPut, double[,] randomMatrix, out double Price)
        {
            double deltaT = T / (Convert.ToDouble(timeSteps - 1));
            double sum = 0;
            double[,] simulatedStockPaths = new double[simNumber, timeSteps];
            double[] terminalPayoffVector = new double[simNumber];
            double[] discountedPayoffVector = new double[simNumber];
            double annoying1 = (r - (Math.Pow(vol, 2)*0.5) * deltaT);
            double annoying2 = vol * Math.Sqrt(deltaT);

            for (int i = 0; i < simNumber; i++)
            {
                simulatedStockPaths[i, 0] = s0;
                for (int j = 1; j < timeSteps; j++)
                {
                    simulatedStockPaths[i, j] = simulatedStockPaths[i, j - 1] * Math.Exp(annoying1 + (annoying2 * randomMatrix[i, j]));
                }
            }

            for (int i = 0; i < simNumber; i++)
            {
                if (callOrPut == 1)
                {
                    terminalPayoffVector[i] = Math.Max(simulatedStockPaths[i, timeSteps - 1] - K, 0);
                    sum += terminalPayoffVector[i];
                    discountedPayoffVector[i] = terminalPayoffVector[i] * Math.Exp(-r * T);
                }
                else if (callOrPut == 0)
                {
                    terminalPayoffVector[i] = Math.Max(K - simulatedStockPaths[i, timeSteps - 1], 0);
                    sum += terminalPayoffVector[i];
                    discountedPayoffVector[i] = terminalPayoffVector[i] * Math.Exp(-r * T);
                }
                else
                {
                    throw new System.ArgumentException("You must type 1 for Call or 0 for Put.");
                }
            }

            Price = (sum / simNumber) * Math.Exp(-r * T);
        }

    }

    public class RandomNumberGenerator
    {
        public void PolarRejection(int simulations, int timeSteps, out double [,] randomMatrix)
        {
            Random rnd = new Random();
            double randn1;
            double randn2;
            double w;
            double c;
            double y1;
            double y2;
            randomMatrix = new double[simulations, timeSteps];
            for (int i = 0; i < simulations; i+=2)
            {
                for (int j = 0; j < timeSteps; j++)
                {
                    do
                    {
                        randn1 = 2 * rnd.NextDouble() - 1;
                        randn2 = 2 * rnd.NextDouble() - 1;
                        w = Math.Pow(randn1, 2) + Math.Pow(randn2, 2);
                    }
                    while (w > 1);
                    c = Math.Sqrt(-2 * (Math.Log(w) / w));
                    y1 = c * randn1;
                    y2 = c * randn2;

                    randomMatrix [i, j] = y1;

                    if (i + 1 < simulations)
                    {
                        randomMatrix[i + 1, j] = y2;
                    }
                }
            }
        }
    }
}
