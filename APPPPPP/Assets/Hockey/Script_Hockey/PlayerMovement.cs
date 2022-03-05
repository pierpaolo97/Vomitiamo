using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    /*bool wasJustClicked = true;
    bool canMove;*/
    Vector2 playerSize;
    Rigidbody2D rb;

    public Collider2D playerCollider {get; private set;}
    public playerController Controller;
    public Transform BoundaryHolder;
    public int? LockedFingerID {get; set;}

    Boundary playerBoundary;
    struct Boundary
    {
        public float Up, Down, Left, Right;
        public Boundary(float up, float down, float left, float right)
        {
            Up = up; Down = down; Left = left; Right = right;
        }
    }

    // Use this for initialization
    void Start()
    {
        //playerSize = GetComponent<SpriteRenderer>().bounds.extents;

        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        playerBoundary = new Boundary(BoundaryHolder.GetChild(0).position.y,
                                      BoundaryHolder.GetChild(1).position.y,
                                      BoundaryHolder.GetChild(2).position.x,
                                      BoundaryHolder.GetChild(3).position.x);

    }

    // Update is called once per frame
    /*void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (wasJustClicked)
            {
                wasJustClicked = false;

                if (playerCollider.OverlapPoint(mousePos))
                /*if ((mousePos.x >= transform.position.x && mousePos.x < transform.position.x + playerSize.x ||
                mousePos.x <= transform.position.x && mousePos.x > transform.position.x - playerSize.x) &&
                (mousePos.y >= transform.position.y && mousePos.y < transform.position.y + playerSize.y ||
                mousePos.y <= transform.position.y && mousePos.y > transform.position.y - playerSize.y))
                {
                    canMove = true;
                }
                else
                {
                    canMove = false;
                }
            }

            if (canMove)
            {
                Vector2 clampedMousePos = new Vector2(Mathf.Clamp(mousePos.x, playerBoundary.Left, playerBoundary.Right),
                                                      Mathf.Clamp(mousePos.y, playerBoundary.Down, playerBoundary.Up));
                rb.MovePosition(clampedMousePos);
                //transform.position = mousePos;
            }
        }
        else
        {
            wasJustClicked = true;
        }
    }*/

    private void OnEnable()
    {
        Controller.Players.Add(this);
    }

    private void OnDisable()
    {
        Controller.Players.Remove(this);
    }


    public void MoveToPosition(Vector2 position)
    {
        Vector2 clampedMousePos = new Vector2(Mathf.Clamp(position.x, playerBoundary.Left, playerBoundary.Right),
                                                      Mathf.Clamp(position.y, playerBoundary.Down, playerBoundary.Up));
        rb.MovePosition(clampedMousePos);
    }
}