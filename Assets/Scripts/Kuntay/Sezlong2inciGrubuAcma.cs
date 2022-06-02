using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Sezlong2inciGrubuAcma : MonoBehaviour
{
    [SerializeField] Text bedelText;
    [SerializeField] GameObject acilacakSezlongGrubu,birinciDenizGrubu;
    [SerializeField] GameObject kapanacakGrubu;
    [SerializeField] int sezlongGrubuNo=0;
    int isOpen2 = 0, isOpen4 = 0;
    // Start is called before the first frame update
    void Start()
    {
        isOpen2 = PlayerPrefs.GetInt("2inciSezlongAlaniAcikMi");
        isOpen4 = PlayerPrefs.GetInt("4uncuSezlongAlaniAcikMi");


        if (isOpen2 == 1)
        {

                acilacakSezlongGrubu.SetActive(true);
                birinciDenizGrubu.SetActive(true);
                kapanacakGrubu.SetActive(false);

        }
        else if (isOpen4 == 1)
        {

            acilacakSezlongGrubu.SetActive(true);
            birinciDenizGrubu.SetActive(true);
            kapanacakGrubu.SetActive(false);

        }

        else
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (bedelText.text=="$0" && isOpen2==0 && sezlongGrubuNo==2)
        {
            isOpen2 = 1;
            PlayerPrefs.SetInt("2inciSezlongAlaniAcikMi", 1);
            acilacakSezlongGrubu.SetActive(true);
            birinciDenizGrubu.SetActive(true);
            kapanacakGrubu.SetActive(false);
        }
        else if (bedelText.text == "$0" && isOpen2 == 0 && sezlongGrubuNo == 4)
        {
            isOpen4 = 1;
            PlayerPrefs.SetInt("4uncuSezlongAlaniAcikMi", 1);
            acilacakSezlongGrubu.SetActive(true);
            birinciDenizGrubu.SetActive(true);
            kapanacakGrubu.SetActive(false);
        }

        else
        {
                
        }
    }
}
