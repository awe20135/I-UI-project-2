using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using StudentProgressFuzzyLogic.FuzzyLogic.Model;

namespace StudentProgressFuzzyLogic
{
    public partial class LVTestForm : Form
    {
        Chart[] charts;

        public LVTestForm()
        {
            InitializeComponent();

            charts = new Chart[]{ chart1, chart2, chart3, chart4 };

            foreach (Chart chart in charts)
            {
                chart.Series.Clear();
            }

            List<LinguisticVariable> linguisticVariables = new List<LinguisticVariable>(FuzzyModel.InputLVs);
            linguisticVariables.Add(FuzzyModel.OutputLV);

            for (int lvIndex = 0; lvIndex < linguisticVariables.Count; lvIndex++)
            {
                charts[lvIndex].Titles.Add(linguisticVariables[lvIndex].Name);

                charts[lvIndex].ChartAreas[0].AxisX.Minimum = linguisticVariables[lvIndex].XStart;
                charts[lvIndex].ChartAreas[0].AxisX.Maximum = linguisticVariables[lvIndex].XEnd;
                charts[lvIndex].ChartAreas[0].AxisX.Interval = linguisticVariables[lvIndex].ChartDX;

                foreach (Term term in linguisticVariables[lvIndex].Terms)
                {
                    Series termSeries = new Series(term.Name);
                    termSeries.ChartType = SeriesChartType.Line;

                    for (int uIndex = 0; uIndex < term.U.Length; uIndex++)
                    {
                        termSeries.Points.AddXY(ConvertTo2PointFloat(linguisticVariables[lvIndex].X[uIndex]), term.U[uIndex]);
                    }

                    termSeries.BorderWidth = 5;

                    termSeries.ToolTip = "X = #VALX, Y = #VALY";

                    charts[lvIndex].Series.Add(termSeries);
                }
            }
        }

        public float ConvertTo2PointFloat(float f)
        {
            return float.Parse(f.ToString("0.00"));
        }

    }
}
