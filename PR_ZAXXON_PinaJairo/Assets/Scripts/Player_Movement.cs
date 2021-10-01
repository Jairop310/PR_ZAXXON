using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] GameObject otroObjeto;
    private Variables_Publicas variables_Publicas;
    [SerializeField] float rotationSpeed;
    float limiteH = 18f;
    float limiteVDown = 0.5f;
    float limiteVUp = 10f;


    // Start is called before the first frame update
    void Start()
    {
        variables_Publicas = otroObjeto.GetComponent<Variables_Publicas>();
        variables_Publicas.speed = 10;
        rotationSpeed = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        float desplH = Input.GetAxis("Horizontal");
        float desplV = Input.GetAxis("Vertical");
        float desplR = Input.GetAxis("Rotation");
        float posX = transform.position.x;
        float posY = transform.position.y;

        transform.Translate(Vector3.right * Time.deltaTime * variables_Publicas.speed * desplH);
        transform.Translate(Vector3.up * Time.deltaTime * variables_Publicas.speed * desplV);
        transform.Rotate(0f, 0f, desplR * Time.deltaTime * -rotationSpeed);

        if(posX > limiteH && desplH > 0)
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

    }

}


