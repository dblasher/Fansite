using FanSite.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FanSite.Repositories
{
    public class SeedData
    {
        //setup on DB connection
        //Service Provider connnects Entity Framework to whatever Database the app uses
        //Have to use IApplicationBuilder in order to call this class in Startup.cs in the Configure method
        public static void Seed(IApplicationBuilder app)
        {
            AppDbContext context = app.ApplicationServices.GetRequiredService<AppDbContext>();
            context.Database.EnsureCreated();

            //If there are no stories in the DB, we'll add some
            if (!context.Stories.Any())
            {
                //create a user
                User author = new User { Username = "John Doe" };
                context.Users.Add(author);

                //create a comment by that user
                Comment comment = new Comment { Commenter = author, CommentText = "I love this story" };
                context.Comments.Add(comment);

                //create a story by that user, add that user's comment to the story
                StoryResponse story = new StoryResponse {
                    Title = "A tale of Seeds",
                    Author = author,
                    Date = "beginning of time",
                    Text = "There once lived a seed, that grew to populate a database"};
                story.Comments.Add(comment);
                context.Stories.Add(story);

                //save all the added seed data to the database
                context.SaveChanges();
            }
        }
    }
}
