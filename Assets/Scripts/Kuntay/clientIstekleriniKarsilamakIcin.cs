using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clientIstekleriniKarsilamakIcin : MonoBehaviour
{
    [SerializeField] GameObject semsiye, dondurma, icecek;
    static public bool semsiyeIstiyor=false, dondurmaIstiyor=false, icecekIstiyor=false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="stuff" && semsiyeIstiyor==true)
        {
            semsiye.SetActive(true);
            semsiyeIstiyor = false;
        }
        else if (other.tag =="icecream" && dondurmaIstiyor==true)
        {
            dondurma.SetActive(true);
            dondurmaIstiyor = false;
        }
        else if (other.tag =="drink" && icecekIstiyor==true)
        {
            icecek.SetActive(true);
            icecekIstiyor = false;
        }
        else
        {

        }
    }


}
