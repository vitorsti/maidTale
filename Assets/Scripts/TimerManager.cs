using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class TimerManager : MonoBehaviour
{
    [SerializeField]
    private float defaultTimer;
    public float currentTimer;
    [SerializeField]
    private TextMeshProUGUI timerText;
    public bool startTimer { get; private set; } = false;
    public static TimerManager instance;
    [Header("---- Debug -----")]
    [SerializeField]
    private bool startTimerDebug;
    private void OnValidate()
    {
        //if (startTimerDebug)
        //{
        startTimer = startTimerDebug;
        if (startTimer)
        {
            //StartCoroutine(CountDown());
            StartTimer();
        }
        else
        {
            StopTimer();
        }
        //}
    }
    private void Awake()
    {
        instance = this;
        currentTimer = defaultTimer;

        UpdateTextime();
    }

    public void SetTimer(bool value)
    {
        startTimer = value;
    }
    void UpdateTextime()
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(currentTimer); 
        timerText.text = timeSpan.Minutes.ToString("00") + ":" + timeSpan.Seconds.ToString("00");
        
        //string niceTime = "";
        //niceTime = timeSpan.Minutes.ToString("00") + ":" + timeSpan.Seconds.ToString("00");
        /*if (timeSpan.Minutes >= 10)
            niceTime = string.Format("{0,2}:{1}", timeSpan.Minutes, timeSpan.Seconds);
        else
            niceTime = string.Format("0{0}:{1}", timeSpan.Minutes, timeSpan.Seconds);*/
        
        //timerText.text = niceTime;
    }
    public void StopTimer()
    {
        StopAllCoroutines();
    }

    public void StartTimer()
    {
        StartCoroutine(CountDown());
    }
    IEnumerator CountDown()
    {

        while (currentTimer > 0)
        {

            //yield return new WaitForSeconds(0.1f);
            currentTimer -= Time.deltaTime * 1f;
            UpdateTextime();
            if (currentTimer <= 0)
            {
                currentTimer = 0;
                UpdateTextime();
                //yield return null;
            }
            yield return null;
        }

    }


}
