using StudentProgressFuzzyLogic.FuzzyLogic.Controller;

namespace StudentProgressFuzzyLogic.FuzzyLogic.Model
{
    public static class FuzzyModel
    {
        public static LinguisticVariable[] InputLVs { get => _inputLVs; }
        public static LinguisticVariable OutputLV { get => _outputLV; }
        public static Rule[] RuleBase { get => _ruleBase; }

        private static LinguisticVariable[] _inputLVs = DataController.GetInputLVs();
        private static LinguisticVariable _outputLV = DataController.GetOutputLV();
        private static Rule[] _ruleBase = DataController.GetRules();

        public static void SetInputLVs()
        {
            _inputLVs = DataController.GetInputLVs();
        }
        public static void SetOutputLV()
        {
            _outputLV = DataController.GetOutputLV();
        }
        public static void SetRuleBase()
        {
            _ruleBase = DataController.GetRules();
        }
    
        public static void SaveInputLVs()
        {
            DataController.SetInputLVs(InputLVs);
        }
    }
}
