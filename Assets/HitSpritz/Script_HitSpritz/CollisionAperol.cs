using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionAperol : MonoBehaviour
{
    //public scoreScript ScoreScriptInstance;
    public GameObject ScoreObject;
    private scoreScript ScoreScriptInstance;
    public GameObject Rotta;

    void Start()
    {
        ScoreObject = GameObject.Find("Score");
        ScoreScriptInstance = ScoreObject.GetComponent<scoreScript>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Touch")
        {
            ScoreScriptInstance.Increment(scoreScript.Score.PlayerDown);

            GameObject RottaBottle = Instantiate(Rotta, transform.position, transform.rotation);

            Destroy(gameObject);
            Destroy(RottaBottle, 0.5f);

            /*if(transform.parent.name == "parentUp")
            {
                scoreObject.GetComponent<Score>().penaltyPlayerUp();
                //Score.scoreUp--;
                //Debug.Log("PUNTOOOOO SUUU");
                Destroy(gameObject);

            }
            else
            {
                scoreObject.GetComponent<Score>().penaltyPlayerDown();
                //Score.scoreDown--;
                //Debug.Log("PUNTOOOOO GIUUU");
                Destroy(gameObject);
            }*/
        }
    }
}
