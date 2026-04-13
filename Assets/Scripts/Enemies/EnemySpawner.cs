using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float spawnRate = 10f;
    [SerializeField] private float minSpawnRate = 1f;
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private bool canSpawn = true;
    public UITimer uITimer;

    private float nextRateDecreaseTime = 30f;

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    private void Update()
    {
        if (uITimer.Timer >= nextRateDecreaseTime)
        {
            spawnRate = Mathf.Max(minSpawnRate, spawnRate - 1f);
            nextRateDecreaseTime += 30f;
        }
    }

    private IEnumerator Spawner()
    {
        while (canSpawn)
        {
            yield return new WaitForSeconds(spawnRate);
            int rand = Random.Range(0, enemyPrefabs.Length);
            Instantiate(enemyPrefabs[rand], transform.position, Quaternion.identity);
        }
    }
}
