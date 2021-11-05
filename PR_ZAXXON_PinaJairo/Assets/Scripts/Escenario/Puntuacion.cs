using System.Collections;
using System.Collections.Generic;
using TMPro; //Utilizado para Text mesh Pro
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Puntuacion : MonoBehaviour
{
    //Cambio de texto en UI

    public TextMeshProUGUI score;
    public static int puntuacion;

    [SerializeField] GameObject otroObjeto;
    private Variables_Publicas variables_Publicas;

    int vidas;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("puntSum");
        //variables_Publicas = otroObjeto.GetComponent<Variables_Publicas>();
    }

    // Update is called once per frame
    void Update()
    {
        vidas = Variables_Publicas.vidasRestantes;
        Score();

        if (vidas < 1)
        {
            StopAllCoroutines();
        }
    }
    void Score()
    {

        score.text = puntuacion.ToString();
        
    }
    IEnumerator puntSum()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        if (sceneName == "Juego")
        {
            puntuacion = 0;
        }
        while (true)
        {
            puntuacion++;
            
            yield return new WaitForSeconds(1f);
        }
    }

}
