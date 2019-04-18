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
            this.components = new System.ComponentModel.Container();
            this.stockInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.strikeInput = new System.Windows.Forms.TextBox();
            this.volInput = new System.Windows.Forms.TextBox();
            this.IRInput = new System.Windows.Forms.TextBox();
            this.timeInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Calculate = new System.Windows.Forms.Button();
            this.numberOfSimulations = new System.Windows.Forms.TextBox();
            this.simulationTimeStep = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
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
            this.Antithetic = new System.Windows.Forms.CheckBox();
            this.CV = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTimer = new System.Windows.Forms.Label();
            this.MultiThreading = new System.Windows.Forms.CheckBox();
            this.coresOutput = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.CallIndicator = new System.Windows.Forms.RadioButton();
            this.PutIndicator = new System.Windows.Forms.RadioButton();
            this.CallOrPutGroupBox = new System.Windows.Forms.GroupBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.TypeGroupBox = new System.Windows.Forms.GroupBox();
            this.RangeIndicator = new System.Windows.Forms.RadioButton();
            this.LookbackIndicator = new System.Windows.Forms.RadioButton();
            this.DigitalIndicator = new System.Windows.Forms.RadioButton();
            this.AsianIndicator = new System.Windows.Forms.RadioButton();
            this.EuroIndicator = new System.Windows.Forms.RadioButton();
            this.BarrierIndicator = new System.Windows.Forms.RadioButton();
            this.BarrierType = new System.Windows.Forms.ComboBox();
            this.RebateInput = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.BarrierInput = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.CallOrPutGroupBox.SuspendLayout();
            this.TypeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // stockInput
            // 
            this.stockInput.Location = new System.Drawing.Point(146, 66);
            this.stockInput.Name = "stockInput";
            this.stockInput.Size = new System.Drawing.Size(100, 20);
            this.stockInput.TabIndex = 0;
            this.stockInput.Text = "50";
            this.stockInput.TextChanged += new System.EventHandler(this.stockInput_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Initial Stock Price";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // strikeInput
            // 
            this.strikeInput.Location = new System.Drawing.Point(146, 92);
            this.strikeInput.Name = "strikeInput";
            this.strikeInput.Size = new System.Drawing.Size(100, 20);
            this.strikeInput.TabIndex = 2;
            this.strikeInput.Text = "50";
            this.strikeInput.TextChanged += new System.EventHandler(this.strikeInput_TextChanged);
            // 
            // volInput
            // 
            this.volInput.Location = new System.Drawing.Point(146, 118);
            this.volInput.Name = "volInput";
            this.volInput.Size = new System.Drawing.Size(100, 20);
            this.volInput.TabIndex = 3;
            this.volInput.Text = "0.5";
            this.volInput.TextChanged += new System.EventHandler(this.volInput_TextChanged);
            // 
            // IRInput
            // 
            this.IRInput.Location = new System.Drawing.Point(146, 144);
            this.IRInput.Name = "IRInput";
            this.IRInput.Size = new System.Drawing.Size(100, 20);
            this.IRInput.TabIndex = 4;
            this.IRInput.Text = "0.05";
            this.IRInput.TextChanged += new System.EventHandler(this.IRInput_TextChanged);
            // 
            // timeInput
            // 
            this.timeInput.Location = new System.Drawing.Point(146, 169);
            this.timeInput.Name = "timeInput";
            this.timeInput.Size = new System.Drawing.Size(100, 20);
            this.timeInput.TabIndex = 6;
            this.timeInput.Text = "1";
            this.timeInput.TextChanged += new System.EventHandler(this.timeInput_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(76, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Strike Price";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(92, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Volatility";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(69, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Interest Rate";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(51, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Length of Option";
            // 
            // Calculate
            // 
            this.Calculate.Location = new System.Drawing.Point(235, 608);
            this.Calculate.Name = "Calculate";
            this.Calculate.Size = new System.Drawing.Size(75, 23);
            this.Calculate.TabIndex = 12;
            this.Calculate.Text = "Calculate";
            this.Calculate.UseVisualStyleBackColor = true;
            this.Calculate.Click += new System.EventHandler(this.Calculate_Click);
            // 
            // numberOfSimulations
            // 
            this.numberOfSimulations.Location = new System.Drawing.Point(146, 195);
            this.numberOfSimulations.Name = "numberOfSimulations";
            this.numberOfSimulations.Size = new System.Drawing.Size(100, 20);
            this.numberOfSimulations.TabIndex = 13;
            this.numberOfSimulations.Text = "1000000";
            this.numberOfSimulations.TextChanged += new System.EventHandler(this.numberOfSimulations_TextChanged);
            // 
            // simulationTimeStep
            // 
            this.simulationTimeStep.Location = new System.Drawing.Point(146, 221);
            this.simulationTimeStep.Name = "simulationTimeStep";
            this.simulationTimeStep.Size = new System.Drawing.Size(100, 20);
            this.simulationTimeStep.TabIndex = 14;
            this.simulationTimeStep.Text = "2";
            this.simulationTimeStep.TextChanged += new System.EventHandler(this.simulationTimeStep_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 198);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Number of Simulations";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 224);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(126, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Time Step for Simulations";
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
            // Antithetic
            // 
            this.Antithetic.AutoSize = true;
            this.Antithetic.Location = new System.Drawing.Point(326, 300);
            this.Antithetic.Name = "Antithetic";
            this.Antithetic.Size = new System.Drawing.Size(173, 17);
            this.Antithetic.TabIndex = 33;
            this.Antithetic.Text = "Antithetic Variance Reduction?";
            this.Antithetic.UseVisualStyleBackColor = true;
            this.Antithetic.CheckedChanged += new System.EventHandler(this.Antithetic_CheckedChanged);
            // 
            // CV
            // 
            this.CV.AutoSize = true;
            this.CV.Location = new System.Drawing.Point(326, 323);
            this.CV.Name = "CV";
            this.CV.Size = new System.Drawing.Size(165, 17);
            this.CV.TabIndex = 34;
            this.CV.Text = "Use Delta as Control Variate?";
            this.CV.UseVisualStyleBackColor = true;
            this.CV.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(332, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "Calculation Time:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Location = new System.Drawing.Point(421, 48);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(58, 13);
            this.lblTimer.TabIndex = 36;
            this.lblTimer.Text = "00:00:00.0";
            this.lblTimer.Click += new System.EventHandler(this.lblTimer_Click);
            // 
            // MultiThreading
            // 
            this.MultiThreading.AutoSize = true;
            this.MultiThreading.Location = new System.Drawing.Point(326, 346);
            this.MultiThreading.Name = "MultiThreading";
            this.MultiThreading.Size = new System.Drawing.Size(120, 17);
            this.MultiThreading.TabIndex = 37;
            this.MultiThreading.Text = "Use Multithreading?";
            this.MultiThreading.UseVisualStyleBackColor = true;
            this.MultiThreading.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged_1);
            // 
            // coresOutput
            // 
            this.coresOutput.Location = new System.Drawing.Point(414, 369);
            this.coresOutput.Name = "coresOutput";
            this.coresOutput.Size = new System.Drawing.Size(100, 20);
            this.coresOutput.TabIndex = 38;
            this.coresOutput.TextChanged += new System.EventHandler(this.coresOutput_TextChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(347, 373);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(63, 13);
            this.label18.TabIndex = 39;
            this.label18.Text = "Cores used:";
            this.label18.Click += new System.EventHandler(this.label18_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(25, 545);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(499, 23);
            this.progressBar1.TabIndex = 40;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // CallIndicator
            // 
            this.CallIndicator.AutoSize = true;
            this.CallIndicator.Checked = true;
            this.CallIndicator.Location = new System.Drawing.Point(6, 19);
            this.CallIndicator.Name = "CallIndicator";
            this.CallIndicator.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CallIndicator.Size = new System.Drawing.Size(42, 17);
            this.CallIndicator.TabIndex = 41;
            this.CallIndicator.TabStop = true;
            this.CallIndicator.Text = "Call";
            this.CallIndicator.UseVisualStyleBackColor = true;
            this.CallIndicator.CheckedChanged += new System.EventHandler(this.RadioButton1_CheckedChanged);
            // 
            // PutIndicator
            // 
            this.PutIndicator.AutoSize = true;
            this.PutIndicator.Location = new System.Drawing.Point(54, 19);
            this.PutIndicator.Name = "PutIndicator";
            this.PutIndicator.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.PutIndicator.Size = new System.Drawing.Size(41, 17);
            this.PutIndicator.TabIndex = 42;
            this.PutIndicator.Text = "Put";
            this.PutIndicator.UseVisualStyleBackColor = true;
            this.PutIndicator.CheckedChanged += new System.EventHandler(this.PutIndicator_CheckedChanged);
            // 
            // CallOrPutGroupBox
            // 
            this.CallOrPutGroupBox.Controls.Add(this.CallIndicator);
            this.CallOrPutGroupBox.Controls.Add(this.PutIndicator);
            this.CallOrPutGroupBox.Location = new System.Drawing.Point(116, 17);
            this.CallOrPutGroupBox.Name = "CallOrPutGroupBox";
            this.CallOrPutGroupBox.Size = new System.Drawing.Size(107, 44);
            this.CallOrPutGroupBox.TabIndex = 43;
            this.CallOrPutGroupBox.TabStop = false;
            this.CallOrPutGroupBox.Text = "Call or Put";
            this.CallOrPutGroupBox.Enter += new System.EventHandler(this.CallOrPutGroupBox_Enter);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // TypeGroupBox
            // 
            this.TypeGroupBox.Controls.Add(this.label19);
            this.TypeGroupBox.Controls.Add(this.BarrierInput);
            this.TypeGroupBox.Controls.Add(this.label10);
            this.TypeGroupBox.Controls.Add(this.label9);
            this.TypeGroupBox.Controls.Add(this.RebateInput);
            this.TypeGroupBox.Controls.Add(this.BarrierType);
            this.TypeGroupBox.Controls.Add(this.CallOrPutGroupBox);
            this.TypeGroupBox.Controls.Add(this.RangeIndicator);
            this.TypeGroupBox.Controls.Add(this.LookbackIndicator);
            this.TypeGroupBox.Controls.Add(this.BarrierIndicator);
            this.TypeGroupBox.Controls.Add(this.DigitalIndicator);
            this.TypeGroupBox.Controls.Add(this.AsianIndicator);
            this.TypeGroupBox.Controls.Add(this.EuroIndicator);
            this.TypeGroupBox.Location = new System.Drawing.Point(10, 257);
            this.TypeGroupBox.Name = "TypeGroupBox";
            this.TypeGroupBox.Size = new System.Drawing.Size(256, 210);
            this.TypeGroupBox.TabIndex = 44;
            this.TypeGroupBox.TabStop = false;
            this.TypeGroupBox.Text = "Type";
            this.TypeGroupBox.Enter += new System.EventHandler(this.TypeGroupBox_Enter);
            // 
            // RangeIndicator
            // 
            this.RangeIndicator.AutoSize = true;
            this.RangeIndicator.Location = new System.Drawing.Point(21, 88);
            this.RangeIndicator.Name = "RangeIndicator";
            this.RangeIndicator.Size = new System.Drawing.Size(57, 17);
            this.RangeIndicator.TabIndex = 4;
            this.RangeIndicator.Text = "Range";
            this.RangeIndicator.UseVisualStyleBackColor = true;
            this.RangeIndicator.CheckedChanged += new System.EventHandler(this.RangeIndicator_CheckedChanged);
            // 
            // LookbackIndicator
            // 
            this.LookbackIndicator.AutoSize = true;
            this.LookbackIndicator.Location = new System.Drawing.Point(21, 65);
            this.LookbackIndicator.Name = "LookbackIndicator";
            this.LookbackIndicator.Size = new System.Drawing.Size(73, 17);
            this.LookbackIndicator.TabIndex = 3;
            this.LookbackIndicator.Text = "Lookback";
            this.LookbackIndicator.UseVisualStyleBackColor = true;
            this.LookbackIndicator.CheckedChanged += new System.EventHandler(this.LookbackIndicator_CheckedChanged);
            // 
            // DigitalIndicator
            // 
            this.DigitalIndicator.AutoSize = true;
            this.DigitalIndicator.Location = new System.Drawing.Point(21, 112);
            this.DigitalIndicator.Name = "DigitalIndicator";
            this.DigitalIndicator.Size = new System.Drawing.Size(54, 17);
            this.DigitalIndicator.TabIndex = 2;
            this.DigitalIndicator.Text = "Digital";
            this.DigitalIndicator.UseVisualStyleBackColor = true;
            this.DigitalIndicator.CheckedChanged += new System.EventHandler(this.DigitalIndicator_CheckedChanged);
            // 
            // AsianIndicator
            // 
            this.AsianIndicator.AutoSize = true;
            this.AsianIndicator.Location = new System.Drawing.Point(21, 42);
            this.AsianIndicator.Name = "AsianIndicator";
            this.AsianIndicator.Size = new System.Drawing.Size(51, 17);
            this.AsianIndicator.TabIndex = 1;
            this.AsianIndicator.Text = "Asian";
            this.AsianIndicator.UseVisualStyleBackColor = true;
            this.AsianIndicator.CheckedChanged += new System.EventHandler(this.AsianIndicator_CheckedChanged);
            // 
            // EuroIndicator
            // 
            this.EuroIndicator.AutoSize = true;
            this.EuroIndicator.Checked = true;
            this.EuroIndicator.Location = new System.Drawing.Point(21, 19);
            this.EuroIndicator.Name = "EuroIndicator";
            this.EuroIndicator.Size = new System.Drawing.Size(71, 17);
            this.EuroIndicator.TabIndex = 0;
            this.EuroIndicator.TabStop = true;
            this.EuroIndicator.Text = "European";
            this.EuroIndicator.UseVisualStyleBackColor = true;
            this.EuroIndicator.CheckedChanged += new System.EventHandler(this.EuroIndicator_CheckedChanged);
            // 
            // BarrierIndicator
            // 
            this.BarrierIndicator.AutoSize = true;
            this.BarrierIndicator.Location = new System.Drawing.Point(21, 148);
            this.BarrierIndicator.Name = "BarrierIndicator";
            this.BarrierIndicator.Size = new System.Drawing.Size(55, 17);
            this.BarrierIndicator.TabIndex = 0;
            this.BarrierIndicator.TabStop = true;
            this.BarrierIndicator.Text = "Barrier";
            this.BarrierIndicator.UseVisualStyleBackColor = true;
            this.BarrierIndicator.CheckedChanged += new System.EventHandler(this.UpInIndicator_CheckedChanged);
            // 
            // BarrierType
            // 
            this.BarrierType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BarrierType.Enabled = false;
            this.BarrierType.FormattingEnabled = true;
            this.BarrierType.Items.AddRange(new object[] {
            "Up and In",
            "Up and Out",
            "Down and In",
            "Down and Out"});
            this.BarrierType.Location = new System.Drawing.Point(136, 147);
            this.BarrierType.Name = "BarrierType";
            this.BarrierType.Size = new System.Drawing.Size(84, 21);
            this.BarrierType.TabIndex = 5;
            this.BarrierType.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // RebateInput
            // 
            this.RebateInput.Enabled = false;
            this.RebateInput.Location = new System.Drawing.Point(136, 111);
            this.RebateInput.Name = "RebateInput";
            this.RebateInput.Size = new System.Drawing.Size(47, 20);
            this.RebateInput.TabIndex = 44;
            this.RebateInput.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(85, 114);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 45;
            this.label9.Text = "Rebate:";
            this.label9.Click += new System.EventHandler(this.Label9_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(85, 150);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 13);
            this.label10.TabIndex = 46;
            this.label10.Text = "Type:";
            this.label10.Click += new System.EventHandler(this.Label10_Click);
            // 
            // BarrierInput
            // 
            this.BarrierInput.Enabled = false;
            this.BarrierInput.Location = new System.Drawing.Point(136, 171);
            this.BarrierInput.Name = "BarrierInput";
            this.BarrierInput.Size = new System.Drawing.Size(47, 20);
            this.BarrierInput.TabIndex = 47;
            this.BarrierInput.TextChanged += new System.EventHandler(this.BarrierInput_TextChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(85, 174);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(40, 13);
            this.label19.TabIndex = 48;
            this.label19.Text = "Barrier:";
            this.label19.Click += new System.EventHandler(this.Label19_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 719);
            this.Controls.Add(this.TypeGroupBox);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.coresOutput);
            this.Controls.Add(this.MultiThreading);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CV);
            this.Controls.Add(this.Antithetic);
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
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.simulationTimeStep);
            this.Controls.Add(this.numberOfSimulations);
            this.Controls.Add(this.Calculate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.timeInput);
            this.Controls.Add(this.IRInput);
            this.Controls.Add(this.volInput);
            this.Controls.Add(this.strikeInput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.stockInput);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.CallOrPutGroupBox.ResumeLayout(false);
            this.CallOrPutGroupBox.PerformLayout();
            this.TypeGroupBox.ResumeLayout(false);
            this.TypeGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox stockInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox strikeInput;
        private System.Windows.Forms.TextBox volInput;
        private System.Windows.Forms.TextBox IRInput;
        private System.Windows.Forms.TextBox timeInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button Calculate;
        private System.Windows.Forms.TextBox numberOfSimulations;
        private System.Windows.Forms.TextBox simulationTimeStep;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
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
        private System.Windows.Forms.CheckBox Antithetic;
        private System.Windows.Forms.CheckBox CV;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.CheckBox MultiThreading;
        private System.Windows.Forms.TextBox coresOutput;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.RadioButton CallIndicator;
        private System.Windows.Forms.RadioButton PutIndicator;
        private System.Windows.Forms.GroupBox CallOrPutGroupBox;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox TypeGroupBox;
        private System.Windows.Forms.RadioButton RangeIndicator;
        private System.Windows.Forms.RadioButton LookbackIndicator;
        private System.Windows.Forms.RadioButton DigitalIndicator;
        private System.Windows.Forms.RadioButton AsianIndicator;
        private System.Windows.Forms.RadioButton EuroIndicator;
        private System.Windows.Forms.ComboBox BarrierType;
        private System.Windows.Forms.RadioButton BarrierIndicator;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox RebateInput;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox BarrierInput;
        private System.Windows.Forms.Label label19;
    }
}

