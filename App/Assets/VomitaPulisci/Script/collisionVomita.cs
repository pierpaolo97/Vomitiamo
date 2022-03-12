using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionVomita : MonoBehaviour
{
    public GameObject ScoreObject;
    private scoreScript ScoreScriptInstance;

    // Start is called before the first frame update
    void Start()
    {
        ScoreObject = GameObject.Find("Score");
        ScoreScriptInstance = ScoreObject.GetComponent<scoreScript>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

        float insta_time = this.gameObject.GetComponent<instantiateTime>().insta_time;
        float time_collider = collision.gameObject.GetComponent<instantiateTime>().insta_time;
        
        if (collision.gameObject.tag != this.gameObject.tag)
        {
            Debug.Log("Insta_Time: " + insta_time + " Time collider: " + time_collider);
            if (insta_time > time_collider)
            {

                Destroy(collision.gameObject);
                Debug.Log("DUUU");
            }
            else
            {
 
                Destroy(this.gameObject);
                Debug.Log("ooooooooo");
            }
        }
    }
}

