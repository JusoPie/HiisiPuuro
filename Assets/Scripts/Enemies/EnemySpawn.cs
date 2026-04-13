using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;

    public float spawnTimer = 3;

    // Start is called before the first frame update
    void Start()
    {

        //Instantiate(enemy, transform.position, transform.rotation);
        //Use the line Invoke to get objects spawning randomly
        Invoke("Spawn", 3);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Spawn()
    {
        Instantiate(enemy, transform.position, transform.rotation);
        spawnTimer = Random.Range(1, 10);
        Invoke("Spawn", spawnTimer);
    }
}
