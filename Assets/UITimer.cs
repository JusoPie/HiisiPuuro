using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITimer : MonoBehaviour
{
    public Text TimerText;
    public Text BestTimeText;
    private float Timer;
    private float BestTime;

    private void Start()
    {
        // Load the best time from PlayerPrefs
        BestTime = PlayerPrefs.GetFloat("BestTime", 0f);
        UpdateBestTimeText();
        Timer = 0f; // Initialize timer to start from 0
    }

    void Update()
    {
        Timer += Time.deltaTime;
        UpdateTimerText();
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(Timer / 60F);
        int seconds = Mathf.FloorToInt(Timer % 60F);
        int milliseconds = Mathf.FloorToInt((Timer * 100F) % 100F);
        TimerText.text = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliseconds.ToString("00");
    }

    void UpdateBestTimeText()
    {
        int minutes = Mathf.FloorToInt(BestTime / 60F);
        int seconds = Mathf.FloorToInt(BestTime % 60F);
        int milliseconds = Mathf.FloorToInt((BestTime * 100F) % 100F);
        BestTimeText.text = "Best Time: " + minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliseconds.ToString("00");
    }

    public void StopTimer()
    {
        // Save the new best time if the current time is better
        if (Timer < BestTime || BestTime == 0)
        {
            BestTime = Timer;
            PlayerPrefs.SetFloat("BestTime", BestTime);
            UpdateBestTimeText();
        }
    }
}
