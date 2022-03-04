using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchLocation : MonoBehaviour
{
    public int touchId;
    public GameObject trail;
    public CircleCollider2D circleCollider;
    public Rigidbody2D rb;

    public touchLocation(int newTouchId, GameObject newTrail, CircleCollider2D newColl, Rigidbody2D newRb)
    {
        touchId = newTouchId;
        trail = newTrail;
        circleCollider = newColl;
        rb = newRb;
    }

}
