using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KabinAcmaScript : MonoBehaviour
{
    [SerializeField] Text bedelText;
    [SerializeField] GameObject acilacakSezlongGrubu;
    [SerializeField] GameObject kapanacakGrubu;
    [SerializeField] GameObject kapanacakCollider;
    [SerializeField] GameObject acilacakCollider;
    [SerializeField] int sezlongGrubuNo = 0;
    int isOpen2 = 0, isOpen4 = 0;
    // Start is called before the first frame update
    void Start()
    {
        isOpen2 = PlayerPrefs.GetInt("2inciKabinAlaniAcikMi");
        isOpen4 = PlayerPrefs.GetInt("4uncuKabinAlaniAcikMi");


        if (isOpen2 == 1 && sezlongGrubuNo == 2)
        {

            acilacakSezlongGrubu.SetActive(true);
            acilacakCollider.SetActive(true);

            kapanacakGrubu.SetActive(false);
            kapanacakCollider.SetActive(false);

            GetComponent<MeshRenderer>().enabled = false;

        }
        else if (isOpen4 == 1 && sezlongGrubuNo == 4)
        {

            acilacakSezlongGrubu.SetActive(true);
            acilacakCollider.SetActive(true);

            kapanacakGrubu.SetActive(false);
            kapanacakCollider.SetActive(false);

            GetComponent<MeshRenderer>().enabled = false;

        }
        else
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (bedelText.text == "$0" && isOpen2 == 0 && sezlongGrubuNo == 2)
        {
            isOpen2 = 1;
            PlayerPrefs.SetInt("2inciKabinAlaniAcikMi", 1);
            acilacakSezlongGrubu.SetActive(true);
            //acilacakSezlongGrubu.GetComponent<AcilisAnimasyonScript>().AcilisAnim();
            acilacakCollider.SetActive(true);

            kapanacakGrubu.SetActive(false);
            kapanacakCollider.SetActive(false);

            GetComponent<MeshRenderer>().enabled = false;
        }
        else if (bedelText.text == "$0" && isOpen4 == 0 && sezlongGrubuNo == 4)
        {
            isOpen4 = 1;
            PlayerPrefs.SetInt("4uncuKabinAlaniAcikMi", 1);
            acilacakSezlongGrubu.SetActive(true);
            //acilacakSezlongGrubu.GetComponent<AcilisAnimasyonScript>().AcilisAnim();
            acilacakCollider.SetActive(true);

            kapanacakGrubu.SetActive(false);
            kapanacakCollider.SetActive(false);

            GetComponent<MeshRenderer>().enabled = false;
        }
        else
        {

        }
    }
}
