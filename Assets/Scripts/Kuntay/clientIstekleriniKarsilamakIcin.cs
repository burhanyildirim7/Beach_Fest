using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clientIstekleriniKarsilamakIcin : MonoBehaviour
{
    [SerializeField] GameObject semsiye, dondurma, icecek, kapatilacakGrup, acilacakGrup, dropParaObjesi;
    public bool semsiyeIstiyor = false, dondurmaIstiyor = false, icecekIstiyor = false;

    public bool _doluMu;

    public GameObject _dolduranClient;


    private void Start()
    {
        _doluMu = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "stuff" && semsiyeIstiyor == true)
        {
            semsiye.SetActive(true);
            semsiyeIstiyor = false;
        }
        else if (other.tag == "icecream" && dondurmaIstiyor == true)
        {
            dondurma.SetActive(true);
            dondurmaIstiyor = false;
        }
        else if (other.tag == "drink" && icecekIstiyor == true)
        {
            icecek.SetActive(true);
            icecekIstiyor = false;
        }
        else
        {

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == _dolduranClient.gameObject)
        {
            semsiye.SetActive(false);
            dondurma.SetActive(false);
            icecek.SetActive(false);
            acilacakGrup.SetActive(true);
            kapatilacakGrup.SetActive(false);
            dropParaObjesi.GetComponent<moneyGrubuKontrolu>().paraEklensinMi = true;
        }
    }

}
