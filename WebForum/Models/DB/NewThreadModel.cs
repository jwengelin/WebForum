using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebForum.Models.DB
{
    public class NewThreadModel
    {
        [Key]
        public int Key { get; set; }
        public Threads Thread{ get; set; }
        public Posts Post {get;set;}
    }
}
