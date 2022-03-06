using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject spritz;
    public GameObject water;
    GameObject instantiateGameObject;
    public float y_screen;
    public float x_screen;
    public float x_minSpawnDown;
    public float x_maxSpawnDown;
    public float y_minSpawnDown;
    public float y_maxSpawnDown;
    public Vector3 spawnPosition;
    public float spawnTime = 0;
    public float spawnDelay = 0.5f;
    public float timeDestroy = 1f;
    public GameObject parentDown;
    public GameObject parentUp;

    void Start()
    {
        x_minSpawnDown = -1.8f;
        x_maxSpawnDown = 1.8f;
        InvokeRepeating("SpawnObjectDown", spawnTime, spawnDelay);
        InvokeRepeating("SpawnObjectUp", spawnTime, spawnDelay);
    }

    public void SpawnObjectDown()
    {
        y_minSpawnDown = -4f;
        y_maxSpawnDown = -1f;

        int x = Random.Range(0, 2);
        spawnPosition.x = Random.Range(x_minSpawnDown, x_maxSpawnDown);
        spawnPosition.y = Random.Range(y_minSpawnDown, y_maxSpawnDown);
        spawnPosition.z = -0.2f;
        if (x == 0)
        {
            instantiateGameObject = spritz;
        }
        else
        {
            instantiateGameObject = water;
        }

        GameObject objectInstance = Instantiate(instantiateGameObject, spawnPosition, Quaternion.Euler(new Vector3(0, 0, 0)));
        objectInstance.transform.parent = parentDown.transform;
        Destroy(objectInstance, timeDestroy);
    }

    public void SpawnObjectUp()
    {
        y_minSpawnDown = 1f;
        y_maxSpawnDown = 4f;

        int x = Random.Range(0, 2);
        spawnPosition.x = Random.Range(x_minSpawnDown, x_maxSpawnDown);
        spawnPosition.y = Random.Range(y_minSpawnDown, y_maxSpawnDown);
        spawnPosition.z = -0.2f;
        if (x == 0)
        {
            instantiateGameObject = spritz;
        }
        else
        {
            instantiateGameObject = water;
        }

        GameObject objectInstance = Instantiate(instantiateGameObject, spawnPosition, Quaternion.Euler(new Vector3(0, 0, 180)));   
        objectInstance.transform.parent = parentUp.transform;
        Destroy(objectInstance, timeDestroy);
         
    }


}
