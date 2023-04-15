using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    [SerializeField]
    private float defaultTimer;
    public float currentTimer;
    public bool startTimer { get; private set; } = false;
    public static TimerManager instance;
    [Header("---- Debug -----")]
    [SerializeField]
    private bool startTimerDebug;
    private void OnValidate()
    {
        if (startTimerDebug)
        {
            SetTimer(true);
        }
    }
    private void Awake()
    {
        instance = this;
        currentTimer = defaultTimer;
    }
    private void Update()
    {
        /*if (startTimer)
        {
            currentTimer -= Time.deltaTime;
            if (currentTimer <= 0)
            {
                currentTimer = 0;
                startTimer = false;
            }
        }*/
    }

    public void SetTimer(bool value)
    {
        startTimer = value;
        if (value)
           StartCoroutine(StartTimer());
        
        
    }
    IEnumerator StartTimer()
        {
        currentTimer -= 0.1f;
            while (startTimer)
            {
            
            yield return new WaitForSeconds(0.1f);
                currentTimer -= 0.1f;
                if (currentTimer <= 0)
                {
                    currentTimer = 0;
                    startTimer = false;
                }
            }
            
        }
    
    
}
