using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pared_de_Cubos : MonoBehaviour
{
    [SerializeField] GameObject cuboPrefab;
    [SerializeField] Transform initPos;
    float desplX = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 destPos = initPos.position;
        Vector3 despl = new Vector3(desplX, 0, 0);
        for(int n= 0;n < 10; n++)
        {
            Instantiate(cuboPrefab, destPos, Quaternion.identity);
            destPos = destPos + despl;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
