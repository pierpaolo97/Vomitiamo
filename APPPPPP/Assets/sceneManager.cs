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
}
