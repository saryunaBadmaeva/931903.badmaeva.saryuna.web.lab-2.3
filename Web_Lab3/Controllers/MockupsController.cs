using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Lab3.Models;
using Web_Lab3.Services;

namespace Web_Lab3.Controllers
{
    public class MockupsController : Controller
    {
        private QuizService _quizService;
        public MockupsController()
        {
            _quizService = QuizService.Instance;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Quiz()
        {
            _quizService.Reset();
            var quiz = _quizService.GetNewQuiz();
            return View(quiz);
        }

        [HttpPost]
        public IActionResult Quiz(string action)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not validated");

            var quiz = _quizService.GetLastQuiz();

            quiz.UserAnswer = !String.IsNullOrEmpty(Request.Form["Answer"]) 
                ? Int32.Parse(Request.Form["Answer"]) 
                : 0;
            quiz.QueryStr += quiz.UserAnswer.ToString();
            _quizService.AddQuizToList(quiz);

            if (action == "Next")
                return View(_quizService.GetNewQuiz());

            return RedirectToAction("QuizResult");

        }

        public IActionResult QuizResult()
        {
            var list = _quizService.GetListQuizzes();
            if (list is not null)
            {
                ViewBag.Result = list.Select(s => s.QueryStr);
                ViewData["All"] = "" + list.Count;
                ViewData["Right"] = "" + list.Count(s => s.RightAnswer == s.UserAnswer);
            }
            return View();
        }
    }
}
