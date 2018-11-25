using FanSite.Models;
using FanSite.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FanSite.Repositories
{
    /// <summary>
    /// Holds a list of stories
    /// </summary>
    //I should refactor my repositories into a single model
    public class StoryRepository : IStoryRepository
    {
        //dependecy injection service will define this property
        private AppDbContext context;

        //Use IQueryable isntead of List so users aren't given the entire DB of stories, rather the ability to search the DB
        public IQueryable<StoryResponse> Stories {
            get
            {
                //need to include the other DB tables so we can display data related to each story, ie their user and comments
                return context.Stories.Include(Stories=>Stories.Author).Include(Stories => Stories.Comments);
            }
        }

        public StoryRepository(AppDbContext appContext)
        {
            context = appContext;
        }

        public void AddStory(StoryResponse story)
        {
            context.Stories.Add(story);
            context.SaveChanges();
        }

        public StoryResponse GetStoryByTitle(string title)
        {
            //couldn't I just use Stories.Find() instead of context?
            //nevermind, gotta use the context for talking to the database
            StoryResponse story = context.Stories.First(s => s.Title == title);
            return story;
        }

        //need to add the comment to the Comments context, otherwise it won't show up in the database
        public void AddComment(StoryResponse story, Comment comment)
        {
            story.Comments.Add(comment);
            context.Stories.Update(story);
            context.SaveChanges();
        }

        //     void AddTestData()
        //    {
        //        StoryResponse story = new StoryResponse()
        //        {
        //            Title = "Ghandi goes on hunger strike",
        //            Date = "April 9th, 1908",
        //            Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec sit amet pulvinar lorem."
        //        };
        //        story.Author = new User()
        //        {
        //            Username = "Ken Burns"
        //        };
        //        stories.Add(story);
        //    }
    }
}
