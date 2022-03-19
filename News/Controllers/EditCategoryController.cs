using Microsoft.AspNetCore.Mvc;
using News.Domain.Entities;
using News.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Controllers
{
    public class EditCategoryController : Controller
    {
        private readonly IPostCategories postCategories;

        public EditCategoryController(IPostCategories categories)
        {
            postCategories = categories;
        }

        public IActionResult RedactCategory(Guid id)
        {
            ViewBag.PageHeadline = "Create New Category";

            var model = id == default ? new PostCategory() : postCategories.GetFieldById(id);

            return View(model);
        }

        [HttpPost]
        public IActionResult RedactCategory(PostCategory model)
        {
            if (ModelState.IsValid)
            {
                postCategories.SaveField(model);
                return RedirectToAction(nameof(AdminPanelController.Index), "AdminPanel");
            }
            return View(model);
        }
    }
}
