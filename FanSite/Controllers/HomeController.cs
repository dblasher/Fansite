using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FanSite.Models;
using System.Web;
using FanSite.Repositories;

namespace FanSite.Controllers
{
    public class HomeController : Controller
    {
        IStoryRepository repo;

        //need to tell the startup.cs what interface to pass in here
        public HomeController(IStoryRepository r)
        {
            repo = r;
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
        //user submitted the Story form, create a new story with that data and add it the the StoryRepostory static model
        [HttpPost]
        public RedirectToActionResult AddStory(string Title, string Authors, string Date, string Text)
        {
            StoryResponse story = new StoryResponse();
            story.Title = Title;
            story.Date = Date; //for now Date is a string
            story.Text = Text;
            //this is messy, the way I set up my form I had to use Authors as an input field
            story.Authors.Add(new User() { Username = Authors });

            repo.AddStory(story);
            return RedirectToAction("UserStories");
        }
        //user navigated to the UserStories page, send the view all the stories currently saved in the StoryRepository model
        public IActionResult UserStories()
        {
            List<StoryResponse> stories = repo.Stories;
            stories.Sort((s1, s2) => s1.Title.CompareTo(s2.Title));
            ViewData["storyCount"] = stories.Count;
            ViewBag.newestStory = stories[stories.Count - 1].Title.ToString();
            return View(stories);
        }

        //user clicked "Add Comment", need to render the title of the story they clicked on
        public IActionResult AddComment(string title)
        {
            return View("AddComment", HttpUtility.HtmlDecode(title));
        }

        //User submitted a comment, add it to the story with that title and return the user back to UserStories view
        [HttpPost]
        public RedirectToActionResult AddComment(string title, string commentText, string commenter)
        {
            StoryResponse story = repo.GetStoryByTitle(title);
            story.Comments.Add(new Comment()
            {
                Commenter = new User() { Username = commenter },
                CommentText = commentText
            });
            ViewBag.newestCommenter = "Thanks for the comment!";
            return RedirectToAction("UserStories");
        }
    }
}
