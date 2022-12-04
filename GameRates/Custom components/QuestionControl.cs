using GameStatsFuzzy2Controller.FuzzyModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameRates.Custom_components
{
    public partial class QuestionControl : UserControl
    {
        LV2 _lv;

        public QuestionControl(LV2 lv)
        {
            _lv = lv;

            InitializeComponent();

            this.Size = new Size(this.Size.Width, questionTitleLabel.Height + trackBar.Height + panel.Height);

            questionTitleLabel.Text = lv.Question;

            trackBar.Minimum = (int)Math.Round(lv.XStart / lv.Dx, 0);
            trackBar.Maximum = (int)Math.Round(lv.XEnd / lv.Dx, 0);

            trackBar.TickFrequency = (int)Math.Round(1 / lv.Dx, 0);

            trackBar.Value = (int)Math.Round((trackBar.Minimum + trackBar.Maximum) / 2d, 0);
        }

        public float GetTermValue()
        {
            return trackBar.Value * _lv.Dx;
        }
    }
}
