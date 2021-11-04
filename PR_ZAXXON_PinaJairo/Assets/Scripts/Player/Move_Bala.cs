using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Bala : MonoBehaviour
{
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 15f);
        //Destruir bala
        float desplZ = transform.position.z;
        if (desplZ > 50)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 16)
        {
            Destroy(other.gameObject);
        }
    }
}
