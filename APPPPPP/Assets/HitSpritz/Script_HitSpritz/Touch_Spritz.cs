using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Touch_Spritz : MonoBehaviour
{

    public scoreScript ScoreScriptInstance;

    private void Update()
    {
        int i = 0;
        while (i < Input.touchCount)
        {
            Touch t = Input.GetTouch(i);
            if (t.phase == TouchPhase.Began)
            {
                Debug.Log("Touch Began");
                Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
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

                }
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
}
