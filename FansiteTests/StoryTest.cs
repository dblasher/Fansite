using FanSite.Controllers;
using FanSite.Repositories;
using FanSite.Models;
using Xunit;
using System.Linq;

namespace FansiteTests.Tests
{
    public class StoryTest
    {

        [Fact]
        public void StoryContructorTest()
        {
            //arrange
            var repo1 = new FakeStoryRepository();

            //act
            //no actions needed, repo should have one story added by the class constructor

            //assert, first story title should be Ghandi "goes on hunger strike"
            Assert.Equal("Ghandi goes on hunger strike", repo1.Stories.Last().Title);
        }

        [Fact]
        public void AddStoryTest()
        {
            //arrange
            StoryResponse story = new StoryResponse()
            {
                Title = "Test title",
                Date = "test date",
                Text = "test text"
            };
            story.Author = new User()
            {
                Username = "Mr. Test"
            };
            var repo2 = new FakeStoryRepository();

            //act
            repo2.AddStory(story);

            //assert, could add a comparer to simply this assertion to one line
            Assert.Equal("Test title", repo2.Stories.Last().Title);
            Assert.Equal("test date", repo2.Stories.Last().Date);
            Assert.Equal("test text", repo2.Stories.Last().Text);
            Assert.Equal("Mr. Test", repo2.Stories.Last().Author.Username);
        }

        [Fact]
        public void AddStoryViewTest()
        {
            //arrange
            var repo3 = new FakeStoryRepository();
            var controller = new StoryController(repo3);

            //act
            StoryResponse story = new StoryResponse() { Title = "Ghandi meets with the Prime Minister", Date = "April 5th, 1968", Text = "The meeting went very poorly." };
            controller.Stories(story, "Carl Sagan");

            //Assert
            Assert.Equal("Ghandi meets with the Prime Minister", repo3.Stories.Last().Title);
        }

        [Fact]
        public void GetStoryByTitleTest()
        {
            //arrange
            var repo4 = new FakeStoryRepository();

            //act
            StoryResponse fetchedStory = repo4.GetStoryByTitle("Ghandi goes on hunger strike");

            //assert, checking a random property of the fetchedStory is equal to that same property in the test data
            Assert.Equal("April 9th, 1908",fetchedStory.Date);

        }
    }
}
