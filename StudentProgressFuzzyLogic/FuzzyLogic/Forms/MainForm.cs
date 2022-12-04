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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            if (StudentResult.StudentResults == null)
            {
                StudentResult.GetResults();
            }

            FuzzyResult.UpdateFuzzyResults();
            DataController.SaveStudentResult(StudentResult.StudentResults);
        }

        private void studentButton_Click(object sender, EventArgs e)
        {
            new StudentForm(this).Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = new TeacherLoginForm().ShowDialog();
            if(dialogResult == DialogResult.OK)
            {
                new TeacherForm(this).Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Inncorrect password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
