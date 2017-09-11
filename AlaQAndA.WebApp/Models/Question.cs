using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;

namespace AlaQAndA.WebApp.Models
{
    public class Question : PublishedContentModel
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public Question(IPublishedContent content)
            : base(content)
        { }

        public Question(string title, string description) 
            : this (null)
        {
            Title = title;
            Description = description;
        }
    }
}