using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models.PublishedContent;

namespace AlaQAndA.WebApp.Models
{
    public partial class Questionlist : PublishedContentModel
    {
        public List<Question> Questions { get; set; }
    }
}