using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Audio
{
    public class WwiseSliderBehaviour : MonoBehaviour
    {
        private Slider _masterVolumeSlider;
        private Slider _musicVolumeSlider;
        private Slider _sfxVolumeSlider;
        private Slider _uiVolumeSlider;
        private bool _settingsEnabled;
        
        private string[] _rtpcNames = {"Master_Volume", "Music_Volume", "SFX_Volume", "UI_Volume"};

        private void OnEnable()
        {
            _settingsEnabled = true;
            GetSliders();
            AddSliderListeners();
            LoadRTPCVolumes();
        }

        private void OnDisable()
        {
            _settingsEnabled = false;
            RemoveSliderListeners();
        }

        private void GetSliders()
        {
            _masterVolumeSlider = GameObject.Find("MasterVolumeSlider").GetComponent<Slider>();
            _musicVolumeSlider = GameObject.Find("MusicVolumeSlider").GetComponent<Slider>();
            _sfxVolumeSlider = GameObject.Find("SFXVolumeSlider").GetComponent<Slider>();
            _uiVolumeSlider = GameObject.Find("UIVolumeSlider").GetComponent<Slider>();
        }

        private void AddSliderListeners()
        {
            _masterVolumeSlider.onValueChanged.AddListener(delegate { SetRTPCVolume("Master_Volume", _masterVolumeSlider.value); });
            _musicVolumeSlider.onValueChanged.AddListener(delegate { SetRTPCVolume("Music_Volume", _musicVolumeSlider.value); });
            _sfxVolumeSlider.onValueChanged.AddListener(delegate { SetRTPCVolume("SFX_Volume", _sfxVolumeSlider.value); });
            _uiVolumeSlider.onValueChanged.AddListener(delegate { SetRTPCVolume("UI_Volume", _uiVolumeSlider.value); });
        }

        private void RemoveSliderListeners()
        {
            _masterVolumeSlider.onValueChanged.RemoveAllListeners();
            _musicVolumeSlider.onValueChanged.RemoveAllListeners();
            _sfxVolumeSlider.onValueChanged.RemoveAllListeners();
            _uiVolumeSlider.onValueChanged.RemoveAllListeners();
        }

        private void SetRTPCVolume(string rptcName, float volume)
        {
            AkSoundEngine.SetRTPCValue(rptcName, volume);
            SaveRTPCVolume(rptcName, volume);
        }
        
        private void SaveRTPCVolume(string rptcName, float volume)
        {
            PlayerPrefs.SetFloat(rptcName, volume);
        }
        
        private void LoadRTPCVolumes()
        {
            foreach(string rtpcName in _rtpcNames)
            {
                if (!PlayerPrefs.HasKey(rtpcName))
                {
                    Debug.Log("No RTPC volume found for " + rtpcName + ". Setting to 1f");
                    PlayerPrefs.SetFloat(rtpcName, 1f);
                }
            }
            
            _masterVolumeSlider.value = PlayerPrefs.GetFloat("Master_Volume");
            _musicVolumeSlider.value = PlayerPrefs.GetFloat("Music_Volume");
            _sfxVolumeSlider.value = PlayerPrefs.GetFloat("SFX_Volume");
            _uiVolumeSlider.value = PlayerPrefs.GetFloat("UI_Volume");
        }
        
        private void ClearRTPCVolumes()
        {
            foreach(string rtpcName in _rtpcNames)
            {
                PlayerPrefs.DeleteKey(rtpcName);
            }
            
            LoadRTPCVolumes();
        }
        
        public bool IsSettingsEnabled()
        {
            return _settingsEnabled;
        }
    }
}

