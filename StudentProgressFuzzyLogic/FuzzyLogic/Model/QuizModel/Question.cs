using StudentProgressFuzzyLogic.FuzzyLogic.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StudentProgressFuzzyLogic.FuzzyLogic.Model.QuizModel
{
    [Serializable]
    public class Question
    {
        public struct QuestionStruct
        {
            public int rightAnswerIndex;
            public string[] answers;
        }

        public static Question[] QuestionBase { get => _questionBase; }

        private static Question[] _questionBase = DataController.GetQuestions();

        public string Title { get => _title; }
        public Answer[] Answers { get => _answers; }

        string _title;
        Answer[] _answers;

        [JsonConstructor]
        public Question(string Title, Answer[] Answers)
        {
            _title = Title;
            _answers = Answers;
        }

        public Question(string title, QuestionStruct questionStruct)
        {
            questionStruct.rightAnswerIndex--;

            _title = title;

            _answers = new Answer[questionStruct.answers.Length];

            for (int answerIndex = 0; answerIndex < _answers.Length; answerIndex++)
            {
                if(answerIndex == questionStruct.rightAnswerIndex)
                {
                    _answers[answerIndex] = new Answer(questionStruct.answers[answerIndex], IsCorrect: true);
                }
                else
                {
                    _answers[answerIndex] = new Answer(questionStruct.answers[answerIndex]);
                }
            }
        }

        public bool IsCorrectAnswer(int answerIndex)
        {
            return _answers[answerIndex].IsCorrect;
        }

        public static void ShuffleQuestionBase()
        {
            RandomExtensions.Shuffle(new Random(), _questionBase);
        }
    }

    static class RandomExtensions
    {
        public static void Shuffle<T>(this Random rng, T[] array)
        {
            int n = array.Length;
            while (n > 1)
            {
                int k = rng.Next(n--);
                T temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
        }
    }
}
