using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;

    public float spawnTimer = 3;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Spawn", 3);
    }


    void Spawn()
    {
        Instantiate(enemy, transform.position, transform.rotation);
        spawnTimer = Random.Range(1, 10);
        Invoke("Spawn", spawnTimer);
    }
}
