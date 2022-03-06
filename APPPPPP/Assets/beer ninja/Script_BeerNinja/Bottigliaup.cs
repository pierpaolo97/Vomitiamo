using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bottigliaup : MonoBehaviour
{
    public GameObject bottleSlicePrefabup;
    Rigidbody2D rbup;
    public float startForceup;


    void Start()
    {
        rbup = GetComponent<Rigidbody2D>();
        rbup.AddForce(transform.up * startForceup, ForceMode2D.Impulse);
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Lame"){


            Vector3 direction = (col.transform.position - transform.position).normalized;

            //Quaternion rotation = Quaternion.LookRotation(direction);
            
            GameObject slicedBottleup = Instantiate(bottleSlicePrefabup, transform.position, transform.rotation);

            Score.scoreUp++;

            Destroy(slicedBottleup, 2f);
            Destroy(gameObject);

        }
    }

}
