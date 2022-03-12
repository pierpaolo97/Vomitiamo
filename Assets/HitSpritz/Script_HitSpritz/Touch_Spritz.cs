using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Touch_Spritz : MonoBehaviour
{

    public scoreScript ScoreScriptInstance;
    public List<touchLocationSpritz> touchesHit = new List<touchLocationSpritz>();
    public GameObject TouchPrefab;

    private void Update()
    {
        int i = 0;
        while (i < Input.touchCount)
        {
            Touch t = Input.GetTouch(i);
            if (t.phase == TouchPhase.Began)
            {
                Debug.Log("Touch Began");
                touchesHit.Add(new touchLocationSpritz(t.fingerId, createTouch(t), getColliderTouch(t)));
                touchLocationSpritz thisTouch = touchesHit.Find(touchLocationSpritz => touchLocationSpritz.touchId == Input.GetTouch(i).fingerId);

                /*Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
                if (hit != null)
                {
                    if (hit.collider.CompareTag("Spritz"))
                    {
                        if (hit.collider.transform.parent.name == "parentUp")
                        {
                            ScoreScriptInstance.Increment(scoreScript.Score.PlayerUp);
                            Destroy(hit.collider.gameObject);
                        }
                        else
                        {
                            ScoreScriptInstance.Increment(scoreScript.Score.PlayerDown);
                            Destroy(hit.collider.gameObject);
                        }

                    }
                    if (hit.collider.CompareTag("Water"))
                    {
                        {
                            if (hit.collider.transform.parent.name == "parentUp")
                            {
                                ScoreScriptInstance.Decrement(scoreScript.Score.PlayerUp);
                                Destroy(hit.collider.gameObject);
                            }
                            else
                            {
                                ScoreScriptInstance.Decrement(scoreScript.Score.PlayerDown);
                                Destroy(hit.collider.gameObject);
                            }
                        }
                    }

                }*/
            }

            else if (Input.GetTouch(i).phase == TouchPhase.Ended)
            {
                //Debug.Log("Fine" + i);
                touchLocationSpritz thisTouch = touchesHit.Find(touchLocationSpritz => touchLocationSpritz.touchId == Input.GetTouch(i).fingerId);
                touchesHit.RemoveAt(touchesHit.IndexOf(thisTouch));

                Destroy(thisTouch.circle);
            }

            ++i;
        }


        /*if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
                    if (hit != null && hit.collider != null)
                    {
                        Debug.Log("I'm hitting " + hit.collider.name);
                    }
                }
            }
        }*/
    }

    GameObject createTouch(Touch t)
    {
        GameObject c = Instantiate(TouchPrefab) as GameObject;
        c.name = "Touch" + t.fingerId;
        c.transform.position = getTouchPosition(t.position);
        return c;
    }


    CircleCollider2D getColliderTouch(Touch t)
    {
        CircleCollider2D coll = GameObject.Find("Touch" + t.fingerId).GetComponent<CircleCollider2D>();
        return coll;
    }

    Vector2 getTouchPosition(Vector2 touchPosition)
    {
        return Camera.main.ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, transform.position.z));
    }
}
