using System;

namespace TaskManagement
{
    public class Task
    {
        private DateTime _startDate;
        private int _estimation;

        public Task(string title, string description, DateTime startDate, string assignee, int estimation)
        {
            Id = Guid.NewGuid();
            Title = title;
            Description = description;
            StartDate = startDate;
            Assignee = assignee;
            Estimation = estimation;
        }
        public Guid Id { get; private set; }

        public string Title { get; private set; }

        public string Description { get; private set; }
        public string Assignee { get; private set; }

        public int Estimation { get => _estimation;
            private set
            {
                if(value <= 0)
                    throw new ArgumentException("Estimation should be greater than 0!");
                _estimation = value;
            }
        }
        public DateTime StartDate
        {
            get => _startDate;
            private set
            {
                if (value < DateTime.Now)
                    throw new ArgumentException("Invalid date!");
                _startDate = value;
            }
        }

        public bool IsOnTrack()
        {
            if (DateTime.Now < StartDate.AddDays(Estimation))
                return true;
            return false;
        }
        public double CalculateRemainingEstimate()
        {
            if (!IsOnTrack())
                return 0;
            return (Estimation - (DateTime.Now - StartDate).Days);
        }
    }

}
