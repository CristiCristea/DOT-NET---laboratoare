using System.Collections.Generic;

namespace JobManagement
{
    public class JobInfoRepository
    {
        private List<JobInfo> jobs;

        public JobInfoRepository()
        {
            jobs = new List<JobInfo>
            {
                new JobInfo("Junior Developer", 0, "Licence diploma", 2000),
                new JobInfo("Secretary", 4,"Should know management and Office", 1500),
                new JobInfo("Ninja Developer",10,"Do everything fast and correct",5000)
            };
        }

        public JobInfo GetJobByTitle(string jobTitle)
        {
            foreach (var job in jobs)
            {
                if (job.Title == jobTitle)
                    return job;
            }
            return null;
        }

        public List<JobInfo> FindAllJobs()
        {
            return jobs;
        }

        public void AddJob(JobInfo job)
        {
            jobs.Add(job);
        }

        public JobInfo GetJobByPosition(int position)
        {
            if (position < jobs.Count && position >= 0)
                return jobs[position];
            return null;
        }

        public void RemoveJobsWithTitle(string jobTitle)
        {
            for (var index = 0; index < jobs.Count; index++)
            {
                var job = jobs[index];
                if (job.Title == jobTitle)
                {
                    jobs.Remove(job);
                }

            }
        }

        public List<JobInfo> GetJobsWithSalaryHigherThan(int limit)
        {
            var jobsWithSalaryHigherTanLimit = new List<JobInfo>();
            foreach (var job in jobs)
            {
                if(job.Salary > limit)
                    jobsWithSalaryHigherTanLimit.Add(job);
            }
            return jobsWithSalaryHigherTanLimit;
        }
    }
}
