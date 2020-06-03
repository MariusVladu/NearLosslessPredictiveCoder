using NearLosslessPredictiveCoder.Contracts.Predictors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using NearLosslessPredictiveCoder.Predictors;
using NearLosslessPredictiveCoder.Entities;
using NearLosslessPredictiveCoder.SaveModes;
using NearLosslessPredictiveCoder.FileOperations;
using System.IO;
using System.Linq;

namespace NearLosslessPredictiveCoder.GUI
{
    public partial class UI : Form
    {
        List<IPredictor> predictors = new List<IPredictor>
        {
            new HalfRange(),
            new A(),
            new B(),
            new C(),
            new Predictor4(),
            new Predictor5(),
            new Predictor6(),
            new Predictor7(),
            new JpegLS()
        };

        PredictorSettings predictorSettings;
        SaveMode saveMode;

        Bitmap originalBitmap;
        Bitmap decodedBitmap;
        EncodedImage encodedImage;
        DecodedImage decodedImage;

        bool lastOperationWasEncode = false;

        string originalFilePath;
        string encodedFilePath;


        public UI()
        {
            InitializeComponent();

            CreateRadioButtons();

            SetDefaultPredictorSettings();

            errorImageType.SelectedIndex = 0;
            fixedSize.SelectedIndex = 0;
        }

        private void SetDefaultPredictorSettings()
        {
            ((RadioButton)groupBoxPredictors.Controls[0]).Checked = true;

            predictorSettings = new PredictorSettings
            {
                Predictor = predictors[0],
                AcceptedError = Convert.ToInt32(KValue.Value),
                Range = 256
            };

            UpdateSaveMode();
        }

        private void UpdateSaveMode()
        {
            saveMode = GetSelectedSaveMode();
        }

        private SaveMode GetSelectedSaveMode()
        {
            if (Fixed.Checked)
                return SaveMode.Fixed;

            if (Table.Checked)
                return SaveMode.Table;

            return SaveMode.Arithmetic;
        }

        private void CreateRadioButtons()
        {
            for (int i = 0; i < predictors.Count; i++)
            {
                RadioButton radioButton = new RadioButton();
                radioButton.Location = new System.Drawing.Point(7, 20 + 24 * i);
                radioButton.Name = "radioButton" + i;
                radioButton.Size = new System.Drawing.Size(85, 17);
                radioButton.Text = predictors[i].Description;
                radioButton.AutoSize = true;
                //rb.UseVisualStyleBackColor = true;

                radioButton.Click += (s, e) =>
                {
                    var predictorIndex = this.groupBoxPredictors.Controls.IndexOf((RadioButton)s);
                    predictorSettings.Predictor = predictors[predictorIndex];
                };

                this.groupBoxPredictors.Controls.Add(radioButton);
            }
        }

        private void buttonLoadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Bitmap Image|*.bmp";
            if (fileDialog.ShowDialog() != DialogResult.OK)
                return;

            originalFilePath = fileDialog.FileName;
            originalBitmap = new Bitmap(originalFilePath);

            this.originalImagePanel.BackgroundImage = originalBitmap;
            this.toolStripStatusLabel.Text = System.IO.Path.GetFileName(originalFilePath) + " loaded.";
            this.buttonEncode.Enabled = true;
        }

        private void buttonLoadEncoded_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "NLP Encoded Image|*.nlp";
            if (fileDialog.ShowDialog() != DialogResult.OK)
                return;

            encodedFilePath = fileDialog.FileName;

            UpdateSettingsFromEncodedFileExtension();

            this.toolStripStatusLabel.Text = Path.GetFileName(encodedFilePath) + " loaded.";
            this.buttonDecode.Enabled = true;
        }

        private void buttonDecode_Click(object sender, EventArgs e)
        {
            using (var encodedImageReader = new EncodedImageReader())
            {
                encodedImage = encodedImageReader.ReadEncodedImage(encodedFilePath, saveMode);
            }

            decodedImage = Decoder.GetDecodedImage(encodedImage);
            decodedBitmap = Decoder.Decode(encodedImage);

            predictorSettings = decodedImage.PredictorSettings;
            UpdateUiFromSettings();

            lastOperationWasEncode = false;
            this.decodedImagePanel.BackgroundImage = decodedBitmap;
            this.toolStripStatusLabel.Text = "Image decoded.";
            this.groupBoxHistogram.Enabled = true;
            this.buttonSaveDecoded.Enabled = true;
            this.radioButtonQuantizedErrorPrediction.Enabled = true;
            this.radioButtonErrorPrediction.Enabled = true;
            this.radioButtonDecoded.Enabled = true;

            RefreshErrorImage();
            RefreshHistogram();
        }

        private void UpdateSettingsFromEncodedFileExtension()
        {
            var pathWithoutNlpExtention = encodedFilePath.Replace(".nlp", "");
            var extension = Path.GetExtension(pathWithoutNlpExtention).Trim('.');

            var k = Convert.ToInt32(extension.Substring(1, extension.IndexOf('p') - extension.IndexOf('k') - 1));
            var predictorIndex = Convert.ToInt32(extension[extension.IndexOf('p') + 1].ToString());
            var saveModeChar = extension.Last();

            predictorSettings.AcceptedError = k;
            predictorSettings.Predictor = predictors[predictorIndex];
            saveMode = (SaveMode)saveModeChar;

            UpdateUiFromSettings();
        }

        private void UpdateUiFromSettings()
        {
            UpdateUiPredictorSelection();

            UpdateUiSaveModeSelection();
        }

        private void UpdateUiPredictorSelection()
        {
            foreach (var radioButtonControl in groupBoxPredictors.Controls)
                ((RadioButton)radioButtonControl).Checked = false;

            var predictor = predictors.First(x => x.Code == predictorSettings.Predictor.Code);
            var predictorIndex = predictors.IndexOf(predictor);
            ((RadioButton)groupBoxPredictors.Controls[predictorIndex]).Checked = true;
        }

        private void UpdateUiSaveModeSelection()
        {
            foreach (var radioButtonControl in groupBoxSaveModes.Controls)
            {
                if(radioButtonControl is RadioButton)
                    ((RadioButton)radioButtonControl).Checked = false;
            }

            if (saveMode == SaveMode.Fixed)
            {
                Fixed.Checked = true;
            }
            else if (saveMode == SaveMode.Table)
            {
                Table.Checked = true;
            }
            else
            {
                Arithmetic.Checked = true;
            }
        }

        private void buttonEncode_Click(object sender, EventArgs e)
        {
            encodedImage = Encoder.Encode(originalBitmap, predictorSettings);

            lastOperationWasEncode = true;

            this.toolStripStatusLabel.Text = "Encoding Complete.";
            this.groupBoxHistogram.Enabled = true;
            this.buttonSaveEncoded.Enabled = true;
            this.radioButtonOriginal.Enabled = true;
            this.radioButtonQuantizedErrorPrediction.Enabled = true;
            this.radioButtonErrorPrediction.Enabled = true;
            this.radioButtonDecoded.Enabled = true;

            RefreshErrorImage();
            RefreshHistogram();
        }

        private void buttonSaveEncoded_Click(object sender, EventArgs e)
        {
            using (var encodedImageWriter = new EncodedImageWriter())
            {
                encodedImageWriter.SaveToFile(encodedImage, originalFilePath, saveMode);
            }

            this.toolStripStatusLabel.Text = "File saved";
        }

        private void buttonSaveDecoded_Click(object sender, EventArgs e)
        {
            string outputPath = $"{encodedFilePath}.bmp";

            using (var imageWriter = new ImageWriter())
            {
                imageWriter.SaveImage(decodedBitmap, encodedFilePath, outputPath);
            }

            this.toolStripStatusLabel.Text = "File saved";
        }

        private void RefreshErrorImage()
        {
            if (encodedImage == null && decodedImage == null)
            {
                return;
            }

            var errorMatrix = GetErrorMatrixBasedOnSelection();
            var scale = contrast.Value;

            DrawErrorImage(errorMatrix, scale);
        }

        private void RefreshHistogram()
        {
            if (encodedImage == null && decodedImage == null)
            {
                return;
            }

            var histogram = GetHistogramBasedOnSelection();

            DrawHistogram(histogram);
        }

        private int[,] GetErrorMatrixBasedOnSelection()
        {
            var selectedOption = (string)errorImageType.SelectedItem;

            if (lastOperationWasEncode)
                return GetErrorMatrixForEncodedImageBasedOnSelection(selectedOption);

            return GetErrorMatrixForDecodedImageBasedOnSelection(selectedOption);
        }

        private int[,] GetErrorMatrixForEncodedImageBasedOnSelection(string selectedOption)
        {
            if (selectedOption == "Prediction error")
                return encodedImage.ErrorPrediction;

            return encodedImage.QuantizedErrorPredictionMatrix;
        }

        private int[,] GetErrorMatrixForDecodedImageBasedOnSelection(string selectedOption)
        {
            if (selectedOption == "Prediction error")
                return decodedImage.ErrorPredictionMatrix;

            return decodedImage.QuantizedErrorPredictionMatrix;
        }

        private int[] GetHistogramBasedOnSelection()
        {
            if(lastOperationWasEncode)
            {
                this.toolStripStatusLabel.Text = "Showing histogram from encoded image";
                return GetHistogramFromEncodedImageBasedOnSelection();
            }

            this.toolStripStatusLabel.Text = "Showing histogram from decoded image";
            return GetHistogramFromDecodedImageBasedOnSelection();
        }

        private int[] GetHistogramFromEncodedImageBasedOnSelection()
        {
            if (radioButtonOriginal.Checked)
                return GetHistogramFromMatrix(encodedImage.Original);

            if (radioButtonErrorPrediction.Checked)
                return GetHistogramFromMatrix(encodedImage.ErrorPrediction);

            if (radioButtonQuantizedErrorPrediction.Checked)
                return GetHistogramFromMatrix(encodedImage.QuantizedErrorPredictionMatrix);

            return GetHistogramFromMatrix(encodedImage.Decoded);
        }

        private int[] GetHistogramFromDecodedImageBasedOnSelection()
        {
            if (radioButtonErrorPrediction.Checked)
                return GetHistogramFromMatrix(decodedImage.ErrorPredictionMatrix);

            if (radioButtonQuantizedErrorPrediction.Checked)
                return GetHistogramFromMatrix(decodedImage.QuantizedErrorPredictionMatrix);

            return GetHistogramFromMatrix(decodedImage.Decoded);
        }

        private int[] GetHistogramFromMatrix(int[,] matrix)
        {
            var height = matrix.GetLength(0);
            var width = matrix.GetLength(1);

            int[] histogram = new int[512];

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    histogram[256 + matrix[i, j]]++;
                }
            }

            return histogram;
        }

        private void DrawHistogram(int[] histogram)
        {
            var dataPointSeries = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                Name = "Histogram",
                Color = Color.Gray,
                IsVisibleInLegend = false,
                ChartType = SeriesChartType.Column,
                MarkerStyle = MarkerStyle.None,
                BorderWidth = 0
            };
            for (int i = 0; i < histogram.Length; i++)
            {
                dataPointSeries.Points.AddXY(-256 + i, histogram[i] * HistogramScale.Value);
            }

            chart.Series.Clear();
            chart.Series.Add(dataPointSeries);
            chart.Series[0]["PointWidth"] = "1";
            chart.ChartAreas[0].AxisY.Maximum = 512;
            chart.ChartAreas[0].AxisY.Minimum = 0;
            chart.ChartAreas[0].AxisX.Minimum = -256;
            chart.ChartAreas[0].AxisX.Maximum = 256;
        }

        private void KValue_ValueChanged(object sender, EventArgs e)
        {
            predictorSettings.AcceptedError = Convert.ToInt32(KValue.Value);
        }

        private void UpdateSaveMode(object sender, EventArgs e)
        {
            UpdateSaveMode();
        }

        private void DrawErrorImage(int[,] errorMatrix, decimal scale)
        {
            var referenceBitmap = originalBitmap ?? decodedBitmap;

            var errorImage = new Bitmap(referenceBitmap.Width, referenceBitmap.Height);

            for (int i = 0; i < referenceBitmap.Width; i++)
            {
                for (int j = 0; j < referenceBitmap.Height; j++)
                {
                    int value = NormalizeValue((int)(128 + (errorMatrix[i, j]) * scale));

                    errorImage.SetPixel(i, j, Color.FromArgb(value, value, value));
                }
            }

            this.errorImagePanel.BackgroundImage = errorImage;
        }

        private int NormalizeValue(int value)
        {
            if (value < 0)
                return 0;

            if (value > 255)
                return 255;

            return value;
        }

        private void fixedSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            var fixedSaveModeValueSize = Convert.ToInt32(fixedSize.SelectedItem);

            FixedSaveMode.NumberOfBitsForValue = fixedSaveModeValueSize;
        }

        private void errorImageType_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshErrorImage();
        }

        private void contrast_ValueChanged(object sender, EventArgs e)
        {
            RefreshErrorImage();
        }

        private void HistogramRadioButtonClick(object sender, EventArgs e)
        {
            RefreshHistogram();
        }

        private void HistogramScale_ValueChanged(object sender, EventArgs e)
        {
            RefreshHistogram();
        }
    }
}
