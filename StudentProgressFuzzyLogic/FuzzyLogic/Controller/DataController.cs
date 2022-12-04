using StudentProgressFuzzyLogic.FuzzyLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using StudentProgressFuzzyLogic.FuzzyLogic.Model.QuizModel;
using static StudentProgressFuzzyLogic.FuzzyLogic.Model.QuizModel.Question;

namespace StudentProgressFuzzyLogic.FuzzyLogic.Controller
{
    public static class DataController
    {
        private static readonly object saveLocker = new object();
        private static readonly object readLocker = new object();

        static readonly string inputLVsFileName = @"InputLVs.json";
        static readonly string outputLVFileName = @"OutputLV.json";
        static readonly string rulesFileName = @"Rules.json";
        static readonly string studentResultsFileName = @"StudentResults.json";
        static readonly string questionsFileName = @"Questions.json";

        static readonly JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };

        public static LinguisticVariable[] GetInputLVs()
        {
            LinguisticVariable[] outputLVs = IsFileExist(inputLVsFileName) ? null : new LinguisticVariable[]{
            new LinguisticVariable("Correct Answers", 0,10,1, 1,
                new Term[]{ new  Term("Low", MemFunc.MEMEBER_FUNCTION_TYPE.TRAPMF, new float[] { 0,0,3,6 }),
                            new  Term("Avarage", MemFunc.MEMEBER_FUNCTION_TYPE.TRAPMF, new float[] { 4,6,7,8 }),
                            new  Term("High", MemFunc.MEMEBER_FUNCTION_TYPE.TRAPMF, new float[] { 6,8,9,10 }),
                            new  Term("Ideal", MemFunc.MEMEBER_FUNCTION_TYPE.TRAPMF, new float[] { 8,10,10,10 })}),

            new LinguisticVariable("Speed", 0,7.5f,.1f, .5f,
                new Term[]{ new  Term("Wrong Data", MemFunc.MEMEBER_FUNCTION_TYPE.TRAPMF, new float[] { 0,0,1,3 }),
                            new  Term("Slow", MemFunc.MEMEBER_FUNCTION_TYPE.TRAPMF, new float[] { 6.5f,7,7.5f,7.5f }),
                            new  Term("Avarage", MemFunc.MEMEBER_FUNCTION_TYPE.TRAPMF, new float[] { 4,5,6,7 }),
                            new  Term("Fast", MemFunc.MEMEBER_FUNCTION_TYPE.TRAPMF, new float[] { 2,3.5f,4,5 })}),

            new LinguisticVariable("Hardest", 0,10,1, 1,
                new Term[]{ new  Term("Low", MemFunc.MEMEBER_FUNCTION_TYPE.TRAPMF, new float[] { 0,0,4,5 }),
                            new  Term("Medium", MemFunc.MEMEBER_FUNCTION_TYPE.TRIMF, new float[] { 3,6,8 }),
                            new  Term("Hard", MemFunc.MEMEBER_FUNCTION_TYPE.TRIMF, new float[] { 6,7,9 }),
                            new  Term("Very Hard", MemFunc.MEMEBER_FUNCTION_TYPE.TRAPMF, new float[] { 6,8,10,10 })},
                            majoritySortType: LinguisticVariable.MAGORITY_SORT_TYPE.Desc)
            };
            return GetDataFromFile(outputLVs, inputLVsFileName); ;
        }
        public static LinguisticVariable GetOutputLV()
        {
            LinguisticVariable outupLV = IsFileExist(outputLVFileName) ? null : new LinguisticVariable("Student progress", 0, 100, 1, 10, new Term[]{ new  Term("Very low", MemFunc.MEMEBER_FUNCTION_TYPE.TRAPMF, new float[] { 0,0,40,60 }),
                                                                                                                                   new  Term("Low", MemFunc.MEMEBER_FUNCTION_TYPE.TRAPMF, new float[] { 40,50,65,70 }),
                                                                                                                                   new  Term("Avarage", MemFunc.MEMEBER_FUNCTION_TYPE.TRAPMF, new float[] { 65,75,80,85 }),
                                                                                                                                   new  Term("High", MemFunc.MEMEBER_FUNCTION_TYPE.TRAPMF, new float[] { 70,80,90,95 }),
                                                                                                                                   new  Term("Very high", MemFunc.MEMEBER_FUNCTION_TYPE.TRAPMF, new float[] { 90,95,100,100 })});
            return GetDataFromFile(outupLV, outputLVFileName);
        }
        public static Rule[] GetRules()
        {
            Rule[] ruleBase = IsFileExist(rulesFileName) ? null : Rule.GenerateRuleBase(FuzzyModel.InputLVs, FuzzyModel.OutputLV);
            return GetDataFromFile(ruleBase, rulesFileName);
        }
        public static StudentResult[] GetStudentResults()
        {
            StudentResult[] studentResults = IsFileExist(studentResultsFileName) ? null : new StudentResult[] { new StudentResult("Dmytro", "Sakharov", 8, 4.5f, 1) };
            return GetDataFromFile(studentResults, studentResultsFileName);
        }
        public static Question[] GetQuestions()
        {
            Question[] questions = null;
            if (!IsFileExist(questionsFileName))
            {
                QuestionStruct[] answers =
            {
                               new QuestionStruct(){rightAnswerIndex = 3,
                               answers = new string[] {
 "to release the quest thread of a I/O operation",
 "to capture the request thread of a I/O operation",
 "to avoid blocking the request thread while waits for an I/ O operation",
 "to block the request thread if it waits for an I/ O operation"
                               }},
                               new QuestionStruct(){rightAnswerIndex = 3,
                               answers = new string[] {
 "You cannot concatenate strings in .NET.",
 "The second string object is modified so it contains the concatenated strings.",
 "A third string object is created containing the concatenated strings.",
 "The first string object is modified so it contains the concatenated strings."
                               }},
                               new QuestionStruct(){rightAnswerIndex = 3,
                               answers = new string[] {
 "XML",
 "C#",
 "LINQ",
 "XAML"
                               }},
                               new QuestionStruct(){rightAnswerIndex = 4,
                               answers = new string[] {
                                 "y = (int)thisObject;",
 "int y = 3;",
 "y = (int)thisObject=;3;",
 "object thisObject = y;"
                               }},
                               new QuestionStruct(){rightAnswerIndex = 3,
                               answers = new string[] {
 "string is used for fied-size strings in C#, while System.String is used for all the strings.",
 "There is no such class as System.String.",
 "There is none—string is an alias for System. String.",
 "System.String is a VB.NET data type, while string is a C# type."
                               }},
                               new QuestionStruct(){rightAnswerIndex = 3,
                               answers = new string[] {
 "It breaks from only the outer loop.",
 "It breaks from all loops.",
 "It breaks from only the inner loop.",
 "It breaks from the outer loop after the second iteration."
                               }},
                               new QuestionStruct(){rightAnswerIndex = 1,
                               answers = new string[] {
 "A statement lambda cannot return a value.",
 "If a statement lambda has a return value, it has to use a return statement.",
 "A statement lambda requires using curly braces.",
 "A statement lambda can have more than one statement."
                               }},
                               new QuestionStruct(){rightAnswerIndex = 3,
                               answers = new string[] {
 "At runtime, its value is evaluated.",
 "It can be either static or an instance member.",
 "It can be initialized at declaration only.",
 "It can be initialized in either the constructor or the declaration."
                               }},
                               new QuestionStruct(){rightAnswerIndex = 3,
                               answers = new string[] {
 "the basic unit to which an operating system allocates processor time",
 "a program that is running on your compiler",
 "a single operation that does not return a value and that usually executes asynchronously",
 "a series of related methods that together turn inputs into outputs",
                               }},
                               new QuestionStruct(){rightAnswerIndex = 3,
                               answers = new string[] {
 "Abstract methods cannot be used in derived classes.",
 "In your derived class, overload the method.",
 "In your derived class, override the method.",
 "In your derived class, declare the method as virtual."
                               }},
            };
                string[] questionTitles =
                {
                "When would you use asynchronous actions?",
                "What happens when you concatenate two strings?",
                "Which is a set of features that extends the query capabilities of the .NET language syntax by adding sets of new standard query operators that allow data manipulation, regardless of the data source?",
                "Assuming y is a value type, which is an example of boxing?",
                "What is the difference between System.String and string?",
                "When break is used inside two nested for loops, does control come out of the inner for loop or the outer for loop?",
                "Which is NOT true about lambda statements?",
                "Which is NOT true about a read-only variable?",
                "What is a task?",
                "When you define an abstract method, how do you use it in a derived class?"
                };

                questions = new Question[answers.Length];

                for (int questionIndex = 0; questionIndex < questions.Length; questionIndex++)
                {
                    questions[questionIndex] = new Question(questionTitles[questionIndex], answers[questionIndex]);
                }
            }

            return GetDataFromFile(questions, questionsFileName);
        }

        public static void SetInputLVs(LinguisticVariable[] newLVs)
        {
            SaveDataInJSon(newLVs, inputLVsFileName);
            FuzzyModel.SetInputLVs();
        }
        public static void SetOutputLV(LinguisticVariable newLV)
        {
            SaveDataInJSon(newLV, outputLVFileName);
            FuzzyModel.SetOutputLV();
        }
        public static void SetRuleBase(Rule[] newRuleBase)
        {
            SaveDataInJSon(newRuleBase, rulesFileName);
            FuzzyModel.SetRuleBase();
        }
        public static string SetStudentResult(StudentResult studentResult)
        {
            string output = "";
            List<StudentResult> oldResults = new List<StudentResult>(GetStudentResults());
            if (oldResults.Contains(studentResult)) 
            {
                output = "Incorect data. Student have been saved already. Please type another name or sername."; 
            }
            else
            {
                oldResults.Add(studentResult);
                SaveDataInJSon(oldResults.ToArray(), studentResultsFileName);
                output = "Data saved.";
            }

            return output;
        }
        
        public static void SaveStudentResult(StudentResult[] studentResults)
        {
            SaveDataInJSon(studentResults, studentResultsFileName);
        }

        private static bool IsFileExist(string fileName)
        {
            return File.Exists(fileName);
        }
        private static T GetDataFromFile<T>(T preparedData, string fileName)
        {
            T datatToGet = default(T);
            lock (readLocker)
            {
                if (!File.Exists(fileName))
                {
                    datatToGet = preparedData;
                    SaveDataInJSon(datatToGet, fileName);
                }
                else
                {
                    string jsonReadedString = File.ReadAllText(fileName);
                    System.Threading.Thread.Sleep(100);
                    datatToGet = JsonSerializer.Deserialize<T>(jsonReadedString, options);
                    System.Threading.Thread.Sleep(100);
                }
            }
            return datatToGet;
        }
        private static void SaveDataInJSon<T>(T newLVs, string fileName)
        {
            lock (saveLocker)
            {
                string serializedString = JsonSerializer.Serialize(newLVs, options);
                File.WriteAllText(fileName, serializedString);
            }
        }
    }
}
