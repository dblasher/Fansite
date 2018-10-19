using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FanSite.Models
{
    /// <summary>
    /// Holds a list of stories
    /// </summary>
    //I should refactor my repositories into a single model
    public static class StoryRepository
    {
        private static List<StoryResponse> stories = new List<StoryResponse>();

        public static List<StoryResponse> Stories { get { return stories; } }

        static StoryRepository()
        {
            AddTestData();
        }

        public static void AddStory(StoryResponse story)
        {
            stories.Add(story);
        }

        public static StoryResponse GetStoryByTitle(string title)
        {
            StoryResponse story = stories.Find(s => s.Title == title);
            return story;
        }

        static void AddTestData()
        {
            StoryResponse story = new StoryResponse()
            {
                Title = "Ghandi goes on hunger strike",
                Date = "April 9th, 1908",
                Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec sit amet pulvinar lorem."
            };
            story.Authors.Add(new User
            {
                Username = "Ken Burns"
            });
            stories.Add(story);
        }
    }
}
