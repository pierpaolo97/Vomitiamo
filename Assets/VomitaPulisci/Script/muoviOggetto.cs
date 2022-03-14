using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyJoystick;

public class muoviOggetto : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Joystick joystick;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float xMovement = joystick.Horizontal();
        float yMovement = joystick.Vertical();

        transform.position += new Vector3(xMovement, yMovement, 0f) * speed * Time.deltaTime;


    }
}
