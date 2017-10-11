using System;
using System.Collections.Generic;

namespace TransportManagement
{
    public class Buss
    {
        public Guid Id { get; private set; }
        public List<RoadTrip> Schedule { get; private set; }
        public bool FullyScheduled;

        public Buss(string name)
        {
            Id = Guid.NewGuid();
            Schedule = new List<RoadTrip>();
            FullyScheduled = false;
        }

        public void AddRoadTrip(RoadTrip roadTrip)
        {
            var corectInterval = true;

            if (roadTrip.Distance > 50)
            {
                throw new BusinessException("Cannot add road trip with more than 50km!");
            }

            if (GetScheduleDistance() + roadTrip.Distance > 100)
            {
                throw new BusinessException(
                    "Cannot add road trip because schedule distance cannot be more than 100!\n" +
                    "Curent schedule distance =" + GetScheduleDistance() + "please add a lower road trip!");
            }

            foreach (var iterator in Schedule)
            {
                if (iterator.StartTime < roadTrip.EndTime && roadTrip.StartTime < iterator.EndTime)
                {
                    corectInterval = false;
                }
            }

            if (corectInterval)
            {
                Schedule.Add(roadTrip);
            }
            else
            {
                throw new BusinessException("Cannot add two roads in the smae period of time!");
            }

            if (GetScheduleDistance() == 100)
            {
                MarkFullyScheduledBuss();
            }
        }

        public List<RoadTrip> GetAllRoadTripSchedule()
        {
            return Schedule;
        }

        public List<RoadTrip> GetAllRoadTripsScheduleFromPeriodTime(TimeSpan startTime, TimeSpan endTime)
        {
            //return Schedule.Where(roadTrip => roadTrip.StartTime > startTime && roadTrip.EndTime < endTime).ToList();
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

        private void MarkFullyScheduledBuss()
        {
            FullyScheduled = true;
        }

        private int GetScheduleDistance()
        {
            //return Schedule.Sum(roadTrip => roadTrip.Distance);
            var scheduleDistance = 0;
            foreach (var roadTrip in Schedule)
            {
                scheduleDistance += roadTrip.Distance;
            }
            return scheduleDistance;
        }

    }
}
