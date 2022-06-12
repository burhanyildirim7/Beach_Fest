using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClientAIScript : MonoBehaviour
{

    [SerializeField] private Animator _giysiliAnimator;
    [SerializeField] private Animator _giysisizAnimator;

    [SerializeField] private GameObject _giysiliKarakter;
    [SerializeField] private GameObject _giysisizKarakter;


    [SerializeField] private NavMeshAgent _agent;

    private Transform _point;


    private AIHareketKontrol _aiHareketKontrol;

    private bool _donuyor;

    private float _timer;

    private int _konumNumber;

    private int _dolanSezlongNumber;

    // Start is called before the first frame update
    private void Awake()
    {

        _aiHareketKontrol = GameObject.FindGameObjectWithTag("AIHareketKontrol").GetComponent<AIHareketKontrol>();
    }
    void Start()
    {
        _giysisizKarakter.SetActive(false);
        _giysiliKarakter.SetActive(true);

        _point = _aiHareketKontrol._girisNoktalari[0].transform;

        _donuyor = false;

        _timer = 0;

        SezlongDoldur();
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (GameController.instance.isContinue == true)
        {
            SetDestination(_point);
        }

        if (GameController.instance.isContinue == true)
        {
            if (_timer > 1)
            {

                _timer = 0;
            }
            else
            {

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _aiHareketKontrol._girisNoktalari[0])
        {

            if (_donuyor == false)
            {
                _point = _aiHareketKontrol._girisNoktalari[1].transform;
            }
            else
            {
                _point = _aiHareketKontrol._cikisNoktalari[0].transform;
            }
            //SetDestination(_tarlaNoktasi.transform);
            //_agent.SetDestination(_tarlaNoktasi.transform.position);
            Debug.Log("Ambarda");
        }
        else if (other.gameObject == _aiHareketKontrol._girisNoktalari[1])
        {
            KabinKontrolEt();


            if (_donuyor == false)
            {
                if (_konumNumber > 0)
                {
                    _point = _aiHareketKontrol._kabinler[_konumNumber].transform;
                }
                else
                {

                }
            }
            else
            {
                _point = _aiHareketKontrol._girisNoktalari[0].transform;
            }


            //SetDestination(_ambarNoktasi.transform);
            //_agent.SetDestination(_ambarNoktasi.transform.position);

            Debug.Log("Tarlada");
        }
        else if (other.gameObject == _aiHareketKontrol._sezlonglar[_konumNumber])
        {


            if (_donuyor == false)
            {
                _donuyor = true;
            }
            else
            {

            }

            StartCoroutine(SezlongtanAyril());



            //SetDestination(_ambarNoktasi.transform);
            //_agent.SetDestination(_ambarNoktasi.transform.position);

            Debug.Log("Tarlada");
        }
        else if (other.gameObject == _aiHareketKontrol._kabinler[_konumNumber])
        {
            if (_giysiliKarakter.activeSelf)
            {
                StartCoroutine(GiysiKapat());
            }
            else
            {
                StartCoroutine(GiysiAc());
            }


            //SetDestination(_ambarNoktasi.transform);
            //_agent.SetDestination(_ambarNoktasi.transform.position);

            Debug.Log("Tarlada");
        }
        else
        {

        }
    }


    private void SetDestination(Transform point)
    {
        _agent.SetDestination(point.position);
    }

    private IEnumerator GiysiKapat()
    {
        yield return new WaitForSeconds(1.5f);

        _giysiliKarakter.SetActive(false);

        yield return new WaitForSeconds(3f);

        _giysisizKarakter.SetActive(true);

        SezlongKontrolEt();

        _point = _aiHareketKontrol._sezlonglar[_konumNumber].transform;
    }

    private IEnumerator GiysiAc()
    {
        yield return new WaitForSeconds(1.5f);

        _giysisizKarakter.SetActive(false);

        yield return new WaitForSeconds(3f);

        _giysiliKarakter.SetActive(true);

        _point = _aiHareketKontrol._girisNoktalari[1].transform;
    }

    private IEnumerator SezlongtanAyril()
    {
        yield return new WaitForSeconds(2f);
        KabinKontrolEt();
        _point = _aiHareketKontrol._kabinler[_konumNumber].transform;
    }

    private void SezlongKontrolEt()
    {
        /*
        for (int i = 1; i < _aiHareketKontrol._sezlonglar.Count; i++)
        {
            if (_aiHareketKontrol._sezlonglar[i].gameObject.transform.parent.gameObject.activeSelf)
            {
                if (_aiHareketKontrol._sezlonglar[i].GetComponent<clientIstekleriniKarsilamakIcin>()._doluMu == false)
                {
                    _konumNumber = i;
                    Debug.Log(_konumNumber);

                    break;
                }
                else
                {

                }
            }
            else
            {

            }

        }*/
        _konumNumber = _dolanSezlongNumber;
    }



    private void KabinKontrolEt()
    {
        for (int i = 1; i < _aiHareketKontrol._kabinler.Count; i++)
        {
            if (_aiHareketKontrol._kabinler[i].gameObject.transform.parent.gameObject.transform.GetChild(1).gameObject.activeSelf)
            {
                if (_aiHareketKontrol._kabinler[i].GetComponent<kabinetkapakacilma>()._doluMu == false)
                {
                    _konumNumber = i;
                    Debug.Log(_konumNumber);

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

    private void SezlongDoldur()
    {
        for (int i = 1; i < _aiHareketKontrol._sezlonglar.Count; i++)
        {
            if (_aiHareketKontrol._sezlonglar[i].gameObject.transform.parent.gameObject.activeSelf)
            {
                if (_aiHareketKontrol._sezlonglar[i].GetComponent<clientIstekleriniKarsilamakIcin>()._doluMu == false)
                {
                    _dolanSezlongNumber = i;
                    Debug.Log(_konumNumber);
                    _aiHareketKontrol._sezlonglar[i].GetComponent<clientIstekleriniKarsilamakIcin>()._doluMu = true;
                    _aiHareketKontrol._sezlonglar[i].GetComponent<clientIstekleriniKarsilamakIcin>()._dolduranClient = gameObject;
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
