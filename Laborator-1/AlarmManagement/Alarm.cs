using System;

namespace AlarmManagement
{
    public abstract class Alarm
    {
        public Alarm(string location, DateTime alertTime)
        {
            Id = Guid.NewGuid();
            Location = location;
            AlertTime = alertTime;
        }

        public Guid Id { get; private set; }
        public DateTime AlertTime { get; protected set; }
        public string Location { get; private set; }

        public abstract string Trigger();
    }
}