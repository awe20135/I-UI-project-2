using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StudentProgressFuzzyLogic.FuzzyLogic.Model
{
    [Serializable]
    public class LinguisticVariable
    {
        public enum MAGORITY_SORT_TYPE
        {
            Desc,
            Asc,
            Custom
        }

        public struct FuzzificationResult
        {
            public Term term;
            public float result;

            public override string ToString()
            {
                return term + " - " + result;
            }
        }
        
        public string Name { get => _name; }
        public Term[] Terms { get => _terms; }
        public float[] X { get => _X; }
        public float XStart { get => _xStart; }
        public float XEnd { get => _xEnd; }
        public float ChartDX { get => _chartDx; }
        public float Majority { get => _majority; set => _majority = value; }

        string _name;
        Term[] _terms;
        float[] _X;
        float _xStart;
        float _xEnd;
        float _chartDx;
        float _majority = 1;

        public LinguisticVariable(string name, float xStart, float xEnd, float dx, float chartDx, Term[] terms, MAGORITY_SORT_TYPE majoritySortType = MAGORITY_SORT_TYPE.Asc)
        {
            _name = name;
            _terms = terms;
            _xStart = xStart;
            _xEnd = xEnd;
            _chartDx = chartDx;

            AutoSetUpTermsMajority(majoritySortType);
            DevidedXFunction(xStart, xEnd, dx);
            CreateUTermsFunction();
            SortTerm();
        }

        [JsonConstructor]
        public LinguisticVariable(string Name, Term[] Terms, float[] X, float XStart, float XEnd, float ChartDx, float Majority)
        {
            _name = Name;
            _terms = Terms;
            _X = X;
            _xStart = XStart;
            _xEnd = XEnd;
            _chartDx = ChartDx;
            _majority = Majority;
        }

        public bool CointainsTerm(Term term)
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

        public Term GetTermByMajority(int majority)
        {
            foreach (Term term in _terms)
            {
                if (term.Majority == majority)
                    return term;
            }

            return null;
        }

        public Term GetTermByName(string name)
        {
            foreach (Term term in _terms)
            {
                if (term.Name.Equals(name))
                    return term;
            }

            return null;
        }

        public FuzzificationResult[] Fuzzification(float x)
        {
            List<FuzzificationResult> results = new List<FuzzificationResult>();

            int uIndex = FindIndexInX(x);
            SetActivatedTerm(uIndex, results);

            return results.ToArray();
        }

        public float Defuzzification(Term resultSet)
        {
            float xTermSum = 0;
            float termSum = 0;

            if (_X.Length != resultSet.U.Length)
                throw new Exception("The number of items in 'x' does not math with 'mfs'");

            for (int xIndex = 0; xIndex < _X.Length; xIndex++)
            {
                xTermSum += _X[xIndex] * resultSet.U[xIndex];
                termSum += resultSet.U[xIndex];
            }

            float answer = xTermSum / termSum;
            return answer;
        }

        public string GetWordAnswer(Term resultSet)
        {
            KeyValuePair<Term, float> maxTerm = new KeyValuePair<Term, float>(null, float.MinValue);

            for (int lvTermIndex = 0; lvTermIndex < _terms.Length; lvTermIndex++)
            {
                float jacardValue = JacardMeasure(_terms[lvTermIndex].U, resultSet.U);
                if (jacardValue > maxTerm.Value)
                    maxTerm = new KeyValuePair<Term, float>(_terms[lvTermIndex], jacardValue);
            }

            return maxTerm.Key.Name;
        }

        private float JacardMeasure(float[] x_mf, float[] y_mf)
        {
            if (x_mf.Length != y_mf.Length)
                throw new Exception("Length of x_mf not equal to length of y_mf");

            float minSum = 0;
            float maxSum = 0;

            for (int index = 0; index < x_mf.Length; index++)
            {
                minSum += Math.Min(x_mf[index], y_mf[index]);
                maxSum += Math.Max(x_mf[index], y_mf[index]);
            }

            return minSum / maxSum;
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
            foreach (Term term in _terms)
            {
                float termAnswer = term.GiveValueInU(uIndex);
                if (termAnswer != 0)
                {
                    results.Add(new FuzzificationResult() { term = term, result = termAnswer });
                }
            }
        }

        private void CreateUTermsFunction()
        {
            foreach (Term term in _terms)
            {
                term.CreateU(_X);
            }
        }

        public void SortTerm()
        {
            Array.Sort(_terms);
            Array.Reverse(_terms);
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

        private void AutoSetUpTermsMajority(MAGORITY_SORT_TYPE majoritySortType)
        {
            for (int termIndex = 0; termIndex < _terms.Length; termIndex++)
            {
                switch (majoritySortType)
                {
                    case MAGORITY_SORT_TYPE.Desc:
                        _terms[termIndex].Majority = _terms.Length - termIndex;
                        break;

                    case MAGORITY_SORT_TYPE.Asc:
                        _terms[termIndex].Majority = termIndex + 1;
                        break;

                    case MAGORITY_SORT_TYPE.Custom:
                    default:
                        break;
                }
            }
        }

        public override string ToString()
        {
            return _name + " " + "Majority: " + _majority;
        }

        public static List<FuzzificationResult[]> FuzzificationTest()
        {
            float[] crispValues = { 7, 2.8f, 4 };

            if (crispValues.Length != FuzzyModel.InputLVs.Length)
                throw new Exception("crisp values count not equal to input LVs count");

            List<FuzzificationResult[]> activatedTerms = new List<FuzzificationResult[]>();

            for (int i = 0; i < crispValues.Length; i++)
            {
                activatedTerms.Add(FuzzyModel.InputLVs[i].Fuzzification(crispValues[i]));
            }

            return activatedTerms;
        }

        public static float DefuzzificationTest()
        {
            Term testFuzzySet = Term.TestAggregateImplicatedTerms();
            return FuzzyModel.OutputLV.Defuzzification(testFuzzySet);
        }

        public static string GetWordAnswerTest()
        {
            Term testFuzzySet = Term.TestAggregateImplicatedTerms();
            return FuzzyModel.OutputLV.GetWordAnswer(testFuzzySet);
        }
    }
}
