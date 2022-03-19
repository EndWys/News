using News.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Models
{
    public class MainPageMainPageModel
    {
        public bool shoIntro;

        public Dictionary<string, string> activeMenuParagraph;

        public IEnumerable<PostItem> allPosts { get; set;}

        public IEnumerable<PostCategory> allCategories { get; set; }
    }
}
