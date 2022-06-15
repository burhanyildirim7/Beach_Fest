using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sezlongAcmaKodu : MonoBehaviour
{
    [SerializeField] GameObject acilacakSezlong, kapacakObje;

    //[SerializeField] private Transform _spawnNoktasi;

    //[SerializeField] private List<GameObject> _spawnClientList = new List<GameObject>();

    [SerializeField] private clientIstekleriniKarsilamakIcin _clientIstekleriniKarsilamakIcin;
    // Start is called before the first frame update

    private AISpawnController _aiSpawnController;

    private void Awake()
    {

    }
    private void Start()
    {
        _aiSpawnController = GameObject.FindGameObjectWithTag("AISpawnController").GetComponent<AISpawnController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "stuff")
        {
            _clientIstekleriniKarsilamakIcin._doluMu = false;
            acilacakSezlong.SetActive(true);
            kapacakObje.SetActive(false);
            Destroy(other.gameObject);


            //SpawnFunc();
        }
        else if (other.gameObject.tag == "Player")
        {
            if (other.gameObject.GetComponent<SirtCantasiScript>()._cantadakiObjeler.Count > 0)
            {
                other.gameObject.GetComponent<SirtCantasiScript>().StuffCek(transform);

            }
            else
            {

            }
        }
        else
        {

        }
    }

    /*
    private void SpawnFunc()
    {
        Instantiate(_spawnClientList[0], _spawnNoktasi.position, Quaternion.identity);
    }
    */

}
