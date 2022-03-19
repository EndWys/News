using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace News.Domain.Entities
{
    public abstract class BaseDBEntity
    {
        protected BaseDBEntity() => dateTime = DateTime.UtcNow;

        [Required]
        public Guid id { get; set; }

        public DateTime dateTime { get; set; }
    }
}
