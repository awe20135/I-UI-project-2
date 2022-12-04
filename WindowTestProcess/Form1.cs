using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using OxyPlot;
using OxyPlot.WindowsForms;
using GameStatsFuzzy2Controller;
using GameStatsFuzzy2Controller.FuzzyModel;
using OxyPlot.Series;
using OxyPlot.Legends;
using OxyPlot.Axes;

namespace WindowTestProcess
{
    public partial class Form1 : Form
    {
        private int numberOfPLotWidth = 0;
        private int numberOfPLotHeight = 0;

        private readonly Size plotSize = new Size(800,320);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Fuzzy2Model.SetUpModel();

            foreach (LV2 lV in Fuzzy2Model.InputLVs)
            {
                CreatePlot(lV);
            }

            if (numberOfPLotWidth != 0)
            {
                numberOfPLotWidth = 0;
                numberOfPLotHeight++;
            }

            CreatePlot(Fuzzy2Model.OutputLV);
        }

        private void CreatePlot(LV2 lv, int width = 2)
        {
            PlotView pv = new PlotView();
            pv.Location = new Point(numberOfPLotWidth * plotSize.Width, numberOfPLotHeight * plotSize.Height);
            pv.Size = plotSize;
            this.Controls.Add(pv);

            if (++numberOfPLotWidth >= width)
            {
                numberOfPLotWidth = 0;
                numberOfPLotHeight++;
            }

            pv.Model = new PlotModel { Title = lv.Name };

            pv.Model.Axes.Add(new LinearAxis
            {
                    Key = "yAxis",
                    IsZoomEnabled = false,
                    IsPanEnabled = false,
                    Position = AxisPosition.Left,
                    MajorGridlineStyle = LineStyle.Dot,
                    MajorGridlineColor = OxyColors.Gray
            });
            
            pv.Model.Axes.Add(new LinearAxis
            {
                    Key = "xAxis",
                    IsZoomEnabled = false,
                    IsPanEnabled = false,
                    Position = AxisPosition.Bottom,
                    MajorGridlineStyle = LineStyle.Dot,
                    MajorGridlineColor = OxyColors.Gray
            });

            pv.Model.Legends.Add(new Legend()
            {
                LegendTitle = "Legend",
                LegendPosition = LegendPosition.RightTop,
                LegendFontSize = 8,
                LegendPlacement = LegendPlacement.Outside,
                LegendPadding = 0,
                LegendMargin = 0
            });

            foreach (Term2 term in lv.Terms)
            {
                AreaSeries fs = new AreaSeries()
                {
                    Fill = OxyColor.FromAColor(50, OxyColors.Blue)
                };
                fs.Title = term.Name;
                

                for (int i = 0; i < lv.X.Length; i++)
                {
                    fs.Points.Add(new DataPoint(lv.X[i], term.UpperBoundTerm.U[i]));
                    fs.Points2.Add(new DataPoint(lv.X[i], term.LowerBoundTerm.U[i]));
                }

                pv.Model.Series.Add(fs);
            }
        }
    }
}
