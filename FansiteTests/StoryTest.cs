using FanSite.Controllers;
using FanSite.Repositories;
using FanSite.Models;
using Xunit;

namespace FansiteTests.Tests
{
    public class StoryTest
    {
        [Fact]
        public void AddStoryTest()
        {
            //arrange
            var repo = new FakeStoryRepository();
            var controller = new StoryController(repo);

            //act
            controller.Stories("Ghandi meets with the Prime Minister", "Carl Sagan", "April 5th, 1968", "The meeting went very poorly.");

            //Assert
            Assert.Equal("Ghandi meets with the Prime Minister", repo.Stories[repo.Stories.Count - 1].Title);
        }
    }
}
