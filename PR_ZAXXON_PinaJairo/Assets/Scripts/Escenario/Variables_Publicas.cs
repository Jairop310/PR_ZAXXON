using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Variables_Publicas : MonoBehaviour
{
    public int speed;
    [SerializeField] Slider mySlider;
    public static int vidasMax;
    public static int vidasRestantes;

    

    // Start is called before the first frame update
    void Start()
    {
        speed = 25;
        vidasRestantes = vidasMax;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        vidasMax = (int)mySlider.value;
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

    public void updateSlider()
    {
        
        print(vidasRestantes);

    }



}
