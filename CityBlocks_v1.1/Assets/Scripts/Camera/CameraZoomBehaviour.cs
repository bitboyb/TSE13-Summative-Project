using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomBehaviour : MonoBehaviour
{
    public float scrollSpeed = 10f;
    private Camera _camera;
    private SettingsBehaviour _settingsBehaviour;
    
    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();
        _settingsBehaviour = GameObject.Find("SettingsButton").GetComponent<SettingsBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_camera.orthographic)
            _camera.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
        else
        {
            _camera.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
            //_camera.fieldOfView = Mathf.Clamp(_camera.fieldOfView, 10f, 60f);
        }
    }
}
