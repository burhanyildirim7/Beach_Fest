using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class garsonAcmaScripti : MonoBehaviour
{


    [SerializeField] GameObject garson1Object, garson2Object, workerPaneli, dondurmaciObjesi;
    [SerializeField] Slider garsonSlideri;


    void Start()
    {

        GarsonAc();
    }

    public void GarsonAc()
    {
        if (PlayerPrefs.GetInt("GarsonSayisi") == 1)
        {
            garson1Object.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("GarsonSayisi") == 2)
        {
            garson2Object.SetActive(true);
        }
        else
        {

        }
    }


}
