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
                //ChangeShaderIllumination();
            }
                
            if(_lastTimeOfDayState != _timeOfDayBehaviour.GetTimeOfDayState())
            {
                //ChangeShaderIllumination();
            }
        }

        private void ChangeShaderIllumination()
        {
            //TODO: BuildingsVertexColour.shader has a float on line 41 I wish to change depending on the state of the day :(
            
            _lastTimeOfDayState = _timeOfDayBehaviour.GetTimeOfDayState();

            foreach (var building in _gameSettings.createdBuildings)
            {
                var buildingRenderer = building.GetComponent<Renderer>();
                
                if (building.name.StartsWith("Shop"))
                {
                    buildingRenderer = building.transform.GetChild(3).GetComponent<Renderer>();
                }
                else
                {
                    buildingRenderer = building.transform.GetChild(0).GetComponent<Renderer>();
                }


                var buildingShaderProperty = "_IlluminationPower";
                var buildingShaderValue = 0f;

                if (_timeOfDayBehaviour.GetTimeOfDayState() == "Morning" || _timeOfDayBehaviour.GetTimeOfDayState() == "Afternoon")
                {
                    buildingShaderValue = morningLightIntensity;
                }
                else
                {
                    buildingShaderValue = eveningLightIntensity;    
                }

                buildingRenderer.material.SetFloat(buildingShaderProperty, buildingShaderValue);
            }
        }
    }
}
