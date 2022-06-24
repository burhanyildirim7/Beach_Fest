using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SefScript : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Animator _agentAnimator;
    [SerializeField] private GameObject _stackNoktasi;

    private Transform _point;

    [Header("Drink Yonetme Objeler")]
    [SerializeField] private GameObject _drinkTepsi;
    public List<GameObject> _tepsidekiDrinks = new List<GameObject>();

    [Header("Cantada Bulunan Obje Cesitleri")]
    public List<GameObject> _cantadakiDrinkObjeleri = new List<GameObject>();

    public List<GameObject> _sezlonglar = new List<GameObject>();

    public int _drinkStackSiniri;

    public int _cantadakiDrinkSayisi;


    void Start()
    {
        _cantadakiDrinkSayisi = 0;
        _drinkStackSiniri = 1;

        _point = _stackNoktasi.transform;



        SirtCantasiLevelStart();
        SefCapacityGuncelle();
        SefSpeedGuncelle();
    }


    void FixedUpdate()
    {
        if (GameController.instance.isContinue == true)
        {
            if (gameObject.GetComponent<NavMeshAgent>().enabled == true)
            {
                SetDestination(_point);
            }
            else
            {

            }



            if (_cantadakiDrinkObjeleri.Count > 0)
            {
                for (int i = 0; i < _sezlonglar.Count; i++)
                {
                    if (_sezlonglar[i].gameObject.transform.parent.gameObject.activeSelf)
                    {
                        if (_sezlonglar[i].GetComponent<clientIstekleriniKarsilamakIcin>().dondurmaIstiyor)
                        {
                            _point = _sezlonglar[i].transform;
                            break;
                        }
                        else
                        {
                            _point = _stackNoktasi.transform;
                        }
                    }
                    else
                    {

                    }

                }
            }
            else
            {
                _point = _stackNoktasi.transform;
            }

        }


    }

    private void SetDestination(Transform point)
    {
        _agent.SetDestination(point.position);
    }

    public void SefCapacityGuncelle()
    {
        if (PlayerPrefs.GetInt("WorkerCapacityLevel") == 0)
        {
            _drinkStackSiniri = 1;

        }
        else if (PlayerPrefs.GetInt("WorkerCapacityLevel") == 1)
        {
            _drinkStackSiniri = 2;

        }
        else if (PlayerPrefs.GetInt("WorkerCapacityLevel") == 2)
        {
            _drinkStackSiniri = 3;

        }
        else
        {

        }
    }

    public void SefSpeedGuncelle()
    {
        if (PlayerPrefs.GetInt("WorkerSpeedLevel") == 0)
        {
            _agent.speed = 2;

        }
        else if (PlayerPrefs.GetInt("WorkerSpeedLevel") == 1)
        {
            _agent.speed = 2;

        }
        else if (PlayerPrefs.GetInt("WorkerSpeedLevel") == 2)
        {
            _agent.speed = 2;

        }
        else
        {

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _stackNoktasi)
        {
            _agentAnimator.SetBool("Walk", false);
        }
        else
        {

        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == _stackNoktasi)
        {
            _agentAnimator.SetBool("Walk", true);
        }
        else
        {

        }
    }

    public void DrinkTopla()
    {

        if (_cantadakiDrinkObjeleri.Count < _drinkStackSiniri)
        {
            for (int i = 0; i < _tepsidekiDrinks.Count; i++)
            {
                if (_tepsidekiDrinks[i].activeSelf == false)
                {
                    _tepsidekiDrinks[i].SetActive(true);
                    //_cantadakiObjeler.Add(_tepsidekiDrinks[i].gameObject);
                    _cantadakiDrinkObjeleri.Add(_tepsidekiDrinks[i].gameObject);
                    _cantadakiDrinkSayisi++;

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

    public void DrinkCek()
    {
        if (_cantadakiDrinkObjeleri.Count > 0)
        {
            int sira = _cantadakiDrinkObjeleri.Count - 1;
            // _cantadakiStuffObjeleri[_cantadakiStuffObjeleri.Count - 1].gameObject.transform.parent = null;
            //_cantadakiStuffObjeleri[_cantadakiStuffObjeleri.Count - 1].gameObject.transform.DOMove(malKabulNoktasi.position, 0.5f);
            // _cantadakiStuffObjeleri[_cantadakiStuffObjeleri.Count - 1].gameObject.transform.DOLocalRotate(Vector3.zero, 0.5f);
            //Destroy(_cantadakiStuffObjeleri[_cantadakiStuffObjeleri.Count - 1].gameObject, 1f);
            _cantadakiDrinkObjeleri[_cantadakiDrinkObjeleri.Count - 1].SetActive(false);
            _cantadakiDrinkObjeleri.RemoveAt(_cantadakiDrinkObjeleri.Count - 1);
            //_cantadakiObjeler.RemoveAt(_cantadakiDrinkObjeleri.Count - 1);
            _cantadakiDrinkSayisi--;

            //CantayiDüzenle();

        }
        else
        {

        }
    }



    public void SirtCantasiLevelStart()
    {


        int cantadakidrinkobjesayi = _cantadakiDrinkObjeleri.Count;
        for (int i = 0; i < cantadakidrinkobjesayi; i++)
        {
            _cantadakiDrinkObjeleri[0].gameObject.SetActive(false);
            _cantadakiDrinkObjeleri.RemoveAt(0);

        }


    }
}
