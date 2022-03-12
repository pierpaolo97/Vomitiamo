using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float time;
    public TextMeshProUGUI timeTxt;
    public GameObject Menu;
    public TextMeshProUGUI txtscoreUp;
    public TextMeshProUGUI txtscoreDown;
    public TextMeshProUGUI txtWinner;
    public GameObject PlayerUp;
    public GameObject PlayerDown;

    private void Start()
    {
        timeTxt.text = time.ToString();
        PlayerUp = GameObject.Find("PlayerUp");
        PlayerDown = GameObject.Find("PlayerDown");
    }

    public void Update()
    {
        if (time > 0)
        {
            time -= 1 * Time.deltaTime;
            timeTxt.text = time.ToString("0");
        }
        else
        {
            PlayerUp.SetActive(false);
            PlayerDown.SetActive(false);
            Menu.SetActive(true);
            writeWinner();
        }
    }

    public void writeWinner()
    {
        int scoreUp = int.Parse(txtscoreUp.text);
        int scoreDown = int.Parse(txtscoreDown.text);

        if(scoreUp > scoreDown)
        {
            txtWinner.text = "Il vincitore è " + "GiocatoreUp";
        }
        else if (scoreDown > scoreUp)
        {
            txtWinner.text = "Il vincitore è " + "GiocatoreDown";
        }
        else if (scoreDown == scoreUp)
        {
            txtWinner.text = "Ops...Bevete entrambi";
        }
        
    }

}
