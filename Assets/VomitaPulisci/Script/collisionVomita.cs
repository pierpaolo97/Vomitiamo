using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionVomita : MonoBehaviour
{
    public GameObject ScoreObject;
    
    void Awake()
    {
        ScoreObject = GameObject.Find("Score");
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

        float insta_time = this.gameObject.GetComponent<instantiateTime>().insta_time;
        float time_collider = collision.gameObject.GetComponent<instantiateTime>().insta_time;
        
        if (collision.gameObject.tag != this.gameObject.tag)  //aggiungere and per distinguere il collider dei bordi
        {
            if (insta_time > time_collider)
            {
                Destroy(collision.gameObject);
                ScoreObject.GetComponent<scoreScript>().Decrement(scoreScript.Score.PlayerUp);
              
            }
            else
            {
                Destroy(this.gameObject);
                ScoreObject.GetComponent<scoreScript>().Decrement(scoreScript.Score.PlayerDown);               
            }
        }
    }
}

