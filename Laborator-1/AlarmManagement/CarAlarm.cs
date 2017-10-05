using System;

namespace AlarmManagement
{
    public class CarAlarm : Alarm
    {
        public CarAlarm(string location, DateTime alertTime) : base(location, alertTime)
        {
        }

        public override string Trigger()
        {
            AlertTime = DateTime.Now;
            return "Car alarm activated at " + Location + ", calling cops.";
        }
    }
}
