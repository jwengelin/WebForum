using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebForum.Models.DB
{
    public partial class Categories
    {
        public Categories()
        {
            Threads = new HashSet<Threads>();
        }

        
        public int CategoryId { get; set; }
        [Display(Name = "Categories")]
        public string CategoryDescription { get; set; }

        public ICollection<Threads> Threads { get; set; }
    }
}
