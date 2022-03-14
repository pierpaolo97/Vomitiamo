using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
    public Camera cam;
    public static GameplayController instanceUp;
    public static GameplayController instanceDown;
    public Follow followScriptUp;
    public Follow followScriptDown;

    public BoxSpawn box_SpawnerUp;
    public BoxSpawn box_SpawnerDown;
    public BoxScriptUp currentBoxUp;
    public BoxScriptDown currentBoxDown;
    private int moveCountUp;
    private int moveCountDown;
    public GameObject fineDown;
    public GameObject fineUp;
    public static bool FirstTouchUp = false;
    public static bool FirstTouchDown = false;


    void Awake()
    {

        if (instanceDown == null)
            instanceDown = this;
        if (instanceUp == null)
            instanceUp = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        box_SpawnerUp.SpawnBox();
        box_SpawnerDown.SpawnBox();
    }

    // Update is called once per frame
    void Update()
    {
        if (BoxScriptUp.gameOverUp == true)
        {
            fineUp.SetActive(true);
        }
        if (BoxScriptDown.gameOverDown == true)
        {
            fineDown.SetActive(true);
        }
        DetectInput();
    }

    void DetectInput()
    {
        Touch[] touches = Input.touches;
        for (int i = 0; i < Input.touchCount; i++)
        {
            if (getTouchPosition(touches[i].position).y > 0)
            {
                currentBoxUp.DropBoxUp();
            }
            else
            {
                currentBoxDown.DropBoxDown();

            }
        }
    }
    Vector2 getTouchPosition(Vector2 touchPosition)
    {
        return cam.ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, transform.position.z));
    }

    public void SpawnNewBoxUp()
    {
        NewBoxUp();
    }
    public void SpawnNewBoxDown()
    {
        NewBoxDown();
    }
    public void NewBoxUp()
    {
        box_SpawnerUp.SpawnBox();
    }
    public void NewBoxDown()
    {
        box_SpawnerDown.SpawnBox();
    }

    public void MoveUp()
    {
        moveCountUp++;

        if (moveCountUp == 2)
        {
            moveCountUp = 0;
            followScriptUp.targetPos.y += 1f;
        }
    }

    public void MoveDown()
    {
        moveCountDown++;

        if (moveCountDown == 2)
        {
            moveCountDown = 0;
            followScriptDown.targetPos.y -= 1f;
        }
    }

}

