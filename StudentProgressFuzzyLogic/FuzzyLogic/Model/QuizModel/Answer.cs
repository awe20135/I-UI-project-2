using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StudentProgressFuzzyLogic.FuzzyLogic.Model.QuizModel
{
    [Serializable]
    public class Answer
    {
        public bool IsCorrect { get => _isCorrect; }
        public string Description { get => _description; }

        string _description;
        bool _isCorrect;

        [JsonConstructor]
        public Answer(string Description, bool IsCorrect = false)
        {
            _description = Description;
            _isCorrect = IsCorrect;
        }

        public override string ToString()
        {
            return _description;
        }
    }
}
