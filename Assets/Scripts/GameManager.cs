using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //public GameObject[] enemySpawner;
    //public GameObject player;

    public Animator fadeScreen;
    public float transitionTime = 1f;
    public Animator camerarotate;

    public static GameManager gameManager;

    //public void SpawnEnemyZone()
    //{
    //    int rnd = Random.Range(0, 4);
    //    Instantiate(enemySpawner[rnd], new Vector3(
    //        player.transform.position.x,
    //        player.transform.position.y,
    //        player.transform.position.z),
    //        player.transform.rotation);
    //}
}


