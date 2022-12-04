using StudentProgressFuzzyLogic.FuzzyLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StudentProgressFuzzyLogic.FuzzyLogic.MemFunc;

namespace GameStatsFuzzy2Controller.FuzzyModel
{
    public class Term2
    {
        public struct TermCreationInfoStruct
        {
            public MEMEBER_FUNCTION_TYPE TYPE;
            public float[] Args;
            public float Height;

            public TermCreationInfoStruct(float[] args)
            {
                Args = args;
                Height = 1;
                TYPE = MEMEBER_FUNCTION_TYPE.TRAPMF;
            }
            
            public TermCreationInfoStruct(float[] args, float height)
            {
                Args = args;
                Height = height;
                TYPE = MEMEBER_FUNCTION_TYPE.TRAPMF;
            }

            public TermCreationInfoStruct(MEMEBER_FUNCTION_TYPE tYPE, float[] args)
            {
                TYPE = tYPE;
                Args = args;
                Height = 1;
            }

            public TermCreationInfoStruct(MEMEBER_FUNCTION_TYPE tYPE, float[] args, float height)
            {
                TYPE = tYPE;
                Args = args;
                Height = height;
            }
        }

        public struct Term2MFStruct
        {
            public float LMF;
            public float UMF;
        }

        public string Name { get => _name; }
        public Term UpperBoundTerm { get => _upperBoundTerm; }
        public Term LowerBoundTerm { get => _lowerBoundTerm; }
        public int Majority { get => _majority; set => _majority = value; }

        private string _name;
        private Term _upperBoundTerm;
        private Term _lowerBoundTerm;
        private float _lmfHeight;
        private int _majority;


        public Term2(string name, TermCreationInfoStruct upperBound, TermCreationInfoStruct lowerBound)
        {
            _name = name;

            _upperBoundTerm = new Term(name + "_umf", upperBound.TYPE, upperBound.Args);
            _lowerBoundTerm = new Term(name + "_lmf", lowerBound.TYPE, lowerBound.Args);

            _lmfHeight = lowerBound.Height;
        }

        private Term2() { }

        public void CreateU(float[] X)
        {
            _upperBoundTerm.CreateU(X);
            _lowerBoundTerm.CreateU(X);

            if (_lmfHeight != 1) {
                for (int uIndex = 0; uIndex < _lowerBoundTerm.U.Length; uIndex++)
                {
                    _lowerBoundTerm.U[uIndex] *= _lmfHeight;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(_name);

            sb.Append("[ ");

            for (int i = 0; i < _lowerBoundTerm.U.Length; i++)
            {
                if (_upperBoundTerm.U[i] != 0)
                    sb.Append($"({_upperBoundTerm.U[i]}, {_lowerBoundTerm.U[i]}), ");
            }

            sb.Append("] ");

            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            Term2 term = obj is Term2 ? obj as Term2 : null;

            if (term == null)
                return false;

            bool isEquals = term._upperBoundTerm.Equals(_upperBoundTerm) && term._lowerBoundTerm.Equals(_lowerBoundTerm);

            return isEquals;
        }

        public override int GetHashCode()
        {
            int hashCode = 1885838507;
            hashCode = hashCode * -1521134295 + EqualityComparer<Term>.Default.GetHashCode(_upperBoundTerm);
            hashCode = hashCode * -1521134295 + EqualityComparer<Term>.Default.GetHashCode(_lowerBoundTerm);
            return hashCode;
        }

        public static Term2[] ImplicateActivatedRules(Rule2[] activatedRules, List<LV2.FuzzificationResult[]> activatedTerms)
        {
            Dictionary<Term2, Term2MFStruct> outputTermsWithMin = GetMinFromActivatedRules(activatedRules, activatedTerms);

            List<Term2> implicatedTerms = new List<Term2>();

            foreach (KeyValuePair<Term2, Term2MFStruct> outputTerm in outputTermsWithMin)
            {
                implicatedTerms.Add(outputTerm.Key.CutUWithUpperBound(outputTerm.Value));
            }

            return implicatedTerms.ToArray();
        }

        private static Dictionary<Term2, Term2MFStruct> GetMinFromActivatedRules(Rule2[] activatedRules, List<LV2.FuzzificationResult[]> activatedTerms)
        {
            Dictionary<Term2, Term2MFStruct> outputTermsWithMin = new Dictionary<Term2, Term2MFStruct>();

            for (int ruleIndex = 0; ruleIndex < activatedRules.Length; ruleIndex++)
            {
                Rule2 currentRule = activatedRules[ruleIndex];
                float minUMF = float.MaxValue;
                float minLMF = float.MaxValue;
                for (int ruleTermIndex = 0; ruleTermIndex < currentRule.InputTerms.Length; ruleTermIndex++)
                {
                    Term2 currentTerm = currentRule.InputTerms[ruleTermIndex];

                    foreach (LV2.FuzzificationResult activatedResult in activatedTerms[ruleTermIndex])
                    {
                        if (currentTerm.Equals(activatedResult.term))
                        {
                            minUMF = Math.Min(minUMF, activatedResult.resultUMF);
                            minLMF = Math.Min(minUMF, activatedResult.resultLMF);
                            break;
                        }
                    }
                }

                if (!outputTermsWithMin.ContainsKey(currentRule.OutputTerm))
                {
                    outputTermsWithMin.Add(currentRule.OutputTerm, new Term2MFStruct { UMF = minUMF, LMF = minLMF });
                }
                else
                {
                    outputTermsWithMin[currentRule.OutputTerm] = new Term2MFStruct
                    {
                        UMF = Math.Min(outputTermsWithMin[currentRule.OutputTerm].UMF, minUMF),
                        LMF = Math.Min(outputTermsWithMin[currentRule.OutputTerm].LMF, minLMF)
                    };
                }
            }

            return outputTermsWithMin;
        }

        private Term2 CutUWithUpperBound(Term2MFStruct bounds)
        {
            Term2 outTerm = new Term2();

            outTerm._name = _name;
            outTerm._lmfHeight = _lmfHeight;
            outTerm._lowerBoundTerm = _lowerBoundTerm.CutUWithUpperBound(bounds.LMF);
            outTerm._upperBoundTerm = _upperBoundTerm.CutUWithUpperBound(bounds.UMF);

            return outTerm;
        }

        public static Term2 AggregateImplicatedTerms(Term2[] implicatedTerms)
        {
            Term2 result = new Term2();

            result._lowerBoundTerm = implicatedTerms[0].LowerBoundTerm;
            result._upperBoundTerm = implicatedTerms[0].UpperBoundTerm;

            foreach (Term2 term in implicatedTerms)
            {
                result += term;
            }

            result._name = Fuzzy2Model.OutputLV.Name;

            return result;
        }

        /// <summary>
        /// Union two terms
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>New term after Union</returns>
        public static Term2 operator +(Term2 a, Term2 b)
        {
            Term2 _out = new Term2();

            _out._lowerBoundTerm = a.LowerBoundTerm + b.LowerBoundTerm;
            _out._upperBoundTerm = a.UpperBoundTerm + b.UpperBoundTerm;

            return _out;
        }
    }
}
