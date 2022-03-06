using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchLocationSpritz
{
    public int touchId;
    public GameObject circle;

    public touchLocationSpritz(int newTouchID, GameObject newCircle)
    {
        touchId = newTouchID;
        circle = newCircle;

    }
}
