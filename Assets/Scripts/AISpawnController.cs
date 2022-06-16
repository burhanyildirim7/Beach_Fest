using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISpawnController : MonoBehaviour
{

    [SerializeField] private List<GameObject> _spawnClientList = new List<GameObject>();

    [SerializeField] private Transform _spawnNoktasi;

    [SerializeField] private float _spawnHizi;

    [SerializeField] private AIHareketKontrol _aiHareketKontrol;

    private float _timer;

    public bool _uret;

    void Start()
    {
        _timer = 0;
    }


    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > _spawnHizi)
        {

            SezlongKontrolEt();
            //YuzmeAlaniKontrolEt();

            _timer = 0;


        }
        else
        {

        }
    }

    private void SpawnFunc()
    {
        Instantiate(_spawnClientList[0], _spawnNoktasi.position, Quaternion.identity);

    }

    private void SezlongKontrolEt()
    {

        for (int i = 1; i < _aiHareketKontrol._sezlonglar.Count; i++)
        {
            if (_aiHareketKontrol._sezlonglar[i].gameObject.transform.parent.gameObject.activeSelf)
            {
                if (_aiHareketKontrol._sezlonglar[i].GetComponent<YuzmeAlaniMi>()._yuzmeAlaniMi)
                {
                    if (_aiHareketKontrol._sezlonglar[i].GetComponent<YuzmeAlaniClientIstek>()._doluMu == false)
                    {
                        _timer = 0;
                        // Debug.Log(_konumNumber);
                        SpawnFunc();


                        break;
                    }
                    else
                    {

                    }

                }
                else
                {
                    if (_aiHareketKontrol._sezlonglar[i].GetComponent<clientIstekleriniKarsilamakIcin>()._doluMu == false)
                    {
                        _timer = 0;
                        // Debug.Log(_konumNumber);
                        SpawnFunc();


                        break;
                    }
                    else
                    {

                    }
                }

            }
            else
            {

            }

        }




    }

    private void YuzmeAlaniKontrolEt()
    {

        for (int i = 1; i < _aiHareketKontrol._yuzmeAlanlari.Count; i++)
        {
            if (_aiHareketKontrol._yuzmeAlanlari[i].gameObject.transform.parent.gameObject.activeSelf)
            {
                if (_aiHareketKontrol._yuzmeAlanlari[i].GetComponent<YuzmeAlaniClientIstek>()._doluMu == false)
                {
                    _timer = 0;
                    // Debug.Log(_konumNumber);
                    SpawnFunc();


                    break;
                }
                else
                {

                }
            }
            else
            {

            }

        }




    }
}
