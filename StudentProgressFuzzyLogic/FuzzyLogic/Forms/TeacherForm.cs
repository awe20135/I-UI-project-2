using StudentProgressFuzzyLogic.FuzzyLogic.Controller;
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
    public partial class TeacherForm : Form
    {
        private MainForm _mainForm;

        public TeacherForm(MainForm mainForm)
        {
            InitializeComponent();

            _mainForm = mainForm;
        }

        private void TeacherForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _mainForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new StudentsResultForm(this).Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            DialogResult dialogResult = new MajorityTweakForm(this).ShowDialog();

            if(dialogResult == DialogResult.OK)
            {
                FuzzyModel.SaveInputLVs();
                
                Model.Rule[] newRuleBase = Model.Rule.GenerateRuleBase(FuzzyModel.InputLVs, FuzzyModel.OutputLV);
                DataController.SetRuleBase(newRuleBase);

                if(StudentResult.StudentResults == null)
                {
                    StudentResult.GetResults();
                }

                FuzzyResult.UpdateFuzzyResults();
                DataController.SaveStudentResult(StudentResult.StudentResults);
            }
            else
            {
                FuzzyModel.SetInputLVs();
            }
        }
    }
}
