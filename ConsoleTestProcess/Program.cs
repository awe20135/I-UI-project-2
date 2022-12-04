using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStatsFuzzy2Controller;
using GameStatsFuzzy2Controller.Controller;
using GameStatsFuzzy2Controller.FuzzyModel;
using static GameStatsFuzzy2Controller.FuzzyModel.LV2;

namespace ConsoleTestProcess
{
    class Program
    {
        static void Main(string[] args)
        {
            Fuzzy2Model.SetUpModel();

            Console.WriteLine(FuzzifierController.GetMamdaniInference(new float[] { 3.9f, 6.1f, 9.2f, 8.9f }, Fuzzy2Model.InputLVs, Fuzzy2Model.RuleBase));
        }
    }
}
