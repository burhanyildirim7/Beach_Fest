using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class birinciExpandAlaniAcilis : MonoBehaviour
{
    [SerializeField] GameObject ExpandAlaniObjesi,beachBarObjesi,iceCreamObjesi;
    [SerializeField] Text beachAlaniParaTexti, iceCreamAlaniParaTexti;
    int beachObjesiIsActive, iceCreamObjesiIsActive;


    // Start is called before the first frame update
    void Start()
    {
        beachObjesiIsActive = 0;
        iceCreamObjesiIsActive = 0;

        beachObjesiIsActive = PlayerPrefs.GetInt("BeachObjesiAcikMi");
        iceCreamObjesiIsActive = PlayerPrefs.GetInt("IceCreamObjesiAcikMi");

        if (beachObjesiIsActive == 1 && iceCreamObjesiIsActive==1)
        {
            beachBarObjesi.SetActive(true);
            iceCreamObjesi.SetActive(true);
            ExpandAlaniObjesi.SetActive(true);
        }
        else
        {

        }

    }

    // Update is called once per frame
    void Update()
    {
        if (beachAlaniParaTexti.text == "$0")
        {
            beachObjesiIsActive = 1;
            PlayerPrefs.SetInt("BeachObjesiAcikMi",1);
            beachBarObjesi.SetActive(true);
        }
        else
        {

        }
        if (iceCreamAlaniParaTexti.text == "$0")
        {
            iceCreamObjesiIsActive = 1;
            PlayerPrefs.SetInt("IceCreamObjesiAcikMi", 1);
            iceCreamObjesi.SetActive(true);
        }
        else
        {

        }
        if (beachObjesiIsActive == 1 && iceCreamObjesiIsActive == 1)
        {
            ExpandAlaniObjesi.SetActive(true);
        }
        else
        {

        }
    }
}
