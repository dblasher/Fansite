using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FanSite.Models;
using System.Web;

namespace FanSite.Controllers
{
    public class HomeController : Controller
    {
        StoryResponse story;

        public HomeController()
        {
            if (StoryRepository.Stories.Count == 0)
            {
                story = new StoryResponse()
                {
                    Title = "Ghandi goes on hunger strike",
                    Date = "April 9th, 1908",
                    Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec sit amet pulvinar lorem."
                };
                story.Authors.Add(new User  //why not close the parenthesis unlike on line 21?
                {
                    Username = "Ken Burns"
                }
                );
                StoryRepository.AddStory(story);
            }
            
        }


        public ViewResult Index()
        {
            return View();
        }

        public ViewResult History()
        {
            return View();
        }

        public ViewResult Stories()
        {
            return View();
        }

        [HttpPost]
        public RedirectToActionResult Stories(string Title, string Authors, string Date, string Text)
        {
            story = new StoryResponse();
            story.Title = Title;
            story.Date = Date; //for now Date is a string
            story.Text = Text;
            //this is messy, the way I set up my form I had to use Authors as an input field
            story.Authors.Add(new User() { Username = Authors });

            StoryRepository.AddStory(story);
            return RedirectToAction("UserStories");
        }

        public IActionResult UserStories()
        {
            List<StoryResponse> stories = StoryRepository.Stories;
            stories.Sort((s1, s2) => s1.Title.CompareTo(s2.Title));
            return View(stories);
        }


        public IActionResult AddComment(string title)
        {
            return View("AddComment", HttpUtility.HtmlDecode(title));
        }

        [HttpPost]
        public RedirectToActionResult AddComment(string title, string commentText, string commenter)
        {
            StoryResponse story = StoryRepository.GetStoryByTitle(title);
            story.Comments.Add(new Comment()
            {
                Commenter = new User() { Username = commenter },
                CommentText = commentText
            });
            return RedirectToAction("UserStories");
        }

        //need to add a post method for UserStories that accepts comment, and username and an index
        //then create a comment instance and assign it StoryRepository[index].addComment(newComment)
    }
}
