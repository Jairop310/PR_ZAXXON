using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Variables_Publicas : MonoBehaviour
{
    public int speed;
    
    public static int vidasRestantes;

    

    // Start is called before the first frame update
    void Start()
    {
        if (CambioVidas.vidasMax < 4)
        {
            CambioVidas.vidasMax = 3;
        }
        speed = 25;
        vidasRestantes = CambioVidas.vidasMax;
        
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        string sceneName = SceneManager.GetActiveScene().name;
        if (sceneName == "Muerte")
        {
            vidasRestantes = 0;
        }

    }

    public int GetLives()
    {
        int livesRet = vidasRestantes;
        return (livesRet);
    }

    



}
