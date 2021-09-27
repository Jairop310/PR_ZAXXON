using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] GameObject otroObjeto;
    private Variables_Publicas variables_Publicas;

    // Start is called before the first frame update
    void Start()
    {
        variables_Publicas = otroObjeto.GetComponent<Variables_Publicas>();
        variables_Publicas.speed = 10;
    }

    // Update is called once per frame
    void Update()
    {
        float desplH = Input.GetAxis("Horizontal");
        float desplV = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * Time.deltaTime * variables_Publicas.speed * desplH);
        transform.Translate(Vector3.up * Time.deltaTime * variables_Publicas.speed * desplV);
    }
}
