using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Audio
{
    public class BuildingAudioBehaviour : MonoBehaviour
    {
        private string _buildingTypeSwitch = "Building_Type";
        private string _buildingPositionSwitch = "Building_Position";
        private string[] _buildingPrefix;
        
        private string _startEvent = "Play_Block", _stopEvent = "Stop_Block";

        private void Start()
        {
            _buildingPrefix = new string[6] {"Apartment", "CityHall", "Elevator", "Office", "Power", "Shop"};
            SetBuildingType();
            AkSoundEngine.PostEvent(_startEvent, gameObject);
        }
    
        private void SetBuildingType()
        {
            for(int i = 0; i <= _buildingPrefix.Length; i++)
            {
                if(gameObject.name.Contains(_buildingPrefix[i]))
                {
                    AkSoundEngine.SetSwitch(_buildingTypeSwitch, _buildingPrefix[i], gameObject);
                    break;
                }
            }
        }

        public void SetBuildingPosition(string position)
        {
            AkSoundEngine.SetSwitch(_buildingPositionSwitch, position, gameObject);
        }

        private void OnDestroy()
        {
            AkSoundEngine.PostEvent(_stopEvent, gameObject);
        }
    }
}

