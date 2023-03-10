using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DayNightCycle
{
    public class BuildingLightBehaviour : MonoBehaviour
    {
        private GameSettings _gameSettings;
        private TimeOfDayBehaviour _timeOfDayBehaviour;
        [SerializeField] private string _lastTimeOfDayState = "Morning";
        private int lastCount = 0;
        
        public float morningLightIntensity = 0f;
        public float eveningLightIntensity = 4f;
        
        private void Start()
        {
            _gameSettings = GameObject.Find("GameManager").GetComponent<GameSettings>();
            _timeOfDayBehaviour = GameObject.Find("GameManager").GetComponent<TimeOfDayBehaviour>();
        }

        private void Update()
        {
            if (_gameSettings.createdBuildings.Count > lastCount)
            {
                lastCount++;
                ChangeShaderIllumination();
            }
                
            if(_lastTimeOfDayState != _timeOfDayBehaviour.GetTimeOfDayState())
            {
                ChangeShaderIllumination();
            }
        }

        private void ChangeShaderIllumination()
        {
            _lastTimeOfDayState = _timeOfDayBehaviour.GetTimeOfDayState();

            foreach (var building in _gameSettings.createdBuildings)
            {
                var buildingRenderer = gameObject.GetComponent<MeshRenderer>();
                
                if (building.name.StartsWith("Shop"))
                {
                    buildingRenderer = building.transform.GetChild(3).GetComponent<MeshRenderer>();
                }
                else if (building.name.StartsWith("Elevator"))
                {
                    buildingRenderer = building.transform.GetChild(2).GetComponent<MeshRenderer>();
                }
                else if (building.name.StartsWith("Apartment"))
                {
                    buildingRenderer = building.transform.GetChild(0).GetComponent<MeshRenderer>();
                }
                else
                {
                    continue;
                }

                if (_timeOfDayBehaviour.GetTimeOfDayState() == "Morning" || _timeOfDayBehaviour.GetTimeOfDayState() == "Afternoon")
                {
                    buildingRenderer.material.SetFloat("_IlluminationPower", morningLightIntensity);
                }
                else
                {
                    buildingRenderer.material.SetFloat("_IlluminationPower", eveningLightIntensity);
                }
            }
        }
    }
}
