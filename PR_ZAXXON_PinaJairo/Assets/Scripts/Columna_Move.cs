using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Columna_Move : MonoBehaviour
{
    [SerializeField] GameObject otroObjeto;
    private Variables_Publicas variables_Publicas;
    int speed;


    // Start is called before the first frame update
    void Start()
    {
        otroObjeto = GameObject.Find("Variables");
        variables_Publicas = otroObjeto.GetComponent<Variables_Publicas>();
        

    }

    // Update is called once per frame
    void Update()
    {
        speed = variables_Publicas.speed;
        transform.Translate(Vector3.back * Time.deltaTime * speed);

        //Destruccion del Objeto cuando llega a una determinada posicion
        float desplZ = transform.position.z;
        if (desplZ < -30)
        {
            Destroy(gameObject);
        }
    }
    

}
