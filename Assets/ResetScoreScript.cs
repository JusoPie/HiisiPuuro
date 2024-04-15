using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResetScoreScript : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public void OnResetHighScoreClick()
    {
        PlayerPrefs.DeleteKey("BestTime"); // Delete the BestTime PlayerPrefs key
        PlayerPrefs.Save(); // Save the PlayerPrefs
        ScoreText.text = "Best Time: 00:00:00";
        Debug.Log("High Score Reset!"); // Log a message to the console
    }
}
