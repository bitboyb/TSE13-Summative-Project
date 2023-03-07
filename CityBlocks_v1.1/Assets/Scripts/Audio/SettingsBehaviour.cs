using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class SettingsBehaviour : MonoBehaviour
{ 
    private bool _settingsEnabled = false;

    public GameObject volumeSliders;
    public Sprite settingsSprite;
    public Sprite closeSprite;

    public void ToggleSettings()
    {
        if (_settingsEnabled)
        {
            volumeSliders.SetActive(false);
            _settingsEnabled = false;
            gameObject.GetComponent<UnityEngine.UI.Image>().sprite = settingsSprite;
        }
        else
        {
            volumeSliders.SetActive(true);
            _settingsEnabled = true;
            gameObject.GetComponent<UnityEngine.UI.Image>().sprite = closeSprite;
        }
    }

    public bool IsSettingsEnabled()
    {
        return _settingsEnabled;
    }
}
