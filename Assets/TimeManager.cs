using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    private int time_minutes = 0;
    private int time_seconds = 0;
    Text text;
    // Start is called before the first frame update
    void Awake()
    {
        // Set up the reference.
        text = GetComponent<Text>();
        time_minutes = 0;
        time_seconds = 0;
}

    // Update is called once per frame
    void Update()
    {
        time_minutes = (int)Time.timeSinceLevelLoad / 60;
        time_seconds = (int)Time.timeSinceLevelLoad % 60;

        if (time_seconds>=10)
        {
            text.text = "Time: " + (time_minutes).ToString() + ':' + (time_seconds).ToString();
        }
        else
        {
            text.text = "Time: " + (time_minutes).ToString() + ':' + '0' + (time_seconds).ToString();
        }
    }
}