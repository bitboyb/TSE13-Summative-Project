using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace DayNightCycle
{
    public class TimeOfDayBehaviour : MonoBehaviour
    {
        private Text _timeText;
        private int _timeOfDay = 6;
        private string _timeOfDayState;

        public AK.Wwise.RTPC timeOfDayRTPC;
        public string timeNotifyEvent;

        private void Start()
        {
            _timeText = GameObject.Find("TimeText").GetComponent<Text>();
            SetTimeOfDayState();
            UpdateTimeText();
        }

        private void UpdateTimeText()
        {
            _timeText.text = _timeOfDay.ToString("00") + ":00";
        }

        public void AddTime()
        {
            _timeOfDay++;
            
            if(_timeOfDay == 12)
                AkSoundEngine.PostEvent(timeNotifyEvent, gameObject);
            else if(_timeOfDay == 9)
                AkSoundEngine.PostEvent(timeNotifyEvent, gameObject);
            else if (_timeOfDay == 17)
                AkSoundEngine.PostEvent(timeNotifyEvent, gameObject);
            else if (_timeOfDay == 24)
            {
                _timeOfDay = 0;
                AkSoundEngine.PostEvent(timeNotifyEvent, gameObject);
            }

            SetTimeOfDayState();
            UpdateTimeText();
        }

        private void SetTimeOfDayState()
        {
            SetTimeOfDayRTPC();
            
            switch (_timeOfDay)
            {
                case 6:
                    //AkSoundEngine.SetState("Time_Of_Day", "Morning");
                    _timeOfDayState = "Morning";
                    break;
                case 12:
                    //AkSoundEngine.SetState("Time_Of_Day", "Afternoon");
                    _timeOfDayState = "Afternoon";
                    break;
                case 18:
                    //AkSoundEngine.SetState("Time_Of_Day", "Evening");
                    _timeOfDayState = "Evening";
                    break;
                case 24:
                    //AkSoundEngine.SetState("Time_Of_Day", "Night");
                    _timeOfDayState = "Night";
                    break;
            }
        }

        private void SetTimeOfDayRTPC()
        {
            timeOfDayRTPC.SetGlobalValue(_timeOfDay);
        }
        
        public string GetTimeOfDayState()
        {
            return _timeOfDayState;
        }
    }
}

