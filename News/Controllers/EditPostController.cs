using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using News.Domain.Entities;
using News.Domain.Repositories.Interfaces;
using News.Interfaces;
using News.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Controllers
{
    public class EditPostController : Controller
    {
        private readonly IPostItems postItems;
        private readonly IPostCategories postCategories;
        public EditPostController(IPostItems posts , IPostCategories categories)
        {
            postItems = posts;
            postCategories = categories;
        }

        public IActionResult RedactPost(Guid id)
        {

            Bag();
            if (id == default)
            {
                ViewBag.PageHeadline = "CreatePost";
                return View(new PostItem());
            }
            else
            {
                ViewBag.PageHeadline = "EditPost";
                return View(postItems.GetFieldById(id));
            }
        }

        [HttpPost]
        public IActionResult RedactPost(PostItem model)
        {
            if (model.categoryId == default)
            {
                return RedirectToAction(nameof(EditCategoryController.RedactCategory), "EditCategory", model.id);
            }
            if (ModelState.IsValid)
            {
                postItems.SaveField(model);
                return RedirectToAction(nameof(AdminPanelController.Index), "AdminPanel");
            }
            Bag();
            return View(model);
        }

        public IActionResult DeletPost(Guid id)
        {
            postItems.DeleteField(id);
            return RedirectToAction(nameof(AdminPanelController.Index), "AdminPanel");
        }

        private void Bag()
        {

            ViewBag.ShowIntro = false;

            List<PostCategory> categoriesList = new List<PostCategory>(postCategories.GetCategories);
            categoriesList.Add(new PostCategory("New"));

            ViewBag.Categories = new SelectList(categoriesList, "id", "categoryName");
            ViewBag.ActiveMenuPartial = new Dictionary<string, string> { { "HomePage", "" }, { "CreatePost", "active" }, { "AboutUs", "" } };
        }
    }
}
