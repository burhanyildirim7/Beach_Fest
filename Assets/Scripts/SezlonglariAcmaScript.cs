using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SezlonglariAcmaScript : MonoBehaviour
{
    [SerializeField] Text bedelText;
    [SerializeField] GameObject acilacakSezlongGrubu;
    [SerializeField] GameObject kapanacakGrubu;
    //[SerializeField] GameObject kapanacakCollider;
    [SerializeField] int sezlongGrubuNo = 0;
    int isOpen1 = 0, isOpen2 = 0, isOpen3 = 0, isOpen4 = 0, isOpen5 = 0;
    // Start is called before the first frame update
    void Start()
    {
        isOpen1 = PlayerPrefs.GetInt("1inciSezlongAcikMi");
        isOpen2 = PlayerPrefs.GetInt("2inciSezlongAcikMi");
        isOpen3 = PlayerPrefs.GetInt("3uncuSezlongAcikMi");
        isOpen4 = PlayerPrefs.GetInt("4uncuSezlongAcikMi");
        isOpen5 = PlayerPrefs.GetInt("5inciSezlongAcikMi");


        if (isOpen1 == 1 && sezlongGrubuNo == 1)
        {

            acilacakSezlongGrubu.SetActive(true);
            //birinciDenizGrubu.SetActive(true);
            kapanacakGrubu.SetActive(false);
            //kapanacakCollider.SetActive(false);

        }
        else if (isOpen2 == 1 && sezlongGrubuNo == 2)
        {

            acilacakSezlongGrubu.SetActive(true);
            //birinciDenizGrubu.SetActive(true);
            kapanacakGrubu.SetActive(false);
            //kapanacakCollider.SetActive(false);

        }
        else if (isOpen3 == 1 && sezlongGrubuNo == 3)
        {

            acilacakSezlongGrubu.SetActive(true);
            //birinciDenizGrubu.SetActive(true);
            kapanacakGrubu.SetActive(false);
            //kapanacakCollider.SetActive(false);

        }
        else if (isOpen4 == 1 && sezlongGrubuNo == 4)
        {

            acilacakSezlongGrubu.SetActive(true);
            //birinciDenizGrubu.SetActive(true);
            kapanacakGrubu.SetActive(false);
            //kapanacakCollider.SetActive(false);

        }
        else if (isOpen5 == 1 && sezlongGrubuNo == 5)
        {

            acilacakSezlongGrubu.SetActive(true);
            //birinciDenizGrubu.SetActive(true);
            kapanacakGrubu.SetActive(false);
            //kapanacakCollider.SetActive(false);

        }
        else
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (bedelText.text == "$0" && isOpen1 == 0 && sezlongGrubuNo == 1)
        {
            isOpen1 = 1;
            PlayerPrefs.SetInt("1inciSezlongAcikMi", 1);
            acilacakSezlongGrubu.SetActive(true);
            //birinciDenizGrubu.SetActive(true);
            kapanacakGrubu.SetActive(false);
            //kapanacakCollider.SetActive(false);
        }
        else if (bedelText.text == "$0" && isOpen2 == 0 && sezlongGrubuNo == 2)
        {
            isOpen2 = 1;
            PlayerPrefs.SetInt("2inciSezlongAcikMi", 1);
            acilacakSezlongGrubu.SetActive(true);
            //birinciDenizGrubu.SetActive(true);
            kapanacakGrubu.SetActive(false);
            //kapanacakCollider.SetActive(false);
        }
        else if (bedelText.text == "$0" && isOpen3 == 0 && sezlongGrubuNo == 3)
        {
            isOpen3 = 1;
            PlayerPrefs.SetInt("3uncuSezlongAcikMi", 1);
            acilacakSezlongGrubu.SetActive(true);
            //birinciDenizGrubu.SetActive(true);
            kapanacakGrubu.SetActive(false);
            //kapanacakCollider.SetActive(false);
        }
        else if (bedelText.text == "$0" && isOpen4 == 0 && sezlongGrubuNo == 4)
        {
            isOpen4 = 1;
            PlayerPrefs.SetInt("4uncuSezlongAcikMi", 1);
            acilacakSezlongGrubu.SetActive(true);
            //birinciDenizGrubu.SetActive(true);
            kapanacakGrubu.SetActive(false);
            //kapanacakCollider.SetActive(false);
        }
        else if (bedelText.text == "$0" && isOpen5 == 0 && sezlongGrubuNo == 5)
        {
            isOpen5 = 1;
            PlayerPrefs.SetInt("5inciSezlongAcikMi", 1);
            acilacakSezlongGrubu.SetActive(true);
            //birinciDenizGrubu.SetActive(true);
            kapanacakGrubu.SetActive(false);
            //kapanacakCollider.SetActive(false);
        }
        else
        {

        }
    }
}
