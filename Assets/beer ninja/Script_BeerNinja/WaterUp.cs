using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaterUp : MonoBehaviour
{
    public GameObject WaterSliceUp;
    Rigidbody2D rbup;
    public float startForceup;
    public GameObject ScoreObject;
    private scoreScript ScoreScriptInstance;


    void Start()
    {
        rbup = GetComponent<Rigidbody2D>();
        rbup.AddForce(transform.up * startForceup, ForceMode2D.Impulse);
        ScoreObject = GameObject.Find("Score");
        ScoreScriptInstance = ScoreObject.GetComponent<scoreScript>();

    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Lame"){

            ScoreScriptInstance.Decrement(scoreScript.Score.PlayerUp);

            Vector3 direction = (col.transform.position - transform.position).normalized;

            //Quaternion rotation = Quaternion.LookRotation(direction);
            
            GameObject slicedWaterUp = Instantiate(WaterSliceUp, transform.position, transform.rotation);

            Score.scoreUp -=2;

            Destroy(slicedWaterUp, 2f);
            Destroy(gameObject);

        }
    }

}
