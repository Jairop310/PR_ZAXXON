using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Disparador_Cargador : MonoBehaviour
{
    //Instanciar balas
    public GameObject bala;
    public Transform cannon;

    //Variables numericas disparos

    public int currentAmmo;
    public int maxAmmo;
    public int defaultAmmo = 10;
    public float reloadTime = 2f;
    public int balasDisparadas;
    //Variables texto disparo

    [SerializeField] TextMeshProUGUI textoBalas;

    //Booleanas

    public bool needReload = false;

    //Audio
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        maxAmmo = 50;
        currentAmmo = 10;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Disparo();
        Recarga();
        textoBalas.text = currentAmmo + "/" + maxAmmo;
    }

    void Disparo()
    {
        if (Input.GetKeyDown("space") && currentAmmo > 0 )
        {
            print("Disparando");
            Instantiate(bala, cannon);
            currentAmmo--;
            balasDisparadas++;
            audioSource.Play();
        }
    }


    void Recarga()
    {
        if(currentAmmo <= 0)
        {
            needReload = true;
            StartCoroutine(Recargar());
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Recargar());
        }
    }
    IEnumerator Recargar()
    {
        print("Recarga");
        yield return new WaitForSeconds(reloadTime);
        if(maxAmmo <= 10)
        {
            currentAmmo = maxAmmo;
            maxAmmo = maxAmmo - balasDisparadas;
            balasDisparadas = 0;

        }
        else
        {
            currentAmmo = 10;
            maxAmmo = maxAmmo - balasDisparadas;
            balasDisparadas = 0;
        }
        needReload = false;
    }
}
