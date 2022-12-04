using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameRates.Custom_components;
using GameRates.Data_Controller;
using GameStatsFuzzy2Controller;
using GameStatsFuzzy2Controller.Controller;

namespace GameRates
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            gameNameLabel.Text = Properties.Resources.Game_name;

            Fuzzy2Model.SetUpModel();

            for (int i = 0; i < Fuzzy2Model.InputLVs.Length; i++)
            {
                QuestionControl question = new QuestionControl(Fuzzy2Model.InputLVs[i]);
                question.Dock = DockStyle.Top;

                questionPanel.Controls.Add(question);
            }
        }

        private void setButton_Click(object sender, EventArgs e)
        {
            float[] crispValues = new float[questionPanel.Controls.Count];

            for (int i = questionPanel.Controls.Count ; i > 0; i--)
            {
                QuestionControl question = questionPanel.Controls[i-1] as QuestionControl;
                crispValues[questionPanel.Controls.Count - i] = question.GetTermValue();
            }

            crispValues[2] = 10 - crispValues[2];

            var answer = FuzzifierController.GetMamdaniInference(crispValues, Fuzzy2Model.InputLVs, Fuzzy2Model.OutputLV, Fuzzy2Model.RuleBase);

            MessageBox.Show($"Your interest on game - {answer.wordResult} - {answer.crispResult}", "Your Interest");
            AnswerDataController.SaveAnswerIntoFile(new AnswerDataController.SavingDataStruct { CrispResult = answer.crispResult,
                                                                                                WordResult = answer.wordResult, 
                                                                                                GameName=gameNameLabel.Text});
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            try
            {
                new ResultsForm().ShowDialog();
            }
            catch { }
        }
    }
}
