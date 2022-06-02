using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Sezlong2inciGrubuAcma : MonoBehaviour
{
    [SerializeField] Text bedelText;
    [SerializeField] GameObject acilacakSezlongGrubu,birinciDenizGrubu;
    [SerializeField] GameObject kapanacakGrubu;
    int isOpen=0;
    // Start is called before the first frame update
    void Start()
    {
        isOpen = PlayerPrefs.GetInt("2inciSezlongAcikMi");

        if (isOpen == 1)
        {
            isOpen = 1;
            PlayerPrefs.SetInt("2inciSezlongAcikMi", 1);
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
        if (bedelText.text=="$0" && isOpen==0)
        {
            isOpen = 1;
            PlayerPrefs.SetInt("2inciSezlongAcikMi",1);
            acilacakSezlongGrubu.SetActive(true);
            birinciDenizGrubu.SetActive(true);
            kapanacakGrubu.SetActive(false);
        }
        else
        {
                
        }
    }
}
