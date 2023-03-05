using UnityEngine;
using UnityEngine.UI;

public class TimeOfDayBehaviour : MonoBehaviour
{
    // Rotation angle for one cycle
    private float rotationAngle = 15f;
    // Time for one cycle
    private float rotationTime = 5f;
    // Current rotation angle
    private float currentAngle = 0f;
    // Time elapsed since last rotation
    private float elapsedTime = 0f;
    // The TimeText UI element
    private Text _timeText;
    
    public int timeOfDay = 6;

    private void Start()
    {
        _timeText = GameObject.Find("TimeText").GetComponent<Text>();
        UpdateTimeText();
    }

    // Update is called once per frame
    private void Update()
    {
        // If the rotation angle has been reached, add one to the time of day
        if (currentAngle == 0)
        {
            timeOfDay++;
            UpdateTimeText();
        }

        // If the time of day is 24, reset it to 0
        if (timeOfDay == 24)
        {
            timeOfDay = 0;
            UpdateTimeText();
        }

        // Increment the elapsed time
        elapsedTime += Time.deltaTime;

        // Calculate the rotation angle based on the elapsed time and rotation time
        float t = elapsedTime / rotationTime;
        float angle = Mathf.Lerp(0f, rotationAngle, t);

        // Calculate the delta angle since the last frame
        float deltaAngle = angle - currentAngle;

        // Rotate the object by the delta angle
        transform.Rotate(deltaAngle, 0f, 0f);

        // Update the current angle
        currentAngle = angle;

        // If the rotation time has elapsed, reset the elapsed time and current angle
        if (elapsedTime >= rotationTime)
        {
            elapsedTime = 0f;
            currentAngle = 0f;
        }
    }

    private void UpdateTimeText()
    {
        _timeText.text = timeOfDay.ToString("00") + ":00";
    }
}