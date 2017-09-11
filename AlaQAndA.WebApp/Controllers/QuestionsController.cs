using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlaQAndA.WebApp.Models;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace AlaQAndA.WebApp.Controllers
{
    public class QuestionsController : SurfaceController
    {
        private const string _filename = @"G:\hein\ala q&a\q&a.csv";

        [HttpGet]
        public ActionResult Index()
        {
            return PartialView("~/Views/MacroPartials/Questions.cshtml", ReadFile());
        }

        [HttpPost]
        public ActionResult New(string title, string content)
        {
            Question newQuestion = new Question(title, content);
            List<Question> questions = ReadFile();

            questions.Add(newQuestion);
            WriteFile(questions);


            return Redirect("~/questions");
        }

        private void WriteFile(List<Question> questions)
        {
            StreamWriter file = new StreamWriter(_filename);

            foreach (Question question in questions)
            {
                file.WriteLine("{0},{1}", question.Title, question.Description);
            }

            file.Close();
        }

        private List<Question> ReadFile()
        {
            List<Question> list = new List<Question>();

            string[] lines = System.IO.File.ReadAllLines(_filename);

            // Display the file contents by using a foreach loop.
            foreach (string line in lines)
            {
                string[] splitted = line.Split(',');
                list.Add(new Question(splitted[0], splitted[1]));
            }

            return list;
        }
    }
}
