using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndShoot : MonoBehaviour
{
    public float power = 10f;
    public Rigidbody2D rb;

    public Vector2 minPower;
    public Vector2 maxPower;

    //TrajectoryLine tl;
    Camera cam;
    Vector2 force;
    Vector3 startPoint;
    Vector3 endPoint;
    public GameObject tl;

    private void Start()
    {
        cam = Camera.main;
        
        //tl.GetComponent<TrajectoryLine>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            startPoint.z = 15;
            
        }

        /*if (Input.GetMouseButton(0))
        {
            Vector3 currentPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            startPoint.z = 15;
            tl.GetComponent<TrajectoryLine>().RenderLine(startPoint, endPoint);
            //tl.RenderLine(startPoint, currentPoint);
        }*/

        if (Input.GetMouseButtonUp(0))
        {
            endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            endPoint.z = 15;
            //force = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x), Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y));
            if (startPoint.y < 0 && this.gameObject.transform.position.y < 0)
            { 
                force = new Vector2(Mathf.Clamp(endPoint.x - startPoint.x, minPower.x, maxPower.x), Mathf.Clamp(endPoint.y - startPoint.y, minPower.y, maxPower.y));
                rb.AddForce(force * power, ForceMode2D.Impulse);
            }
            else if (startPoint.y > 0 && this.gameObject.transform.position.y > 0)
            {
                force = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x), Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y));
                rb.AddForce(-force * power, ForceMode2D.Impulse);
            }
            
        }
    }
}
