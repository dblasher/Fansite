using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FanSite.Models
{
    public class User
    {
        public int UserID { get; set; }

        private List<StoryResponse> stories = new List<StoryResponse>();
        private List<Comment> comments = new List<Comment>();

        //[Required(ErrorMessage = "Please enter a username")]
        public string Username { get; set; }

        public List<StoryResponse> Stories { get { return stories; } }
        public List<Comment> Comments { get { return comments; } }
    }
}
