using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    //Recogida de variables publicas
    [SerializeField] GameObject otroObjeto;
    private Variables_Publicas variables_Publicas;
    [SerializeField] float rotationSpeed;
    int speed;
    int vidas;
    
    //Limites de movimiento vertical y horizontal 
    float limiteH = 18f;
    float limiteVDown = 1f;
    float limiteVUp = 10f;
    


    // Start is called before the first frame update
    void Start()
    {
        //Llamada de variables que estan en otros scripts
        variables_Publicas = otroObjeto.GetComponent<Variables_Publicas>();
        rotationSpeed = 100f;
   
    }

    // Update is called once per frame
    void Update()
    {
        MoverNave();
        speed = variables_Publicas.speed;
        vidas = variables_Publicas.vidas;
    }
     
    void MoverNave()
    {
        //Variables de movimiento y rotacion
        float desplH = Input.GetAxis("Horizontal");
        float desplV = Input.GetAxis("Vertical");
        float desplR = Input.GetAxis("Rotation");
        //Variables De restriccion de movimiento
        float posX = transform.position.x;
        float posY = transform.position.y;

       //Rotacion de la Nave(Opcional)
       // transform.Rotate(0f, 0f, desplR * Time.deltaTime * -rotationSpeed);

        //Restriccion de movimiento (Manera del profesor)

        if ((posX < limiteH || desplH < 0f) && (posX > -limiteH || desplH > 0f))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed * desplH);
        }
        if ((posY > limiteVDown || desplV > 0f) && (posY < limiteVUp || desplV < 0f))
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed * desplV);
        }

        /*
        //Restriccion de movimiento (No es la manera del profesor)
        if (posX > limiteH && desplH > 0)
        {
            transform.position = new Vector3(posX, transform.position.y, transform.position.z);
        }
       if(posX < -limiteH && desplH < 0)
        {
            transform.position = new Vector3(posX, transform.position.y, transform.position.z);
        }
        if (posY < limiteVDown && desplV < 0)
        {
            transform.position = new Vector3(transform.position.x, posY, transform.position.z);
        }
        if(posY > limiteVUp && desplV > 0)
        {
            transform.position = new Vector3(transform.position.x, posY, transform.position.z);
        }
        */
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 16)
        {
            if(vidas > 0)
            {
                variables_Publicas.vidas--;
                print("Te han dado");
            }
            else
            {
                print("Muerto");
                //Script para que el mesh Renderer del hijo desaparezca
                gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
                variables_Publicas.speed = 0;
            }

        }
    }



}


