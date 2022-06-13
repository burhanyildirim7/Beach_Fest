using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class garsonAcmaScripti : MonoBehaviour
{

    float garsonSayisi;
    [SerializeField] GameObject garson1Object, garson2Object,workerPaneli,dondurmaciObjesi;
    [SerializeField] Slider garsonSlideri;

    // Start is called before the first frame update
    void Start()
    {
        if (dondurmaciObjesi.activeSelf==true)
        {
            workerPaneli.SetActive(true);
        }
        else
        {

        }
        
        garsonSayisi = PlayerPrefs.GetFloat("GarsonSayisi");
        garsonSlideri.value = garsonSayisi;
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
        garsonSayisi=garsonSlideri.value;

        if (garsonSayisi == 1)
        {
            garson1Object.SetActive(true);
            PlayerPrefs.SetFloat("GarsonSayisi",garsonSayisi);
        }
        else if (garsonSayisi == 2)
        {
            garson2Object.SetActive(true);
            PlayerPrefs.SetFloat("GarsonSayisi", garsonSayisi);
        }
        else
        {

        }
    }
}
