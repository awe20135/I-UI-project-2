using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StudentProgressFuzzyLogic.FuzzyLogic.Model
{
    [Serializable]
    public class Term : IComparable
    {
        public string Name { get => _name; }
        public float[] U { get => _u; }
        public int Majority { get => _majority; set => _majority = value; }
        public MemFunc.MEMEBER_FUNCTION_TYPE MFType { get => _MFType; }
        public float[] Args { get => _args; }

        string _name;
        MemFunc.MEMEBER_FUNCTION_TYPE _MFType;
        float[] _args;
        float[] _u;
        int _majority;

        [JsonConstructor]
        public Term(string name, MemFunc.MEMEBER_FUNCTION_TYPE mFType, float[] args, float[] u, int majority) : this(name, mFType, args)
        {
            _u = u;
            _majority = majority;
        }

        public Term(string name, MemFunc.MEMEBER_FUNCTION_TYPE mFType, float[] args)
        {
            this._name = name;
            _MFType = mFType;
            this._args = args;
        }

        private Term() { }

        public void CreateU(float[] X)
        {
            _u = MemFunc.MembershipFunction(X, _args, _MFType);
        }

        public float GiveValueInU(int uIndex)
        {
            return _u[uIndex];
        }

        public Term CutUWithUpperBound(float upperBound)
        {
            float[] newU = new float[_u.Length];

            for (int uIndex = 0; uIndex < _u.Length; uIndex++)
            {
                newU[uIndex] = Math.Min(_u[uIndex], upperBound);
            }

            Term outTerm = new Term();
            outTerm._name = _name;
            outTerm._u = newU;

            return outTerm;
        }

        public int CompareTo(object obj)
        {
            Term compareTerm = obj is Term ? obj as Term : null;
            if (compareTerm == null)
                throw new Exception("Undefined Object to compare");

            return _majority.CompareTo(compareTerm.Majority);
        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            Term term = obj is Term ? obj as Term : null;

            if (term == null)
                return false;

            bool isEquals = true;

            if (_u.Length != term.U.Length)
                return false;

            for (int uIndex = 0; uIndex < _u.Length; uIndex++)
            {
                if (!_u[uIndex].Equals(term.U[uIndex]))
                {
                    isEquals = false;
                    break;
                }
            }

            if (!_name.Equals(term._name))
                return false;

            if (_MFType != term._MFType)
                return false;

            if (_args.Length != term._args.Length)
                return false;

            for (int argIndex = 0; argIndex < _args.Length; argIndex++)
            {
                if (!_args[argIndex].Equals(term._args[argIndex]))
                {
                    isEquals = false;
                    break;
                }
            }

            return isEquals;
        }

        public override int GetHashCode()
        {
            int hashCode = -496545542;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_name);
            hashCode = hashCode * -1521134295 + _MFType.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<float[]>.Default.GetHashCode(_args);
            hashCode = hashCode * -1521134295 + EqualityComparer<float[]>.Default.GetHashCode(_u);
            return hashCode;
        }

        private static void CheckTermsInOverallU(Term a, Term b)
        {
            if (a.U.Length != b.U.Length)
            {
                throw new Exception("Terms have different U functions.");
            }
        }

        /// <summary>
        /// Union two terms
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>New term after Union</returns>
        public static Term operator +(Term a, Term b)
        {
            CheckTermsInOverallU(a, b);

            Term _out = new Term();
            _out._u = new float[a.U.Length];

            for (int UIndex = 0; UIndex < a.U.Length; UIndex++)
            {
                _out._u[UIndex] = Math.Max(a.U[UIndex], b.U[UIndex]);
            }

            return _out;
        }

        /// <summary>
        /// Intersection two terms
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>New term after Intersection</returns>
        public static Term operator *(Term a, Term b)
        {
            CheckTermsInOverallU(a, b);

            Term _out = new Term();
            _out._u = new float[a.U.Length];

            for (int UIndex = 0; UIndex < a.U.Length; UIndex++)
            {
                _out._u[UIndex] = Math.Min(a.U[UIndex], b.U[UIndex]);
            }

            return _out;
        }

        /// <summary>
        /// Negation term
        /// </summary>
        /// <param name="a"></param>
        /// <returns>New term after Negation</returns>
        public static Term operator !(Term a)
        {
            Term _out = new Term();
            _out._u = new float[a.U.Length];

            for (int UIndex = 0; UIndex < a.U.Length; UIndex++)
            {
                _out._u[UIndex] = 1 - a.U[UIndex];
            }

            return _out;
        }

        public static Term[] ImplicateActivatedRules(Rule[] activatedRules, List<LinguisticVariable.FuzzificationResult[]> activatedTerms)
        {
            Dictionary<Term, float> outputTermsWithMin = GetMinFromActivatedRules(activatedRules, activatedTerms);

            List<Term> implicatedTerms = new List<Term>();

            foreach (KeyValuePair<Term, float> outputTerm in outputTermsWithMin)
            {
                implicatedTerms.Add(outputTerm.Key.CutUWithUpperBound(outputTerm.Value));
            }

            return implicatedTerms.ToArray();
        }

        public static Term AggregateImplicatedTerms(Term[] implicatedTerms)
        {
            Term result = new Term();
            result._u = new float[implicatedTerms[0].U.Length];

            foreach (Term term in implicatedTerms)
            {
                result += term;
            }

            result._name = FuzzyModel.OutputLV.Name;

            return result;
        }

        private static Dictionary<Term, float> GetMinFromActivatedRules(Rule[] activatedRules, List<LinguisticVariable.FuzzificationResult[]> activatedTerms)
        {
            Dictionary<Term, float> outputTermsWithMin = new Dictionary<Term, float>();
            for (int ruleIndex = 0; ruleIndex < activatedRules.Length; ruleIndex++)
            {
                Rule currentRule = activatedRules[ruleIndex];
                float min = float.MaxValue;
                for (int ruleTermIndex = 0; ruleTermIndex < currentRule.InputTerms.Length; ruleTermIndex++)
                {
                    Term currentTerm = currentRule.InputTerms[ruleTermIndex];

                    foreach (LinguisticVariable.FuzzificationResult activatedResult in activatedTerms[ruleTermIndex])
                    {
                        if (currentTerm.Equals(activatedResult.term))
                        {
                            min = Math.Min(min, activatedResult.result);
                            break;
                        }
                    }
                }

                if (!outputTermsWithMin.ContainsKey(currentRule.OutputTerm))
                {
                    outputTermsWithMin.Add(currentRule.OutputTerm, min);
                }
                else
                {
                    outputTermsWithMin[currentRule.OutputTerm] = Math.Min(outputTermsWithMin[currentRule.OutputTerm], min);
                }
            }

            return outputTermsWithMin;
        }

        public static Term[] TestImplicateActivatedRules()
        {
            List<LinguisticVariable.FuzzificationResult[]> fuzzificationResults = LinguisticVariable.FuzzificationTest();
            Rule[] activatedRules = Rule.GetActivatedRules(FuzzyModel.RuleBase, fuzzificationResults);

            return ImplicateActivatedRules(activatedRules, fuzzificationResults);
        }

        public static Term TestAggregateImplicatedTerms()
        {
            List<LinguisticVariable.FuzzificationResult[]> fuzzificationResults = LinguisticVariable.FuzzificationTest();
            Rule[] activatedRules = Rule.GetActivatedRules(FuzzyModel.RuleBase, fuzzificationResults);
            Term[] implicatedTerms = ImplicateActivatedRules(activatedRules, fuzzificationResults);

            return AggregateImplicatedTerms(implicatedTerms);
        }
    }
}
