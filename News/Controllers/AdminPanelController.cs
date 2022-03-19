using Microsoft.AspNetCore.Mvc;
using News.Domain.Repositories.Interfaces;
using News.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Controllers
{
    public class AdminPanelController : Controller
    {
        private readonly IPostItems postItems;
        private readonly IPostCategories postCategories;
        public AdminPanelController(IPostItems posts, IPostCategories categories)
        {
            postItems = posts;
            postCategories = categories;
        }
        public IActionResult Index()
        {
            ViewBag.PageHeadline = "Admin Panel";
            return View(postItems.GetPostItems);
        }
    }
}
