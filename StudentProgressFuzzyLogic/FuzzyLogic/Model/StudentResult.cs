using StudentProgressFuzzyLogic.FuzzyLogic.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StudentProgressFuzzyLogic.FuzzyLogic.Model
{
    [Serializable]
    public class StudentResult : FuzzyResult
    {
        public static StudentResult[] StudentResults { get => _studentResults; }
        private static StudentResult[] _studentResults = DataController.GetStudentResults();

        public string Name { get => _name; }
        public string Sername { get => _sername; }

        string _name;
        string _sername;

        [JsonConstructor]
        public StudentResult(string name, string sername, float answerCount, float time, float highest, float CrispValue, string VerbValue) : base(answerCount, time, highest, CrispValue, VerbValue)
        {
            _name = name;
            _sername = sername;
        }
        
        public StudentResult(string name, string sername, float answerCount, float time, float highest) : base(answerCount, time, highest)
        {
            _name = name;
            _sername = sername;
        }

        public StudentResult(string name, string sername, bool saveResult = true) : base(saveResult)
        {
            _name = name;
            _sername = sername;
        }

        public override string ToString()
        {
            return $"{_name} {_sername} --> {CrispValue} - {VerbValue}";
        }

        public override bool Equals(object obj)
        {
            return obj is StudentResult result &&
                   _name.ToLower().Equals( result._name.ToLower()) &&
                   _sername.ToLower().Equals(result._sername.ToLower());
        }

        public override int GetHashCode()
        {
            int hashCode = -1650412468;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_sername);
            return hashCode;
        }

        public static void GetResults()
        {
            _studentResults = DataController.GetStudentResults();
        }
    }
}
