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



    // Start is called before the first frame update
    void Start()
    {
        otroObjeto = GameObject.Find("Variables");
        variables_Publicas = otroObjeto.GetComponent<Variables_Publicas>();
        // intervalo = 0.3f;
        distance = 10f;
       
        
        StartCoroutine("CrearColumna");
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
            print(intervalo);
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


