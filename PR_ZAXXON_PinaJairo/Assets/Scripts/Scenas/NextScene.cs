using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    
    // Start is called before the first frame update
  public void Configuracion()
    {
        SceneManager.LoadScene(2);
            
    }
  public void Juego()
    {
        SceneManager.LoadScene(1);
       
    }
    public void Inicio()
    {
        SceneManager.LoadScene(0);
    }
    public void HighScore()
    {
        SceneManager.LoadScene(3);
    }
   
}
