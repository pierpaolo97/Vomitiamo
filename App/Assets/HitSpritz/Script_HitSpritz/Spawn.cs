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

    public Collider2D[] colliders;
    public float radius;
    


    void Start()
    {
        x_minSpawnDown = -1.5f;
        x_maxSpawnDown = 1.5f;
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
        //InvokeRepeating("SpawnObjectUp", spawnTime, spawnDelay);
    }

    public void SpawnObject()
    {
        y_minSpawnDown = -3.5f;
        y_maxSpawnDown = 3.5f;

        bool canSpawnHere = false;
        while (!canSpawnHere) {

            int x = Random.Range(0, 2);
            spawnPosition.x = Random.Range(x_minSpawnDown, x_maxSpawnDown);
            spawnPosition.y = Random.Range(y_minSpawnDown, y_maxSpawnDown);
            spawnPosition.z = -0.4f;

            canSpawnHere = PreventSpawnOverlap(spawnPosition);

            if (canSpawnHere)
            {
                if (x == 0)
                {
                    instantiateGameObject = spritz;
                }
                else
                {
                    instantiateGameObject = water;
                }

                int ranRotz = Random.Range(-360, 360);
                GameObject objectInstance = Instantiate(instantiateGameObject, spawnPosition, Quaternion.Euler(new Vector3(0, 0, ranRotz)));
                objectInstance.transform.parent = parentDown.transform;
                Destroy(objectInstance, timeDestroy);
            }
        }
        
    }

    /*public void SpawnObjectUp()
    {
        y_minSpawnDown = 1f;
        y_maxSpawnDown = 4f;

        bool canSpawnHere = false;
        
        while (!canSpawnHere)
        {
            int x = Random.Range(0, 2);
            spawnPosition.x = Random.Range(x_minSpawnDown, x_maxSpawnDown);
            spawnPosition.y = Random.Range(y_minSpawnDown, y_maxSpawnDown);
            spawnPosition.z = -0.2f;
            canSpawnHere = PreventSpawnOverlap(spawnPosition);
            Debug.Log(canSpawnHere);
            if (canSpawnHere)
            {
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
       
         
    }*/

    bool PreventSpawnOverlap(Vector3 spawnPos)
    {
        
        colliders = Physics2D.OverlapCircleAll(spawnPos, radius);
        foreach (Collider2D col in colliders)
        {
            // If this collider is tagged "Obstacle"
            if (col.tag == "Spritz" || col.tag == "Water")
            {
                // Then this position is not a valid spawn position
                return false;
            }
        }
       
        
        return true;
    }


}
