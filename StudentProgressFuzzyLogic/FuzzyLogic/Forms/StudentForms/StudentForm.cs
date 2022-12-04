using StudentProgressFuzzyLogic.FuzzyLogic.Controller;
using StudentProgressFuzzyLogic.FuzzyLogic.Model;
using StudentProgressFuzzyLogic.FuzzyLogic.Model.QuizModel;
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
    public partial class StudentForm : Form
    {
        public static StudentResult CurrentStudentResult { get => currentStudentResult; }

        
        private static StudentResult currentStudentResult;

        private MainForm _mainForm;
        

        public StudentForm(MainForm mainForm)
        {
            InitializeComponent();

            _mainForm = mainForm;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            StudentResult.GetResults();

            LoginForm loginForm = new LoginForm();

            loginForm.ShowDialog();

            if(loginForm.DialogResult == DialogResult.OK)
            {
                StudentResult studentResult = new StudentResult(loginForm.StudentName, loginForm.StudentSername, saveResult: false);
                if (StudentResult.StudentResults.Contains(studentResult))
                {
                    foreach (StudentResult result in StudentResult.StudentResults)
                    {
                        if (result.Equals(studentResult))
                        {
                            currentStudentResult = result;
                            break;
                        }
                    }
                }
                else
                {
                    currentStudentResult = new StudentResult(studentResult.Name, studentResult.Sername);
                }

                if (currentStudentResult.IsValid())
                {
                    viewResultButton.Enabled = true;
                }
                else
                {
                    startTestButton.Enabled = true;
                }

                loginButton.Visible = false;
                logoutButton.Visible = true;
                logedinStudentLabel.Text = $"Hello, {currentStudentResult.Name} {currentStudentResult.Sername}";

            }

            if (loginForm.DialogResult == DialogResult.Abort)
            {
                MessageBox.Show("Incorect name or sername", "Wrong login data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            loginButton.Visible = true;
            logoutButton.Visible = false;

            viewResultButton.Enabled = false;
            startTestButton.Enabled = false;

            logedinStudentLabel.Text = "Not log in";

            currentStudentResult.Remove();
            currentStudentResult = null;
        }

        private void startTestButton_Click(object sender, EventArgs e)
        {
            Question.ShuffleQuestionBase();

            QuizForm quizForm = new QuizForm(this);
            quizForm.Show();
            this.Hide();
        }

        private void viewResultButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Points: {currentStudentResult.CrispValue} - {currentStudentResult.VerbValue}");
        }

        public void EndOfQuiz()
        {
            currentStudentResult.SetCrispValues(QuizForm.RightAnswers, QuizForm.Time, ChooseHardOfQuizForm.Hardest);

            QuizForm.Reset();

            startTestButton.Enabled = false;
            viewResultButton.Enabled = true;

            DataController.SetStudentResult(currentStudentResult);
        }

        private void StudentForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _mainForm.Show();
        }
    }
}
