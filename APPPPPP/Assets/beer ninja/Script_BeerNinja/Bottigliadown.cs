using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottigliadown : MonoBehaviour
{
    public GameObject bottleSlicePrefabdown;
    Rigidbody2D rbdown;
    public float startForcedown;

    void Start()
    {
        rbdown = GetComponent<Rigidbody2D>();
        rbdown.AddForce(transform.up * startForcedown, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Lame"){

            Vector3 direction = (col.transform.position - transform.position).normalized;

            //Quaternion rotation = Quaternion.LookRotation(direction);

            GameObject slicedBottledown = Instantiate(bottleSlicePrefabdown, transform.position, transform.rotation);
            Score.scoreDown++;

            Destroy(slicedBottledown, 2f);
            Destroy(gameObject);

        }
    }

}
