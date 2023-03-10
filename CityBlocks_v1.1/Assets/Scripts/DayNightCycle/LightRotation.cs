using System;
using Audio;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace DayNightCycle
{
    public class LightRotation : MonoBehaviour
    {
        private float rotationAngle = 15f;
        [SerializeField] private float rotationTime = 5f;
        private float currentAngle = 0f;
        private float elapsedTime = 0f;

        private TimeOfDayBehaviour _timeOfDayBehaviour;
        private SettingsBehaviour _settingsBehaviour;

        private void Start()
        {
            _timeOfDayBehaviour = GameObject.Find("GameManager").GetComponent<TimeOfDayBehaviour>();
            _settingsBehaviour = GameObject.Find("SettingsButton").GetComponentInChildren<SettingsBehaviour>();
        }
        
        private void Update()
        {
            if (_settingsBehaviour.IsSettingsEnabled())
                return;
            
            if (currentAngle == 0)
            {
                _timeOfDayBehaviour.AddTime();
            }
            
            elapsedTime += Time.deltaTime;
            
            float t = elapsedTime / rotationTime;
            float angle = Mathf.Lerp(0f, rotationAngle, t);
            float deltaAngle = angle - currentAngle;
            
            transform.Rotate(deltaAngle, 0f, 0f);
            
            currentAngle = angle;
            
            if (elapsedTime >= rotationTime)
            {
                elapsedTime = 0f;
                currentAngle = 0f;
            }
        }
    }
}
