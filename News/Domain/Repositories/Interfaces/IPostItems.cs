using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using News.Domain.Repositories.Interfaces;
using News.Models;

namespace News.Interfaces
{
    public interface IPostItems : IDBEntity<PostItem>
    {
        public IEnumerable<PostItem> GetPostItems { get; }
        
        public IEnumerable<PostItem> GetPostByCategory { get;}
    }
}
