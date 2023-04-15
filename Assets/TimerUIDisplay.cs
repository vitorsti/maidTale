using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TimerUIDisplay : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    // Start is called before the first frame update
    void Start()
    {
        //TimerManager.instance.SetTimer(true);
        //StartCoroutine(UpdateText());
       // SetText();
#if !UNITY_EDITOR
        TimerManager.instance.SetTimer(true);
#endif
        
    }

    // Update is called once per frame
    /*void Update()
    {
        SetText(); 
         = true;
    }*/

    void SetText()
    {
        timerText.text = TimerManager.instance.currentTimer.ToString();
    }
    IEnumerator UpdateText()
    {
        //TimerManager.instance.SetTimer(true);
        SetText();
        while (TimerManager.instance.startTimer) {
            SetText();
        }
        yield return null;
    }
}
