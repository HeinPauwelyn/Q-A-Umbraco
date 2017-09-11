using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AlaQAndA.WebApp.Controllers;
using AlaQAndA.WebApp.Helpers;
using AlaQAndA.WebApp.Service;
using Umbraco.Core;
using Umbraco.Web.UI.JavaScript;
using Umbraco.Web;

namespace AlaQAndA.WebApp
{
    public class ServerVariableParserEvent : ApplicationEventHandler
    {
        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            base.ApplicationStarted(umbracoApplication, applicationContext);

            ServerVariablesParser.Parsing += ServerVariablesParser_Parsing;
        }

        void ServerVariablesParser_Parsing(object sender, Dictionary<string, object> e)
        {
            if (HttpContext.Current == null) return;
            var urlHelper = new UrlHelper(new RequestContext(new HttpContextWrapper(HttpContext.Current), new RouteData()));

            var mainDictionary = new Dictionary<string, object>();
            mainDictionary.Add(ConstantString.QuestionBaseUrl, urlHelper.GetUmbracoApiServiceBaseUrl<QuestionsApiController>(controller => controller.GetAll()));

            if (!e.Keys.Contains(nameof(QuestionService)))
            {
                e.Add(nameof(QuestionService), mainDictionary);
            }
        }
    }
}