using Microsoft.AspNetCore.Mvc.Rendering;
using News.Domain.Entities;
using News.Domain.Repositories.Interfaces;
using News.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Models
{
    public class PostEditModel
    {
        public PostItem postItem { get; set; }

        public SelectList categoriesList { get; set; }

        public PostEditModel(Guid id, IPostItems postItems, IPostCategories postCategories)
        {
            categoriesList = new SelectList(postCategories.GetCategories, "id", "categoryName");
            postItem = postItems.GetFieldById(id);
        }

        public PostEditModel(){ }
    }
}
