using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScriptUp : MonoBehaviour
{
    private float min_X = -2f, max_X = 2f;

    private bool canMove;
    private float move_Speed = 4f;

    private Rigidbody2D myBodyUp;

    public static bool gameOverUp;
    private bool ignoreCollisionUp;
    private bool ignoreTriggerUp;
    private GameObject[] clones;
    public GameObject ScoreObject;
    private scoreScript ScoreScriptInstance;


    private void Awake()
    {
        myBodyUp = GetComponent<Rigidbody2D>();
        myBodyUp.gravityScale = 0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        ScoreObject = GameObject.Find("Score");
        ScoreScriptInstance = ScoreObject.GetComponent<scoreScript>();
        canMove = true;

        if (Random.Range(0, 4) > 0)
        {
            move_Speed += -1f;
        }
        GameplayController.instanceUp.currentBoxUp = this;
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

    public void DropBoxUp()
    {
        canMove = false;
        myBodyUp.gravityScale = Random.Range(-2, -4);
    }

    void Landed()
    {
        if (gameOverUp)
            return;

        ignoreCollisionUp = true;
        ignoreTriggerUp = true;
        GameplayController.instanceUp.SpawnNewBoxUp();
        GameplayController.instanceUp.MoveUp();
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if (ignoreCollisionUp)
            return;
        if (target.gameObject.tag == "Platform")
        {
            Invoke("Landed", 2f);
            ignoreCollisionUp = true;
            if (GameplayController.FirstTouchUp == false)
            {
                GameplayController.FirstTouchUp = true;
                ScoreScriptInstance.Increment(scoreScript.Score.PlayerUp);
            }

        }
        if (target.gameObject.tag == "BoxUp")
        {
            Invoke("Landed", 2f);
            ignoreCollisionUp = true;
            ScoreScriptInstance.Increment(scoreScript.Score.PlayerUp);
        }
    }

    public void OnTriggerEnter2D(Collider2D target)
    {
        //if (ignoreTriggerUp)
           // return;
        if (target.tag == "GameOver")
        {
            CancelInvoke("Landed");
            gameOverUp = true;
            ignoreTriggerUp = true;
            EndGameUp();
        }
    }
    void EndGameUp()
    {
        if (gameOverUp == true)
        {
            clones = GameObject.FindGameObjectsWithTag("BoxUp");
            foreach (GameObject clone in clones)
            {
                Destroy(clone);
            }
        }
    }
}
