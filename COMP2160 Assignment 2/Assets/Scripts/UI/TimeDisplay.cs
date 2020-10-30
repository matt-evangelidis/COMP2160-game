using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeDisplay : MonoBehaviour
{
    private Text timeText;
	private TimeSpan timer;
	public TimeSpan Timer
	{
		get
		{
			return timer;
		}
	}

    // Start is called before the first frame update
    void Start()
    {
        timeText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timer = TimeSpan.FromSeconds(Time.timeSinceLevelLoad);

        String text = String.Format("{0:D2}:{1:D2}:{2:D2}", timer.Minutes, timer.Seconds, timer.Milliseconds);

        timeText.text = "Time: " + text;
    }
}
