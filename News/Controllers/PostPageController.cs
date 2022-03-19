using Microsoft.AspNetCore.Mvc;
using News.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Controllers
{
    public class PostPageController : Controller
    {
        private readonly IPostItems postItems;

        public PostPageController(IPostItems posts)
        {
            postItems = posts;
        }

        public IActionResult Post(Guid id)
        {
            var post = postItems.GetFieldById(id);
            Bag();
            return View(post);
        }

        private void Bag()
        {
            ViewBag.ShowIntro = true;
            ViewBag.ActiveMenuPartial = new Dictionary<string, string> { { "HomePage", "" }, { "CreatePost", "active" }, { "AboutUs", "" } };
        }
    }
}
