using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class garsonAcmaScripti : MonoBehaviour
{


    [SerializeField] GameObject garson1Object, garson2Object;


    [SerializeField] private bool _icecek;
    [SerializeField] private bool _stuff;



    void Start()
    {

        GarsonAc();
    }

    public void GarsonAc()
    {
        if (_icecek)
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
        else if (_stuff)
        {
            if (PlayerPrefs.GetInt("WorkerSayisi") == 1)
            {
                garson1Object.SetActive(true);
            }
            else if (PlayerPrefs.GetInt("WorkerSayisi") == 2)
            {
                garson2Object.SetActive(true);
            }
            else
            {

            }
        }
        else
        {
            if (PlayerPrefs.GetInt("SefSayisi") == 1)
            {
                garson1Object.SetActive(true);
            }
            else if (PlayerPrefs.GetInt("SefSayisi") == 2)
            {
                garson2Object.SetActive(true);
            }
            else
            {

            }
        }

    }


}
