﻿using FanSite.Models;
using FanSite.Repositories;
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
        private List<StoryResponse> stories = new List<StoryResponse>();

        public List<StoryResponse> Stories { get { return stories; } }

        public StoryRepository()
        {
            AddTestData();
        }

        public void AddStory(StoryResponse story)
        {
            stories.Add(story);
        }

        public StoryResponse GetStoryByTitle(string title)
        {
            StoryResponse story = stories.Find(s => s.Title == title);
            return story;
        }

         void AddTestData()
        {
            StoryResponse story = new StoryResponse()
            {
                Title = "Ghandi goes on hunger strike",
                Date = "April 9th, 1908",
                Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec sit amet pulvinar lorem."
            };
            story.Author = new User()
            {
                Username = "Ken Burns"
            };
            stories.Add(story);
        }
    }
}
