using System;

namespace JobManagement
{
    public class JobInfo
    {
        private double _salary;
        private int _yearsOfExperience;
        public Guid Id { get; private set; }
        public string Title { get; private set; }

        public int MinimumYearsOfExperience
        {
            get => _yearsOfExperience;
            private set
            {
                if (value < 0)
                    throw new ArgumentException("Minimum Years Of Experience should be greater than 0!");
                _yearsOfExperience = value;
            }


        }
        public string Requirements { get; private set; }
        public double Salary { get => _salary;
            private set
            {
                if(value < 0)
                    throw  new ArgumentException("Salary should be greater than 0!");
                _salary = value;
            }
        }

        public JobInfo(string title, int minimumYearsOfExperience, string requirements, double salary)
        {
            Id = Guid.NewGuid();
            Title = title;
            MinimumYearsOfExperience = minimumYearsOfExperience;
            Requirements = requirements;
            Salary = salary;
        }

    }
}
