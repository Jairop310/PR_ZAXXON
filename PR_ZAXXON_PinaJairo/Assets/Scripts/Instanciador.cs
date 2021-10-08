using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instanciador : MonoBehaviour
{
    public float intervalo;
    [SerializeField] float distance;
    [SerializeField] GameObject [] obstaculos;
    [SerializeField] Transform instantiatePosicion;


    [SerializeField] GameObject otroObjeto;
    private Variables_Publicas variables_Publicas;
    int speed;
    int puntuacion;

    //Variables para instanciar columnas iniciales
    [SerializeField] float posZcolumna1 = 50f;


    // Start is called before the first frame update
    void Start()
    {
        otroObjeto = GameObject.Find("Variables");
        variables_Publicas = otroObjeto.GetComponent<Variables_Publicas>();
        // intervalo = 0.3f;
        distance = 10f;
        StartCoroutine("CrearColumna");
        //Creacion de columnas al inicion del juego
        float posZ = transform.position.z;
        float columnasIniciales = (posZ - posZcolumna1) / distance;

        columnasIniciales = Mathf.Round(columnasIniciales);
        print(columnasIniciales);
        for(float n= posZcolumna1; n < posZ; n += distance)
        {
            float randomX = Random.Range(-18f, 18f);
            float randomY = Random.Range(0.5f, 10.5f);
            Vector3 columnaInicialPos = new Vector3(randomX,randomY, n);
            Instantiate(obstaculos[0],columnaInicialPos,Quaternion.identity);
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CrearColumna()
    {
        while (true)
        {

            speed = variables_Publicas.speed;
            intervalo = distance / speed;
           //Generacion aleatoria de prefabs
            float randomX = Random.Range(-18f, 18f);
            float randomY = Random.Range(0.5f, 10.5f);
            Vector3 newPos = new Vector3(randomX, randomY, instantiatePosicion.position.z);
            //Genero un numero aleatorio para elegir objeto
            int numA = Random.Range(0, obstaculos.Length);
            Instantiate(obstaculos[numA], newPos, Quaternion.identity);

            yield return new WaitForSeconds(intervalo);
        }
    }

   
        
    }


