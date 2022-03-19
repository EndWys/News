using News.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Domain.Entities
{
    public class PostCategory : BaseDBEntity
    {
        public PostCategory() : base() { }

        public PostCategory(string name):base()
        {
            categoryName = name;
            //postsNumber = 0;
        }
        public string categoryName { get; set; }
        //public int postsNumber { get; set;  }
    }
}
