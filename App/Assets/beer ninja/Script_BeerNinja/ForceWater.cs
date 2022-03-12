using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceWater : MonoBehaviour
{
    Rigidbody rbWater;


    public float ForceRightDown;
    public float ForceUPDown;
    public float ForceTappo;


    void Start()
    {
        rbWater = GetComponent<Rigidbody>();
        //down
        if (Lama.check == false & transform.position.y < 0)
        {

            rbWater.AddForce(transform.right * -ForceRightDown, ForceMode.Impulse);
            rbWater.AddTorque(0, 0, -0.5f, ForceMode.Impulse);
        }
        else if (Lama.check == true & transform.position.y < 0)
        {
            rbWater.AddForce(transform.right * ForceRightDown, ForceMode.Impulse);
            rbWater.AddTorque(0, 0, 0.5f, ForceMode.Impulse);
        }

        //up
        if (Lama.check == true & transform.position.y > 0)
        {
            rbWater.AddForce(transform.right * ForceRightDown, ForceMode.Impulse);
            rbWater.AddTorque(0, 0, 0.5f, ForceMode.Impulse);
        }
        else if (Lama.check == false & transform.position.y > 0)
        {
            rbWater.AddForce(transform.right * -ForceRightDown, ForceMode.Impulse);
            rbWater.AddTorque(0, 0, -0.5f, ForceMode.Impulse);
        }


        rbWater.AddForce(transform.up * ForceUPDown, ForceMode.Impulse);
    }

}
