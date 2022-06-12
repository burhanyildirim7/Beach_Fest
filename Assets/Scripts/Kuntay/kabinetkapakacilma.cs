using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class kabinetkapakacilma : MonoBehaviour
{
    [SerializeField] Animator kabinatorAnim;

    public bool _doluMu;

    private void Start()
    {
        _doluMu = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "client")
        {
            kabinatorAnim.SetBool("open", true);
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
