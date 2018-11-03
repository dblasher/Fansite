using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FanSite.Models;

namespace FanSite.Repositories
{
    /// <summary>
    /// Used for accessing the StoryResponse Model
    /// </summary>
    public interface IStoryRepository
    {
        List<StoryResponse> Stories { get;}

        void AddStory(StoryResponse story);

        StoryResponse GetStoryByTitle(string title);
    }
}
