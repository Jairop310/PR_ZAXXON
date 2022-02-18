using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public void CargarEscena(int escena)
    { 
        SceneManager.LoadScene(escena);
    }

    public void Salir()
    {
        Application.Quit();
    }

}
