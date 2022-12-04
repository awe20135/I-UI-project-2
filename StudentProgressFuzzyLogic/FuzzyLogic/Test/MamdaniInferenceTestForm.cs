using StudentProgressFuzzyLogic.FuzzyLogic.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace StudentProgressFuzzyLogic.FuzzyLogic.Test
{
    public partial class MamdaniInferenceTestForm : Form
    {
        public MamdaniInferenceTestForm()
        {
            InitializeComponent();
        }

        private void DrawButton_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();

            float[] crispValues = { float.Parse(textBox1.Text), float.Parse(textBox2.Text), float.Parse(textBox3.Text) };

            Term term = FuzzyInference.MamdaniInferenceProcess(crispValues);

            chart1.ChartAreas[0].AxisX.Minimum = FuzzyModel.OutputLV.XStart;
            chart1.ChartAreas[0].AxisX.Maximum = FuzzyModel.OutputLV.XEnd;
            chart1.ChartAreas[0].AxisX.Interval = FuzzyModel.OutputLV.ChartDX;


            Series termSeries = new Series(term.Name);
            termSeries.ChartType = SeriesChartType.Line;

            for (int uIndex = 0; uIndex < term.U.Length; uIndex++)
            {
                termSeries.Points.AddXY(ConvertTo2PointFloat(FuzzyModel.OutputLV.X[uIndex]), term.U[uIndex]);
            }

            termSeries.BorderWidth = 5;

            termSeries.ToolTip = "X = #VALX, Y = #VALY";

            chart1.Series.Add(termSeries);

            float crispAnswer = FuzzyModel.OutputLV.Defuzzification(term);
            answerTextBox.Text = crispAnswer.ToString("0.00");
            answerLabel.Text = FuzzyModel.OutputLV.GetWordAnswer(term);
        }

        public float ConvertTo2PointFloat(float f)
        {
            return float.Parse(f.ToString("0.00"));
        }
    }
}
