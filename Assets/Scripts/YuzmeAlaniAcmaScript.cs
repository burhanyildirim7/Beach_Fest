using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YuzmeAlaniAcmaScript : MonoBehaviour
{
    [SerializeField] Text bedelText;
    [SerializeField] GameObject acilacakSezlongGrubu;
    [SerializeField] GameObject kapanacakGrubu;
    //[SerializeField] GameObject kapanacakCollider;
    [SerializeField] int sezlongGrubuNo = 0;
    int isOpen1 = 0, isOpen2 = 0, isOpen3 = 0, isOpen4 = 0;

    // Start is called before the first frame update
    void Start()
    {
        isOpen1 = PlayerPrefs.GetInt("1inciYuzmeAcikMi");
        isOpen2 = PlayerPrefs.GetInt("2inciYuzmeAcikMi");
        isOpen3 = PlayerPrefs.GetInt("3uncuYuzmeAcikMi");
        isOpen4 = PlayerPrefs.GetInt("4uncuYuzmeAcikMi");



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
            PlayerPrefs.SetInt("1inciYuzmeAcikMi", 1);
            acilacakSezlongGrubu.SetActive(true);
            //birinciDenizGrubu.SetActive(true);
            kapanacakGrubu.SetActive(false);
            //kapanacakCollider.SetActive(false);
        }
        else if (bedelText.text == "$0" && isOpen2 == 0 && sezlongGrubuNo == 2)
        {
            isOpen2 = 1;
            PlayerPrefs.SetInt("2inciYuzmeAcikMi", 1);
            acilacakSezlongGrubu.SetActive(true);
            //birinciDenizGrubu.SetActive(true);
            kapanacakGrubu.SetActive(false);
            //kapanacakCollider.SetActive(false);
        }
        else if (bedelText.text == "$0" && isOpen3 == 0 && sezlongGrubuNo == 3)
        {
            isOpen3 = 1;
            PlayerPrefs.SetInt("3uncuYuzmeAcikMi", 1);
            acilacakSezlongGrubu.SetActive(true);
            //birinciDenizGrubu.SetActive(true);
            kapanacakGrubu.SetActive(false);
            //kapanacakCollider.SetActive(false);
        }
        else if (bedelText.text == "$0" && isOpen4 == 0 && sezlongGrubuNo == 4)
        {
            isOpen4 = 1;
            PlayerPrefs.SetInt("4uncuYuzmeAcikMi", 1);
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
