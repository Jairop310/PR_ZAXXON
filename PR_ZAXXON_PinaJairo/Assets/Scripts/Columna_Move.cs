using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Columna_Move : MonoBehaviour
{
    float speed;
    float intervalo;

    // Start is called before the first frame update
    void Start()
    {
        speed = 10f;
        intervalo = 1f;
        StartCoroutine("CrearColumna");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed );
    }
    IEnumerator CrearColumna()
    {
        while (true)
        {
            print("Hola");
            yield return new WaitForSeconds(intervalo);
        }
    }

}
