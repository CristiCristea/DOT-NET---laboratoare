using System;

namespace AlarmManagement
{
    internal interface IAlertService
    {
        void SoundAlarm(Guid id);
    }
}