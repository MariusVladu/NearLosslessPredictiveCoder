namespace NearLosslessPredictiveCoder.GUI
{
    partial class UI
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.originalImagePanel = new System.Windows.Forms.Panel();
            this.errorImagePanel = new System.Windows.Forms.Panel();
            this.decodedImagePanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonEncode = new System.Windows.Forms.Button();
            this.buttonSaveEncoded = new System.Windows.Forms.Button();
            this.groupBoxPredictors = new System.Windows.Forms.GroupBox();
            this.contrast = new System.Windows.Forms.NumericUpDown();
            this.buttonLoadEncoded = new System.Windows.Forms.Button();
            this.buttonDecode = new System.Windows.Forms.Button();
            this.buttonSaveDecoded = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBoxHistogram = new System.Windows.Forms.GroupBox();
            this.radioButtonQuantizedErrorPrediction = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.radioButtonDecoded = new System.Windows.Forms.RadioButton();
            this.radioButtonErrorPrediction = new System.Windows.Forms.RadioButton();
            this.radioButtonOriginal = new System.Windows.Forms.RadioButton();
            this.HistogramScale = new System.Windows.Forms.NumericUpDown();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBoxSaveModes = new System.Windows.Forms.GroupBox();
            this.fixedSize = new System.Windows.Forms.ComboBox();
            this.Arithmetic = new System.Windows.Forms.RadioButton();
            this.Table = new System.Windows.Forms.RadioButton();
            this.Fixed = new System.Windows.Forms.RadioButton();
            this.KValue = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.errorImageType = new System.Windows.Forms.ComboBox();
            this.computeError = new System.Windows.Forms.Button();
            this.labelMinimumError = new System.Windows.Forms.Label();
            this.labelMaximumError = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.contrast)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.groupBoxHistogram.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HistogramScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.groupBoxSaveModes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KValue)).BeginInit();
            this.SuspendLayout();
            // 
            // originalImagePanel
            // 
            this.originalImagePanel.Location = new System.Drawing.Point(12, 29);
            this.originalImagePanel.Name = "originalImagePanel";
            this.originalImagePanel.Size = new System.Drawing.Size(256, 256);
            this.originalImagePanel.TabIndex = 0;
            // 
            // errorImagePanel
            // 
            this.errorImagePanel.Location = new System.Drawing.Point(274, 29);
            this.errorImagePanel.Name = "errorImagePanel";
            this.errorImagePanel.Size = new System.Drawing.Size(256, 256);
            this.errorImagePanel.TabIndex = 0;
            // 
            // decodedImagePanel
            // 
            this.decodedImagePanel.Location = new System.Drawing.Point(536, 29);
            this.decodedImagePanel.Name = "decodedImagePanel";
            this.decodedImagePanel.Size = new System.Drawing.Size(256, 256);
            this.decodedImagePanel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Original Image 256 x 256";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(271, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Error Image 256 x 256";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(533, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Decoded Image 256 x 256";
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(12, 291);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(75, 23);
            this.buttonLoad.TabIndex = 2;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoadImage_Click);
            // 
            // buttonEncode
            // 
            this.buttonEncode.Enabled = false;
            this.buttonEncode.Location = new System.Drawing.Point(91, 291);
            this.buttonEncode.Name = "buttonEncode";
            this.buttonEncode.Size = new System.Drawing.Size(75, 23);
            this.buttonEncode.TabIndex = 3;
            this.buttonEncode.Text = "Encode";
            this.buttonEncode.UseVisualStyleBackColor = true;
            this.buttonEncode.Click += new System.EventHandler(this.buttonEncode_Click);
            // 
            // buttonSaveEncoded
            // 
            this.buttonSaveEncoded.Enabled = false;
            this.buttonSaveEncoded.Location = new System.Drawing.Point(172, 291);
            this.buttonSaveEncoded.Name = "buttonSaveEncoded";
            this.buttonSaveEncoded.Size = new System.Drawing.Size(96, 23);
            this.buttonSaveEncoded.TabIndex = 4;
            this.buttonSaveEncoded.Text = "Save Encoded";
            this.buttonSaveEncoded.UseVisualStyleBackColor = true;
            this.buttonSaveEncoded.Click += new System.EventHandler(this.buttonSaveEncoded_Click);
            // 
            // groupBoxPredictors
            // 
            this.groupBoxPredictors.AutoSize = true;
            this.groupBoxPredictors.Location = new System.Drawing.Point(12, 331);
            this.groupBoxPredictors.Name = "groupBoxPredictors";
            this.groupBoxPredictors.Size = new System.Drawing.Size(115, 253);
            this.groupBoxPredictors.TabIndex = 5;
            this.groupBoxPredictors.TabStop = false;
            this.groupBoxPredictors.Text = "Choose Predictor";
            // 
            // contrast
            // 
            this.contrast.DecimalPlaces = 1;
            this.contrast.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.contrast.Location = new System.Drawing.Point(493, 291);
            this.contrast.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.contrast.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.contrast.Name = "contrast";
            this.contrast.Size = new System.Drawing.Size(37, 20);
            this.contrast.TabIndex = 6;
            this.contrast.Value = new decimal(new int[] {
            15,
            0,
            0,
            65536});
            this.contrast.ValueChanged += new System.EventHandler(this.contrast_ValueChanged);
            // 
            // buttonLoadEncoded
            // 
            this.buttonLoadEncoded.Location = new System.Drawing.Point(536, 291);
            this.buttonLoadEncoded.Name = "buttonLoadEncoded";
            this.buttonLoadEncoded.Size = new System.Drawing.Size(87, 23);
            this.buttonLoadEncoded.TabIndex = 8;
            this.buttonLoadEncoded.Text = "Load encoded";
            this.buttonLoadEncoded.UseVisualStyleBackColor = true;
            this.buttonLoadEncoded.Click += new System.EventHandler(this.buttonLoadEncoded_Click);
            // 
            // buttonDecode
            // 
            this.buttonDecode.Enabled = false;
            this.buttonDecode.Location = new System.Drawing.Point(629, 291);
            this.buttonDecode.Name = "buttonDecode";
            this.buttonDecode.Size = new System.Drawing.Size(74, 23);
            this.buttonDecode.TabIndex = 9;
            this.buttonDecode.Text = "Decode";
            this.buttonDecode.UseVisualStyleBackColor = true;
            this.buttonDecode.Click += new System.EventHandler(this.buttonDecode_Click);
            // 
            // buttonSaveDecoded
            // 
            this.buttonSaveDecoded.Enabled = false;
            this.buttonSaveDecoded.Location = new System.Drawing.Point(709, 291);
            this.buttonSaveDecoded.Name = "buttonSaveDecoded";
            this.buttonSaveDecoded.Size = new System.Drawing.Size(85, 23);
            this.buttonSaveDecoded.TabIndex = 10;
            this.buttonSaveDecoded.Text = "Save decoded";
            this.buttonSaveDecoded.UseVisualStyleBackColor = true;
            this.buttonSaveDecoded.Click += new System.EventHandler(this.buttonSaveDecoded_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 636);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(804, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel.Text = "Ready";
            // 
            // groupBoxHistogram
            // 
            this.groupBoxHistogram.Controls.Add(this.radioButtonQuantizedErrorPrediction);
            this.groupBoxHistogram.Controls.Add(this.label4);
            this.groupBoxHistogram.Controls.Add(this.radioButtonDecoded);
            this.groupBoxHistogram.Controls.Add(this.radioButtonErrorPrediction);
            this.groupBoxHistogram.Controls.Add(this.radioButtonOriginal);
            this.groupBoxHistogram.Controls.Add(this.HistogramScale);
            this.groupBoxHistogram.Enabled = false;
            this.groupBoxHistogram.Location = new System.Drawing.Point(133, 442);
            this.groupBoxHistogram.Name = "groupBoxHistogram";
            this.groupBoxHistogram.Size = new System.Drawing.Size(111, 142);
            this.groupBoxHistogram.TabIndex = 12;
            this.groupBoxHistogram.TabStop = false;
            this.groupBoxHistogram.Text = "Histograms";
            // 
            // radioButtonQuantizedErrorPrediction
            // 
            this.radioButtonQuantizedErrorPrediction.AutoSize = true;
            this.radioButtonQuantizedErrorPrediction.Enabled = false;
            this.radioButtonQuantizedErrorPrediction.Location = new System.Drawing.Point(7, 66);
            this.radioButtonQuantizedErrorPrediction.Name = "radioButtonQuantizedErrorPrediction";
            this.radioButtonQuantizedErrorPrediction.Size = new System.Drawing.Size(98, 17);
            this.radioButtonQuantizedErrorPrediction.TabIndex = 9;
            this.radioButtonQuantizedErrorPrediction.Text = "Quantized Error";
            this.radioButtonQuantizedErrorPrediction.UseVisualStyleBackColor = true;
            this.radioButtonQuantizedErrorPrediction.Click += new System.EventHandler(this.HistogramRadioButtonClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Scale";
            // 
            // radioButtonDecoded
            // 
            this.radioButtonDecoded.AutoSize = true;
            this.radioButtonDecoded.Enabled = false;
            this.radioButtonDecoded.Location = new System.Drawing.Point(7, 89);
            this.radioButtonDecoded.Name = "radioButtonDecoded";
            this.radioButtonDecoded.Size = new System.Drawing.Size(69, 17);
            this.radioButtonDecoded.TabIndex = 0;
            this.radioButtonDecoded.Text = "Decoded";
            this.radioButtonDecoded.UseVisualStyleBackColor = true;
            this.radioButtonDecoded.Click += new System.EventHandler(this.HistogramRadioButtonClick);
            // 
            // radioButtonErrorPrediction
            // 
            this.radioButtonErrorPrediction.AutoSize = true;
            this.radioButtonErrorPrediction.Checked = true;
            this.radioButtonErrorPrediction.Location = new System.Drawing.Point(7, 43);
            this.radioButtonErrorPrediction.Name = "radioButtonErrorPrediction";
            this.radioButtonErrorPrediction.Size = new System.Drawing.Size(97, 17);
            this.radioButtonErrorPrediction.TabIndex = 0;
            this.radioButtonErrorPrediction.TabStop = true;
            this.radioButtonErrorPrediction.Text = "Prediction Error";
            this.radioButtonErrorPrediction.UseVisualStyleBackColor = true;
            this.radioButtonErrorPrediction.Click += new System.EventHandler(this.HistogramRadioButtonClick);
            // 
            // radioButtonOriginal
            // 
            this.radioButtonOriginal.AutoSize = true;
            this.radioButtonOriginal.Enabled = false;
            this.radioButtonOriginal.Location = new System.Drawing.Point(7, 20);
            this.radioButtonOriginal.Name = "radioButtonOriginal";
            this.radioButtonOriginal.Size = new System.Drawing.Size(60, 17);
            this.radioButtonOriginal.TabIndex = 0;
            this.radioButtonOriginal.Text = "Original";
            this.radioButtonOriginal.UseVisualStyleBackColor = true;
            this.radioButtonOriginal.Click += new System.EventHandler(this.HistogramRadioButtonClick);
            // 
            // HistogramScale
            // 
            this.HistogramScale.DecimalPlaces = 1;
            this.HistogramScale.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.HistogramScale.Location = new System.Drawing.Point(44, 112);
            this.HistogramScale.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.HistogramScale.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.HistogramScale.Name = "HistogramScale";
            this.HistogramScale.Size = new System.Drawing.Size(37, 20);
            this.HistogramScale.TabIndex = 6;
            this.HistogramScale.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.HistogramScale.ValueChanged += new System.EventHandler(this.HistogramScale_ValueChanged);
            // 
            // chart
            // 
            this.chart.BackColor = System.Drawing.Color.Transparent;
            chartArea2.AxisX.Interval = 256D;
            chartArea2.AxisX.MajorGrid.Enabled = false;
            chartArea2.AxisX.MajorTickMark.Enabled = false;
            chartArea2.AxisX.Title = "Intensity";
            chartArea2.AxisY.MajorGrid.Enabled = false;
            chartArea2.AxisY.MajorTickMark.Enabled = false;
            chartArea2.AxisY.Title = "Frequency (# of pixels)";
            chartArea2.BackColor = System.Drawing.Color.Transparent;
            chartArea2.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea2);
            legend2.BackColor = System.Drawing.Color.Transparent;
            legend2.Name = "Legend1";
            this.chart.Legends.Add(legend2);
            this.chart.Location = new System.Drawing.Point(262, 331);
            this.chart.Name = "chart";
            this.chart.Size = new System.Drawing.Size(530, 297);
            this.chart.TabIndex = 13;
            this.chart.Text = "chart1";
            // 
            // groupBoxSaveModes
            // 
            this.groupBoxSaveModes.Controls.Add(this.fixedSize);
            this.groupBoxSaveModes.Controls.Add(this.Arithmetic);
            this.groupBoxSaveModes.Controls.Add(this.Table);
            this.groupBoxSaveModes.Controls.Add(this.Fixed);
            this.groupBoxSaveModes.Location = new System.Drawing.Point(133, 331);
            this.groupBoxSaveModes.Name = "groupBoxSaveModes";
            this.groupBoxSaveModes.Size = new System.Drawing.Size(111, 105);
            this.groupBoxSaveModes.TabIndex = 14;
            this.groupBoxSaveModes.TabStop = false;
            this.groupBoxSaveModes.Text = "Save Mode";
            // 
            // fixedSize
            // 
            this.fixedSize.FormattingEnabled = true;
            this.fixedSize.Items.AddRange(new object[] {
            "9",
            "16",
            "32"});
            this.fixedSize.Location = new System.Drawing.Point(60, 19);
            this.fixedSize.Name = "fixedSize";
            this.fixedSize.Size = new System.Drawing.Size(44, 21);
            this.fixedSize.TabIndex = 15;
            this.fixedSize.SelectedIndexChanged += new System.EventHandler(this.fixedSize_SelectedIndexChanged);
            // 
            // Arithmetic
            // 
            this.Arithmetic.AutoSize = true;
            this.Arithmetic.Location = new System.Drawing.Point(6, 66);
            this.Arithmetic.Name = "Arithmetic";
            this.Arithmetic.Size = new System.Drawing.Size(71, 17);
            this.Arithmetic.TabIndex = 0;
            this.Arithmetic.Text = "Arithmetic";
            this.Arithmetic.UseVisualStyleBackColor = true;
            this.Arithmetic.Click += new System.EventHandler(this.UpdateSaveMode);
            // 
            // Table
            // 
            this.Table.AutoSize = true;
            this.Table.Checked = true;
            this.Table.Location = new System.Drawing.Point(7, 43);
            this.Table.Name = "Table";
            this.Table.Size = new System.Drawing.Size(52, 17);
            this.Table.TabIndex = 0;
            this.Table.TabStop = true;
            this.Table.Text = "Table";
            this.Table.UseVisualStyleBackColor = true;
            this.Table.Click += new System.EventHandler(this.UpdateSaveMode);
            // 
            // Fixed
            // 
            this.Fixed.AutoSize = true;
            this.Fixed.Location = new System.Drawing.Point(7, 20);
            this.Fixed.Name = "Fixed";
            this.Fixed.Size = new System.Drawing.Size(50, 17);
            this.Fixed.TabIndex = 0;
            this.Fixed.Text = "Fixed";
            this.Fixed.UseVisualStyleBackColor = true;
            this.Fixed.Click += new System.EventHandler(this.UpdateSaveMode);
            // 
            // KValue
            // 
            this.KValue.Location = new System.Drawing.Point(12, 608);
            this.KValue.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.KValue.Name = "KValue";
            this.KValue.Size = new System.Drawing.Size(113, 20);
            this.KValue.TabIndex = 15;
            this.KValue.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.KValue.ValueChanged += new System.EventHandler(this.KValue_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 592);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Accepted Error";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(441, 293);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Contrast";
            // 
            // errorImageType
            // 
            this.errorImageType.FormattingEnabled = true;
            this.errorImageType.Items.AddRange(new object[] {
            "Prediction error",
            "Quantized error"});
            this.errorImageType.Location = new System.Drawing.Point(274, 290);
            this.errorImageType.Name = "errorImageType";
            this.errorImageType.Size = new System.Drawing.Size(150, 21);
            this.errorImageType.TabIndex = 19;
            this.errorImageType.SelectedIndexChanged += new System.EventHandler(this.errorImageType_SelectedIndexChanged);
            // 
            // computeError
            // 
            this.computeError.Location = new System.Drawing.Point(133, 587);
            this.computeError.Name = "computeError";
            this.computeError.Size = new System.Drawing.Size(111, 23);
            this.computeError.TabIndex = 20;
            this.computeError.Text = "Compute Error";
            this.computeError.UseVisualStyleBackColor = true;
            this.computeError.Click += new System.EventHandler(this.computeError_Click);
            // 
            // labelMinimumError
            // 
            this.labelMinimumError.AutoSize = true;
            this.labelMinimumError.Location = new System.Drawing.Point(131, 615);
            this.labelMinimumError.Name = "labelMinimumError";
            this.labelMinimumError.Size = new System.Drawing.Size(36, 13);
            this.labelMinimumError.TabIndex = 21;
            this.labelMinimumError.Text = "Min = ";
            // 
            // labelMaximumError
            // 
            this.labelMaximumError.AutoSize = true;
            this.labelMaximumError.Location = new System.Drawing.Point(190, 615);
            this.labelMaximumError.Name = "labelMaximumError";
            this.labelMaximumError.Size = new System.Drawing.Size(39, 13);
            this.labelMaximumError.TabIndex = 22;
            this.labelMaximumError.Text = "Max = ";
            // 
            // UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 658);
            this.Controls.Add(this.labelMaximumError);
            this.Controls.Add(this.labelMinimumError);
            this.Controls.Add(this.computeError);
            this.Controls.Add(this.errorImageType);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.KValue);
            this.Controls.Add(this.groupBoxSaveModes);
            this.Controls.Add(this.groupBoxHistogram);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.buttonSaveDecoded);
            this.Controls.Add(this.buttonDecode);
            this.Controls.Add(this.buttonLoadEncoded);
            this.Controls.Add(this.contrast);
            this.Controls.Add(this.groupBoxPredictors);
            this.Controls.Add(this.buttonSaveEncoded);
            this.Controls.Add(this.buttonEncode);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.decodedImagePanel);
            this.Controls.Add(this.errorImagePanel);
            this.Controls.Add(this.originalImagePanel);
            this.Controls.Add(this.chart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UI";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Near Lossless Predictive Coder";
            ((System.ComponentModel.ISupportInitialize)(this.contrast)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBoxHistogram.ResumeLayout(false);
            this.groupBoxHistogram.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HistogramScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.groupBoxSaveModes.ResumeLayout(false);
            this.groupBoxSaveModes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel originalImagePanel;
        private System.Windows.Forms.Panel errorImagePanel;
        private System.Windows.Forms.Panel decodedImagePanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button buttonEncode;
        private System.Windows.Forms.Button buttonSaveEncoded;
        private System.Windows.Forms.GroupBox groupBoxPredictors;
        private System.Windows.Forms.NumericUpDown contrast;
        private System.Windows.Forms.Button buttonLoadEncoded;
        private System.Windows.Forms.Button buttonDecode;
        private System.Windows.Forms.Button buttonSaveDecoded;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.GroupBox groupBoxHistogram;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radioButtonDecoded;
        private System.Windows.Forms.RadioButton radioButtonErrorPrediction;
        private System.Windows.Forms.RadioButton radioButtonOriginal;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.GroupBox groupBoxSaveModes;
        private System.Windows.Forms.RadioButton Arithmetic;
        private System.Windows.Forms.RadioButton Table;
        private System.Windows.Forms.RadioButton Fixed;
        private System.Windows.Forms.ComboBox fixedSize;
        private System.Windows.Forms.NumericUpDown KValue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown HistogramScale;
        private System.Windows.Forms.RadioButton radioButtonQuantizedErrorPrediction;
        private System.Windows.Forms.ComboBox errorImageType;
        private System.Windows.Forms.Button computeError;
        private System.Windows.Forms.Label labelMinimumError;
        private System.Windows.Forms.Label labelMaximumError;
    }
}

