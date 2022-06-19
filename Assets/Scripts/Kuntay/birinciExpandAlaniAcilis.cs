using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class birinciExpandAlaniAcilis : MonoBehaviour
{
    [SerializeField] GameObject ExpandAlaniObjesi, beachBarObjesi, iceCreamObjesi, iceCreamArabaObjesi, _kapanacakObje, _kapanacakCollider, _kapanacakIceCreamCanvas, _drinkParaCollider, _iceParaCollider;
    [SerializeField] Text beachAlaniParaTexti, iceCreamAlaniParaTexti;
    int beachObjesiIsActive, iceCreamObjesiIsActive;


    // Start is called before the first frame update
    void Start()
    {
        beachObjesiIsActive = 0;
        iceCreamObjesiIsActive = 0;

        beachObjesiIsActive = PlayerPrefs.GetInt("BeachObjesiAcikMi");
        iceCreamObjesiIsActive = PlayerPrefs.GetInt("IceCreamObjesiAcikMi");

        //PlayerPrefs.SetInt("IceCreamObjesiAcikMi", 0);

        //iceCreamObjesi.SetActive(false);

        _kapanacakObje.SetActive(true);
        _kapanacakCollider.SetActive(true);

        if (beachObjesiIsActive == 1)
        {
            beachBarObjesi.SetActive(true);
            _kapanacakObje.SetActive(false);
            _kapanacakCollider.SetActive(false);
            _drinkParaCollider.SetActive(false);
        }
        else
        {

        }

        if (iceCreamObjesiIsActive == 1)
        {

            iceCreamObjesi.SetActive(true);
            iceCreamArabaObjesi.SetActive(true);
            _kapanacakIceCreamCanvas.SetActive(false);
            _iceParaCollider.SetActive(false);
            //_kapanacakObje.SetActive(false);
            //_kapanacakCollider.SetActive(false);

        }
        else
        {

        }

        if (beachObjesiIsActive == 1 && iceCreamObjesiIsActive == 1)
        {
            ExpandAlaniObjesi.SetActive(true);
            _kapanacakObje.SetActive(false);
            _kapanacakCollider.SetActive(false);
            _drinkParaCollider.SetActive(false);
            _iceParaCollider.SetActive(false);
        }
        else
        {

        }

    }

    // Update is called once per frame
    void Update()
    {
        if (beachAlaniParaTexti.text == "$0" && beachObjesiIsActive == 0)
        {
            beachObjesiIsActive = 1;
            PlayerPrefs.SetInt("BeachObjesiAcikMi", 1);
            beachBarObjesi.SetActive(true);
            _kapanacakObje.SetActive(false);
            _kapanacakCollider.SetActive(false);
            _drinkParaCollider.SetActive(false);
        }
        else
        {

        }

        if (iceCreamAlaniParaTexti.text == "$0" && iceCreamObjesiIsActive == 0)
        {
            iceCreamObjesiIsActive = 1;
            PlayerPrefs.SetInt("IceCreamObjesiAcikMi", 1);
            iceCreamObjesi.SetActive(true);
            iceCreamArabaObjesi.SetActive(true);
            _kapanacakIceCreamCanvas.SetActive(false);
            _iceParaCollider.SetActive(false);
            //_kapanacakObje.SetActive(false);
            //_kapanacakCollider.SetActive(false);
        }
        else
        {

        }

        if (beachObjesiIsActive == 1 && iceCreamObjesiIsActive == 1 && ExpandAlaniObjesi.activeSelf == false)
        {
            ExpandAlaniObjesi.SetActive(true);
        }
        else
        {

        }


    }
}
