using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class ClientAIScript : MonoBehaviour
{

    [SerializeField] private Animator _giysiliAnimator;
    [SerializeField] private Animator _giysisizAnimator;

    [SerializeField] private GameObject _giysiliKarakter;
    [SerializeField] private GameObject _giysisizKarakter;

    [SerializeField] private List<GameObject> _snorkelSeti = new List<GameObject>();
    [SerializeField] private GameObject _canSimidi;
    [SerializeField] private GameObject _kopukEfekti;
    [SerializeField] private GameObject _snorkelEfekti;


    [SerializeField] private NavMeshAgent _agent;

    private Transform _point;


    private AIHareketKontrol _aiHareketKontrol;
    private AISpawnController _aiSpawnController;

    private bool _donuyor;

    private float _timer;

    private int _konumNumber;

    private int _dolanSezlongNumber;

    public int _kabinNumber;

    public bool _kabineGit;

    public bool _kabinde;

    public bool _kabineGidiyor;

    public int _kabinSirasiNumber;

    public bool _kabinSirasinda;

    [SerializeField] private List<GameObject> _gidilecekSezlonglar = new List<GameObject>();

    private List<GameObject> _gidilecekYuzmeAlanlari = new List<GameObject>();

    private int _dolanYuzmeAlaniNumber;

    private bool _yuzecek;

    private bool _yuzmedenDonuyor;

    private bool _dusaGit;

    private bool _dusaGidiyor;

    private int _dusSirasiNumber;

    private bool _dusSirasinda;

    private bool _dusta;

    private int _dusNumber;

    // Start is called before the first frame update
    private void Awake()
    {

        _aiHareketKontrol = GameObject.FindGameObjectWithTag("AIHareketKontrol").GetComponent<AIHareketKontrol>();
        _aiSpawnController = GameObject.FindGameObjectWithTag("AISpawnController").GetComponent<AISpawnController>();
    }
    void Start()
    {
        gameObject.transform.parent = GameObject.FindGameObjectWithTag("AIParent").transform;

        _giysisizKarakter.SetActive(false);
        _giysiliKarakter.SetActive(true);

        _point = _aiHareketKontrol._girisNoktalari[0].transform;

        _donuyor = false;

        _kabineGit = false;
        _dusaGit = false;

        _dusaGidiyor = false;
        _dusSirasinda = false;
        _dusta = false;

        _kabinde = false;
        _kabinSirasinda = false;

        _kabinNumber = 1;
        _dusNumber = 1;
        _timer = 0;

        //YuzmeAlaniEkle();
        SezlongEkle();
        SezlongDoldur();

        if (_gidilecekSezlonglar[_dolanSezlongNumber].GetComponent<YuzmeAlaniMi>()._yuzmeAlaniMi)
        {
            _yuzecek = true;
        }
        else
        {
            _yuzecek = false;
        }


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




                if (_donuyor == false)
                {
                    if (_kabineGit == true)
                    {
                        KabinKontrolEt();
                        // Debug.Log(_kabineGit);


                        if (_kabinNumber > 0)
                        {
                            if (gameObject.transform.parent != null)
                            {
                                if (gameObject == gameObject)
                                {
                                    if (_aiHareketKontrol._kabinler[_kabinNumber].GetComponent<kabinetkapakacilma>()._doluMu == false)
                                    {

                                        if (_kabinSirasiNumber == 0)
                                        {
                                            gameObject.GetComponent<NavMeshAgent>().enabled = true;
                                            _point = _aiHareketKontrol._kabinler[_kabinNumber].transform;
                                            _aiHareketKontrol._kabinler[_kabinNumber].GetComponent<kabinetkapakacilma>()._doluMu = true;
                                            _aiHareketKontrol._kabinSirasi[_kabinSirasiNumber].GetComponent<KabinSirasiKontrol>()._doluMu = false;
                                            gameObject.transform.parent = null;
                                            _kabineGidiyor = true;
                                        }
                                        else
                                        {

                                        }



                                        //Debug.Log(_kabinNumber);
                                    }
                                    else
                                    {
                                        if (_kabinde == false)
                                        {
                                            KabinSirasinaGec();
                                            _point = _aiHareketKontrol._kabinSirasi[_kabinSirasiNumber].transform;
                                            _aiHareketKontrol._kabinSirasi[_kabinSirasiNumber].GetComponent<KabinSirasiKontrol>()._doluMu = true;

                                            //Debug.Log("siraya gir");
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
                    else if (_dusaGit == true)
                    {
                        DusKontrolEt();
                        // Debug.Log(_kabineGit);


                        if (_dusNumber > 0)
                        {
                            if (gameObject.transform.parent != null)
                            {
                                if (gameObject == gameObject)
                                {
                                    if (_aiHareketKontrol._duslar[_dusNumber].GetComponent<DusAlaniEvent>()._doluMu == false)
                                    {

                                        if (_dusSirasiNumber == 0)
                                        {
                                            gameObject.GetComponent<NavMeshAgent>().enabled = true;
                                            _point = _aiHareketKontrol._duslar[_dusNumber].transform;
                                            _aiHareketKontrol._duslar[_dusNumber].GetComponent<DusAlaniEvent>()._doluMu = true;
                                            _aiHareketKontrol._dusSirasi[_dusSirasiNumber].GetComponent<KabinSirasiKontrol>()._doluMu = false;
                                            gameObject.transform.parent = null;
                                            _dusaGidiyor = true;
                                        }
                                        else
                                        {

                                        }



                                        //Debug.Log(_kabinNumber);
                                    }
                                    else
                                    {
                                        if (_dusta == false)
                                        {
                                            DusSirasinaGec();
                                            _point = _aiHareketKontrol._dusSirasi[_dusSirasiNumber].transform;
                                            _aiHareketKontrol._dusSirasi[_dusSirasiNumber].GetComponent<KabinSirasiKontrol>()._doluMu = true;

                                            //Debug.Log("siraya gir");
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



                //_timer = 0;
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
                _kabineGidiyor = false;
                _kabinSirasinda = false;

            }
            else
            {
                _point = _aiHareketKontrol._girisNoktalari[0].transform;
            }

            //SetDestination(_ambarNoktasi.transform);
            //_agent.SetDestination(_ambarNoktasi.transform.position);

            //Debug.Log("Tarlada");
        }
        else if (other.gameObject == _gidilecekSezlonglar[_konumNumber])
        {



            if (_gidilecekSezlonglar[_dolanSezlongNumber].GetComponent<YuzmeAlaniMi>()._yuzmeAlaniMi)
            {
                StartCoroutine(YuzmeyeBasla());
            }
            else
            {
                StartCoroutine(SezlongtanAyril());
            }




            //SetDestination(_ambarNoktasi.transform);
            //_agent.SetDestination(_ambarNoktasi.transform.position);

            //Debug.Log("Tarlada");
        }
        else if (other.gameObject == _aiHareketKontrol._kabinler[_kabinNumber])
        {
            _kabinde = true;

            gameObject.transform.parent = null;

            Debug.Log("KABINE GELDI");

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
        else if (_yuzecek)
        {
            if (other.gameObject == _gidilecekSezlonglar[_konumNumber].GetComponent<YuzmeAlaniClientIstek>()._denizeGirilecekNokta.transform)
            {
                if (_yuzmedenDonuyor)
                {
                    _dusaGit = true;

                    for (int i = 0; i < _snorkelSeti.Count; i++)
                    {
                        _snorkelSeti[i].SetActive(true);
                    }
                }
                else
                {
                    int rota = Random.Range(0, _aiHareketKontrol._yuzmeAlanlari.Count + 1);

                    _point = _aiHareketKontrol._yuzmeAlanlari[rota].transform;

                    YuzmeyeDevamEdiyor();
                }
            }
            else
            {

            }


            //SetDestination(_ambarNoktasi.transform);
            //_agent.SetDestination(_ambarNoktasi.transform.position);

            //Debug.Log("Tarlada");
        }
        else if (other.gameObject == _aiHareketKontrol._duslar[_dusNumber])
        {
            Debug.Log("DUSA GELDI");
            _dusta = true;

            gameObject.transform.parent = null;

            StartCoroutine(Dustayiz());


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
        else if (other.gameObject == _aiHareketKontrol._kabinSirasi[_kabinSirasiNumber])
        {

            _aiHareketKontrol._kabinSirasi[_kabinSirasiNumber].GetComponent<KabinSirasiKontrol>()._doluMu = true;

            //_kabinSirasinda = false;

            if (_kabineGit == true)
            {
                //gameObject.GetComponent<NavMeshAgent>().enabled = false;
            }
            else
            {

            }

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
        else if (other.gameObject == _aiHareketKontrol._kabinSirasi[_kabinSirasiNumber])
        {

            //_aiHareketKontrol._kabinSirasi[_kabinSirasiNumber].GetComponent<KabinSirasiKontrol>()._doluMu = false;

            //_kabinSirasinda = false;

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


        _point = _gidilecekSezlonglar[_dolanSezlongNumber].transform;



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
        //_point = _aiHareketKontrol._kabinler[0].transform;
        _kabineGit = true;
        _kabineGidiyor = false;
        _kabinSirasinda = false;
        //KabinSirasinaGec();
    }

    private IEnumerator YuzmeyeBasla()
    {
        yield return new WaitForSeconds(1f);
        //gameObject.transform.parent = GameObject.FindGameObjectWithTag("AIParent").transform;

        gameObject.transform.DORotate(new Vector3(0, 135f, 0), 1f);

        yield return new WaitForSeconds(2f);

        for (int i = 0; i < _snorkelSeti.Count; i++)
        {
            _snorkelSeti[i].SetActive(true);
        }

        yield return new WaitForSeconds(1f);

        _point = _gidilecekSezlonglar[_dolanSezlongNumber].GetComponent<YuzmeAlaniClientIstek>()._denizeGirilecekNokta.transform;

        //_kabineGit = true;
        //_kabineGidiyor = false;
        //_kabinSirasinda = false;

    }

    private IEnumerator YuzmeyeDevamEdiyor()
    {
        yield return new WaitForSeconds(15f);
        //gameObject.transform.parent = GameObject.FindGameObjectWithTag("AIParent").transform;

        _point = _gidilecekSezlonglar[_dolanSezlongNumber].GetComponent<YuzmeAlaniClientIstek>()._denizeGirilecekNokta.transform;

        _yuzmedenDonuyor = true;

        yield return new WaitForSeconds(2f);







        //_kabineGit = true;
        //_kabineGidiyor = false;
        //_kabinSirasinda = false;

    }

    private IEnumerator Dustayiz()
    {
        yield return new WaitForSeconds(3f);
        //gameObject.transform.parent = GameObject.FindGameObjectWithTag("AIParent").transform;

        _dusta = false;

        _dusaGit = false;

        _kabineGit = true;









        //_kabineGit = true;
        //_kabineGidiyor = false;
        //_kabinSirasinda = false;

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

    private void DusKontrolEt()
    {
        if (_dusaGidiyor == false)
        {
            for (int i = 1; i < _aiHareketKontrol._duslar.Count; i++)
            {
                if (_aiHareketKontrol._duslar[i].gameObject.transform.parent.gameObject.transform.GetChild(1).gameObject.activeSelf)
                {
                    if (_aiHareketKontrol._duslar[i].GetComponent<DusAlaniEvent>()._doluMu == false)
                    {
                        _dusNumber = i;


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

    private void SezlongEkle()
    {
        for (int i = 1; i < _aiHareketKontrol._sezlonglar.Count; i++)
        {
            if (_aiHareketKontrol._sezlonglar[i].gameObject.transform.parent.gameObject.activeSelf)
            {
                if (_aiHareketKontrol._sezlonglar[i].GetComponent<YuzmeAlaniMi>()._yuzmeAlaniMi)
                {
                    if (_aiHareketKontrol._sezlonglar[i].GetComponent<YuzmeAlaniClientIstek>()._doluMu == false)
                    {
                        _gidilecekSezlonglar.Add(_aiHareketKontrol._sezlonglar[i]);

                    }
                    else
                    {
                        for (int k = 0; k < _gidilecekSezlonglar.Count; k++)
                        {
                            if (_aiHareketKontrol._sezlonglar[i] == _gidilecekSezlonglar[k])
                            {
                                _gidilecekSezlonglar.RemoveAt(k);
                            }
                            else
                            {

                            }
                        }
                    }
                }
                else
                {
                    if (_aiHareketKontrol._sezlonglar[i].GetComponent<clientIstekleriniKarsilamakIcin>()._doluMu == false)
                    {
                        _gidilecekSezlonglar.Add(_aiHareketKontrol._sezlonglar[i]);

                    }
                    else
                    {
                        for (int k = 0; k < _gidilecekSezlonglar.Count; k++)
                        {
                            if (_aiHareketKontrol._sezlonglar[i] == _gidilecekSezlonglar[k])
                            {
                                _gidilecekSezlonglar.RemoveAt(k);
                            }
                            else
                            {

                            }
                        }
                    }
                }

            }
            else
            {

            }

        }
    }

    private void SezlongDoldur()
    {
        /*
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
        */

        int k = 0;
        k = Random.Range(0, _gidilecekSezlonglar.Count);
        if (_gidilecekSezlonglar[k].gameObject.transform.parent.gameObject.activeSelf)
        {
            if (_gidilecekSezlonglar[k].GetComponent<YuzmeAlaniMi>()._yuzmeAlaniMi)
            {
                if (_gidilecekSezlonglar[k].GetComponent<YuzmeAlaniClientIstek>()._doluMu == false)
                {
                    _dolanSezlongNumber = k;
                    // Debug.Log(_konumNumber);
                    _gidilecekSezlonglar[k].GetComponent<YuzmeAlaniClientIstek>()._doluMu = true;
                    _gidilecekSezlonglar[k].GetComponent<YuzmeAlaniClientIstek>()._dolduranClient = gameObject;
                    //_aiSpawnController._uret = false;

                }
                else
                {

                }
            }
            else
            {
                if (_gidilecekSezlonglar[k].GetComponent<clientIstekleriniKarsilamakIcin>()._doluMu == false)
                {
                    _dolanSezlongNumber = k;
                    // Debug.Log(_konumNumber);
                    _gidilecekSezlonglar[k].GetComponent<clientIstekleriniKarsilamakIcin>()._doluMu = true;
                    _gidilecekSezlonglar[k].GetComponent<clientIstekleriniKarsilamakIcin>()._dolduranClient = gameObject;
                    //_aiSpawnController._uret = false;

                }
                else
                {

                }
            }

        }
        else
        {
            SezlongDoldur();
        }



    }

    private void KabinSirasinaGec()
    {
        if (_kabineGidiyor == false)
        {
            if (_kabinSirasinda == false)
            {
                for (int i = 0; i < _aiHareketKontrol._kabinSirasi.Count; i++)
                {
                    if (_aiHareketKontrol._kabinSirasi[i].gameObject.activeSelf)
                    {
                        if (_aiHareketKontrol._kabinSirasi[i].GetComponent<KabinSirasiKontrol>()._doluMu == false)
                        {
                            //_aiHareketKontrol._kabinSirasi[_kabinSirasiNumber].GetComponent<KabinSirasiKontrol>()._doluMu = false;
                            _kabinSirasiNumber = i;
                            _aiHareketKontrol._kabinSirasi[_kabinSirasiNumber].GetComponent<KabinSirasiKontrol>()._doluMu = true;
                            _kabinSirasinda = true;

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
                if (_kabinSirasiNumber > 0)
                {
                    if (_aiHareketKontrol._kabinSirasi[_kabinSirasiNumber - 1].GetComponent<KabinSirasiKontrol>()._doluMu == false)
                    {
                        _aiHareketKontrol._kabinSirasi[_kabinSirasiNumber].GetComponent<KabinSirasiKontrol>()._doluMu = false;
                        _kabinSirasiNumber--;
                        _aiHareketKontrol._kabinSirasi[_kabinSirasiNumber].GetComponent<KabinSirasiKontrol>()._doluMu = true;
                        //_kabinSirasinda = true;
                    }
                    else
                    {


                    }
                }
                else
                {

                }

                /*
                for (int i = 0; i < _aiHareketKontrol._kabinSirasi.Count; i++)
                {
                    if (_aiHareketKontrol._kabinSirasi[i].gameObject.activeSelf)
                    {
                        if (_aiHareketKontrol._kabinSirasi[i].GetComponent<KabinSirasiKontrol>()._doluMu == false)
                        {
                            if (i <= _kabinSirasiNumber)
                            {
                                _aiHareketKontrol._kabinSirasi[_kabinSirasiNumber].GetComponent<KabinSirasiKontrol>()._doluMu = false;
                                _kabinSirasiNumber = i;
                                _aiHareketKontrol._kabinSirasi[_kabinSirasiNumber].GetComponent<KabinSirasiKontrol>()._doluMu = true;
                                //_kabinSirasinda = true;

                                break;
                            }



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
                */
            }

        }
        else
        {

        }

    }

    private void DusSirasinaGec()
    {
        if (_dusaGidiyor == false)
        {
            if (_dusSirasinda == false)
            {
                for (int i = 0; i < _aiHareketKontrol._dusSirasi.Count; i++)
                {
                    if (_aiHareketKontrol._dusSirasi[i].gameObject.activeSelf)
                    {
                        if (_aiHareketKontrol._dusSirasi[i].GetComponent<KabinSirasiKontrol>()._doluMu == false)
                        {
                            //_aiHareketKontrol._kabinSirasi[_kabinSirasiNumber].GetComponent<KabinSirasiKontrol>()._doluMu = false;
                            _dusSirasiNumber = i;
                            _aiHareketKontrol._dusSirasi[_dusSirasiNumber].GetComponent<KabinSirasiKontrol>()._doluMu = true;
                            _dusSirasinda = true;

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
                if (_dusSirasiNumber > 0)
                {
                    if (_aiHareketKontrol._dusSirasi[_dusSirasiNumber - 1].GetComponent<KabinSirasiKontrol>()._doluMu == false)
                    {
                        _aiHareketKontrol._dusSirasi[_dusSirasiNumber].GetComponent<KabinSirasiKontrol>()._doluMu = false;
                        _dusSirasiNumber--;
                        _aiHareketKontrol._dusSirasi[_dusSirasiNumber].GetComponent<KabinSirasiKontrol>()._doluMu = true;
                        //_kabinSirasinda = true;
                    }
                    else
                    {


                    }
                }
                else
                {

                }

                /*
                for (int i = 0; i < _aiHareketKontrol._kabinSirasi.Count; i++)
                {
                    if (_aiHareketKontrol._kabinSirasi[i].gameObject.activeSelf)
                    {
                        if (_aiHareketKontrol._kabinSirasi[i].GetComponent<KabinSirasiKontrol>()._doluMu == false)
                        {
                            if (i <= _kabinSirasiNumber)
                            {
                                _aiHareketKontrol._kabinSirasi[_kabinSirasiNumber].GetComponent<KabinSirasiKontrol>()._doluMu = false;
                                _kabinSirasiNumber = i;
                                _aiHareketKontrol._kabinSirasi[_kabinSirasiNumber].GetComponent<KabinSirasiKontrol>()._doluMu = true;
                                //_kabinSirasinda = true;

                                break;
                            }



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
                */
            }

        }
        else
        {

        }

    }


    private void YuzmeAlaniEkle()
    {
        for (int i = 1; i < _aiHareketKontrol._yuzmeAlanlari.Count; i++)
        {
            if (_aiHareketKontrol._yuzmeAlanlari[i].gameObject.transform.parent.gameObject.activeSelf)
            {

                if (_aiHareketKontrol._yuzmeAlanlari[i].GetComponent<YuzmeAlaniClientIstek>()._doluMu == false)
                {
                    _gidilecekYuzmeAlanlari.Add(_aiHareketKontrol._yuzmeAlanlari[i]);

                }
                else
                {
                    for (int k = 0; k < _gidilecekYuzmeAlanlari.Count; k++)
                    {
                        if (_aiHareketKontrol._yuzmeAlanlari[i] == _gidilecekYuzmeAlanlari[k])
                        {
                            _gidilecekYuzmeAlanlari.RemoveAt(k);
                        }
                        else
                        {

                        }
                    }
                }
            }
            else
            {

            }

        }
    }

    private void YuzmeAlaniDoldur()
    {
        /*
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
        */

        int k = 0;
        k = Random.Range(0, _gidilecekYuzmeAlanlari.Count);
        if (_gidilecekYuzmeAlanlari[k].gameObject.transform.parent.gameObject.activeSelf)
        {
            if (_gidilecekYuzmeAlanlari[k].GetComponent<YuzmeAlaniClientIstek>()._doluMu == false)
            {
                _dolanYuzmeAlaniNumber = k;
                // Debug.Log(_konumNumber);
                _gidilecekYuzmeAlanlari[k].GetComponent<YuzmeAlaniClientIstek>()._doluMu = true;
                _gidilecekYuzmeAlanlari[k].GetComponent<YuzmeAlaniClientIstek>()._dolduranClient = gameObject;
                //_aiSpawnController._uret = false;

            }
            else
            {

            }
        }
        else
        {
            //YuzmeAlaniDoldur();
        }



    }
}
