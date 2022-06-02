using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpandKontrol : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Text bedelText;
    [SerializeField] GameObject acilacakGrup;
    [SerializeField] GameObject kapanacakGrup,kapanacakOrman;
    [SerializeField] int yeniAlanNo = 0;
    int isOpenYeniAlan1 = 0;//, isOpenYeniAlan2 =0;
    // Start is called before the first frame update
    void Start()
    {
        isOpenYeniAlan1 = PlayerPrefs.GetInt("1inciYeniAlanAcikMi");
       // isOpenYeniAlan2 = PlayerPrefs.GetInt("2inciYeniAlanAcikMi");


        if (isOpenYeniAlan1 == 1)
        {

            acilacakGrup.SetActive(true);
            kapanacakGrup.SetActive(false);
            kapanacakOrman.SetActive(false);

        }
        /* else if (isOpenYeniAlan2 == 1)
         {

             acilacakGrup.SetActive(true);
             kapanacakGrup.SetActive(false);

         }*/

        else
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (bedelText.text == "$0" && isOpenYeniAlan1 == 0 && yeniAlanNo == 1)
        {
            isOpenYeniAlan1 = 1;
            PlayerPrefs.SetInt("1inciYeniAlanAcikMi", 1);
            acilacakGrup.SetActive(true);
            kapanacakGrup.SetActive(false);
            kapanacakOrman.SetActive(false);
        }
        /* else if (bedelText.text == "$0" && isOpenYeniAlan1 == 0 && denizeGirisGrubuNo == 2)
         {
             isOpenYeniAlan2 = 1;
             PlayerPrefs.SetInt("2inciYeniAlanAcikMi", 1);
             acilacakGrup.SetActive(true);
             kapanacakGrup.SetActive(false);
             kapanacakOrman.SetActive(false);
         }*/

        else
        {

        }
    }

}
