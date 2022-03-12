using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaterDown : MonoBehaviour
{
    public GameObject WaterSliceDown;
    Rigidbody2D rbdown;
    public float startForceDown;
    public GameObject ScoreObject;
    private scoreScript ScoreScriptInstance;

    void Start()
    {
        rbdown = GetComponent<Rigidbody2D>();
        rbdown.AddForce(transform.up * startForceDown, ForceMode2D.Impulse);
        ScoreObject = GameObject.Find("Score");
        ScoreScriptInstance = ScoreObject.GetComponent<scoreScript>();

    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Lame"){

            ScoreScriptInstance.Decrement(scoreScript.Score.PlayerDown);

            Vector3 direction = (col.transform.position - transform.position).normalized;

            Quaternion rotation = Quaternion.LookRotation(direction);
            
            GameObject slicedWaterDown = Instantiate(WaterSliceDown, transform.position, rotation);

            Score.scoreDown -=2;

            Destroy(slicedWaterDown, 2f);
            Destroy(gameObject);

        }
    }

}
