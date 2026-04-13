using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MainMenuHighScore : MonoBehaviour
{
    public TextMeshProUGUI HighScoreText;

    void Start()
    {
        // Load the best time from PlayerPrefs
        float bestTime = PlayerPrefs.GetFloat("BestTime", 0f);

        // Convert bestTime to minutes, seconds, and milliseconds
        int minutes = Mathf.FloorToInt(bestTime / 60F);
        int seconds = Mathf.FloorToInt(bestTime % 60F);
        int milliseconds = Mathf.FloorToInt((bestTime * 100F) % 100F);

        // Set the HighScoreText to display the high score
        HighScoreText.text = "Best Time: " + minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliseconds.ToString("00");
    }
}

