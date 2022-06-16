using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DusAlaniEvent : MonoBehaviour
{
    [SerializeField] GameObject _suEfekti;

    public bool _doluMu;

    private void Start()
    {
        _doluMu = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "client")
        {
            _suEfekti.SetActive(true);
            _doluMu = true;
            // Debug.Log("dolu mu " + _doluMu);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "client")
        {
            _suEfekti.SetActive(false);
            _doluMu = false;
            // Debug.Log("dolu mu " + _doluMu);
        }
    }
}
