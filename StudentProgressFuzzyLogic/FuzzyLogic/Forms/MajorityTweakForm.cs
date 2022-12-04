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

namespace StudentProgressFuzzyLogic.FuzzyLogic.Forms
{
    public partial class MajorityTweakForm : Form
    {
        private TeacherForm _studentForm;
        private Dictionary<string, LinguisticVariable> lvs = new Dictionary<string, LinguisticVariable>();

        public MajorityTweakForm(TeacherForm studentForm)
        {
            InitializeComponent();

            _studentForm = studentForm;

            foreach (LinguisticVariable lv in FuzzyModel.InputLVs)
            {
                GenerateButton(lv);
            }

        }

        private void MajorityTweakForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _studentForm.Show();
        }

        private void LVButtonMajorityTweak_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            DialogResult dialogResult = new TweakLVMajorityForm(lvs[button.Text]).ShowDialog();
        }

        private void GenerateButton(LinguisticVariable linguisticVariable)
        {
            lvs.Add(linguisticVariable.Name, linguisticVariable);

            Button button = new Button();
            button.Dock = DockStyle.Top;
            button.AutoSize = true;
            button.MouseClick += LVButtonMajorityTweak_Click;

            button.Text = linguisticVariable.Name;
            LvPanel.Controls.Add(button);
        }

        private void MajorityTweakForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            lvs = null;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void abortButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
        }
    }
}
