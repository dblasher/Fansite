using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FanSite.Models
{
    /// <summary>
    /// holds list of authors, comments, string Title, Date, and Text, and int Rating
    /// </summary>
    public class StoryResponse
    {
        public int StoryResponseID { get; set; }
        //private User author = new User();
        private List<Comment> comments = new List<Comment>();

        public int rating = 0;

        [StringLength(100, MinimumLength = 2)]
        [Required(ErrorMessage = "Please enter a title")]
        public string Title { get; set; }

        [StringLength(20, MinimumLength = 6)]
        [Required(ErrorMessage = "Please enter a date")]
        public string Date { get; set; }

        [StringLength(200, MinimumLength = 15)]
        [Required(ErrorMessage = "Please enter your story text")]
        public string Text { get; set; }

        public int Rating { get; set; }

        public User Author { get; set; }
        public ICollection<Comment> Comments { get { return comments; } }
    }
}
