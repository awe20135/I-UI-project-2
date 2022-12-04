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
    public partial class TweakLVMajorityForm : Form
    {
        private LinguisticVariable _lv;

        public TweakLVMajorityForm(LinguisticVariable lv)
        {
            InitializeComponent();

            _lv = lv;

            lvNameLabel.Text = _lv.Name;
            majorityTextBox.Text = _lv.Majority.ToString();

            FillTermRichTextBox();
        }

        private void FillTermRichTextBox()
        {
            for (int termIndex = 0; termIndex < _lv.Terms.Length; termIndex++)
            {
                termsRichTextBox.Text += _lv.Terms[termIndex].Name + "\n";
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void WarningMessage(string message)
        {
            MessageBox.Show(message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        
        private void WarningMessageWithRessetTermTextBox(string message)
        {
            DialogResult dialogResult = MessageBox.Show(message, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                termsRichTextBox.Text = "";
                FillTermRichTextBox();
            }
        }

        private void setButton_Click(object sender, EventArgs e)
        {
            float newMajority = GetNewLVMajority();
            if (newMajority == float.MinValue) { return; }

            Dictionary<Term, int> termsMajority = GetNewTermsMajorities();
            if (termsMajority == null) { return; }

            _lv.Majority = newMajority;

            foreach (KeyValuePair<Term, int> pair in termsMajority)
            {
                pair.Key.Majority = pair.Value;
            }

            _lv.SortTerm();

            DialogResult = DialogResult.OK;
        }

        private float GetNewLVMajority()
        {
            float newMajority;

            if (!float.TryParse(majorityTextBox.Text, out newMajority))
            {
                WarningMessage("Incorrect majority. Please type correct float number. Hint: if you type `.` change it to `,`");
                return float.MinValue;
            }

            if (newMajority < 0 || newMajority > 1)
            {
                WarningMessage("Incorrect majority. Majority must be in range [0; 1]");
                return float.MinValue;
            }

            return newMajority;
        }

        private Dictionary<Term, int> GetNewTermsMajorities()
        {
            Dictionary<Term, int> termsMajoritys = new Dictionary<Term, int>();
            List<Term> updatedTerms = new List<Term>();

            List<string> richTextBoxContent = termsRichTextBox.Text.Split('\n').ToList();
            richTextBoxContent.RemoveAll((x) => x == "");
            string[] sortedTermNamesByNewMajority = richTextBoxContent.ToArray();

            if (sortedTermNamesByNewMajority.Length != _lv.Terms.Length)
            {
                MessageBox.Show("Incorrect term sorted. Please type correct term name and count of term in rich text box.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            for (int sotedTermIndex = 0; sotedTermIndex < sortedTermNamesByNewMajority.Length; sotedTermIndex++)
            {
                Term updatedTerm = _lv.GetTermByName(sortedTermNamesByNewMajority[sotedTermIndex]);
                if (updatedTerm == null)
                {

                    WarningMessageWithRessetTermTextBox($"Term `{sortedTermNamesByNewMajority[sotedTermIndex]}` not found. Reset term majority?");
                    return null;
                }

                if (updatedTerms.Contains(updatedTerm))
                {
                    WarningMessageWithRessetTermTextBox($"Term `{sortedTermNamesByNewMajority[sotedTermIndex]}` duplicate. Reset term majority?");
                    return null;
                }

                termsMajoritys.Add(updatedTerm, sortedTermNamesByNewMajority.Length - sotedTermIndex);
                updatedTerms.Add(updatedTerm);
            }

            return termsMajoritys;
        }
    }
}
