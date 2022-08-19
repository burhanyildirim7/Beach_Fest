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
        semsiye.SetActive(false);
        dondurma.SetActive(false);
        icecek.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (other.gameObject.GetComponent<SirtCantasiScript>()._cantadakiStuffObjeleri.Count > 0 && semsiyeIstiyor == true)
            {
                other.gameObject.GetComponent<SirtCantasiScript>().StuffSemsiyeCek(gameObject.transform);
                semsiye.SetActive(true);
                _dolduranClient.GetComponent<ClientAIScript>().IsteklerKarsilandi();
                dropParaObjesi.GetComponent<moneyGrubuKontrolu>().paraEklensinMi = true;
                semsiyeIstiyor = false;
            }
            else if (other.gameObject.GetComponent<SirtCantasiScript>()._cantadakiIceCreamObjeleri.Count > 0 && dondurmaIstiyor == true)
            {
                other.gameObject.GetComponent<SirtCantasiScript>().IceCreamCek();
                //dondurma.SetActive(true);
                _dolduranClient.GetComponent<ClientAIScript>().IsteklerKarsilandi();
                dropParaObjesi.GetComponent<moneyGrubuKontrolu>().paraEklensinMi = true;
                dondurmaIstiyor = false;
            }
            else if (other.gameObject.GetComponent<SirtCantasiScript>()._cantadakiDrinkObjeleri.Count > 0 && icecekIstiyor == true)
            {
                other.gameObject.GetComponent<SirtCantasiScript>().DrinkCek();
                //icecek.SetActive(true);
                _dolduranClient.GetComponent<ClientAIScript>().IsteklerKarsilandi();
                dropParaObjesi.GetComponent<moneyGrubuKontrolu>().paraEklensinMi = true;
                icecekIstiyor = false;
            }
            else
            {

            }
        }
        else if (other.gameObject.tag == "Garson")
        {
            if (other.gameObject.GetComponent<GarsonScript>()._cantadakiDrinkObjeleri.Count > 0 && icecekIstiyor == true)
            {
                other.gameObject.GetComponent<GarsonScript>().DrinkCek();
                //icecek.SetActive(true);
                _dolduranClient.GetComponent<ClientAIScript>().IsteklerKarsilandi();
                dropParaObjesi.GetComponent<moneyGrubuKontrolu>().paraEklensinMi = true;
                icecekIstiyor = false;
            }
            else
            {

            }
        }
        else if (other.gameObject.tag == "Sef")
        {
            if (other.gameObject.GetComponent<SefScript>()._cantadakiDrinkObjeleri.Count > 0 && dondurmaIstiyor == true)
            {
                other.gameObject.GetComponent<SefScript>().DrinkCek();
                //dondurma.SetActive(true);
                _dolduranClient.GetComponent<ClientAIScript>().IsteklerKarsilandi();
                dropParaObjesi.GetComponent<moneyGrubuKontrolu>().paraEklensinMi = true;
                dondurmaIstiyor = false;
            }
            else
            {

            }
        }
        else if (other.gameObject.tag == "Worker")
        {
            if (other.gameObject.GetComponent<WorkerScript>()._cantadakiStuffObjeleri.Count > 0 && semsiyeIstiyor == true && other.gameObject.GetComponent<WorkerScript>()._worker2)
            {
                other.gameObject.GetComponent<WorkerScript>().StuffCek(gameObject.transform);
                semsiye.SetActive(true);
                _dolduranClient.GetComponent<ClientAIScript>().IsteklerKarsilandi();
                dropParaObjesi.GetComponent<moneyGrubuKontrolu>().paraEklensinMi = true;
                semsiyeIstiyor = false;
            }
            else
            {

            }
        }
        else
        {

        }

        if (other.gameObject.tag == "stuffsemsiye")
        {
            Destroy(other.gameObject);
        }
        else
        {

        }

        /*
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
        */
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == _dolduranClient.gameObject)
        {
            semsiye.SetActive(false);
            dondurma.SetActive(false);
            icecek.SetActive(false);
            acilacakGrup.SetActive(true);
            //kapatilacakGrup.GetComponent<AcilisAnimasyonScript>().ChildKapat();
            kapatilacakGrup.SetActive(false);
            dropParaObjesi.GetComponent<moneyGrubuKontrolu>().paraEklensinMi = true;
        }
    }

}
