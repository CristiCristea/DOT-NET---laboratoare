using System;
using TaskManagement;
using Xunit;

namespace TaskManagerXUnitTest
{
    public class TaskManaerTest
    {
        [Fact]
        public void Give_ANewTaskInstance_When_SettingValidParameters_Then_TheValuesShouldBeSet()
        {
            Task task = new Task("tema", "laborator 1 optional", DateTime.Now.AddDays(1), "Vasile", 20);
            Assert.Equal("tema", task.Title);
            Assert.Equal("laborator 1 optional",task.Description);
            Assert.Equal(DateTime.Now.AddDays(1).Date,task.StartDate.Date);
            Assert.Equal("Vasile", task.Assignee);
            Assert.Equal(20,task.Estimation);
        }

        [Fact]
        public void Given_ANewTaskInstace_When_SettingIvalidParamers_Then_ArgumentExceptionShouldBeThrown()
        {
            Exception ex = Assert.Throws<ArgumentException>(() => new Task("tema", "laborator 1 optional", DateTime.Now, "Vasile", 20));
            Assert.Equal("Invalid date!",ex.Message);  
        }

        [Fact]
        public void Given_AValidInstance_When_IsOnTrackIsCalled_Then_ShouldBeTrue()
        {
            Task task = new Task("tema", "laborator 1 optional", DateTime.Now.AddDays(1), "Vasile", 20);
            Assert.Equal(true , task.IsOnTrack());
        }

        [Fact]
        public void Given_AValidInstance_When_CalculateRemainingEstimateIsCalled_Then_ShouldBe20()
        {
            Task task = new Task("tema", "laborator 1 optional", DateTime.Now.AddDays(1), "Vasile", 20);
            Assert.Equal(20 , task.CalculateRemainingEstimate());
        }
    }
}
