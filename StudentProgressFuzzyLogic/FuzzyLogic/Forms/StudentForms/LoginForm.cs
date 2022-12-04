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
    public partial class LoginForm : Form
    {
        public string StudentName { get => _studentName; }
        public string StudentSername { get => _studentSername; }

        private string _studentName;
        private string _studentSername;

        public LoginForm()
        {
            InitializeComponent();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text == string.Empty || sernameTextBox.Text == string.Empty)
            {
                DialogResult = DialogResult.Abort;
                return;
            }

            _studentName = ReworkToNameFormat(nameTextBox.Text);
            _studentSername = ReworkToNameFormat(sernameTextBox.Text);

            DialogResult = DialogResult.OK;
        }

        private string ReworkToNameFormat(string name)
        {
            string output = name.ToLower().Replace(" ", "");
            string firstLetter = output.Substring(0, 1);
            output = firstLetter.ToUpper() + output.Substring(1);

            return output;
        }
    }
}
