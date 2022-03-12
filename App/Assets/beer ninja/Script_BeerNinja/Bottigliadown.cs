using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottigliadown : MonoBehaviour
{
    public GameObject bottleSlicePrefabdown;
    Rigidbody2D rbdown;
    public float startForcedown;
    public GameObject ScoreObject;
    private scoreScript ScoreScriptInstance;

    void Start()
    {
        rbdown = GetComponent<Rigidbody2D>();
        rbdown.AddForce(transform.up * startForcedown, ForceMode2D.Impulse);
        ScoreObject = GameObject.Find("Score");
        ScoreScriptInstance = ScoreObject.GetComponent<scoreScript>();

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Lame"){

            ScoreScriptInstance.Increment(scoreScript.Score.PlayerDown);


            Vector3 direction = (col.transform.position - transform.position).normalized;

            //Quaternion rotation = Quaternion.LookRotation(direction);

            GameObject slicedBottledown = Instantiate(bottleSlicePrefabdown, transform.position, transform.rotation);
            //Score.scoreDown++;


            Destroy(slicedBottledown, 2f);
            Destroy(gameObject);

        }
    }

}
