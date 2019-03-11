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
        private void Antithetic_CheckedChanged(object sender, EventArgs e) { }
        private void checkBox1_CheckedChanged(object sender, EventArgs e) { }

        private void Calculate_Click(object sender, EventArgs e)
        {
            double s0, K, vol, r, T;
            int simNumber, timeSteps, callOrPut;
            bool antithetic = Antithetic.Checked;
            bool cv = CV.Checked;

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

            double Price, SE, forGreeks, ignore, ignore2, deltaUp, deltaDown, vegaUp, vegaDown, thetaUp, rhoUp, rhoDown, Delta, Gamma, Vega, Theta, Rho;  

            RandomNumberGenerator randomComponentMatrix = new RandomNumberGenerator();

            double[,] randomMatrix;

            randomComponentMatrix.PolarRejection(simNumber, timeSteps, antithetic, out randomMatrix);

            Price = Calculated(s0, K, vol, r, T, simNumber, timeSteps, antithetic, cv, callOrPut, randomMatrix, out SE, out forGreeks);
            deltaUp = Calculated(s0 + deltaS, K, vol, r, T, simNumber, timeSteps, antithetic, false, callOrPut, randomMatrix, out ignore, out ignore2);
            deltaDown = Calculated(s0 - deltaS, K, vol, r, T, simNumber, timeSteps, antithetic, false, callOrPut, randomMatrix, out ignore, out ignore2);
            vegaUp = Calculated(s0, K, vol + deltaVol, r, T, simNumber, timeSteps, antithetic, false, callOrPut, randomMatrix, out ignore, out ignore2);
            vegaDown = Calculated(s0, K, vol - deltaVol, r, T, simNumber, timeSteps, antithetic, false, callOrPut, randomMatrix, out ignore, out ignore2);
            thetaUp = Calculated(s0, K, vol, r, T + deltaTheta, simNumber, timeSteps, antithetic, false, callOrPut, randomMatrix, out ignore, out ignore2);
            rhoUp = Calculated(s0, K, vol, r + deltaR, T, simNumber, timeSteps, antithetic, false, callOrPut, randomMatrix, out ignore, out ignore2);
            rhoDown = Calculated(s0, K, vol, r - deltaR, T, simNumber, timeSteps, antithetic, false, callOrPut, randomMatrix, out ignore, out ignore2);

            Delta = (deltaUp - deltaDown) / (2 * deltaS);
            Gamma = (deltaUp - (2 * forGreeks) + deltaDown) / (deltaS * deltaS);
            Vega = (vegaUp - vegaDown) / (2 * deltaVol);
            Theta = (forGreeks - thetaUp) / deltaTheta;
            Rho = (rhoUp - rhoDown) / (2 * deltaR);

            priceOutput.Text = Price.ToString();
            seOutput.Text = SE.ToString();
            deltaOutput.Text = Delta.ToString();
            gammaOutput.Text = Gamma.ToString();
            vegaOutput.Text = Vega.ToString();
            thetaOutput.Text = Theta.ToString();
            rhoOutput.Text = Rho.ToString();
        }

        public double Calculated(double s0, double K, double vol, double r, double T, int simNumber, int timeSteps, bool antithetic, bool CV, int callOrPut, double[,] randomMatrix, out double SE, out double forGreeks)
        {
            if (!antithetic)
            {
                Simulator simulation = new Simulator();
                double[,] simulatedStockPaths;
                simulation.PathSimulator(s0, vol, r, T, simNumber, timeSteps, randomMatrix, out simulatedStockPaths);

                Pricer price = new Pricer();
                return price.Price(K, r, T, vol, simNumber, timeSteps, callOrPut, simulatedStockPaths, CV, antithetic, out SE, out forGreeks);
            }
            else
            {
                Simulator simulation = new Simulator();
                double[,] simulatedStockPaths;
                simulation.PathSimulator(s0, vol, r, T, 2 * simNumber, timeSteps, randomMatrix, out simulatedStockPaths);

                Pricer price = new Pricer();
                return price.Price(K, r, T, vol, 2 * simNumber, timeSteps, callOrPut, simulatedStockPaths, CV, antithetic, out SE, out forGreeks);
            }
        }
    }
}

