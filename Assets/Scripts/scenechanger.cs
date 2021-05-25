using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenechanger : MonoBehaviour
{

   public void sceneChanger()
    {
        SceneManager.LoadScene("2playerGameplay");
    }

    public void soloPlay()
    {
        SceneManager.LoadScene("SoloPlay");
    }

    public void instruccion()
    {
        SceneManager.LoadScene("instructions");
    }

    public void menu()
    {
        SceneManager.LoadScene("Principal");
    }
}
