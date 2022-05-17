using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColiseumScript : MonoBehaviour
{
    [Header("Ihtiyac Listesi")]
    public bool _samanGerekli;
    public bool _altinGerekli;
    public bool _demirGerekli;
    public bool _gladyatorGerekli;

    [Header("Acilmasi İcin İhtiyac Olan Malzemelerin Sayi Texti")]
    public Text _ihtiyacText;

    [Header("Acilmasi İcin İhtiyac Olan Malzeme Sayisi(Gerekmeyenlere 0 Yazicalak)")]
    public int _gerekliSamanSayisi;
    public int _gerekliAltinSayisi;
    public int _gerekliDemirSayisi;
    public int _gerekliGladyatorSayisi;

    [Header("Cekilen Malzemenin Gidecegi Transform")]
    public Transform _malKabulNoktasi;

    private int _toplananMalzemeSayisi;
    private MeshRenderer _meshRenderer;
    private SirtCantasiScript _sirtCantasiScript;
    private Rigidbody _playerRigidbody;

    private float _timer;


    void Start()
    {

        _sirtCantasiScript = GameObject.FindGameObjectWithTag("Player").GetComponent<SirtCantasiScript>();
        _playerRigidbody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        _meshRenderer = GetComponent<MeshRenderer>();
        _ihtiyacText.text = _gerekliSamanSayisi.ToString();

        _timer = 0;
    }


    void Update()
    {

    }


    private void OnTriggerStay(Collider other)
    {
        if (GameController.instance.isContinue == true)
        {
            if (other.gameObject.tag == "Player")
            {
                if (_playerRigidbody.velocity.x == 0 || _playerRigidbody.velocity.z == 0)
                {
                    if (_gerekliSamanSayisi > 0)
                    {
                        _timer += Time.deltaTime;

                        if (_timer > 0.1f)
                        {
                            if (_sirtCantasiScript._cantadakiSamanObjeleri.Count > 0)
                            {
                                _sirtCantasiScript.SamanCek(_malKabulNoktasi);
                                _gerekliSamanSayisi--;
                                _ihtiyacText.text = _gerekliSamanSayisi.ToString();
                                _timer = 0;
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
                        GameController.instance.isContinue = false;
                        GameController.instance.SetScore(100);
                        GameController.instance.ScoreCarp(1);
                        UIController.instance.ActivateWinScreen();
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
}
