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
    public partial class ChooseHardOfQuizForm : Form
    {
        public static float Hardest { get => _hardest; }

        private static float _hardest;
        
        List<RadioButton> _radioButtons = new List<RadioButton>();

        StudentForm _studentForm;

        public ChooseHardOfQuizForm(StudentForm studentForm)
        {
            InitializeComponent();
            InitializeRadioGroup();

            _studentForm = studentForm;
        }

        private void setButton_Click(object sender, EventArgs e)
        {
            bool isRadioChecked = false;

            for (int radioIndex = 0; radioIndex < _radioButtons.Count; radioIndex++)
            {
                if (_radioButtons[radioIndex].Checked)
                {
                    isRadioChecked = true;
                    _hardest = radioIndex + 1;
                    break;
                }
            }

            if (!isRadioChecked)
            {
                MessageBox.Show("Please select the difficulty of the quiz.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _studentForm.EndOfQuiz();
            _studentForm.Show();
            this.Close();
        }

        private void InitializeRadioGroup()
        {
            _radioButtons.Add(radioButton1);
            _radioButtons.Add(radioButton2);
            _radioButtons.Add(radioButton3);
            _radioButtons.Add(radioButton4);
            _radioButtons.Add(radioButton5);
            _radioButtons.Add(radioButton6);
            _radioButtons.Add(radioButton7);
            _radioButtons.Add(radioButton8);
            _radioButtons.Add(radioButton9);
            _radioButtons.Add(radioButton10);
        }
    }
}
