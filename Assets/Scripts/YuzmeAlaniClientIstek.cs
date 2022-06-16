using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YuzmeAlaniClientIstek : MonoBehaviour
{
    [SerializeField] GameObject kapatilacakGrup, acilacakGrup, dropParaObjesi;


    public bool _doluMu;

    public GameObject _dolduranClient;


    private void Start()
    {
        _doluMu = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == _dolduranClient.gameObject)
        {
            dropParaObjesi.GetComponent<moneyGrubuKontrolu>().paraEklensinMi = true;
        }
    }

    public void PaletGiy()
    {
        kapatilacakGrup.SetActive(false);
    }

    public void DenizdenCikti()
    {
        acilacakGrup.SetActive(true);
    }
}
