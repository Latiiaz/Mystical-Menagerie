using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering;


public class DayNightSystem : MonoBehaviour
{
    public TextMeshProUGUI displayTime;
    public TextMeshProUGUI displayDay;


    [SerializeField] public float tickSpeed = 5f; //Controls how fast time pasts

    [SerializeField] public float seconds;
    [SerializeField] public float minutes;
    [SerializeField] public float hours;

    [SerializeField] public float days; // 1-7 Sunday - Saturday



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        TimeStatus();
        DisplayTime();
    }

    public void TimeStatus()
    {
        seconds += Time.deltaTime * tickSpeed;

        if (seconds >= 60) // 60 sec = 1 min
        {
            seconds = 0;
            minutes += 1;
        }

        if (minutes >= 60) //60 min = 1 hr
        {
            minutes = 0;
            hours += 1;
        }

        if (hours >= 24) //24 hr = 1 day
        {
            hours = 0;
            days += 1;
        }
    }

    public void DisplayTime()
    {
        displayTime.text = string.Format("{0:00}:{1:00}", hours, minutes);
    }


}
