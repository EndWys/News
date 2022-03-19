using Microsoft.AspNetCore.Mvc;
using News.Domain;
using News.Interfaces;
using News.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Controllers
{
    public class HomeController : Controller
    {
        private IPostItems postItems;

        public HomeController(IPostItems posts)
        {
             postItems = posts; 
        }
        public IActionResult Index()
        {
            Bag();
            return View(postItems.GetPostItems);
        }

        private void Bag()
        {

            ViewBag.ShowIntro = true;
            ViewBag.ActiveMenuPartial = new Dictionary<string, string> { { "HomePage", "active" }, { "CreatePost", "" }, { "AboutUs", "" } };
        }
    }
}
