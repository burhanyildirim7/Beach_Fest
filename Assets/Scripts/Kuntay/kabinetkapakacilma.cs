using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class kabinetkapakacilma : MonoBehaviour
{
    [SerializeField] Animator kabinatorAnim;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="client")
        {
            kabinatorAnim.SetBool("open",true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "client")
        {
            kabinatorAnim.SetBool("open", false);
        }
    }

}
