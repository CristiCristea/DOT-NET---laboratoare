using System;

namespace AlarmManagement
{
    public class HouseAlarm : Alarm
    {
        private readonly string _adress;

        public HouseAlarm   (string adress, DateTime alertTime) : base(adress, alertTime)
        {
            _adress = adress;
        }

        public override string Trigger()
        {
            AlertTime = DateTime.Now;
            return "House alarm triggered, calling cops.";
        }
    }
}
