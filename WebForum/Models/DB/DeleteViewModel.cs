using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebForum.Models.DB
{
    public class DeleteViewModel 
    {
        public int PostId { get; set; }
        public int ThreaId { get; set; }

        public Posts Post { get; set; }
    }
}
