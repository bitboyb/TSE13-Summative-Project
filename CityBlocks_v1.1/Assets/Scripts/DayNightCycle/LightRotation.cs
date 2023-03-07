using System;
using Audio;
using UnityEngine;
using UnityEngine.UI;

namespace DayNightCycle
{
    public class LightRotation : MonoBehaviour
    {
        private float rotationAngle = 15f;
        private float rotationTime = 5f;
        private float currentAngle = 0f;
        private float elapsedTime = 0f;

        private TimeOfDayBehaviour _timeOfDayBehaviour;
        private WwiseSliderBehaviour _wwiseSliderBehaviour;

        private void Start()
        {
            _timeOfDayBehaviour = GameObject.Find("GameManager").GetComponent<TimeOfDayBehaviour>();
            _wwiseSliderBehaviour = GameObject.Find("VolumeSliders").GetComponent<WwiseSliderBehaviour>();
        }
        
        private void Update()
        {
            if (_wwiseSliderBehaviour.IsSettingsEnabled())
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
