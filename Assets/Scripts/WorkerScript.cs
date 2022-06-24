using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.AI;

public class WorkerScript : MonoBehaviour
{
    [Header("Objeler Toplandiğinda Parent Atanacak Obje")]
    public GameObject _sirtCantasiObject;
    [Header("Objelerin Yerlesecegi Transform Listesi")]
    public List<Transform> _yerlesmeNoktalari = new List<Transform>();
    [Header("Cantada Bulunan Objelerin Tamami")]
    public List<GameObject> _cantadakiObjeler = new List<GameObject>();
    [Header("Cantada Bulunan Obje Cesitleri")]
    public List<GameObject> _cantadakiStuffObjeleri = new List<GameObject>();


    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Animator _agentAnimator;
    [SerializeField] private GameObject _stackNoktasi;

    public List<GameObject> _sezlonglar = new List<GameObject>();

    private Transform _point;

    [Header("Kontrol Amacli")]
    public int _cantadakiObjeSayisi;

    public int _cantadakiStuffSayisi;

    public int _cantadakiIceCreamSayisi;

    public int _cantadakiDrinkSayisi;

    public int _stuffStackSiniri;

    public int _iceCreamStackSiniri;

    public int _drinkStackSiniri;

    void Start()
    {
        _cantadakiObjeSayisi = 0;
        _cantadakiStuffSayisi = 0;
        _cantadakiIceCreamSayisi = 0;
        _cantadakiDrinkSayisi = 0;
        _stuffStackSiniri = 4;
        _iceCreamStackSiniri = 1;
        _drinkStackSiniri = 1;


        PlayerCapacityGuncelle();

        _point = _stackNoktasi.transform;

        WorkerCapacityGuncelle();
        WorkerSpeedGuncelle();
    }

    private void FixedUpdate()
    {

        CantayiDüzenle();
        CantayiHizala();

        if (GameController.instance.isContinue == true)
        {
            if (gameObject.GetComponent<NavMeshAgent>().enabled == true)
            {
                SetDestination(_point);
            }
            else
            {

            }



            if (_cantadakiStuffObjeleri.Count > 0)
            {
                for (int i = 0; i < _sezlonglar.Count; i++)
                {
                    if (_sezlonglar[i].gameObject.transform.parent.gameObject.activeSelf)
                    {
                        if (_sezlonglar[i].GetComponent<clientIstekleriniKarsilamakIcin>().semsiyeIstiyor)
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
                        _point = _sezlonglar[i].transform;
                        break;
                    }

                }
            }
            else
            {
                _point = _stackNoktasi.transform;
            }

        }

        /*
        if (_cantadakiIceCreamSayisi > 0)
        {
            _iceCreamTepsi.SetActive(true);
        }
        else
        {
            _iceCreamTepsi.SetActive(false);
        }
        */
    }

    private void SetDestination(Transform point)
    {
        _agent.SetDestination(point.position);
    }

    public void WorkerCapacityGuncelle()
    {
        if (PlayerPrefs.GetInt("WorkerCapacityLevel") == 0)
        {
            _stuffStackSiniri = 4;

        }
        else if (PlayerPrefs.GetInt("WorkerCapacityLevel") == 1)
        {
            _stuffStackSiniri = 7;

        }
        else if (PlayerPrefs.GetInt("WorkerCapacityLevel") == 2)
        {
            _stuffStackSiniri = 10;

        }
        else
        {

        }
    }

    public void WorkerSpeedGuncelle()
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

    public void PlayerCapacityGuncelle()
    {
        /*
        if (PlayerPrefs.GetInt("PlayerCapacityLevel") == 0)
        {
            _stuffStackSiniri = 4;
            _iceCreamStackSiniri = 1;
            _drinkStackSiniri = 1;
        }
        else if (PlayerPrefs.GetInt("PlayerCapacityLevel") == 1)
        {
            _stuffStackSiniri = 7;
            _iceCreamStackSiniri = 2;
            _drinkStackSiniri = 2;
        }
        else if (PlayerPrefs.GetInt("PlayerCapacityLevel") == 2)
        {
            _stuffStackSiniri = 10;
            _iceCreamStackSiniri = 3;
            _drinkStackSiniri = 3;
        }
        else
        {

        }
        */
    }

    public void StuffTopla(GameObject other)
    {

        if (_cantadakiStuffObjeleri.Count < _stuffStackSiniri)
        {
            other.gameObject.transform.parent = _sirtCantasiObject.transform;
            _cantadakiObjeler.Add(other.gameObject);
            _cantadakiStuffObjeleri.Add(other.gameObject);

            int sira = _cantadakiObjeSayisi;
            //other.gameObject.transform.DOLocalMove(new Vector3(_yerlesmeNoktalari[sira].localPosition.x, _yerlesmeNoktalari[sira].localPosition.y + 0.5f, _yerlesmeNoktalari[sira].localPosition.z - 0.5f), 0.2f).OnComplete(() => other.gameObject.transform.DOLocalMove(_yerlesmeNoktalari[sira].localPosition, 0.2f));
            other.gameObject.transform.DOLocalMove(_yerlesmeNoktalari[sira].localPosition, 0.5f);
            other.gameObject.transform.DOLocalRotate(new Vector3(90, 90, 0), 0.5f);
            _cantadakiStuffSayisi++;
            _cantadakiObjeSayisi++;
        }
        else
        {

        }

    }







    public void StuffCek(Transform malKabulNoktasi)
    {
        if (_cantadakiStuffObjeleri.Count > 0)
        {
            int sira = _cantadakiStuffObjeleri.Count - 1;
            _cantadakiStuffObjeleri[_cantadakiStuffObjeleri.Count - 1].gameObject.transform.parent = null;
            _cantadakiStuffObjeleri[_cantadakiStuffObjeleri.Count - 1].gameObject.transform.DOMove(malKabulNoktasi.position, 0.5f);
            _cantadakiStuffObjeleri[_cantadakiStuffObjeleri.Count - 1].gameObject.transform.DOLocalRotate(Vector3.zero, 0.5f);
            //Destroy(_cantadakiStuffObjeleri[_cantadakiStuffObjeleri.Count - 1].gameObject, 1f);
            _cantadakiStuffObjeleri.RemoveAt(_cantadakiStuffObjeleri.Count - 1);
            _cantadakiStuffSayisi--;
            _cantadakiObjeSayisi--;
            //CantayiDüzenle();

        }
        else
        {

        }
    }








    private void CantayiDüzenle()
    {
        for (int i = 0; i < _cantadakiObjeler.Count; i++)
        {
            if (_cantadakiObjeler[i] == null)
            {
                _cantadakiObjeler.RemoveAt(i);
            }
            else
            {

            }
        }



    }

    private void CantayiHizala()
    {
        for (int i = 0; i < _sirtCantasiObject.transform.childCount; i++)
        {
            _sirtCantasiObject.transform.GetChild(i).transform.position = _yerlesmeNoktalari[i].transform.position;
        }



    }

    public void SirtCantasiLevelStart()
    {
        int cantadakiobjesayi = _cantadakiObjeler.Count;
        for (int i = 0; i < cantadakiobjesayi; i++)
        {
            Destroy(_cantadakiObjeler[0].gameObject);
            _cantadakiObjeler.RemoveAt(0);

        }

        int cantadakistuffobjesayi = _cantadakiStuffObjeleri.Count;
        for (int i = 0; i < cantadakistuffobjesayi; i++)
        {
            Destroy(_cantadakiStuffObjeleri[0].gameObject);
            _cantadakiStuffObjeleri.RemoveAt(0);

        }




        _cantadakiObjeSayisi = 0;
    }
}
