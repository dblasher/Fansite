using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FanSite.Models
{
    public class Comment
    {
        [Required(ErrorMessage = "Please enter a Comment")]
        public string CommentText { get; set; }

        [Required(ErrorMessage = "Please enter your name. No Trolling!")]
        public User Commenter { get; set; }
    }
}
