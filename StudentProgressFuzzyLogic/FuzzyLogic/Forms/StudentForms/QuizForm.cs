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
    public partial class QuizForm : Form
    {
        public static int RightAnswers { get => _rightAnswers; }
        public static float Time { get => _time; }

        private static int _currentQuestionIndex = 0;

        private static int _minutes = 0;
        private static int _seconds = 0;

        private static int _rightAnswers = 0;
        private static float _time;

        List<RadioButton> _radioButtons = new List<RadioButton>();
        Question _currentQuestion;

        StudentForm _studentForm;

        public QuizForm(StudentForm studentForm)
        {
            InitializeComponent();
            InitializeRadioGroup();

            SetTimeLabel();
            _studentForm = studentForm;

            OpenNewQuestion();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _seconds++;

            if (_seconds >= 60)
            {
                _seconds = 0;
                _minutes++;
            }

            SetTimeLabel();
        }

        private void SetTimeLabel()
        {
            timeLabel.Text = $"Time: {GetFormatedTime(_minutes)}:{GetFormatedTime(_seconds)}";
        }

        private string GetFormatedTime(int time)
        {
            return time < 10 ? $"0{time}" : $"{time}";
        }

        private void InitializeRadioGroup()
        {
            _radioButtons.Add(answerRadioButton1);
            _radioButtons.Add(answerRadioButton2);
            _radioButtons.Add(answerRadioButton3);
            _radioButtons.Add(answerRadioButton4);
        }

        private void nextQuestionButton_Click(object sender, EventArgs e)
        {
            bool isRadioChecked = false;

            for (int radioIndex = 0; radioIndex < _radioButtons.Count; radioIndex++)
            {
                if (_radioButtons[radioIndex].Checked)
                {
                    isRadioChecked = true;
                    _rightAnswers += _currentQuestion.IsCorrectAnswer(radioIndex) ? 1 : 0;
                    break;
                }
            }

            if (!isRadioChecked)
            {
                DialogResult result = MessageBox.Show("You sure? Answer has not been chosen.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(result == DialogResult.No)
                {
                    return;
                }
            }

            OpenNewQuestion();
        }

        private void endQuizButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you ready to end of the quiz?", "End of quiz", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.No)
            {
                return;
            }

            _time = _minutes + (float)_seconds / 60;

            new ChooseHardOfQuizForm(_studentForm).Show();
            this.Close();
        }

        private void OpenNewQuestion()
        {
            _currentQuestion = Question.QuestionBase[_currentQuestionIndex];

            questionTitleLabel.Text = _currentQuestion.Title;

            for (int radioIndex = 0; radioIndex < _radioButtons.Count; radioIndex++)
            {
                _radioButtons[radioIndex].Text = _currentQuestion.Answers[radioIndex].Description;
                _radioButtons[radioIndex].Checked = false;
            }

            if (_currentQuestionIndex >= Question.QuestionBase.Length - 1)
            {
                nextQuestionButton.Visible = false;
                endQuizButton.Visible = true;
            }
            else
            {
                _currentQuestionIndex++;
            }
        }

        public static void Reset()
        {
            _currentQuestionIndex = 0;
            _minutes = 0;
            _seconds = 0;

            _rightAnswers = 0;
            _time = 0;
        }
    }
}
