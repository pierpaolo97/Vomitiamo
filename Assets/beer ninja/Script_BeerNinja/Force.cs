using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force : MonoBehaviour
{
    public Rigidbody rbTappo;
    Rigidbody rbSotto;
    Rigidbody rbBolle;


    public float ForceRightDown;
    public float ForceUPDown;
    public float ForceTappo;


    void Start()
    {
        rbTappo = transform.GetChild(0).GetComponent<Rigidbody>();
        rbSotto = transform.GetChild(1).GetComponent<Rigidbody>();
        rbBolle = transform.GetChild(2).GetComponent<Rigidbody>();


        //if (Random.value < 0.5f)
        //down
        if (Lama.check == false & transform.position.y < 0)
        {
            ForzaDestra();

        }
        else if (Lama.check == true & transform.position.y < 0)
        {
            ForzaSinistra();

        }

        //up
        if (Lama.check == true & transform.position.y > 0)
        {
            ForzaDestra();

        }
        else if (Lama.check == false & transform.position.y > 0)
        {
            ForzaSinistra();

        }

        rbTappo.AddForce(transform.up * ForceTappo, ForceMode.Impulse);
        rbBolle.AddForce(transform.up * ForceUPDown, ForceMode.Impulse);
        rbSotto.AddForce(transform.up * ForceUPDown, ForceMode.Impulse);
    }

    void ForzaDestra()
    {
        rbSotto.AddForce(transform.right * ForceRightDown, ForceMode.Impulse);
        rbBolle.AddForce(transform.right * ForceRightDown, ForceMode.Impulse);
        rbSotto.AddTorque(0, 0, 0.5f, ForceMode.Impulse);
        rbBolle.AddTorque(0, 0, 0.5f, ForceMode.Impulse);

        rbTappo.AddForce(transform.right * ForceRightDown, ForceMode.Impulse);
    }

    void ForzaSinistra()
    {
        rbSotto.AddForce(transform.right * -ForceRightDown, ForceMode.Impulse);
        rbBolle.AddForce(transform.right * -ForceRightDown, ForceMode.Impulse);
        rbSotto.AddTorque(0, 0, -0.5f, ForceMode.Impulse);
        rbBolle.AddTorque(0, 0, -0.5f, ForceMode.Impulse);

        rbTappo.AddForce(transform.right * -ForceRightDown, ForceMode.Impulse);
    }
}
