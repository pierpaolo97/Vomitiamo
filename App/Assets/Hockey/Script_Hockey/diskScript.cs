using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diskScript : MonoBehaviour
{
    public scoreScript ScoreScriptInstance;
    public static bool WasGoal { get; private set; }
    public Rigidbody2D rb;
    public float maxSpeed;
    public AudioSource audioSource;
    public ParticleSystem Impact;

    void Start()
    {
        rb.GetComponent<Rigidbody2D>();
        WasGoal = false;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {


        Debug.Log(other.tag);
        if (!WasGoal)
        {
            if(other.tag == "PlayerUpGoal")
            {
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
                ScoreScriptInstance.Increment(scoreScript.Score.PlayerDown);
                WasGoal = true;
                StartCoroutine(ResetDisk(false));
                audioSource.Play();
            }
            else if (other.tag == "PlayerDownGoal")
            {
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
                ScoreScriptInstance.Increment(scoreScript.Score.PlayerUp);
                WasGoal = true;
                StartCoroutine(ResetDisk(true));
                audioSource.Play();
            }

        }

    }

    private void FixedUpdate()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
    }

    private IEnumerator ResetDisk(bool didPlayerUpScore)
    {
        yield return new WaitForSecondsRealtime(1);
        rb.constraints = RigidbodyConstraints2D.None;
        WasGoal = false;
        rb.velocity = rb.position = new Vector2(0, 0);

        if (didPlayerUpScore)
            rb.position = new Vector2(0, -1);
        else
            rb.position = new Vector2(0, 1);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pedine")
        {
            Impact.Play();
            /*ContactPoint2D[] contacts = new ContactPoint2D[10];

            // Get the contact points for this collision
            int numContacts = collision.GetContacts(contacts);

            // Iterate through each contact point
            for (int i = 0; i < numContacts; i++)
            {
                Colpo = Instantiate(BumAnim, transform.position, transform.rotation);
                Destroy(Colpo, 2f);
            }*/
        }

    }


}

