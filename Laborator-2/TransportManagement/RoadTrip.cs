using System;

namespace TransportManagement
{
    public class RoadTrip
    {
        private int _distance;
        public TimeSpan StartTime { get; private set; }
        public TimeSpan EndTime { get; private set; }
        public string Name { get; private set; }
        public int Distance { get => _distance;
            private set
            {
                if(value < 0)
                    throw new BusinessException("Cannot add road trip with negative distance!");
                _distance = value;
            }
        }
        public RoadTrip(string name, int distance, TimeSpan startTime, TimeSpan endTime)
        {
            if (startTime > endTime)
                throw new BusinessException("End time should be great than start time!");
            
            Name = name;
            Distance = distance;
            StartTime = startTime;
            EndTime = endTime;
        }

    }
}
