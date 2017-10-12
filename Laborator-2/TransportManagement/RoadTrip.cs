using System;

namespace TransportManagement
{
    public class RoadTrip
    {
        private int _distance;
        public TimeSpan StartTime { get; private set; }
        public TimeSpan EndTime { get; private set; }
        public int Distance { get => _distance;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Cannot add road trip with negative distance!");
                }
                if (value > 50)
                {
                    throw new ArgumentException("Cannot add road trip with more than 50km!");
                }
                _distance = value;
            }
        }
        public RoadTrip(int distance, TimeSpan startTime, TimeSpan endTime)
        {
            if (startTime > endTime)
            {
                throw new ArgumentException("End time should be great than start time!");
            }
            Distance = distance;
            StartTime = startTime;
            EndTime = endTime;
        }

    }
}
