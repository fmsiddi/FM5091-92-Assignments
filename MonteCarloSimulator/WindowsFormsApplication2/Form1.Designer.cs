namespace WindowsFormsApplication2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.stockInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.strikeInput = new System.Windows.Forms.TextBox();
            this.volInput = new System.Windows.Forms.TextBox();
            this.IRInput = new System.Windows.Forms.TextBox();
            this.dividendInput = new System.Windows.Forms.TextBox();
            this.timeInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Calculate = new System.Windows.Forms.Button();
            this.numberOfSimulations = new System.Windows.Forms.TextBox();
            this.simulationTimeStep = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.callOrPutInput = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.priceOutput = new System.Windows.Forms.TextBox();
            this.seOutput = new System.Windows.Forms.TextBox();
            this.deltaOutput = new System.Windows.Forms.TextBox();
            this.gammaOutput = new System.Windows.Forms.TextBox();
            this.vegaOutput = new System.Windows.Forms.TextBox();
            this.thetaOutput = new System.Windows.Forms.TextBox();
            this.rhoOutput = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // stockInput
            // 
            this.stockInput.Location = new System.Drawing.Point(134, 66);
            this.stockInput.Name = "stockInput";
            this.stockInput.Size = new System.Drawing.Size(100, 20);
            this.stockInput.TabIndex = 0;
            this.stockInput.TextChanged += new System.EventHandler(this.stockInput_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Initial Stock Price";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // strikeInput
            // 
            this.strikeInput.Location = new System.Drawing.Point(134, 92);
            this.strikeInput.Name = "strikeInput";
            this.strikeInput.Size = new System.Drawing.Size(100, 20);
            this.strikeInput.TabIndex = 2;
            this.strikeInput.TextChanged += new System.EventHandler(this.strikeInput_TextChanged);
            // 
            // volInput
            // 
            this.volInput.Location = new System.Drawing.Point(134, 118);
            this.volInput.Name = "volInput";
            this.volInput.Size = new System.Drawing.Size(100, 20);
            this.volInput.TabIndex = 3;
            this.volInput.TextChanged += new System.EventHandler(this.volInput_TextChanged);
            // 
            // IRInput
            // 
            this.IRInput.Location = new System.Drawing.Point(134, 144);
            this.IRInput.Name = "IRInput";
            this.IRInput.Size = new System.Drawing.Size(100, 20);
            this.IRInput.TabIndex = 4;
            this.IRInput.TextChanged += new System.EventHandler(this.IRInput_TextChanged);
            // 
            // dividendInput
            // 
            this.dividendInput.Location = new System.Drawing.Point(134, 170);
            this.dividendInput.Name = "dividendInput";
            this.dividendInput.Size = new System.Drawing.Size(100, 20);
            this.dividendInput.TabIndex = 5;
            this.dividendInput.TextChanged += new System.EventHandler(this.dividendInput_TextChanged);
            // 
            // timeInput
            // 
            this.timeInput.Location = new System.Drawing.Point(134, 196);
            this.timeInput.Name = "timeInput";
            this.timeInput.Size = new System.Drawing.Size(100, 20);
            this.timeInput.TabIndex = 6;
            this.timeInput.TextChanged += new System.EventHandler(this.timeInput_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Strike Price";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(80, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Volatility";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(57, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Interest Rate";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(50, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Dividend Rate";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(39, 199);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Length of Option";
            // 
            // Calculate
            // 
            this.Calculate.Location = new System.Drawing.Point(235, 482);
            this.Calculate.Name = "Calculate";
            this.Calculate.Size = new System.Drawing.Size(75, 23);
            this.Calculate.TabIndex = 12;
            this.Calculate.Text = "Calculate";
            this.Calculate.UseVisualStyleBackColor = true;
            this.Calculate.Click += new System.EventHandler(this.Calculate_Click);
            // 
            // numberOfSimulations
            // 
            this.numberOfSimulations.Location = new System.Drawing.Point(134, 222);
            this.numberOfSimulations.Name = "numberOfSimulations";
            this.numberOfSimulations.Size = new System.Drawing.Size(100, 20);
            this.numberOfSimulations.TabIndex = 13;
            this.numberOfSimulations.TextChanged += new System.EventHandler(this.numberOfSimulations_TextChanged);
            // 
            // simulationTimeStep
            // 
            this.simulationTimeStep.Location = new System.Drawing.Point(134, 248);
            this.simulationTimeStep.Name = "simulationTimeStep";
            this.simulationTimeStep.Size = new System.Drawing.Size(100, 20);
            this.simulationTimeStep.TabIndex = 14;
            this.simulationTimeStep.TextChanged += new System.EventHandler(this.simulationTimeStep_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 225);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Number of Simulations";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(-1, 251);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(126, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Time Step for Simulations";
            // 
            // callOrPutInput
            // 
            this.callOrPutInput.Location = new System.Drawing.Point(134, 274);
            this.callOrPutInput.Name = "callOrPutInput";
            this.callOrPutInput.Size = new System.Drawing.Size(100, 20);
            this.callOrPutInput.TabIndex = 17;
            this.callOrPutInput.TextChanged += new System.EventHandler(this.callOrPut_TextChanged);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 23);
            this.label9.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(43, 277);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Call = 1; Put = 0";
            // 
            // priceOutput
            // 
            this.priceOutput.Location = new System.Drawing.Point(424, 66);
            this.priceOutput.Name = "priceOutput";
            this.priceOutput.Size = new System.Drawing.Size(100, 20);
            this.priceOutput.TabIndex = 19;
            this.priceOutput.TextChanged += new System.EventHandler(this.priceOutput_TextChanged);
            // 
            // seOutput
            // 
            this.seOutput.Location = new System.Drawing.Point(424, 92);
            this.seOutput.Name = "seOutput";
            this.seOutput.Size = new System.Drawing.Size(100, 20);
            this.seOutput.TabIndex = 20;
            this.seOutput.TextChanged += new System.EventHandler(this.seOutput_TextChanged);
            // 
            // deltaOutput
            // 
            this.deltaOutput.Location = new System.Drawing.Point(424, 117);
            this.deltaOutput.Name = "deltaOutput";
            this.deltaOutput.Size = new System.Drawing.Size(100, 20);
            this.deltaOutput.TabIndex = 21;
            this.deltaOutput.TextChanged += new System.EventHandler(this.deltaOutput_TextChanged);
            // 
            // gammaOutput
            // 
            this.gammaOutput.Location = new System.Drawing.Point(424, 144);
            this.gammaOutput.Name = "gammaOutput";
            this.gammaOutput.Size = new System.Drawing.Size(100, 20);
            this.gammaOutput.TabIndex = 22;
            this.gammaOutput.TextChanged += new System.EventHandler(this.gammaOutput_TextChanged);
            // 
            // vegaOutput
            // 
            this.vegaOutput.Location = new System.Drawing.Point(424, 170);
            this.vegaOutput.Name = "vegaOutput";
            this.vegaOutput.Size = new System.Drawing.Size(100, 20);
            this.vegaOutput.TabIndex = 23;
            this.vegaOutput.TextChanged += new System.EventHandler(this.vegaOutput_TextChanged);
            // 
            // thetaOutput
            // 
            this.thetaOutput.Location = new System.Drawing.Point(424, 196);
            this.thetaOutput.Name = "thetaOutput";
            this.thetaOutput.Size = new System.Drawing.Size(100, 20);
            this.thetaOutput.TabIndex = 24;
            this.thetaOutput.TextChanged += new System.EventHandler(this.thetaOutput_TextChanged);
            // 
            // rhoOutput
            // 
            this.rhoOutput.Location = new System.Drawing.Point(424, 222);
            this.rhoOutput.Name = "rhoOutput";
            this.rhoOutput.Size = new System.Drawing.Size(100, 20);
            this.rhoOutput.TabIndex = 25;
            this.rhoOutput.TextChanged += new System.EventHandler(this.rhoOutput_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(387, 69);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 13);
            this.label11.TabIndex = 26;
            this.label11.Text = "Price";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(345, 95);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 13);
            this.label12.TabIndex = 27;
            this.label12.Text = "Standard Error";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(386, 121);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(32, 13);
            this.label13.TabIndex = 28;
            this.label13.Text = "Delta";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(377, 147);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(43, 13);
            this.label14.TabIndex = 29;
            this.label14.Text = "Gamma";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(388, 173);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(32, 13);
            this.label15.TabIndex = 30;
            this.label15.Text = "Vega";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(383, 199);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(35, 13);
            this.label16.TabIndex = 31;
            this.label16.Text = "Theta";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(391, 225);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(27, 13);
            this.label17.TabIndex = 32;
            this.label17.Text = "Rho";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 526);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.rhoOutput);
            this.Controls.Add(this.thetaOutput);
            this.Controls.Add(this.vegaOutput);
            this.Controls.Add(this.gammaOutput);
            this.Controls.Add(this.deltaOutput);
            this.Controls.Add(this.seOutput);
            this.Controls.Add(this.priceOutput);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.callOrPutInput);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.simulationTimeStep);
            this.Controls.Add(this.numberOfSimulations);
            this.Controls.Add(this.Calculate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.timeInput);
            this.Controls.Add(this.dividendInput);
            this.Controls.Add(this.IRInput);
            this.Controls.Add(this.volInput);
            this.Controls.Add(this.strikeInput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.stockInput);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox stockInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox strikeInput;
        private System.Windows.Forms.TextBox volInput;
        private System.Windows.Forms.TextBox IRInput;
        private System.Windows.Forms.TextBox dividendInput;
        private System.Windows.Forms.TextBox timeInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button Calculate;
        private System.Windows.Forms.TextBox numberOfSimulations;
        private System.Windows.Forms.TextBox simulationTimeStep;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox callOrPutInput;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox priceOutput;
        private System.Windows.Forms.TextBox seOutput;
        private System.Windows.Forms.TextBox deltaOutput;
        private System.Windows.Forms.TextBox gammaOutput;
        private System.Windows.Forms.TextBox vegaOutput;
        private System.Windows.Forms.TextBox thetaOutput;
        private System.Windows.Forms.TextBox rhoOutput;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
    }
}

