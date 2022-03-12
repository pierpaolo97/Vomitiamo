using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class scoreScript : MonoBehaviour
{

    public enum Score
    {
        PlayerDown, PlayerUp
    }

    //public Text playerUpTxt, playerDownTxt;
    public TextMeshProUGUI playerUpTxt, playerDownTxt;
    private int playerUpScore, playerDownScore;


    public void Increment(Score whichScore)
    {
        if (whichScore == Score.PlayerUp)
            playerUpTxt.text = (++playerUpScore).ToString();
        else
            playerDownTxt.text = (++playerDownScore).ToString();
    }

    public void Decrement(Score whichScore)
    {
        if (whichScore == Score.PlayerUp)
            playerUpTxt.text = (--playerUpScore).ToString();
        else
            playerDownTxt.text = (--playerDownScore).ToString();

    }
}
