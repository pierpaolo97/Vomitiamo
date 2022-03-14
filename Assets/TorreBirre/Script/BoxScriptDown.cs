using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScriptDown : MonoBehaviour
{
    private float min_X = -2f, max_X = 2f;

    private bool canMove;
    private float move_Speed = 2f;

    private Rigidbody2D myBodyDown;

    public static bool gameOverDown;
    private bool ignoreCollisionDown;
    private bool ignoreTriggerDown;
    private GameObject[] clones;
    public GameObject ScoreObject;
    private scoreScript ScoreScriptInstance;

    private void Awake()
    {
        myBodyDown = GetComponent<Rigidbody2D>();
        myBodyDown.gravityScale = 0f;

    }

    // Start is called before the first frame update
    void Start()
    {
        ScoreObject = GameObject.Find("Score");
        ScoreScriptInstance = ScoreObject.GetComponent<scoreScript>();
        canMove = true;

        if (Random.Range(0, 2) > 0)
        {
            move_Speed += -1f;
        }
        GameplayController.instanceDown.currentBoxDown = this;
    }

    // Update is called once per frame
    void Update()
    {
        MoveBox();
    }

    void MoveBox()
    {
        if (canMove)
        {
            Vector3 temp = transform.position;
            temp.x += move_Speed * Time.deltaTime;

            if (temp.x > max_X)
            {
                move_Speed += -1f;
            }
            else if (temp.x < min_X)
            {
                move_Speed += 1f;
            }
            transform.position = temp;
        }
    }

    public void DropBoxDown()
    {
        canMove = false;
        myBodyDown.gravityScale = Random.Range(2, 4);
    }

    void Landed()
    {
        if (gameOverDown)
            return;

        ignoreCollisionDown = true;
        ignoreTriggerDown = true;
        GameplayController.instanceDown.SpawnNewBoxDown();
        GameplayController.instanceDown.MoveDown() ;
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if (ignoreCollisionDown)
            return;
        if (target.gameObject.tag == "Platform")
        {
            Invoke("Landed", 2f);
            ignoreCollisionDown = true;
            if (GameplayController.FirstTouchDown == false)
            {
                GameplayController.FirstTouchDown = true;
                ScoreScriptInstance.Increment(scoreScript.Score.PlayerDown);
            }
        }
        if (target.gameObject.tag == "BoxDown")
        {
            Invoke("Landed", 2f);
            ignoreCollisionDown = true;
            ScoreScriptInstance.Increment(scoreScript.Score.PlayerDown);

        }
    }

    public void OnTriggerEnter2D(Collider2D target)
    {
       // if (ignoreTriggerDown)
       //     return;
        if (target.tag == "GameOver")
        {
            Destroy(gameObject);
            CancelInvoke("Landed");
            gameOverDown = true;
            ignoreTriggerDown = true;
            EndGameDown();
        }
    }

    void EndGameDown()
    {
        if (gameOverDown == true)
        {
            clones = GameObject.FindGameObjectsWithTag("BoxDown");
            foreach (GameObject clone in clones)
            {
                Destroy(clone);
            }
        }
    }
}
