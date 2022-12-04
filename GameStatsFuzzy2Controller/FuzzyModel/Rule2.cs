using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStatsFuzzy2Controller.FuzzyModel
{
    public class Rule2
    {
        public Term2[] InputTerms { get => _inputTerms; }
        public Term2 OutputTerm { get => _outputTerm; }

        Term2[] _inputTerms;
        Term2 _outputTerm;

        public Rule2(Term2[] inputTerms)
        {
            _inputTerms = inputTerms;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Term2 term in _inputTerms)
            {
                sb.Append(term.Name + " + ");
            }

            sb.Remove(sb.Length - 4, 3);

            if (_outputTerm != null)
                sb.Append(" = " + _outputTerm.Name);

            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            bool @out = obj is Rule2 rule;
            if (!@out)
                return false;

            rule = obj as Rule2;

            if (_inputTerms.Length != rule._inputTerms.Length)
                return false;

            for (int i = 0; i < _inputTerms.Length; i++)
            {
                @out = _inputTerms[i].Equals(rule.InputTerms[i]);

                if (!@out)
                    break;
            }

            return @out;
        }

        public override int GetHashCode()
        {
            return -457553095 + EqualityComparer<Term2[]>.Default.GetHashCode(_inputTerms);
        }

        public static Rule2[] GenerateRuleBase(LV2[] inputLVs, LV2 outputLV)
        {
            List<Rule2> generatedRules = new List<Rule2>();

            GenerateInputTerms(inputLVs, generatedRules);
            SetUpOutputTerm(generatedRules, inputLVs, outputLV);

            /*StringBuilder sb = new StringBuilder();

            foreach (Rule2 rule in generatedRules)
            {
                sb.Append(rule);
                sb.AppendLine();
            }*/

            return generatedRules.ToArray();
        }

        private static void GenerateInputTerms(LV2[] inputLVs, List<Rule2> generatedRules, int currentLVIndex = 0, List<Term2> currentTermRule = null)
        {
            if (currentTermRule == null)
                currentTermRule = new List<Term2>();

            Term2[] currentLVTerms = inputLVs[currentLVIndex].Terms;
            currentLVIndex++;
            for (int i = 0; i < currentLVTerms.Length; i++)
            {
                if (currentLVIndex < inputLVs.Length)
                {
                    currentTermRule.Add(currentLVTerms[i]);
                    GenerateInputTerms(inputLVs, generatedRules, currentLVIndex, currentTermRule);
                    currentTermRule.Remove(currentLVTerms[i]);
                }
                else
                {
                    currentTermRule.Add(currentLVTerms[i]);
                    generatedRules.Add(new Rule2(currentTermRule.ToArray()));
                    currentTermRule.Remove(currentLVTerms[i]);
                }
            }
        }

        public static void SetUpOutputTerm(List<Rule2> generatedRules, LV2[] inputLVs, LV2 outputLV)
        {

            foreach (Rule2 rule in generatedRules)
            {
                float answer = 0;
                foreach (Term2 ruleTerm in rule._inputTerms)
                {
                    foreach (LV2 inputLV in inputLVs)
                    {
                        if (inputLV.CointainsTerm(ruleTerm))
                        {
                            answer += (float)ruleTerm.Majority / (float)inputLV.Terms.Length;
                            break;
                        }
                    }
                }
                answer /= rule.InputTerms.Length;
                answer *= outputLV.Terms.Length;
                int finalAnswer = (int)Math.Round(answer, 0);
                finalAnswer = finalAnswer > outputLV.Terms.Length ? outputLV.Terms.Length : finalAnswer;
                rule._outputTerm = outputLV.GetTermByMajority(finalAnswer);
            }
        }

        public static Rule2[] GetActivatedRules(Rule2[] ruleBase, List<LV2.FuzzificationResult[]> activatedTerms)
        {
            List<Rule2> activatedTermRules = new List<Rule2>();

            ShuffleActivatedTerm(activatedTerms, activatedTermRules);

            return GetEqualsRules(activatedTermRules.ToArray(), ruleBase).ToArray();
        }

        private static void ShuffleActivatedTerm(List<LV2.FuzzificationResult[]> activatedTerms, List<Rule2> generatedRules, int currentLVIndex = 0, List<Term2> currentTermRule = null)
        {
            if (currentTermRule == null)
                currentTermRule = new List<Term2>();

            LV2.FuzzificationResult[] currentResult = activatedTerms[currentLVIndex];
            currentLVIndex++;
            for (int i = 0; i < currentResult.Length; i++)
            {
                if (currentLVIndex < activatedTerms.Count)
                {
                    currentTermRule.Add(currentResult[i].term);
                    ShuffleActivatedTerm(activatedTerms, generatedRules, currentLVIndex, currentTermRule);
                    currentTermRule.Remove(currentResult[i].term);
                }
                else
                {
                    currentTermRule.Add(currentResult[i].term);
                    generatedRules.Add(new Rule2(currentTermRule.ToArray()));
                    currentTermRule.Remove(currentResult[i].term);
                }
            }
        }

        private static Rule2[] GetEqualsRules(Rule2[] a, Rule2[] b)
        {
            List<Rule2> rules = new List<Rule2>();

            foreach (Rule2 rule in a)
            {
                foreach (Rule2 rule1 in b)
                {
                    if (rule.Equals(rule1))
                    {
                        rules.Add(rule1);
                        break;
                    }
                }
            }

            return rules.ToArray();
        }

       
    }
}
