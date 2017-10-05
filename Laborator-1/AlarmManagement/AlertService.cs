using System;
using System.Collections.Generic;

namespace AlarmManagement
{
    class AlertService : IAlertService
    {
        private List<Alarm> alarms;

        public AlertService()
        {
            alarms = new List<Alarm>
            {
                new CarAlarm("In parcare", DateTime.Now),
                new HouseAlarm("Mircea cel Batran", new DateTime(2017, 12, 2)),
                new CarAlarm("La facultate", DateTime.MinValue)
            };
        }

        public void SoundAlarm(Guid id)
        {
            foreach (Alarm alarm in alarms)
                if (alarm.Id == id)
                    alarm.Trigger();
        }
    }
}
