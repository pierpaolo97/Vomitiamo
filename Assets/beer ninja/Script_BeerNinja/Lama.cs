using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Lama : MonoBehaviour
{
    Camera cam;
    public GameObject LamaTrail;
    public List<touchLocation> touches = new List<touchLocation>();

    bool isCutting = false;
    GameObject currentBladeTrail;

    Vector2 previousPosition;
    public float minCuttingVelocity = .01f;

    public static bool check;

    private void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {

        var tapCount = Input.touchCount;
        //Debug.Log(Input.touchCount);



        for (var i = 0; i < tapCount; i++)
        {

            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                //Debug.Log("Inizio" + i);
                touches.Add(new touchLocation(Input.GetTouch(i).fingerId, createTrail(Input.GetTouch(i)), getCollider(Input.GetTouch(i)), getRb(Input.GetTouch(i))));

                isCutting = true;
                touchLocation thisTouch = touches.Find(touchLocation => touchLocation.touchId == Input.GetTouch(i).fingerId);
                //thisTouch.circleCollider.enabled = true;

                previousPosition = getTouchPosition(Input.GetTouch(i).position);

            }
            else if (Input.GetTouch(i).phase == TouchPhase.Ended)
            {
                //Debug.Log("Fine" + i);
                touchLocation thisTouch = touches.Find(touchLocation => touchLocation.touchId == Input.GetTouch(i).fingerId);
                touches.RemoveAt(touches.IndexOf(thisTouch));
                isCutting = true;

                Destroy(thisTouch.trail);
            }
            else if (Input.GetTouch(i).phase == TouchPhase.Moved)
            {
                //Debug.Log("Muove" + i);
                touchLocation thisTouch = touches.Find(touchLocation => touchLocation.touchId == Input.GetTouch(i).fingerId);
                Vector2 newPosition = thisTouch.trail.transform.position = getTouchPosition(Input.GetTouch(i).position);

                var direction = newPosition - previousPosition;
                if (direction.x >= 0)
                {
                    Debug.Log("DESTRA");
                    check = true;
                }
                else
                {
                    Debug.Log("SINISTRA");
                    check = false;

                }

                //thisTouch.rb.position = newPosition;
                float velocity = (newPosition - previousPosition).magnitude * Time.deltaTime;
                if (velocity > minCuttingVelocity)
                {
                    thisTouch.circleCollider.enabled = true;
                }else
                {
                    thisTouch.circleCollider.enabled = false;
                }
                previousPosition = newPosition;

       
            }
        }


        Vector2 getTouchPosition(Vector2 touchPosition)
        {
            return cam.ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, transform.position.z));
        }

        GameObject createTrail(Touch t)
        {
            GameObject c = Instantiate(LamaTrail) as GameObject;
            c.name = "Touch" + t.fingerId;
            c.transform.position = getTouchPosition(t.position);

            return c;
        }

        CircleCollider2D getCollider(Touch t)
        {
            CircleCollider2D coll = GameObject.Find("Touch" + t.fingerId).GetComponent<CircleCollider2D>();
            return coll;
        }

        Rigidbody2D getRb(Touch t)
        {
            Rigidbody2D rb = GameObject.Find("Touch" + t.fingerId).GetComponent<Rigidbody2D>();
            return rb;

        }


        /*if (Input.GetMouseButtonDown(0))
        {
            StartCutting();

        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopCutting();
        }
        if (isCutting)
        {
            UpdateCut();
        }*/

    }

}
