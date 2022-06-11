using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sezlongAcmaKodu : MonoBehaviour
{
    [SerializeField] GameObject acilacakSezlong, kapacakObje;

    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "stuff")
        {
            acilacakSezlong.SetActive(true);
            kapacakObje.SetActive(false);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Player")
        {
            if (other.gameObject.GetComponent<SirtCantasiScript>()._cantadakiObjeler.Count > 0)
            {
                other.gameObject.GetComponent<SirtCantasiScript>().StuffCek(transform);
            }
            else
            {

            }
        }
        else
        {

        }
    }


}
