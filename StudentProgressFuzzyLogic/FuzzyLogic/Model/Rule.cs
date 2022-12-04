using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StudentProgressFuzzyLogic.FuzzyLogic.Model
{
    [Serializable]
    public class Rule
    {
        public Term[] InputTerms { get => _inputTerms; }
        public Term OutputTerm { get => _outputTerm; }

        Term[] _inputTerms;
        Term _outputTerm;

        private Rule(Term[] inputTerms)
        {
            _inputTerms = inputTerms;
        }

        [JsonConstructor]
        public Rule(Term[] inputTerms, Term outputTerm)
        {
            _inputTerms = inputTerms;
            _outputTerm = outputTerm;
        }

        public static Rule[] GenerateRuleBase(LinguisticVariable[] inputLVs, LinguisticVariable outputLV)
        {
            List<Rule> generatedRules = new List<Rule>();

            SetUpInputTerms(inputLVs, generatedRules);
            SetUpOutputTerm(generatedRules, inputLVs, outputLV);

            return generatedRules.ToArray();
        }

        public static Rule[] GetActivatedRules(Rule[] ruleBase, List<LinguisticVariable.FuzzificationResult[]> activatedTerms)
        {
            List<Rule> activatedTermRules = new List<Rule>();
            ShuffleActivatedTerm(activatedTerms, activatedTermRules);

            return GetEqualsRules(activatedTermRules.ToArray(), ruleBase).ToArray();
        }

        private static Rule[] GetEqualsRules(Rule[] a, Rule[] b)
        {
            List<Rule> rules = new List<Rule>();

            foreach (Rule rule in a)
            {
                foreach (Rule rule1 in b)
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

        private static void SetUpInputTerms(LinguisticVariable[] inputLVs, List<Rule> generatedRules, int currentLVIndex = 0, List<Term> currentTermRule = null)
        {
            if (currentTermRule == null)
                currentTermRule = new List<Term>();

            Term[] currentLVTerms = inputLVs[currentLVIndex].Terms;
            currentLVIndex++;
            for (int i = 0; i < currentLVTerms.Length; i++)
            {
                if (currentLVIndex < inputLVs.Length)
                {
                    currentTermRule.Add(currentLVTerms[i]);
                    SetUpInputTerms(inputLVs, generatedRules, currentLVIndex, currentTermRule);
                    currentTermRule.Remove(currentLVTerms[i]);
                }
                else
                {
                    currentTermRule.Add(currentLVTerms[i]);
                    generatedRules.Add(new Rule(currentTermRule.ToArray()));
                    currentTermRule.Remove(currentLVTerms[i]);
                }
            }
        }

        private static void ShuffleActivatedTerm(List<LinguisticVariable.FuzzificationResult[]> activatedTerms, List<Rule> generatedRules, int currentLVIndex = 0, List<Term> currentTermRule = null)
        {
            if (currentTermRule == null)
                currentTermRule = new List<Term>();

            LinguisticVariable.FuzzificationResult[] currentResult = activatedTerms[currentLVIndex];
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
                    generatedRules.Add(new Rule(currentTermRule.ToArray()));
                    currentTermRule.Remove(currentResult[i].term);
                }
            }
        }   
        
        private static void SetUpOutputTerm(List<Rule> generatedRules, LinguisticVariable[] inputLVs, LinguisticVariable outputLV)
        {
            float koefSum = 0;

            foreach (LinguisticVariable inputLV in inputLVs)
            {
                koefSum += inputLV.Majority;
            }

            foreach (Rule rule in generatedRules)
            {
                float answer = 0;
                foreach (Term ruleTerm in rule._inputTerms)
                {
                    foreach (LinguisticVariable inputLV in inputLVs)
                    {
                        if (inputLV.CointainsTerm(ruleTerm))
                        {
                            float koef = 1f / koefSum * inputLV.Majority;
                            answer += (float)ruleTerm.Majority / (float)inputLV.Terms.Length * koef;
                            break;
                        }
                    }
                }

                answer *= outputLV.Terms.Length;
                int finalAnswer = (int)Math.Round(answer, 0);
                finalAnswer = finalAnswer > outputLV.Terms.Length ? outputLV.Terms.Length : finalAnswer;
                rule._outputTerm = outputLV.GetTermByMajority(finalAnswer);
            }
        }

        public override string ToString()
        {
            string _out = "";

            foreach (Term term in _inputTerms)
            {
                _out += term + " | ";
            }

            _out += "= " + _outputTerm;

            return _out ;
        }

        public static string TestGeneratedRuleBase()
        {
            Rule[] rules = Rule.GenerateRuleBase(FuzzyModel.InputLVs, FuzzyModel.OutputLV);
            string @out = "";

            foreach (Rule rule in rules)
            {
                @out += rule + "\n";
            }

            return @out;
        }

        public static Rule[] TestGetActivatedRules()
        {
            List<LinguisticVariable.FuzzificationResult[]> fuzzificationResults = LinguisticVariable.FuzzificationTest();
            return GetActivatedRules(FuzzyModel.RuleBase, fuzzificationResults);
        }

        public override bool Equals(object obj)
        {
            bool @out = obj is Rule rule;
            if (!@out)
                return false;

            rule = obj as Rule;

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
            return -457553095 + EqualityComparer<Term[]>.Default.GetHashCode(_inputTerms);
        }
    }
}
