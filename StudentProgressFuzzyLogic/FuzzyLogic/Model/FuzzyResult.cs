using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StudentProgressFuzzyLogic.FuzzyLogic.Model
{
    [Serializable]
    public class FuzzyResult
    {
        private static List<FuzzyResult> initResults = new List<FuzzyResult>();

        public float AnswerCount { get => _answerCount; }
        public float Time { get => _time; }
        public float Highest { get => _highest; }
        public float CrispValue { get { if(_crispValue == float.MinValue) _crispValue = GetCrispValue(); return _crispValue; } }
        public string VerbValue { get { if(_verValue == string.Empty) _verValue = GetVerbValue(); return _verValue; } }

        float _answerCount;
        float _time;
        float _highest;

        float _crispValue = float.MinValue;
        string _verValue = string.Empty;

        [NonSerialized]
        Term fuzzyInferenceSet;

        [JsonConstructor]
        public FuzzyResult(float answerCount, float time, float highest, float CrispValue, string VerbValue)
        {
            _answerCount = answerCount;
            _time = time;
            _highest = highest;
            _crispValue = CrispValue;
            _verValue = VerbValue;

            fuzzyInferenceSet = FuzzyInference.MamdaniInferenceProcess(new float[] { _answerCount, _time, _highest });
            initResults.Add(this);
        }
        
        public FuzzyResult(float answerCount, float time, float highest)
        {
            _answerCount = answerCount;
            _time = time;
            _highest = highest;

            fuzzyInferenceSet = FuzzyInference.MamdaniInferenceProcess(new float[] { _answerCount, _time, _highest });
            initResults.Add(this);
        }

        public FuzzyResult(bool saveResult)
        {
            _answerCount = float.MinValue;
            _time = float.MinValue;
            _highest = float.MinValue;

            if (saveResult)
            {
                initResults.Add(this);
            }
        }

        public void SetCrispValues(float answerCount, float time, float highest)
        {
            _answerCount = answerCount;
            _time = time;
            _highest = highest;

            fuzzyInferenceSet = FuzzyInference.MamdaniInferenceProcess(new float[] { _answerCount, _time, _highest });
        }

        private float GetCrispValue()
        {
            return (float)Math.Round(FuzzyModel.OutputLV.Defuzzification(fuzzyInferenceSet), 2);
        }

        private string GetVerbValue()
        {
            return FuzzyModel.OutputLV.GetWordAnswer(fuzzyInferenceSet);
        }

        public bool IsValid()
        {
            return _answerCount != float.MinValue && _time != float.MinValue && _highest != float.MinValue;
        }

        public void Remove()
        {
            if (!IsValid())
            {
                initResults.Remove(this);
            }
        }

        public static void UpdateFuzzyResults()
        {
            for (int resultIndex = 0; resultIndex < initResults.Count; resultIndex++)
            {
                FuzzyResult currentRsult = initResults[resultIndex];
                if (currentRsult.IsValid())
                {
                    currentRsult.fuzzyInferenceSet = FuzzyInference.MamdaniInferenceProcess(new float[] { currentRsult._answerCount, currentRsult._time, currentRsult._highest });
                    currentRsult._crispValue = currentRsult.GetCrispValue();
                    currentRsult._verValue = currentRsult.GetVerbValue();
                }
            }
        }
    }
}
