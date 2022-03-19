using News.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Domain.Repositories.Interfaces
{
    public interface IPostCategories : IDBEntity<PostCategory>
    {
        public IEnumerable<PostCategory> GetCategories { get; }
    }
}
