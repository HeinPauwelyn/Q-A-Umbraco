using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using AlaQAndA.WebApp.Models;
using AlaQAndA.WebApp.Service;
using AutoMapper;
using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.Editors;
using Umbraco.Web.Mvc;

namespace AlaQAndA.WebApp.Controllers
{
    [PluginController("Questions")]
    public class QuestionsApiController : UmbracoAuthorizedJsonController
    {
        private QuestionService _questionService = new QuestionService();

        [HttpGet]
        public IEnumerable<Question> GetAll()
        {
            return _questionService.ReadFile();
        }

        [HttpPost]
        public IEnumerable<Question> Delete(int id)
        {
            return _questionService.DeleteRow(id);
        }
    }
}