using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebForum.Models.DB;

namespace WebForum.Models
{
    public partial class PostsViewModel
    {
        [Key]
        public int key { get; set; }
        public Threads Thread { get; set; }
        public Posts Post { get; set; }
        public UserAccounts UserAccount { get; set; }
    }
}
