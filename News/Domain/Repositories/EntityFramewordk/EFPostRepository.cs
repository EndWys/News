using Microsoft.EntityFrameworkCore;
using News.Domain;
using News.Domain.Repositories.EntityFramewordk;
using News.Interfaces;
using News.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News
{
    public class EFPostRepository : IPostItems
    {
        private readonly AppDBContext context;
        public EFPostRepository(AppDBContext context)
        {
            this.context = context;
        }


        public IEnumerable<PostItem> GetPostItems => context.postItems;
        public IEnumerable<PostItem> GetPostByCategory => context.postItems.Include(c => c.category);
        public void DeleteField(Guid fieldId)
        {
            context.postItems.Remove(new PostItem() { id = fieldId });
            context.SaveChanges();
        }

        public PostItem GetFieldById(Guid fieldId)
        {
            return context.postItems.FirstOrDefault(x => x.id == fieldId);
        }

        public void SaveField(PostItem field)
        {
            if (field.id == default)
                context.Entry(field).State = EntityState.Added;
            else
                context.Entry(field).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
