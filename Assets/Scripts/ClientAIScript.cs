using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class ClientAIScript : MonoBehaviour
{

    [SerializeField] private bool _Erkek1;
    [SerializeField] private bool _Erkek2;
    [SerializeField] private bool _ErkekCocuk;
    [SerializeField] private bool _Kadin1;
    [SerializeField] private bool _Kadin2;
    [SerializeField] private bool _KizCocuk;


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

    public bool _yuzecek;

    public bool _yuzmedenDonuyor;

    public bool _dusaGit;

    public bool _dusaGidiyor;

    public int _dusSirasiNumber;

    public bool _dusSirasinda;

    public bool _dusta;

    public int _dusNumber;

    private GameObject _rotaBaslangic;

    private int rota;

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
        _yuzmedenDonuyor = false;

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

        if (_giysiliKarakter.activeSelf)
        {
            _giysiliAnimator.SetBool("walk", true);
        }
        else
        {
            _giysisizAnimator.SetBool("walk", true);
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

                                            if (_kabinSirasinda == false || _kabinde == false)
                                            {
                                                if (_giysiliKarakter.activeSelf)
                                                {

                                                    _giysiliAnimator.SetBool("walk", true);
                                                }
                                                else
                                                {

                                                    _giysisizAnimator.SetBool("walk", true);
                                                }
                                            }
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

                                            if (_dusSirasinda == false || _dusta == false)
                                            {
                                                if (_giysiliKarakter.activeSelf)
                                                {

                                                    _giysiliAnimator.SetBool("walk", true);
                                                }
                                                else
                                                {

                                                    _giysisizAnimator.SetBool("walk", true);
                                                }
                                            }
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
        else if (other.gameObject == _gidilecekSezlonglar[_dolanSezlongNumber])
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
        else if (other.gameObject.tag == "RotaOlustur")
        {
            if (_yuzecek)
            {
                Debug.Log("YUZMEYE GELDI");

                _rotaBaslangic = other.gameObject;

                if (_yuzmedenDonuyor)
                {
                    _dusaGit = true;

                    for (int i = 0; i < _snorkelSeti.Count; i++)
                    {
                        _snorkelSeti[i].SetActive(false);
                    }

                    _gidilecekSezlonglar[_dolanSezlongNumber].GetComponent<YuzmeAlaniClientIstek>().DenizdenCikti();
                }
                else
                {


                    YuzmeRotasiOlustur();

                    //Debug.Log(_aiHareketKontrol._yuzmeRotalari[rota].name);
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

            _kopukEfekti.SetActive(true);

            gameObject.transform.parent = null;

            if (_yuzecek)
            {
                if (_giysiliKarakter.activeSelf)
                {
                    _giysiliAnimator.SetBool("walk", false);
                    _giysiliAnimator.SetBool("shower", true);
                }
                else
                {
                    _giysisizAnimator.SetBool("walk", false);
                    _giysisizAnimator.SetBool("shower", true);
                }


            }
            else
            {

            }

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
                if (_giysiliKarakter.activeSelf)
                {

                    _giysiliAnimator.SetBool("walk", false);
                }
                else
                {

                    _giysisizAnimator.SetBool("walk", false);
                }
            }
            else
            {

            }

            //SetDestination(_ambarNoktasi.transform);
            //_agent.SetDestination(_ambarNoktasi.transform.position);

            //Debug.Log("Tarlada");
        }
        else if (other.gameObject == _aiHareketKontrol._kabinler[0])
        {

            if (_yuzecek)
            {
                if (_yuzmedenDonuyor)
                {
                    gameObject.transform.parent = GameObject.FindGameObjectWithTag("AIParent").transform;

                    _yuzmedenDonuyor = false;

                    _kabineGit = true;
                }
                else
                {

                }
            }
            else
            {

            }
        }
        else if (other.gameObject.tag == "YuzmeAlani")
        {
            if (_yuzecek)
            {
                if (_giysiliKarakter.activeSelf)
                {
                    _giysiliAnimator.SetBool("walk", false);
                    _giysiliAnimator.SetBool("swim", true);
                }
                else
                {
                    _giysisizAnimator.SetBool("walk", false);
                    _giysisizAnimator.SetBool("swim", true);
                }


            }
            else
            {

            }


            //SetDestination(_ambarNoktasi.transform);
            //_agent.SetDestination(_ambarNoktasi.transform.position);

            //Debug.Log("Tarlada");
        }
        else if (other.gameObject == _aiHareketKontrol._yuzmeRotalari[rota])
        {
            Debug.Log("HA BURAYA GELDI");
            if (_yuzecek)
            {
                if (_giysiliKarakter.activeSelf)
                {
                    _giysiliAnimator.SetBool("swim", false);
                    _giysiliAnimator.SetBool("swimidle", true);
                }
                else
                {
                    _giysisizAnimator.SetBool("swim", false);
                    _giysisizAnimator.SetBool("swimidle", true);
                }

                StartCoroutine(YuzmeyeDevamEdiyor());


            }
            else
            {

            }
        }
        else if (other.gameObject == _aiHareketKontrol._dusSirasi[_dusSirasiNumber])
        {

            //_aiHareketKontrol._kabinSirasi[_kabinSirasiNumber].GetComponent<KabinSirasiKontrol>()._doluMu = true;



            //_kabinSirasinda = false;

            if (_dusaGit == true)
            {
                if (_giysiliKarakter.activeSelf)
                {

                    _giysiliAnimator.SetBool("walk", false);
                }
                else
                {

                    _giysisizAnimator.SetBool("walk", false);
                }
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

            if (_giysiliKarakter.activeSelf)
            {

                _giysiliAnimator.SetBool("walk", true);
            }
            else
            {

                _giysisizAnimator.SetBool("walk", true);
            }

        }
        else if (other.gameObject == _aiHareketKontrol._dusSirasi[_dusSirasiNumber])
        {

            //_aiHareketKontrol._kabinSirasi[_kabinSirasiNumber].GetComponent<KabinSirasiKontrol>()._doluMu = true;



            //_kabinSirasinda = false;


            if (_giysiliKarakter.activeSelf)
            {

                _giysiliAnimator.SetBool("walk", true);
            }
            else
            {

                _giysisizAnimator.SetBool("walk", true);
            }


            //SetDestination(_ambarNoktasi.transform);
            //_agent.SetDestination(_ambarNoktasi.transform.position);

            //Debug.Log("Tarlada");
        }
        else if (other.gameObject.tag == "YuzmeAlani")
        {
            if (_yuzecek)
            {
                if (_giysiliKarakter.activeSelf)
                {
                    _giysiliAnimator.SetBool("swim", false);
                    _giysiliAnimator.SetBool("walk", true);
                }
                else
                {
                    _giysisizAnimator.SetBool("swim", false);
                    _giysisizAnimator.SetBool("walk", true);
                }


            }
            else
            {

            }


            //SetDestination(_ambarNoktasi.transform);
            //_agent.SetDestination(_ambarNoktasi.transform.position);

            //Debug.Log("Tarlada");
        }
        else if (other.gameObject == _aiHareketKontrol._yuzmeRotalari[rota])
        {
            if (_yuzecek)
            {
                if (_giysiliKarakter.activeSelf)
                {
                    _giysiliAnimator.SetBool("swimidle", false);
                    _giysiliAnimator.SetBool("swim", true);
                }
                else
                {
                    _giysisizAnimator.SetBool("swimidle", false);
                    _giysisizAnimator.SetBool("swim", true);
                }

                _aiHareketKontrol._yuzmeRotalari[rota].GetComponent<KabinSirasiKontrol>()._doluMu = false;

            }
            else
            {

            }
        }
        else
        {

        }
    }

    private void YuzmeRotasiOlustur()
    {
        rota = Random.Range(0, _aiHareketKontrol._yuzmeAlanlari.Count);

        if (_aiHareketKontrol._yuzmeRotalari[rota].GetComponent<KabinSirasiKontrol>()._doluMu == false)
        {
            _point = _aiHareketKontrol._yuzmeRotalari[rota].transform;
            _aiHareketKontrol._yuzmeRotalari[rota].GetComponent<KabinSirasiKontrol>()._doluMu = true;
        }
        else
        {
            YuzmeRotasiOlustur();
        }
    }

    private void SetDestination(Transform point)
    {
        _agent.SetDestination(point.position);
    }

    private IEnumerator GiysiKapat()
    {
        if (_giysiliKarakter.activeSelf)
        {

            _giysiliAnimator.SetBool("walk", false);
        }
        else
        {

            _giysisizAnimator.SetBool("walk", false);
        }

        yield return new WaitForSeconds(1.3f);

        _giysiliKarakter.SetActive(false);

        yield return new WaitForSeconds(2.5f);

        _giysisizKarakter.SetActive(true);

        _kabineGit = false;

        yield return new WaitForSeconds(1f);

        //_aiHareketKontrol._kabinler[_kabinNumber].GetComponent<kabinetkapakacilma>()._doluMu = false;


        _point = _gidilecekSezlonglar[_dolanSezlongNumber].transform;

        if (_giysiliKarakter.activeSelf)
        {

            _giysiliAnimator.SetBool("walk", true);
        }
        else
        {

            _giysisizAnimator.SetBool("walk", true);
        }



    }

    private IEnumerator GiysiAc()
    {

        if (_giysiliKarakter.activeSelf)
        {

            _giysiliAnimator.SetBool("walk", false);
        }
        else
        {

            _giysisizAnimator.SetBool("walk", false);
        }

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

        if (_giysiliKarakter.activeSelf)
        {

            _giysiliAnimator.SetBool("walk", true);
        }
        else
        {

            _giysisizAnimator.SetBool("walk", true);
        }
    }

    private IEnumerator SezlongtanAyril()
    {

        yield return new WaitForSeconds(0.5f);

        gameObject.transform.DORotate(new Vector3(0, 135f, 0), 0.5f);

        yield return new WaitForSeconds(0.5f);
        //gameObject.transform.DOMoveY(-0.5f, 0.5f);

        if (_Erkek1)
        {
            //_giysisizKarakter.transform.DOLocalMove(new Vector3(-0.2f, -0.6f, -0.25f), 0.1f);
            _giysisizKarakter.transform.localPosition = new Vector3(-0.2f, -0.6f, -0.25f);
        }
        else if (_Erkek2)
        {
            //_giysisizKarakter.transform.DOLocalMove(new Vector3(-0.2f, -0.6f, -0.25f), 0.1f);
            _giysisizKarakter.transform.localPosition = new Vector3(-0.2f, -0.6f, -0.25f);
        }
        else if (_ErkekCocuk)
        {
            //_giysisizKarakter.transform.DOLocalMove(new Vector3(-0.2f, -0.5f, -1f), 0.1f);
            _giysisizKarakter.transform.localPosition = new Vector3(-0.2f, -0.5f, -1f);
        }
        else if (_Kadin1)
        {
            //_giysisizKarakter.transform.DOLocalMove(new Vector3(-0.2f, -0.6f, -0.25f), 0.1f);
            _giysisizKarakter.transform.localPosition = new Vector3(-0.2f, -0.6f, -0.25f);
        }
        else if (_Kadin2)
        {
            //_giysisizKarakter.transform.DOLocalMove(new Vector3(-0.2f, -1f, -0.5f), 0.1f);
            _giysisizKarakter.transform.localPosition = new Vector3(-0.2f, -1f, -0.5f);
        }
        else if (_KizCocuk)
        {
            //_giysisizKarakter.transform.DOLocalMove(new Vector3(-0.2f, -0.6f, -0.25f), 0.1f);
            _giysisizKarakter.transform.localPosition = new Vector3(-0.2f, -0.6f, -0.25f);
        }
        else
        {

        }


        //yield return new WaitForSeconds(0.5f);

        if (_giysiliKarakter.activeSelf)
        {
            _giysiliAnimator.SetBool("walk", false);
            _giysiliAnimator.SetBool("yatis", true);
        }
        else
        {
            _giysisizAnimator.SetBool("walk", false);
            _giysisizAnimator.SetBool("yatis", true);
        }

        yield return new WaitForSeconds(10f);

        if (_giysiliKarakter.activeSelf)
        {
            _giysiliAnimator.SetBool("yatis", false);
            _giysiliAnimator.SetBool("walk", true);
        }
        else
        {
            _giysisizAnimator.SetBool("yatis", false);
            _giysisizAnimator.SetBool("walk", true);
        }
        //gameObject.transform.DOMoveY(0f, 0.5f);
        if (_ErkekCocuk)
        {
            //_giysisizKarakter.transform.DOLocalMove(new Vector3(0, 0.52f, 0), 0.1f);
            _giysisizKarakter.transform.localPosition = new Vector3(0, 0.52f, 0);
        }
        else
        {
            //_giysisizKarakter.transform.DOLocalMove(new Vector3(0, 0, 0), 0.1f);
            _giysisizKarakter.transform.localPosition = new Vector3(0, 0, 0);
        }

        //yield return new WaitForSeconds(0.5f);
        gameObject.transform.parent = GameObject.FindGameObjectWithTag("AIParent").transform;
        //_point = _aiHareketKontrol._kabinler[0].transform;
        _kabineGit = true;
        _kabineGidiyor = false;
        _kabinSirasinda = false;


        //KabinSirasinaGec();
    }

    private IEnumerator YuzmeyeBasla()
    {

        //gameObject.transform.parent = GameObject.FindGameObjectWithTag("AIParent").transform;

        gameObject.transform.DORotate(new Vector3(0, 135f, 0), 0.5f);



        if (_giysiliKarakter.activeSelf)
        {
            _giysiliAnimator.SetBool("walk", false);
            _giysiliAnimator.SetBool("paletgiy", true);
        }
        else
        {
            _giysisizAnimator.SetBool("walk", false);
            _giysisizAnimator.SetBool("paletgiy", true);
        }

        yield return new WaitForSeconds(1f);

        _snorkelEfekti.SetActive(true);

        for (int i = 0; i < _snorkelSeti.Count; i++)
        {
            _snorkelSeti[i].SetActive(true);
        }

        _gidilecekSezlonglar[_dolanSezlongNumber].GetComponent<YuzmeAlaniClientIstek>().PaletGiy();

        yield return new WaitForSeconds(1f);

        _snorkelEfekti.SetActive(false);

        if (_giysiliKarakter.activeSelf)
        {
            _giysiliAnimator.SetBool("paletgiy", false);
            _giysiliAnimator.SetBool("walk", true);
        }
        else
        {
            _giysisizAnimator.SetBool("paletgiy", false);
            _giysisizAnimator.SetBool("walk", true);
        }

        _point = _gidilecekSezlonglar[_dolanSezlongNumber].GetComponent<YuzmeAlaniClientIstek>()._denizeGirilecekNokta.transform;

        //_kabineGit = true;
        //_kabineGidiyor = false;
        //_kabinSirasinda = false;

    }

    private IEnumerator YuzmeyeDevamEdiyor()
    {
        yield return new WaitForSeconds(15f);
        //gameObject.transform.parent = GameObject.FindGameObjectWithTag("AIParent").transform;

        _point = _rotaBaslangic.transform;

        _yuzmedenDonuyor = true;

        gameObject.transform.parent = GameObject.FindGameObjectWithTag("AIParent").transform;









        //_kabineGit = true;
        //_kabineGidiyor = false;
        //_kabinSirasinda = false;

    }

    private IEnumerator Dustayiz()
    {
        yield return new WaitForSeconds(4f);
        //gameObject.transform.parent = GameObject.FindGameObjectWithTag("AIParent").transform;

        _kopukEfekti.SetActive(false);

        _dusta = false;

        _dusaGit = false;





        _dusaGidiyor = false;



        _point = _aiHareketKontrol._kabinler[0].transform;

        if (_yuzecek)
        {
            if (_giysiliKarakter.activeSelf)
            {
                _giysiliAnimator.SetBool("shower", false);
                _giysiliAnimator.SetBool("walk", true);
            }
            else
            {
                _giysisizAnimator.SetBool("shower", false);
                _giysisizAnimator.SetBool("walk", true);
            }


        }
        else
        {

        }





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
