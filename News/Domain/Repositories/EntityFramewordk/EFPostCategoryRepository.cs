using Microsoft.EntityFrameworkCore;
using News.Domain.Entities;
using News.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Domain.Repositories.EntityFramewordk
{
    public class EFPostCategoryRepository : IPostCategories
    {
        private readonly AppDBContext context;

        public EFPostCategoryRepository (AppDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<PostCategory> GetCategories => context.postCategories;

        public void DeleteField(Guid fieldId)
        {
            context.postCategories.Remove(new PostCategory() { id = fieldId });
            context.SaveChanges();
        }

        public PostCategory GetFieldById(Guid fieldId)
        {
            return context.postCategories.FirstOrDefault(x => x.id == fieldId);
        }

        public void SaveField(PostCategory field)
        {
            if (field.id == default)
                context.Entry(field).State = EntityState.Added;
            else
                context.Entry(field).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
