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

        //had to add this since we needed in the StoryRepository, which inherits this interface class
        void AddComment(StoryResponse story, Comment comment);

        StoryResponse GetStoryByTitle(string title);
    }
}
