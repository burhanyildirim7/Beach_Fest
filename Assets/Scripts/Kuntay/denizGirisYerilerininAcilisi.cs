using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class denizGirisYerilerininAcilisi : MonoBehaviour
{
    [SerializeField] Text bedelText;
    [SerializeField] GameObject acilacakDusGrubu, denizeGirisYerleri;
    [SerializeField] GameObject kapanacakGrubu;
    [SerializeField] int denizeGirisGrubuNo = 0;
    int isOpen1 = 0, isOpen2 = 0;
    // Start is called before the first frame update
    void Start()
    {
        isOpen1 = PlayerPrefs.GetInt("1inciDenizeGirisAlaniAcikMi");
        isOpen2 = PlayerPrefs.GetInt("2inciDenizeGirisAlaniAcikMi");


        if (isOpen1 == 1)
        {

            acilacakDusGrubu.SetActive(true);
            denizeGirisYerleri.SetActive(true);
            kapanacakGrubu.SetActive(false);

        }
        else if (isOpen2 == 1)
        {

            acilacakDusGrubu.SetActive(true);
            denizeGirisYerleri.SetActive(true);
            kapanacakGrubu.SetActive(false);

        }

        else
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (bedelText.text == "$0" && isOpen1 == 0 && denizeGirisGrubuNo == 1)
        {
            isOpen1 = 1;
            PlayerPrefs.SetInt("1inciDenizeGirisAlaniAcikMi", 1);
            acilacakDusGrubu.SetActive(true);
            denizeGirisYerleri.SetActive(true);
            kapanacakGrubu.SetActive(false);
        }
        else if (bedelText.text == "$0" && isOpen1 == 0 && denizeGirisGrubuNo == 2)
        {
            isOpen2 = 1;
            PlayerPrefs.SetInt("2inciDenizeGirisAlaniAcikMi", 1);
            acilacakDusGrubu.SetActive(true);
            denizeGirisYerleri.SetActive(true);
            kapanacakGrubu.SetActive(false);
        }

        else
        {

        }
    }
}
