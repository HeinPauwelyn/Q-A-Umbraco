using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;

namespace AlaQAndA.WebApp.Models
{
    public class Question
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public Question(string title, string description)
        {
            Title = title;
            Description = description;  
        }

        public Question(int id, string title, string description)
        {
            ID = id;
            Title = title;
            Description = description;
        }

        public override bool Equals(object obj)
        {
            if (obj is Question)
            {
                return (obj as Question).ID == ID;
            }
            return false;
        }
    }
}