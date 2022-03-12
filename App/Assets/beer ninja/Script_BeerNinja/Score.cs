using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreUIUp;
    public TextMeshProUGUI scoreUIDown;
    public static int scoreUp = 0;
    public static int scoreDown = 0;


    public void scorePlayerUp()
    {
        scoreUp++;
        scoreUIUp.text = scoreUp.ToString();
    }

    public void scorePlayerDown()
    {
        scoreDown++;
        scoreUIDown.text = scoreDown.ToString();
    }

    public void scorePenalityUp()
    {
        scoreUp--;
        scoreUIUp.text = scoreUp.ToString();
    }

    public void scorePenalityDown()
    {
        scoreDown--;
        scoreUIDown.text = scoreDown.ToString();
    }

    /*public void penaltyPlayerUp()
    {
        scoreUp--;
        if (scoreUp < 0)
        {
            scoreUp = 0;
        }
        scoreUIUp.text = scoreUp.ToString();

    }

    public void penaltyPlayerDown()
    {
        scoreDown--;
        if (scoreDown < 0)
        {
            scoreDown = 0;
        }
        scoreUIDown.text = scoreDown.ToString();
    }*/

    /*void Update()
    {
        
        if (scoreDown < 0)
        {
            scoreDown = 0;
        }

        if (scoreUp < 0)
        {
            scoreUp = 0;
        }

        scoreUIUp.text = scoreUp.ToString();
        scoreUIDown.text = scoreDown.ToString();
    }*/

}
