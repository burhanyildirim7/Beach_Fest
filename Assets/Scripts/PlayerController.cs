using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;
using ElephantSDK;
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


    private float _stayTimer;

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

            StartCoroutine(ParaAnim());
        }
        else
        {

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "BedelOdemeCollider")
        {
            if (PlayerPrefs.GetInt("Money") > 0)
            {
                _stayTimer += Time.deltaTime;

                if (_stayTimer > 0.5f)
                {
                    _paraUI.transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.2f).OnComplete(() => _paraUI.transform.DOScale(new Vector3(1f, 1f, 1f), 0.2f));
                    other.GetComponent<BedelOdemeler>().BedelOdeUlen();
                    PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - 10);
                    UIController.instance.SetGamePlayScoreText();
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


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "YuzmeAlani")
        {
            _yuzuyorMu = false;
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

        Elephant.LevelStarted(1);

    }

    private void OnApplicationQuit()
    {
        Elephant.LevelCompleted(1);
        //Debug.Log("Application ending after " + Time.time + " seconds");
    }

}
