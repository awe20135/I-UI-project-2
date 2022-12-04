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
    public partial class StudentsResultForm : Form
    {
        private TeacherForm _teacherForm;

        public StudentsResultForm(TeacherForm teacherForm)
        {
            InitializeComponent();

            _teacherForm = teacherForm;

            studentsResultDataGridView.DataSource = StudentResult.StudentResults;
            for (int columnIndex = 0; columnIndex < studentsResultDataGridView.Columns.Count; columnIndex++)
            {
                studentsResultDataGridView.Columns[columnIndex].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            for (int lvIndex = 0; lvIndex < FuzzyModel.InputLVs.Length; lvIndex++)
            {
                Label label = new Label();
                label.Dock = DockStyle.Top;
                label.Text = FuzzyModel.InputLVs[lvIndex].ToString();
                termPanel.Controls.Add(label);
            }
            
        }

        private void StudentsResultForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _teacherForm.Show();
        }
    }
}
