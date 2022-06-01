using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sezlongAcmaKodu : MonoBehaviour
{
    [SerializeField] GameObject acilacakSezlong,kapacakObje;

    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="stuff")
        {
            acilacakSezlong.SetActive(true);
            kapacakObje.SetActive(false);
        }
        else
        {

        }
    }


}
