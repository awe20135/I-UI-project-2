using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStatsFuzzy2Controller.FuzzyModel;
using StudentProgressFuzzyLogic.FuzzyLogic.Model;
using static GameStatsFuzzy2Controller.FuzzyModel.LV2;

namespace GameStatsFuzzy2Controller.Controller
{
    public static class FuzzifierController
    {
        public struct MamdaniInderenceResultStruct
        {
            public string wordResult;
            public float crispResult;
        }

        public static MamdaniInderenceResultStruct GetMamdaniInference(float[] crispValue, LV2[] inputLVs, LV2 outputLV, Rule2[] rulebase)
        {
            List<FuzzificationResult[]> activatedTerms = Fuzzification(crispValue, inputLVs);
            Rule2[] activatedRules = ActivatedRules(rulebase, activatedTerms);
            Term2[] implicatedTerms = ImplicateActivatedRules(activatedRules, activatedTerms);
            Term2 aggregatedTerm = AggregateImplicatedTerms(implicatedTerms);

            float crispResult = Defuzzification(outputLV, aggregatedTerm);
            string wordResult = GetWordResult(aggregatedTerm);

            return new MamdaniInderenceResultStruct { wordResult = wordResult, crispResult = (float)Math.Round(crispResult, 2) };
        }

        private static List<FuzzificationResult[]> Fuzzification(float[] crispValues, LV2[] inputLVs)
        {
            List<FuzzificationResult[]> result = new List<FuzzificationResult[]>();

            for (int i = 0; i < crispValues.Length; i++)
            {
                result.Add(inputLVs[i].Fuzzification(crispValues[i]));
            }

            return result;
        }

        private static Rule2[] ActivatedRules(Rule2[] ruleBase, List<LV2.FuzzificationResult[]> activatedTerms)
        {
            return Rule2.GetActivatedRules(ruleBase, activatedTerms);
        }

        private static Term2[] ImplicateActivatedRules(Rule2[] activatedRules, List<LV2.FuzzificationResult[]> activatedTerms)
        {
            return Term2.ImplicateActivatedRules(activatedRules, activatedTerms);
        }

        private static Term2 AggregateImplicatedTerms(Term2[] implicatedTerms)
        {
            return Term2.AggregateImplicatedTerms(implicatedTerms);
        }

        private static string GetWordResult(Term2 aggregatedTerm)
        {
            return Fuzzy2Model.OutputLV.GetWordAnswer(aggregatedTerm);
        }

        private static float Defuzzification(LV2 outputLV, Term2 aggregatedTerm)
        {
            float[] EKMResult = EKM(outputLV, aggregatedTerm);

            float multipleSum = 0;
            float sum = 0;

            for (int i = 0; i < outputLV.X.Length; i++)
            {
                sum += EKMResult[i];
                multipleSum += outputLV.X[i] * EKMResult[i];
            }

            return multipleSum / sum;

        }

        #region EKM

        private static float[] EKM(LV2 outputLV, Term2 aggregatedTerm, int periods = 100)
        {
            if (aggregatedTerm.LowerBoundTerm.U.Max() == 0)
                return aggregatedTerm.UpperBoundTerm.U;

            int L = GetPoint(outputLV.X, aggregatedTerm.UpperBoundTerm.U, aggregatedTerm.LowerBoundTerm.U, aggregatedTerm, 2.4, 1, periods);
            int R = GetPoint(outputLV.X,  aggregatedTerm.LowerBoundTerm.U, aggregatedTerm.UpperBoundTerm.U, aggregatedTerm, 1.7, -1, periods);

            return LRPointsInterpritator(aggregatedTerm, L, R);
        }

        private static float ArraySum(float[] array1, float[] array2, int end, int start = 0, char @operator = '*')
        {
            float sum = 0;

            for (int i = start; i < end; i++)
            {
                if(@operator == '*')
                    sum += array1[i] * array2[i];
                else if (@operator == '-')
                    sum += array1[i] - array2[i];
            }

            return sum;
        }

        private static float ArraySum(float[] array1, float[] array2, float[] array3, int end, int start = 0)
        {
            float sum = 0;

            for (int i = start; i < end; i++)
            {
                sum += array1[i] * (array2[i] - array3[i]);
            }

            return sum;
        }

        private static float ArraySum(float[] array1, int end, int start = 0)
        {
            float sum = 0;

            for (int i = start; i < end; i++)
            {
                sum += array1[i];
            }

            return sum;
        }

        private static int SearchSwitchPoint(float[] X, float y)
        {
            int index = -1;
            float max = float.MinValue;

            for (int i = 0; i < X.Length; i++)
            {
                if(X[i] >= y && X[i] > max)
                {
                    index = i;
                    max = X[index];
                }
            }

            return index != -1 ? index : throw new Exception("Switch point not found");
        }

        private static int GetPoint(  float[] X,  float[] firstArray, float[] lastArray, Term2 aggregatedTerm, double midleConst, int a_1Multipler, int periods)
        {
            float a = 0;
            float b = 0;
            int k = (int)Math.Round(X.Length / midleConst);

            a += ArraySum(X, firstArray, end: k);
            b += ArraySum(firstArray, end: k);
            a += ArraySum(X, lastArray, start: k, end: X.Length);
            b += ArraySum(lastArray, start: k, end: X.Length);

            float y = b != 0 ? a / b : 0;

            int k_1 = 0;
            int iteration = 0;

            while (iteration <= periods)
            {
                k_1 = SearchSwitchPoint(X, y);

                if (k == k_1)
                    break;

                int s = k_1 - k > 0 ? 1 : -1;

                float a_1 = a_1Multipler * ArraySum(X, aggregatedTerm.UpperBoundTerm.U, aggregatedTerm.LowerBoundTerm.U, start: Math.Min(k, k_1), end: Math.Max(k, k_1));
                float b_1 = a_1Multipler * ArraySum(aggregatedTerm.UpperBoundTerm.U, aggregatedTerm.LowerBoundTerm.U, @operator: '-', start: Math.Min(k, k_1), end: Math.Max(k, k_1));

                a_1 = a + s * a_1;
                b_1 = b + s * b_1;

                float y_1 = b_1 != 0 ? a_1 / b_1 : 0;

                a = a_1;
                b = b_1;
                k = k_1;
                y = y_1;

                ++iteration;
            }

           return iteration == periods ? (int)Math.Round((k + k_1) / 2d) : k;
        }

        private static float[] LRPointsInterpritator(Term2 aggregatedTerm, int L, int R)
        {
            if(L > R)
            {
                int buffer = R;
                R = L;
                L = buffer;
            }

            float[] @out = new float[aggregatedTerm.LowerBoundTerm.U.Length];

            for (int i = 0; i < L; i++) { @out[i] = aggregatedTerm.UpperBoundTerm.U[i]; }
            for (int i = L; i < R; i++) { @out[i] = aggregatedTerm.LowerBoundTerm.U[i]; }
            for (int i = R; i < @out.Length; i++) { @out[i] = aggregatedTerm.UpperBoundTerm.U[i]; }

            return @out;
        }
        #endregion
    }
}
