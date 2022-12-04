using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStatsFuzzy2Controller.FuzzyModel
{
    public class LV2
    {
        private struct TermMajority : IComparable
        {
            public Term2 term;
            public float firstArg;

            public int CompareTo(object obj)
            {
                TermMajority compareableObject = obj is TermMajority ? (TermMajority)obj : throw new Exception("Invalid Type to compare");
                return firstArg.CompareTo(compareableObject.firstArg);
            }
        }

        public struct FuzzificationResult
        {
            public LV2 lv;
            public Term2 term;
            public float resultUMF;
            public float resultLMF;
        }

        public float[] X { get => _X; }
        public float XStart { get => _xStart; }
        public float XEnd { get => _xEnd; }
        public string Name { get => _name; }
        public string Question { get => _question; }
        public Term2[] Terms { get => _terms; }
        public float Dx { get => _dx; }

        private string _name;
        private string _question;
        private Term2[] _terms;
        private float[] _X;
        private float _xStart;
        private float _xEnd;
        private float _dx;

        public float arg;

        public LV2(string name, string question, Term2[] terms, float xStart = 0, float xEnd = 10, float dx = .01f)
        {
            _name = name;
            _question = question;
            _terms = terms;
            _X = X;
            _xStart = xStart;
            _xEnd = xEnd;
            _dx = dx;

            DevidedXFunction(_xStart, _xEnd, _dx);

            List<TermMajority> majorityRates = new List<TermMajority>();

            foreach (Term2 term in _terms)
            {
                arg = term.UpperBoundTerm.Args[0];
                majorityRates.Add(new TermMajority{ firstArg = arg, term = term });

                term.CreateU(_X);
            }

            majorityRates.Sort();

            for (int i = 0; i < majorityRates.Count; i++)
            {
                majorityRates[i].term.Majority = i + 1;
            }
        }

        public LV2(Term2[] terms)
        {
            _terms = terms;
        }

        public Term2 GetTermByMajority(int majority)
        {
            foreach (Term2 term in _terms)
            {
                if (term.Majority == majority)
                    return term;
            }

            return null;
        }

        private void DevidedXFunction(float xStart, float xEnd, float dx)
        {
            float actualLength = (xEnd - xStart) / dx;
            int arraySize = (int)(actualLength + 1);
            _X = new float[arraySize];

            int xArrayIndex = 0;
            for (float xIndex = xStart; xIndex < xEnd; xIndex = ConvertTo2PointFloat(xIndex + dx))
            {
                _X[xArrayIndex] = xIndex;
                xArrayIndex++;
            }

            _X[xArrayIndex] = xEnd;
        }

        private float ConvertTo2PointFloat(float f)
        {
            return float.Parse(f.ToString("0.00"));
        }

        public override string ToString()
        {
            return _name;
        }

        public bool CointainsTerm(Term2 term)
        {
            bool isContain = false;

            for (int termIndex = 0; termIndex < _terms.Length; termIndex++)
            {
                if (_terms[termIndex].Equals(term))
                {
                    isContain = true;
                    break;
                }
            }

            return isContain;
        }

        public FuzzificationResult[] Fuzzification(float x)
        {
            List<FuzzificationResult> results = new List<FuzzificationResult>();

            int uIndex = FindIndexInX(x);
            SetActivatedTerm(uIndex, results);

            return results.ToArray();
        }

        private int FindIndexInX(float x)
        {
            int uIndex = int.MinValue;
            for (int xIndex = 0; xIndex < _X.Length; xIndex++)
            {
                if (_X[xIndex] <= x)
                {
                    uIndex = xIndex;
                }
                else
                {
                    break;
                }
            }
            return uIndex;
        }

        private void SetActivatedTerm(int uIndex, List<FuzzificationResult> results)
        {
            foreach (Term2 term in _terms)
            {
                float termAnswer = term.UpperBoundTerm.GiveValueInU(uIndex);
                if (termAnswer > 0)
                {
                    results.Add(new FuzzificationResult() { term = term, resultUMF = termAnswer, resultLMF = term.LowerBoundTerm.GiveValueInU(uIndex), lv = this });
                }
            }
        }

        public string GetWordAnswer(Term2 resultSet)
        {
            KeyValuePair<Term2, float> maxTerm = new KeyValuePair<Term2, float>(null, float.MinValue);

            for (int lvTermIndex = 0; lvTermIndex < _terms.Length; lvTermIndex++)
            {
                float jacardValue = JacardMeasure(_terms[lvTermIndex], resultSet);
                if (jacardValue > maxTerm.Value)
                    maxTerm = new KeyValuePair<Term2, float>(_terms[lvTermIndex], jacardValue);
            }

            return maxTerm.Key.Name;
        }

        private static float JacardMeasure(Term2 xTerm, Term2 yTerm)
        {
            Dictionary<string, float> jacardUMF = GetMinMax(xTerm.UpperBoundTerm.U, yTerm.UpperBoundTerm.U);
            Dictionary<string, float> jacardLMF = GetMinMax(xTerm.LowerBoundTerm.U, yTerm.LowerBoundTerm.U);

            return (jacardUMF["sumMin"] + jacardLMF["sumMin"]) / (jacardUMF["sumMax"] + jacardLMF["sumMax"]);
        }

        /// <summary>
        /// Get jacard min-max from two arrays
        /// </summary>
        /// <param name="xU"></param>
        /// <param name="yU"></param>
        /// <returns>Float Array { min, max }</returns>
        private static Dictionary<string, float> GetMinMax(float[] xU, float[] yU)
        {
            Dictionary<string, float> result = new Dictionary<string, float>();
            result.Add("sumMin", 0);
            result.Add("sumMax", 0);

            for (int index = 0; index < xU.Length; index++)
            {
                result["sumMin"] += Math.Min(xU[index], yU[index]);
                result["sumMax"] += Math.Max(xU[index], yU[index]);
            }

            return result;
        }
    }
}
