using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variables_Publicas : MonoBehaviour
{
    public int speed;
    public int puntuacion;
    public int vidas;


    // Start is called before the first frame update
    void Start()
    {
        speed = 25;
        StartCoroutine("puntSum");

    }

    // Update is called once per frame
    void Update()
    {

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
}
