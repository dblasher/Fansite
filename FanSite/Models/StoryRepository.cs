using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FanSite.Models
{
    public static class StoryRepository
    {
        private static List<StoryResponse> stories = new List<StoryResponse>();

        public static List<StoryResponse> Stories { get { return stories; } }
        public static void AddStory(StoryResponse story)
        {
            stories.Add(story);
        }

        public static StoryResponse GetStoryByTitle(string title)
        {
            StoryResponse story = stories.Find(s => s.Title == title);
            return story;
        }
    }
}
