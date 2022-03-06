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

    void Update()
    {
        scoreUIUp.text = scoreUp.ToString();
        scoreUIDown.text = scoreDown.ToString();
        if (scoreDown < 0)
        {
            scoreDown = 0;
        }

        if (scoreUp < 0)
        {
            scoreUp = 0;
        }
    }

}
