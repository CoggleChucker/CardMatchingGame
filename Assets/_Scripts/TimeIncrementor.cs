using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeIncrementor : MonoBehaviour
{
    public bool stopTime = false;
    public TextMeshProUGUI timeIndicator;

    private float timeElapsed = 0f;

    public void OnEnable()
    {
        timeElapsed = 0f;
    }

    private void Start()
    {
        MyEventsManager.instance.onGameWon += StopTime;
    }

    private void OnDestroy()
    {
        MyEventsManager.instance.onGameWon -= StopTime;
    }
    private void StopTime()
    {
        stopTime = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!stopTime && timeIndicator != null)
        {
            timeElapsed+= Time.deltaTime;
            timeIndicator.text = Mathf.FloorToInt(timeElapsed).ToString();
        }
    }
}
