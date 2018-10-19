using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FanSite.Models
{
    public class Comment
    {
        public string CommentText { get; set; }
        public User Commenter { get; set; }
    }
}
