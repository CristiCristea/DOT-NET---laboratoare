using System;
using FluentAssertions;
using JobManagement;
using Xunit;

namespace JobManagementTest
{
    public class JobInfoTest
    {
        [Fact]
        public void Give_ANewJobInstaceInstance_When_SettingValidParameters_Then_TheValuesShouldBeSet()
        {
            var jobInfo = new JobInfo("Job now", 22, "Know about moon", 2000);
            jobInfo.Id.Should().NotBeEmpty();
            jobInfo.Title.Should().Be("Job now");
            jobInfo.MinimumYearsOfExperience.Should().Be(22);
            jobInfo.Requirements.Should().Be("Know about moon");
            jobInfo.Salary.Should().Be(2000);
        }

        [Fact]
        public void Give_ANewJobInstaceInstance_When_SettingInValidYearsOfExperience_Then_ArgumentExceptionShouldBeThrown()
        {
            Exception ex = Assert.Throws<ArgumentException>(() =>
                new JobInfo("Job now", -22, "Know about moon", 2000));

            ex.Message.Should().Be("Minimum Years Of Experience should be greater than 0!");
           
        }

        [Fact]
        public void Give_ANewJobInstaceInstance_When_SettingInValidSalary_Then_ArgumentExceptionShouldBeThrown()
        {
            Exception ex = Assert.Throws<ArgumentException>(() =>
                new JobInfo("Job now", 22, "Know about moon", -2000));

            ex.Message.Should().Be("Salary should be greater than 0!");

        }

        [Fact]
        public void Give_ANewJobRepositoryInstance_When_SettingValidParameters_Then_TheLengthShouldBe3()
        {
            var jobInfoRepository = new JobInfoRepository();
            jobInfoRepository.FindAllJobs().Count.Should().Be(3);
        }

        [Fact]
        public void Give_AJobRepositoryInstance_When_GetJobByTitleIsCalledWhithValidTitle_Then_ShoudReturnJob()
        {
            var jobInfoRepository = new JobInfoRepository();
            jobInfoRepository.GetJobByTitle("Secretary").Should().NotBeNull();
        }
        [Fact]
        public void Give_AJobRepositoryInstance_When_GetJobByTitleIsCalledWhithInvalidTitle_Then_ShoudReturnNull()
        {
            var jobInfoRepository = new JobInfoRepository();
            jobInfoRepository.GetJobByTitle("Secretary1").Should().BeNull();
        }
        [Fact]
        public void Give_AJobRepositoryInstance_When_FindAllJobIsCalledWhithNewInstance_Then_ShoudReturnAllJob()
        {
            var jobInfoRepository = new JobInfoRepository();
            jobInfoRepository.FindAllJobs().Count.Should().Be(3);
        }

        [Fact]
        public void Give_AJobRepositoryInstance_When_AddJobIsCalledWhithValidJob_Then_ShoudBe4()
        {
            var jobInfoRepository = new JobInfoRepository();
            jobInfoRepository.AddJob(new JobInfo("Job now",22,"Know about moon",2000));
            jobInfoRepository.FindAllJobs().Count.Should().Be(4);
        }

        [Fact]
        public void Give_AJobRepositoryInstance_When_GetJobByPositionIsCalledWhithValidPosition_Then_ShoudBeSecretary()
        {
            var jobInfoRepository = new JobInfoRepository();
            jobInfoRepository.GetJobByPosition(1).Title.Should().Be("Secretary");
        }

        [Fact]
        public void Give_AJobRepositoryInstance_When_GetJobByPositionIsCalledWhithInValidPosition_Then_ShoudBeNull()
        {
            var jobInfoRepository = new JobInfoRepository();
            jobInfoRepository.GetJobByPosition(-1).Should().BeNull();
        }

        [Fact]
        public void Give_AJobRepositoryInstance_When_RemoveJobsWithTitleIsCalledWhithValidTitle_Then_ShoudBe2Jobs()
        {
            var jobInfoRepository = new JobInfoRepository();
            jobInfoRepository.RemoveJobsWithTitle("Secretary");
            jobInfoRepository.FindAllJobs().Count.Should().Be(2);
        }
        
        [Fact]
        public void Give_AJobRepositoryInstance_When_GetJobsWithSalaryHigherThanIsCalledWhithValidTitle_Then_ShoudBe2Jobs()
        {
            var jobInfoRepository = new JobInfoRepository();
            jobInfoRepository.GetJobsWithSalaryHigherThan(1600).Count.Should().Be(2);
        }



    }
}
