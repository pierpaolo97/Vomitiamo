using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchLocationSpritz
{
    public int touchId;
    public GameObject circle;
    public CircleCollider2D circleCollider;

    public touchLocationSpritz(int newTouchID, GameObject newCircle, CircleCollider2D newColl)
    {
        touchId = newTouchID;
        circle = newCircle;
        circleCollider = newColl;

    }
}
