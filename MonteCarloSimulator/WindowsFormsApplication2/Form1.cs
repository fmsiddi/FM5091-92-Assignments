using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace WindowsFormsApplication2
{

    public partial class Form1 : Form
    {

        int progress = 0;

        public delegate void IncrementProgress();
        public IncrementProgress myDelegate;

        public Form1()
        {
            InitializeComponent();
        }
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
        private void label5_Click(object sender, EventArgs e) { }
        private void lblTimer_Click(object sender, EventArgs e) { }
        private void checkBox1_CheckedChanged_1(object sender, EventArgs e) { }
        private void coresOutput_TextChanged(object sender, EventArgs e) { }
        private void label18_Click(object sender, EventArgs e) { }
        private void progressBar1_Click(object sender, EventArgs e) { }
        private void CallOrPutGroupBox_Enter(object sender, EventArgs e) { }
        private void RadioButton1_CheckedChanged(object sender, EventArgs e) { }
        private void PutIndicator_CheckedChanged(object sender, EventArgs e) { }
        private void TypeGroupBox_Enter(object sender, EventArgs e) { }
        private void EuroIndicator_CheckedChanged(object sender, EventArgs e) { }
        private void AsianIndicator_CheckedChanged(object sender, EventArgs e) { }
        private void DigitalIndicator_CheckedChanged(object sender, EventArgs e)
        {
            RebateInput.Enabled = DigitalIndicator.Checked;
        }
        private void LookbackIndicator_CheckedChanged(object sender, EventArgs e) { }
        private void RangeIndicator_CheckedChanged(object sender, EventArgs e) { }
        private void UpInIndicator_CheckedChanged(object sender, EventArgs e)
        {
            BarrierType.Enabled = BarrierIndicator.Checked;
            BarrierInput.Enabled = BarrierIndicator.Checked;
        }
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void Label9_Click(object sender, EventArgs e) { }
        private void TextBox1_TextChanged(object sender, EventArgs e) { }
        private void Label10_Click(object sender, EventArgs e) { }
        private void BarrierInput_TextChanged(object sender, EventArgs e) { }
        private void Label19_Click(object sender, EventArgs e) { }



        private void Calculate_Click(object sender, EventArgs e)
        {
            double s0, K, vol, r, T; 
            double? digitalRebate, barrier;
            int simNumber, timeSteps;
            bool antithetic = Antithetic.Checked;
            bool cv = CV.Checked;
            bool threading = MultiThreading.Checked;
            bool callOrPut = CallIndicator.Checked;
            string barrierType = BarrierType.Text;
            var watch = Stopwatch.StartNew();

            try
            {
                s0 = Double.Parse(stockInput.Text);
                K = Double.Parse(strikeInput.Text);
                vol = Double.Parse(volInput.Text);
                r = Double.Parse(IRInput.Text);
                T = Double.Parse(timeInput.Text);
                simNumber = Int32.Parse(numberOfSimulations.Text);
                timeSteps = Int32.Parse(simulationTimeStep.Text);
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
            if (RebateInput.Text != "")
            {
                try
                {
                    digitalRebate = Double.Parse(RebateInput.Text);
                }
                catch (Exception xc)
                {
                    MessageBox.Show(xc.Message);
                }
                digitalRebate = Convert.ToDouble(RebateInput.Text);
            }
            if (BarrierInput.Text != "")
            {
                try
                {
                    barrier = Double.Parse(BarrierInput.Text);
                }
                catch (Exception xc)
                {
                    MessageBox.Show(xc.Message);
                }
                barrier = Convert.ToDouble(RebateInput.Text);
            }
            simNumber = Convert.ToInt32(numberOfSimulations.Text);
            timeSteps = Convert.ToInt32(simulationTimeStep.Text);
            

            double deltaVol = 0.001 * vol;
            double deltaS = 0.001 * s0;
            double deltaR = 0.001 * r;
            double deltaTheta = 0.001 * T;

            double Price, deltaUp, deltaDown, vegaUp, vegaDown, thetaUp, rhoUp, rhoDown, Delta, Gamma, Vega, Theta, Rho;  

            RandomNumberGenerator randomComponentMatrix = new RandomNumberGenerator();

            double[,] randomMatrix;

            progressBar1.Maximum = 10;

            Stopwatch debugStopWatch = new Stopwatch();
            debugStopWatch.Start();
            randomMatrix = randomComponentMatrix.PolarRejection(simNumber, timeSteps, antithetic, threading);
            Debug.WriteLine($"matrix simulated: {debugStopWatch.ElapsedMilliseconds}");
            debugStopWatch.Restart();

            progressBar1.Value = 1;
            Price = Calculated(s0, K, vol, r, T, simNumber, timeSteps, antithetic, cv, callOrPut, randomMatrix, threading, out double SE, out double forGreeks);
            Debug.WriteLine($"base: {debugStopWatch.ElapsedMilliseconds}");
            debugStopWatch.Restart();

            progressBar1.Value = 2;
            deltaUp = Calculated(s0 + deltaS, K, vol, r, T, simNumber, timeSteps, antithetic, false, callOrPut, randomMatrix, threading, out double ignore, out double ignore2);
            Debug.WriteLine($"delta up: {debugStopWatch.ElapsedMilliseconds}");
            debugStopWatch.Restart();

            progressBar1.Value = 3;
            deltaDown = Calculated(s0 - deltaS, K, vol, r, T, simNumber, timeSteps, antithetic, false, callOrPut, randomMatrix, threading, out ignore, out ignore2);
            Debug.WriteLine($"delta down: {debugStopWatch.ElapsedMilliseconds}");
            debugStopWatch.Restart();

            progressBar1.Value = 4;
            vegaUp = Calculated(s0, K, vol + deltaVol, r, T, simNumber, timeSteps, antithetic, false, callOrPut, randomMatrix, threading, out ignore, out ignore2);
            Debug.WriteLine($"vega up: {debugStopWatch.ElapsedMilliseconds}");
            debugStopWatch.Restart();

            progressBar1.Value = 5;
            vegaDown = Calculated(s0, K, vol - deltaVol, r, T, simNumber, timeSteps, antithetic, false, callOrPut, randomMatrix, threading, out ignore, out ignore2);
            Debug.WriteLine($"vega down: {debugStopWatch.ElapsedMilliseconds}");
            debugStopWatch.Restart();

            progressBar1.Value = 6;
            thetaUp = Calculated(s0, K, vol, r, T + deltaTheta, simNumber, timeSteps, antithetic, false, callOrPut, randomMatrix, threading, out ignore, out ignore2);
            Debug.WriteLine($"theta up: {debugStopWatch.ElapsedMilliseconds}");
            debugStopWatch.Restart();

            progressBar1.Value = 7;
            rhoUp = Calculated(s0, K, vol, r + deltaR, T, simNumber, timeSteps, antithetic, false, callOrPut, randomMatrix, threading, out ignore, out ignore2);
            Debug.WriteLine($"rho up: {debugStopWatch.ElapsedMilliseconds}");
            debugStopWatch.Restart();

            progressBar1.Value = 8;
            rhoDown = Calculated(s0, K, vol, r - deltaR, T, simNumber, timeSteps, antithetic, false, callOrPut, randomMatrix, threading, out ignore, out ignore2);
            Debug.WriteLine($"rho down: {debugStopWatch.ElapsedMilliseconds}");
            debugStopWatch.Restart();

            progressBar1.Value = 9;

            Delta = (deltaUp - deltaDown) / (2 * deltaS);
            Gamma = (deltaUp - (2 * forGreeks) + deltaDown) / (deltaS * deltaS);
            Vega = (vegaUp - vegaDown) / (2 * deltaVol);
            Theta = (forGreeks - thetaUp) / deltaTheta;
            Rho = (rhoUp - rhoDown) / (2 * deltaR);
            progressBar1.Value = 10;

            watch.Stop();

            if (!threading)
            {
                coresOutput.Text = "1";
            }
            else
            {
                coresOutput.Text = Environment.ProcessorCount.ToString();
            }
            
            lblTimer.Text = watch.Elapsed.ToString();
            priceOutput.Text = Price.ToString();
            seOutput.Text = SE.ToString();
            deltaOutput.Text = Delta.ToString();
            gammaOutput.Text = Gamma.ToString();
            vegaOutput.Text = Vega.ToString();
            thetaOutput.Text = Theta.ToString();
            rhoOutput.Text = Rho.ToString();
        }

        public double Calculated(double s0, double K, double vol, double r, double T, int simNumber, int timeSteps, bool antithetic, bool CV, bool callOrPut, double[,] randomMatrix, bool threading, out double SE, out double forGreeks)
        {
            var stopwatch = new Stopwatch();

            if (!antithetic)
            {
                Simulator simulation = new Simulator();
                double[,] simulatedStockPaths;
                stopwatch.Start();
                simulatedStockPaths = simulation.PathSimulator(s0, vol, r, T, simNumber, timeSteps, randomMatrix, threading);
                Debug.WriteLine($"simulation: {stopwatch.ElapsedMilliseconds}");

                stopwatch.Restart();
                Pricer price = new Pricer();
                double output = price.Price(K, r, T, vol, simNumber, timeSteps, callOrPut, simulatedStockPaths, CV, antithetic, out SE, out forGreeks);
                Debug.WriteLine($"pricing: {stopwatch.ElapsedMilliseconds}");
                return output;
            }
            else
            {
                Simulator simulation = new Simulator();
                double[,] simulatedStockPaths;
                stopwatch.Start();
                simulatedStockPaths = simulation.PathSimulator(s0, vol, r, T, 2 * simNumber, timeSteps, randomMatrix, threading);
                Debug.WriteLine($"simulation: {stopwatch.ElapsedMilliseconds}");

                stopwatch.Restart();
                Pricer price = new Pricer();
                double output = price.Price(K, r, T, vol, 2 * simNumber, timeSteps, callOrPut, simulatedStockPaths, CV, antithetic, out SE, out forGreeks);
                Debug.WriteLine($"pricing: {stopwatch.ElapsedMilliseconds}");
                return output;
            }
        }
    }
}

