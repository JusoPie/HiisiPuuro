using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToGame : MonoBehaviour
{
    private GameManager gm;

    private void Start()
    {
        gm = GameObject.Find("GM").GetComponent<GameManager>();
    }

    public void LoadScene(string SampleScene)
    {
        SceneManager.LoadScene(SampleScene);
    }
}
