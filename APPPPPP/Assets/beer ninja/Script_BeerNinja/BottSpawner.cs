using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottSpawner : MonoBehaviour
{
    public GameObject bottlePrefab;
    public GameObject bottleWater;

    public Transform[] spawnPoints;
    public Transform[] spawnWater;

    public float minDelay = .1f;
    public float maxDelay = 1f;

    public float minDelayWater = .1f;
    public float maxDelayWater = 1f;

    void Start()
    {
        StartCoroutine(SpawnBottle());
        StartCoroutine(SpawnWater());

    }


    IEnumerator SpawnBottle()
    {
        while(true)
        {
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);

            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];
                
            GameObject spawnedBottle = Instantiate(bottlePrefab, spawnPoint.position, spawnPoint.rotation);
            Destroy(spawnedBottle, 5f);
        }
    }

    IEnumerator SpawnWater()
    {
        while (true)
        {
            float delay = Random.Range(minDelayWater, maxDelayWater);
            yield return new WaitForSeconds(delay);

            int spawnIndex = Random.Range(0, spawnWater.Length);
            Transform spawnPointEnemy = spawnWater[spawnIndex]; ;

            GameObject spawnedBottleWater = Instantiate(bottleWater, spawnPointEnemy.position, spawnPointEnemy.rotation);
            Destroy(spawnedBottleWater, 5f);

        }
    }
}
