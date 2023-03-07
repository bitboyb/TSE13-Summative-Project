using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SettingsBehaviour : MonoBehaviour
{ 
    public GameObject volumeSliders;
    private bool _settingsEnabled = false;

    public void ToggleSettings()
    {
        if (_settingsEnabled)
        {
            volumeSliders.SetActive(false);
            _settingsEnabled = false;
        }
        else
        {
            volumeSliders.SetActive(true);
            _settingsEnabled = true;
        }
    }
}
