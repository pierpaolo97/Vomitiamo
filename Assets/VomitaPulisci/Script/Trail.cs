using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour
{
    //public TrailRenderer trail; //the trail
    //public GameObject TrailFollower;
    public GameObject ColliderPrefab;
    //public Sprite SpriteVomitSin;
    //public Sprite SpriteVomitDes;
    public scoreScript ScoreScriptInstance;

    private Vector3 spawnPosition;
    /*public int poolSize = 200;
    GameObject[] pool;*/

    public GameObject previousPosition;

    private void Start()
    {
        previousPosition.transform.position = new Vector2(0f, 0f);
    }

    void FixedUpdate()
    {
        float dist = Vector2.Distance(this.gameObject.transform.position, previousPosition.transform.position);
        if (this.gameObject.name == "PlayerDown")
        {
            spawnPosition.x = this.gameObject.transform.position.x + 0.16f;
            spawnPosition.y = this.gameObject.transform.position.y - 1f;
            spawnPosition.z = 0.5f;
        }
        if (this.gameObject.name == "PlayerUp")
        {
            spawnPosition.x = this.gameObject.transform.position.x + 0.16f;
            spawnPosition.y = this.gameObject.transform.position.y + 1f;
            spawnPosition.z = 0.5f;
        }

        if (dist > 0.45)
        {

            //this.gameObject.GetComponent<Animator>().enabled = true;

            /*if (Random.value > 0.35){

                GameObject col = Instantiate(ColliderPrefab, spawnPosition, Quaternion.Euler(new Vector3(0, 0, 0)));
                col.transform.localScale = new Vector3(0.13f, 0.13f, 0.13f);
                col.GetComponent<SpriteRenderer>().sprite = SpriteVomitSin;
            }

            else if (Random.value > 0.35)
            {
                GameObject col = Instantiate(ColliderPrefab, spawnPosition, Quaternion.Euler(new Vector3(0, 0, 0)));
                col.transform.localScale = new Vector3(0.13f, 0.13f, 0.13f);
                col.GetComponent<SpriteRenderer>().sprite = SpriteVomitDes;
            }
            else
            {
                GameObject col = Instantiate(ColliderPrefab, spawnPosition, Quaternion.Euler(new Vector3(0, 0, 0)));
                col.transform.localScale = new Vector3(0.13f, 0.13f, 0.13f); 
            }*/

            if (this.gameObject.name == "PlayerDown")
            {
                ScoreScriptInstance.Increment(scoreScript.Score.PlayerDown);
            }
            if (this.gameObject.name == "PlayerUp")
            {
                ScoreScriptInstance.Increment(scoreScript.Score.PlayerUp);
            }

            GameObject col = Instantiate(ColliderPrefab, spawnPosition, Quaternion.Euler(new Vector3(0, 0, 0)));
            col.transform.localScale = new Vector3(0.18f, 0.20f, 0.18f);

            previousPosition.transform.position = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y);

            Debug.Log(previousPosition);

        }

        else 
        {

            //this.gameObject.GetComponent<Animator>().enabled = true;
            Debug.Log("Fermo");
        }
        
        //col.transform.parent = this.gameObject.transform;
    }





    /*void Start()
    {
        trail = GetComponent<TrailRenderer>();
        pool = new GameObject[poolSize];
        for (int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(ColliderPrefab);
            pool[i].transform.parent = this.gameObject.transform;
        }
    }
    

    void Update()
    {
        if (!trail.isVisible)
        {
            for (int i = 0; i < pool.Length; i++)
            {
                pool[i].gameObject.SetActive(false);

            }
        }
        else
        {
            TrailCollission();
        }

    }

    void TrailCollission()
    {
        for (int i = 0; i < pool.Length; i++)
        {
            if (pool[i].gameObject.activeSelf == false)
            {
                pool[i].gameObject.SetActive(true);
                pool[i].gameObject.transform.position = TrailFollower.gameObject.transform.position;
                return;
            }
        }
    }*/
}
