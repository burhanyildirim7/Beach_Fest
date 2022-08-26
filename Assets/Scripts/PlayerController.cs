using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;
//using ElephantSDK;
using DG.Tweening;


public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public int collectibleDegeri;
    public bool xVarMi = true;
    public bool collectibleVarMi = true;

    [SerializeField] private Transform _moneyEfektSpawnPoint;
    [SerializeField] private GameObject _moneyEfektObject;

    [SerializeField] private GameObject _gidecekParaObject;
    [SerializeField] private GameObject _gidecekParaParent;
    [SerializeField] private GameObject _paraUI;
    [SerializeField] private GameObject _gidecegiKonum;

    [HideInInspector] public bool _yuzuyorMu;
    [HideInInspector] public bool _elindeStaffVarMi;


    [SerializeField] private GameObject _bedelOdemePara;

    [SerializeField] private GameObject _moneySpawnPoint;


    [SerializeField] private GameObject _waterEfekt;
    [SerializeField] private GameObject _yurumeEfekt;



    private float _efektTimer;

    private int _kalanBedel;
    private float _stayTimer;

    private float _velocityX;
    private float _velocityZ;

    private bool _denizeGirdi;

    public string _yollanacakLevel;

    private void Awake()
    {
        if (instance == null) instance = this;
        //else Destroy(this);
    }

    void Start()
    {
        StartingEvents();


    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "YuzmeAlani")
        {
            _yuzuyorMu = true;

        }
        else if (other.gameObject.tag == "money")
        {
            other.gameObject.SetActive(false);

            MoreMountains.NiceVibrations.MMVibrationManager.Haptic(MoreMountains.NiceVibrations.HapticTypes.MediumImpact);

            StartCoroutine(ParaAnim());
        }
        else if (other.gameObject.tag == "BedelOdemeCollider")
        {
            _kalanBedel = other.GetComponent<BedelOdemeler>()._odenecekBedel;
        }
        else if (other.gameObject.tag == "DenizSiniri")
        {
            _denizeGirdi = true;
            _waterEfekt.SetActive(true);
            _yurumeEfekt.SetActive(false);
            gameObject.GetComponent<SirtCantasiScript>().SirtCantasiLevelStart();

        }
        else
        {

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "BedelOdemeCollider")
        {
            _velocityX = GameObject.FindGameObjectWithTag("Player").GetComponent<JoystickController>()._velocityX;
            _velocityZ = GameObject.FindGameObjectWithTag("Player").GetComponent<JoystickController>()._velocityZ;


            if (_velocityX == 0 || _velocityZ == 0)
            {
                if (PlayerPrefs.GetInt("Money") > 0 && _kalanBedel > 0)
                {
                    _stayTimer += Time.deltaTime;

                    if (_stayTimer > 0.05f)
                    {
                        _paraUI.transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.2f).OnComplete(() => _paraUI.transform.DOScale(new Vector3(1f, 1f, 1f), 0.2f));
                        GameObject para = Instantiate(_bedelOdemePara, _moneySpawnPoint.transform.position, Quaternion.identity);
                        para.transform.rotation = Quaternion.Euler(90, 0, 0);
                        //para.transform.DOMove(other.gameObject.transform.position, 1f);
                        para.transform.DOJump(other.gameObject.transform.position, 3, 1, 1f);
                        //other.GetComponent<BedelOdemeler>().BedelOdeUlen();
                        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - 10);
                        UIController.instance.SetGamePlayScoreText();
                        _kalanBedel -= 10;

                        MoreMountains.NiceVibrations.MMVibrationManager.Haptic(MoreMountains.NiceVibrations.HapticTypes.MediumImpact);

                        _stayTimer = 0;
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


        }
        else
        {

        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "YuzmeAlani")
        {
            _yuzuyorMu = false;

        }
        else if (other.gameObject.tag == "DenizSiniri")
        {
            _denizeGirdi = false;
            _yurumeEfekt.SetActive(true);
            _waterEfekt.SetActive(false);
        }
        else
        {

        }
    }


    IEnumerator ParaAnim()
    {
        Instantiate(_moneyEfektObject, _moneyEfektSpawnPoint.position, Quaternion.identity);

        GameObject gidecekPara = Instantiate(_gidecekParaObject, _gidecekParaParent.transform.position, Quaternion.identity);

        gidecekPara.transform.parent = _gidecekParaParent.transform;
        gidecekPara.transform.rotation = Quaternion.Euler(0, 0, 20);

        gidecekPara.transform.DOLocalMove(new Vector3(_gidecegiKonum.transform.localPosition.x, _gidecegiKonum.transform.localPosition.y, 0), 1f).OnComplete(() => Destroy(gidecekPara.gameObject));

        yield return new WaitForSeconds(1f);

        _paraUI.transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.2f).OnComplete(() => _paraUI.transform.DOScale(new Vector3(1f, 1f, 1f), 0.2f));

        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + 10);
        UIController.instance.SetGamePlayScoreText();


        if (PlayerPrefs.GetInt("UpgradeSenaryosu") < 1)
        {
            if (PlayerPrefs.GetInt("Money") > 500)
            {
                StartCoroutine(GameObject.FindGameObjectWithTag("OnBoardingController").GetComponent<OnBoardingController>().UpgradeSenaryo());
                PlayerPrefs.SetInt("UpgradeSenaryosu", 1);
            }
            else
            {

            }

        }
        else
        {

        }
    }




    public void StartingEvents()
    {

        transform.parent.transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.parent.transform.position = Vector3.zero;
        GameController.instance.isContinue = false;
        GameController.instance.score = 0;
        transform.position = new Vector3(0, transform.position.y, 0);
        GetComponent<Collider>().enabled = true;
        GetComponent<SirtCantasiScript>().SirtCantasiLevelStart();

        _yuzuyorMu = false;

        _denizeGirdi = false;

        _yollanacakLevel = 1.ToString();
        string gönderilenLevel = JsonUtility.ToJson(_yollanacakLevel);
        AppMetrica.Instance.ReportEvent("level_start", gönderilenLevel);
        AppMetrica.Instance.SendEventsBuffer();
        //Elephant.LevelStarted(1);

        PlayerPrefs.SetInt("Money", 99999);
        UIController.instance.SetGamePlayScoreText();

    }

    private void OnApplicationQuit()
    {
        _yollanacakLevel = 1.ToString();
        string gönderilenLevel = JsonUtility.ToJson(_yollanacakLevel);
        AppMetrica.Instance.ReportEvent("level_finish", gönderilenLevel);
        AppMetrica.Instance.SendEventsBuffer();
        //Elephant.LevelCompleted(1);
        //Debug.Log("Application ending after " + Time.time + " seconds");
    }

}
