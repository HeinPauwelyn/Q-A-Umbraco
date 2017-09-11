using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlaQAndA.WebApp.Models;
using AlaQAndA.WebApp.Service;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace AlaQAndA.WebApp.Controllers
{
    public class QuestionsController : SurfaceController
    {
        private QuestionService _questionService = new QuestionService();

        [HttpGet]
        public ActionResult Index()
        {
            return PartialView("~/Views/MacroPartials/Questions.cshtml", _questionService.ReadFile());
        }

        [HttpGet]
        [Route("~/questions/details/{id}")]
        public ActionResult Details(int id)
        {
            return View(_questionService.ReadFile().ElementAt(id));
        }

        [HttpPost]
        public ActionResult New(string title, string content)
        {
            Question newQuestion = new Question(title, content);
            List<Question> questions = _questionService.ReadFile();
            newQuestion.ID = questions.Count;

            questions.Add(newQuestion);
            _questionService.WriteFile(questions);


            return Redirect("~/questions");
        }
    }
}
