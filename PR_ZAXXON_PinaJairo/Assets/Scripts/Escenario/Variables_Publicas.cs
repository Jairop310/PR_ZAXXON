using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variables_Publicas : MonoBehaviour
{
    public int speed;
    public int puntuacion;
    public  int vidas;



    // Start is called before the first frame update
    void Start()
    {
        speed = 25;
        vidas = 3;
        StartCoroutine("puntSum");
        

    }

    // Update is called once per frame
    void Update()
    {
        //StartCoroutine("aumentoDevelocidad");

        if (vidas < 1)
        {
            StopAllCoroutines();
        }
    }
    IEnumerator puntSum()
    {
        while (true)
        {
            puntuacion++;
            print(puntuacion);
            yield return new WaitForSeconds(1f);
        }
    }

   /*IEnumerator aumentoDevelocidad()
    {
        if (puntuacion > 100)
        {
            speed = 50;
        }
        yield return new WaitForSeconds(0.01f);
    }*/
}
