using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Lab3.Models;

namespace Web_Lab3.Services
{
    public class QuizService
    {
        private Random _random;
        private List<Quiz> _listQuizzes;
        public static QuizService Instance { get; set; } = new();

        public void Reset()
        {
            _random = new Random();
            _listQuizzes = new List<Quiz>();
        }

        public Quiz GetNewQuiz()
        {
            var quiz = new Quiz();

            quiz.Number1 = _random.Next(0, 10);
            quiz.Number2 = _random.Next(0, 10);
            switch (_random.Next(0, 4))
            {
                case 0:
                    quiz.Operation = "+";
                    quiz.RightAnswer = quiz.Number1 + quiz.Number2;
                    quiz.QueryStr = quiz.Number1.ToString() + " + " + quiz.Number2.ToString() + " = ";
                   break;

                case 1:
                    quiz.Operation = "-";
                    quiz.RightAnswer = quiz.Number1 - quiz.Number2;
                    quiz.QueryStr = quiz.Number1.ToString() + " - " + quiz.Number2.ToString() + " = ";
                    break;

                case 2:
                    quiz.Operation = "*";
                    quiz.RightAnswer = quiz.Number1 * quiz.Number2;
                    quiz.QueryStr = quiz.Number1.ToString() + " * " + quiz.Number2.ToString() + " = ";
                    break;

                case 3:
                    quiz.Operation = "/";
                    quiz.Number2 = quiz.Number2 == 0 ? 1 : quiz.Number2;
                    quiz.RightAnswer = quiz.Number1 / quiz.Number2;
                    quiz.QueryStr = quiz.Number1.ToString() + " / " + quiz.Number2.ToString() + " = ";
                    break;
            }

            _listQuizzes.Add(quiz);

            return quiz;
        }

        public void AddQuizToList(Quiz quiz)
        {
            _listQuizzes.RemoveAt(_listQuizzes.Count - 1);
            _listQuizzes.Add(quiz);
        }

        public Quiz GetLastQuiz()
        {
            return _listQuizzes.Last();
        }

        public List<Quiz> GetListQuizzes()
        {
            return _listQuizzes;
        }
    }
}
