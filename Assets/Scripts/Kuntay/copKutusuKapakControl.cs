using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class copKutusuKapakControl : MonoBehaviour
{
    [SerializeField]Animator kapakAnimator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            kapakAnimator.SetBool("open",true);
            kapakAnimator.SetBool("close", false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag=="Player")
        {
            kapakAnimator.SetBool("open", false);
            kapakAnimator.SetBool("close", true);
        }
    }

}
