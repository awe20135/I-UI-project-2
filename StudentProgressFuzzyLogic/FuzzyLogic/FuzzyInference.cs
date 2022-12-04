using StudentProgressFuzzyLogic.FuzzyLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StudentProgressFuzzyLogic.FuzzyLogic.Model.LinguisticVariable;

namespace StudentProgressFuzzyLogic.FuzzyLogic
{
    public static class FuzzyInference
    {
        public static Term MamdaniInferenceProcess(float[] crispValues)
        {
            if (crispValues.Length != FuzzyModel.InputLVs.Length)
                throw new Exception("crisp values count not equal to input LVs count");

            List<FuzzificationResult[]> activatedTerms = new List<FuzzificationResult[]>();

            for (int i = 0; i < crispValues.Length; i++)
            {
                activatedTerms.Add(FuzzyModel.InputLVs[i].Fuzzification(crispValues[i]));
            }

            Rule[] activatedRules = Rule.GetActivatedRules(FuzzyModel.RuleBase, activatedTerms);
            Term[] implicatedTerms = Term.ImplicateActivatedRules(activatedRules, activatedTerms);

            return Term.AggregateImplicatedTerms(implicatedTerms);
        }

        public static float MamdaniInferenceDefuzzification(float[] crispValues)
        {
            Term fuzzySet = MamdaniInferenceProcess(crispValues);

            return FuzzyModel.OutputLV.Defuzzification(fuzzySet);
        }
    }
}
