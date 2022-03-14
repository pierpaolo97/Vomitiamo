using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{

    public void goToHockey()
    {
        SceneManager.LoadScene("Hockey");
    }

    public void goToBeerNinja()
    {
        SceneManager.LoadScene("Bottle ninja");
    }
    public void goToHitSpritz()
    {
        SceneManager.LoadScene("HitSpritz");
    }

    public void goToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void goToVomitaPulisci()
    {
        SceneManager.LoadScene("VomitaPulisci");
    }

    public void goToScappaDalleGuardie()
    {
        SceneManager.LoadScene("ScappaGuardie");
    }

    public void goToTorreBirra()
    {
        SceneManager.LoadScene("TorreBirre");
    }



}
