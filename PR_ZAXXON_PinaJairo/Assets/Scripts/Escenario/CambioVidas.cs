using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CambioVidas : MonoBehaviour
{
    public static int vidasMax;
    [SerializeField] Slider mySlider;
    

     void Start()
    {
        
    }
     void FixedUpdate()
    {
        vidasMax = (int)mySlider.value;
      
    }
    public void updateSlider()
    {

        print(vidasMax);

    }
}
