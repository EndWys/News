using News.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace News.Models
{
    public class PostItem : BaseDBEntity
    {
        public PostItem() : base() { }
        [Required]
        public string titele { get; set; }
        public string image { get; set; }
        public string shortDescription { get; set; }
        public string longDescription { get; set; }
        public bool showFlag { get; set; }

        [Required]
        public Guid categoryId { get; set; }

        public virtual PostCategory category { get; set; }
    }
}
