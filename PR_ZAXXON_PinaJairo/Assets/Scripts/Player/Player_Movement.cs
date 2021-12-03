using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Movement : MonoBehaviour
{
    //Recogida de variables publicas
    [SerializeField] GameObject otroObjeto;
    private Variables_Publicas variables_Publicas;
    
    int speed;
    int vidas;
    
    
    //Limites de movimiento vertical y horizontal 
    float limiteH = 18f;
    float limiteVDown = 1f;
    float limiteVUp = 10f;

    //Barra de vida
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    //Instanciar balas
    public GameObject bala;
    public Transform cannon;

    

    // Start is called before the first frame update
    void Start()
    {
        //Llamada de variables que estan en otros scripts
        variables_Publicas = otroObjeto.GetComponent<Variables_Publicas>();
        
   
    }

    // Update is called once per frame
    void Update()
    {
        MoverNave();
        TakeDamage();
        Disparo();
      
        speed = variables_Publicas.speed;
        vidas = Variables_Publicas.vidasRestantes;
      
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
            if(vidas > 1)
            {
                Variables_Publicas.vidasRestantes--;
                
            }
            else
            {
                //Script para que el mesh Renderer del hijo desaparezca
                gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
                variables_Publicas.speed = 0;
                Invoke("muerte", 3);
            }

        }
        if (other.gameObject.layer == 17)
        {
            if (other.gameObject.tag == ("Disparo"))
            {
                print("Más Disparos");
            }
            if(other.gameObject.tag == ("Velocidad"))
            {
                print("Mas Velocidad");
            }
            if(other.gameObject.tag == ("VidaUp") && Variables_Publicas.vidasRestantes <6)
            {
                Variables_Publicas.vidasRestantes++;
                
            }
        }
    }
    void TakeDamage()
    {
        fill.color = gradient.Evaluate(slider.normalizedValue);
        slider.value = Variables_Publicas.vidasRestantes;
    }
    void Disparo()
    {
        if (Input.GetKeyDown("space"))
        {
            print("Disparando");
            Instantiate(bala, cannon);
        }
    }

    void muerte()
    {
        
        
        SceneManager.LoadScene(4);
    }

}


