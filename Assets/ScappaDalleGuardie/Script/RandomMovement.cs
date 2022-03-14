using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    public scoreScript ScoreScriptInstance;
    public static bool WasGoal { get; private set; }
    public Rigidbody2D rb;
    public float maxSpeed;
    private Rigidbody2D rbFreeze;

    public int value;

    void Start()
    {
        rb.GetComponent<Rigidbody2D>();
        WasGoal = false;
        InvokeRepeating("addRandomForce", 0, 0.5f);
        rbFreeze = gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
    }


    public void addRandomForce()
    {
        Vector2 direction = new Vector2((float)Random.Range(-value, value), (float)Random.Range(-value, value));
        float force = (float)Random.Range(-value, value);
        rb.AddForce(direction * force);
        rbFreeze.constraints = RigidbodyConstraints2D.FreezeRotation;

    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!WasGoal)
        {
            if (other.tag == "PlayerUpGoal")
            {
                StartCoroutine(ResetDisk(false));
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
                ScoreScriptInstance.Increment(scoreScript.Score.PlayerUp);
                WasGoal = true;
            }
            else if (other.tag == "PlayerDownGoal")
            {
                StartCoroutine(ResetDisk(true));
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
                ScoreScriptInstance.Increment(scoreScript.Score.PlayerDown);
                WasGoal = true;
            }
        }
    }

    private IEnumerator ResetDisk(bool didPlayerUpScore)
    {
        yield return new WaitForSecondsRealtime(0.5f);
        rb.constraints = RigidbodyConstraints2D.None;
        WasGoal = false;
        rb.velocity = rb.position = new Vector2(0, 0);
        rb.position = new Vector2(0, 0);
    }
}
