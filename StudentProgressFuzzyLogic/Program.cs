using StudentProgressFuzzyLogic.FuzzyLogic.Controller;
using StudentProgressFuzzyLogic.FuzzyLogic.Forms;
using StudentProgressFuzzyLogic.FuzzyLogic.Model;
using StudentProgressFuzzyLogic.FuzzyLogic.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentProgressFuzzyLogic
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            OpenMainForm();

            //string test = Rule.TestGeneratedRuleBase();

            //LinguisticVariable.FuzzificationResult[]  test = LinguisticVariable.FuzzificationTest();

            //Rule[] test = Rule.TestGetActivatedRules();

            //Term[] test = Term.TestImplicateActivatedRules();

            //Term test = Term.TestAggregateImplicatedTerms();

            //float testCrisp = LinguisticVariable.DefuzzificationTest();

            //string testWord = LinguisticVariable.GetWordAnswerTest();

            /*StudentResult[] studentResults = DataController.GetStudentResults();
            string saveResult = DataController.SetStudentResult(new StudentResult("dmytro", "xxx", 0, 0, 0));
            studentResults = DataController.GetStudentResults();*/
        }

        private static void OpenTestForms()
        {
            new LVTestForm().Show();
            Application.Run(new MamdaniInferenceTestForm());
        }

        private static void OpenMainForm()
        {
            Application.Run(new MainForm());
            //Application.Run(new QuizForm());
        }
    }
}
