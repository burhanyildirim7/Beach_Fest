using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class garsonAcmaScripti : MonoBehaviour
{

    public static int garsonSayisi;
    [SerializeField] GameObject garson1Object, garson2Object;

    // Start is called before the first frame update
    void Start()
    {
        garsonSayisi = PlayerPrefs.GetInt("GarsonSayisi");
        if (garsonSayisi == 1)
        {
            garson1Object.SetActive(true);
        }
        else if (garsonSayisi == 2)
        {
            garson2Object.SetActive(true);
        }
        else
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (garsonSayisi == 1)
        {
            garson1Object.SetActive(true);
        }
        else if (garsonSayisi == 2)
        {
            garson2Object.SetActive(true);
        }
        else
        {

        }
    }
}
