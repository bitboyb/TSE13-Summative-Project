using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Audio
{
    public class BuildingAudioBehaviour : MonoBehaviour
    {
        private string buildingTypeSwitch = "Building_Type";
        private string buildingPositionSwitch = "Building_Position";
        private string[] buildingPrefix;
        
        [SerializeField] private string startEvent, stopEvent;

        private void Start()
        {
            buildingPrefix = new string[6] {"Apartment", "CityHall", "Elevator", "Office", "Power", "Shop"};
            SetBuildingType();
        }
    
        private void SetBuildingType()
        {
            foreach (var prefix in buildingPrefix)
            {
                AkSoundEngine.SetSwitch(buildingTypeSwitch, prefix, gameObject);
                startEvent = "Play_Block_" + prefix;
                stopEvent = "Stop_Block_" + prefix;
            }
        }

        public void SetBuildingPosition(string position)
        {
            AkSoundEngine.SetSwitch(buildingPositionSwitch, position, gameObject);
        }

        private void OnEnable()
        {
            AkSoundEngine.PostEvent(startEvent, gameObject);
        }

        private void OnDestroy()
        {
            AkSoundEngine.PostEvent(stopEvent, gameObject);
        }
    }
}

