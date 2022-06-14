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

    private int _kabinNumber;

    private bool _kabineGit;

    private bool _kabinde;

    private bool _kabineGidiyor;

    // Start is called before the first frame update
    private void Awake()
    {

        _aiHareketKontrol = GameObject.FindGameObjectWithTag("AIHareketKontrol").GetComponent<AIHareketKontrol>();
    }
    void Start()
    {
        gameObject.transform.parent = GameObject.FindGameObjectWithTag("AIParent").transform;

        _giysisizKarakter.SetActive(false);
        _giysiliKarakter.SetActive(true);

        _point = _aiHareketKontrol._girisNoktalari[0].transform;

        _donuyor = false;

        _kabineGit = false;

        _kabinde = false;

        _timer = 0;

        SezlongDoldur();
    }

    private void FixedUpdate()
    {
        _timer += Time.deltaTime;

        if (GameController.instance.isContinue == true)
        {
            if (gameObject.GetComponent<NavMeshAgent>().enabled == true)
            {
                SetDestination(_point);
            }
            else
            {

            }

        }

        if (GameController.instance.isContinue == true)
        {
            if (_timer > 0.1f)
            {
                KabinKontrolEt();


                if (_donuyor == false)
                {
                    if (_kabineGit == true)
                    {
                        // Debug.Log(_kabineGit);


                        if (_kabinNumber > 0)
                        {
                            if (_aiHareketKontrol._kabinler[_kabinNumber].GetComponent<kabinetkapakacilma>()._doluMu == false)
                            {
                                if (gameObject.transform.parent != null)
                                {
                                    if (gameObject == GameObject.FindGameObjectWithTag("AIParent").gameObject.transform.GetChild(0).gameObject)
                                    {
                                        gameObject.GetComponent<NavMeshAgent>().enabled = true;
                                        _point = _aiHareketKontrol._kabinler[_kabinNumber].transform;
                                        _aiHareketKontrol._kabinler[_kabinNumber].GetComponent<kabinetkapakacilma>()._doluMu = true;
                                        gameObject.transform.parent = null;
                                        _kabineGidiyor = true;

                                        //Debug.Log(_kabinNumber);
                                    }
                                    else
                                    {
                                        if (_kabinde == false)
                                        {

                                            _point = _aiHareketKontrol._kabinler[0].transform;
                                        }
                                        else
                                        {

                                        }
                                        //_point = _aiHareketKontrol._kabinler[0].transform;
                                        //_point = gameObject.transform;
                                    }
                                }
                                else
                                {

                                }




                            }
                            else
                            {
                                /*
                                if (_kabinde == false)
                                {

                                    _point = _aiHareketKontrol._kabinler[0].transform;
                                }
                                else
                                {

                                }
                                */

                            }

                        }
                        else
                        {

                        }
                    }
                    else
                    {

                    }

                }
                else
                {

                }

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
            //Debug.Log("Ambarda");
        }
        else if (other.gameObject == _aiHareketKontrol._girisNoktalari[1])
        {



            if (_donuyor == false)
            {
                _kabineGit = true;
            }
            else
            {
                _point = _aiHareketKontrol._girisNoktalari[0].transform;
            }

            //SetDestination(_ambarNoktasi.transform);
            //_agent.SetDestination(_ambarNoktasi.transform.position);

            //Debug.Log("Tarlada");
        }
        else if (other.gameObject == _aiHareketKontrol._sezlonglar[_konumNumber])
        {




            StartCoroutine(SezlongtanAyril());



            //SetDestination(_ambarNoktasi.transform);
            //_agent.SetDestination(_ambarNoktasi.transform.position);

            //Debug.Log("Tarlada");
        }
        else if (other.gameObject == _aiHareketKontrol._kabinler[_kabinNumber])
        {
            _kabinde = true;

            gameObject.transform.parent = null;

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

            //Debug.Log("Tarlada");
        }
        else if (other.gameObject == _aiHareketKontrol._kabinler[0])
        {
            if (_kabineGit == true)
            {
                gameObject.GetComponent<NavMeshAgent>().enabled = false;
            }
            else
            {

            }


            //SetDestination(_ambarNoktasi.transform);
            //_agent.SetDestination(_ambarNoktasi.transform.position);

            //Debug.Log("Tarlada");
        }
        else if (other.gameObject == _aiHareketKontrol._cikisNoktalari[0])
        {
            Destroy(gameObject);


            //SetDestination(_ambarNoktasi.transform);
            //_agent.SetDestination(_ambarNoktasi.transform.position);

            //Debug.Log("Tarlada");
        }
        else
        {

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == _aiHareketKontrol._kabinler[_kabinNumber])
        {
            _kabinde = false;

            _kabineGidiyor = false;
            //SetDestination(_ambarNoktasi.transform);
            //_agent.SetDestination(_ambarNoktasi.transform.position);

            //Debug.Log("Tarlada");
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
        yield return new WaitForSeconds(1.3f);

        _giysiliKarakter.SetActive(false);

        yield return new WaitForSeconds(2.5f);

        _giysisizKarakter.SetActive(true);

        _kabineGit = false;

        yield return new WaitForSeconds(1f);

        //_aiHareketKontrol._kabinler[_kabinNumber].GetComponent<kabinetkapakacilma>()._doluMu = false;

        SezlongKontrolEt();

        _point = _aiHareketKontrol._sezlonglar[_konumNumber].transform;
    }

    private IEnumerator GiysiAc()
    {
        yield return new WaitForSeconds(1.3f);

        _giysisizKarakter.SetActive(false);

        yield return new WaitForSeconds(2.5f);

        _giysiliKarakter.SetActive(true);

        _kabineGit = false;

        if (_donuyor == false)
        {
            _donuyor = true;
        }
        else
        {

        }

        yield return new WaitForSeconds(1f);

        //_aiHareketKontrol._kabinler[_kabinNumber].GetComponent<kabinetkapakacilma>()._doluMu = false;

        _point = _aiHareketKontrol._girisNoktalari[1].transform;
    }

    private IEnumerator SezlongtanAyril()
    {
        yield return new WaitForSeconds(10f);
        gameObject.transform.parent = GameObject.FindGameObjectWithTag("AIParent").transform;
        _kabineGit = true;
        _kabineGidiyor = false;
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
        if (_kabineGidiyor == false)
        {
            for (int i = 1; i < _aiHareketKontrol._kabinler.Count; i++)
            {
                if (_aiHareketKontrol._kabinler[i].gameObject.transform.parent.gameObject.transform.GetChild(1).gameObject.activeSelf)
                {
                    if (_aiHareketKontrol._kabinler[i].GetComponent<kabinetkapakacilma>()._doluMu == false)
                    {
                        _kabinNumber = i;


                        break;
                    }
                    else
                    {
                        //_kabinNumber = 0;
                    }
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

    private void SezlongDoldur()
    {
        for (int i = 1; i < _aiHareketKontrol._sezlonglar.Count; i++)
        {
            if (_aiHareketKontrol._sezlonglar[i].gameObject.transform.parent.gameObject.activeSelf)
            {
                if (_aiHareketKontrol._sezlonglar[i].GetComponent<clientIstekleriniKarsilamakIcin>()._doluMu == false)
                {
                    _dolanSezlongNumber = i;
                    // Debug.Log(_konumNumber);
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
