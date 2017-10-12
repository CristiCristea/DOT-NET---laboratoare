using System;
using System.Collections.Generic;

namespace TransportManagement
{
    public class Bus
    {
        public Guid Id { get; private set; }
        public int Mileage;
        public List<RoadTrip> Schedule { get; private set; }
        public bool FullyScheduled;

        public Bus()
        {
            Id = Guid.NewGuid();
            Schedule = new List<RoadTrip>();
            Mileage = 0;
            FullyScheduled = false;
        }

        public void AddRoadTrip(RoadTrip roadTrip)
        {
            if (FullyScheduled)
            {
                throw new BusinessException("Bus is fully scheduled!\nTry tomorrow! :)");
            }

            if (Mileage + roadTrip.Distance > 100)
            {
                throw new BusinessException(
                    "Cannot add road trip because schedule distance cannot be more than 100!\n" +
                    "Curent schedule distance =" + Mileage + " please add a lower road trip!");
            }

            foreach (var iterator in Schedule)
            {
                if (iterator.StartTime < roadTrip.EndTime && roadTrip.StartTime < iterator.EndTime)
                {
                    throw new BusinessException("Cannot add two roads in the smae period of time!");
                }
            }

            Schedule.Add(roadTrip);
            Mileage += roadTrip.Distance;
            
            if (Mileage == 100)
            {
                FullyScheduled = true;
            }
        }

        public List<RoadTrip> GetAllRoadTripSchedule()
        {
            return Schedule;
        }

        public List<RoadTrip> GetAllRoadTripsScheduleFromPeriodTime(TimeSpan startTime, TimeSpan endTime)
        {
            var roadTrips = new List<RoadTrip>();
            foreach (var roadTrip in Schedule)
            {
                if (roadTrip.StartTime > startTime && roadTrip.EndTime < endTime)
                {
                    roadTrips.Add(roadTrip);
                }
            }
            return roadTrips;
        }

    }
}
