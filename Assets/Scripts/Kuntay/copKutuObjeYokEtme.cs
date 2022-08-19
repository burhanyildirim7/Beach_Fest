using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class copKutuObjeYokEtme : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "stuff" || other.tag == "icecream" || other.tag == "drink" || other.tag == "stuffsemsiye" || other.tag == "stuffpalet")
        {
            Destroy(other.gameObject);
        }
    }

}
