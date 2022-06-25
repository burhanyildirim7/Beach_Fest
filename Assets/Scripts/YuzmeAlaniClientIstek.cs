using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YuzmeAlaniClientIstek : MonoBehaviour
{
    [SerializeField] GameObject kapatilacakGrup, acilacakGrup, dropParaObjesi;

    public GameObject _denizeGirilecekNokta;

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

        }
    }

    public void PaletGiy()
    {
        kapatilacakGrup.SetActive(false);
        dropParaObjesi.GetComponent<moneyGrubuKontrolu>().paraEklensinMi = true;
    }

    public void ParaVer()
    {

        dropParaObjesi.GetComponent<moneyGrubuKontrolu>().paraEklensinMi = true;
    }

    public void DenizdenCikti()
    {
        acilacakGrup.SetActive(true);
    }
}
