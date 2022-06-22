using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BedelOdemeler : MonoBehaviour
{

    [SerializeField] private Text _bedelText;
    [SerializeField] private bool _alan1Kabin1;
    [SerializeField] private bool _alan1Kabin2;
    [SerializeField] private bool _alan1Dus1;
    [SerializeField] private bool _alan1SezlongAlani;
    [SerializeField] private bool _alan1DenizAlani;
    [SerializeField] private bool _alan1Drink;
    [SerializeField] private bool _alan1IceCream;

    public int _odenecekBedel;

    private float _velocityX;
    private float _velocityZ;

    private Vector3 _boyut;

    private void Start()
    {
        _boyut = _bedelText.transform.parent.gameObject.transform.parent.gameObject.transform.localScale;

        if (_alan1Kabin1)
        {
            if (PlayerPrefs.GetInt("Alan1Kabin1") > 0)
            {
                _odenecekBedel = PlayerPrefs.GetInt("Alan1Kabin1");
                _bedelText.text = "$" + _odenecekBedel.ToString();
            }
            else
            {
                PlayerPrefs.SetInt("Alan1Kabin1", _odenecekBedel);
            }

        }
        else if (_alan1Kabin2)
        {
            if (PlayerPrefs.GetInt("Alan1Kabin2") > 0)
            {
                _odenecekBedel = PlayerPrefs.GetInt("Alan1Kabin2");
                _bedelText.text = "$" + _odenecekBedel.ToString();
            }
            else
            {
                PlayerPrefs.SetInt("Alan1Kabin2", _odenecekBedel);
            }

        }
        else if (_alan1Dus1)
        {
            if (PlayerPrefs.GetInt("Alan1Dus1") > 0)
            {
                _odenecekBedel = PlayerPrefs.GetInt("Alan1Dus1");
                _bedelText.text = "$" + _odenecekBedel.ToString();
            }
            else
            {
                PlayerPrefs.SetInt("Alan1Dus1", _odenecekBedel);
            }

        }
        else if (_alan1SezlongAlani)
        {
            if (PlayerPrefs.GetInt("Alan1SezlongAlani") > 0)
            {
                _odenecekBedel = PlayerPrefs.GetInt("Alan1SezlongAlani");
                _bedelText.text = "$" + _odenecekBedel.ToString();
            }
            else
            {
                PlayerPrefs.SetInt("Alan1SezlongAlani", _odenecekBedel);
            }

        }
        else if (_alan1DenizAlani)
        {
            if (PlayerPrefs.GetInt("Alan1DenizAlani") > 0)
            {
                _odenecekBedel = PlayerPrefs.GetInt("Alan1DenizAlani");
                _bedelText.text = "$" + _odenecekBedel.ToString();
            }
            else
            {
                PlayerPrefs.SetInt("Alan1DenizAlani", _odenecekBedel);
            }

        }
        else if (_alan1Drink)
        {
            if (PlayerPrefs.GetInt("Alan1Drink") > 0)
            {
                _odenecekBedel = PlayerPrefs.GetInt("Alan1Drink");
                _bedelText.text = "$" + _odenecekBedel.ToString();
            }
            else
            {
                PlayerPrefs.SetInt("Alan1Drink", _odenecekBedel);
            }

        }
        else if (_alan1IceCream)
        {
            if (PlayerPrefs.GetInt("Alan1IceCream") > 0)
            {
                _odenecekBedel = PlayerPrefs.GetInt("Alan1IceCream");
                _bedelText.text = "$" + _odenecekBedel.ToString();
            }
            else
            {
                PlayerPrefs.SetInt("Alan1IceCream", _odenecekBedel);
            }

        }
        else
        {

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BedelOdemeMoney")
        {
            BedelOdeUlen();
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Player")
        {
            _bedelText.transform.parent.gameObject.transform.parent.gameObject.transform.DOScale(new Vector3(_boyut.x * 1.2f, _boyut.y * 1.2f, _boyut.z * 1.2f), 0.1f).OnComplete(() => BoyutGuncelle());

        }
        else
        {

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _bedelText.transform.parent.gameObject.transform.parent.gameObject.transform.DOScale(new Vector3(_boyut.x / 1.2f, _boyut.y / 1.2f, _boyut.z / 1.2f), 0.1f).OnComplete(() => BoyutGuncelle());

        }
        else
        {

        }
    }

    private void BoyutGuncelle()
    {
        _boyut = _bedelText.transform.parent.gameObject.transform.parent.gameObject.transform.localScale;
    }
    public void BedelOdeUlen()
    {
        //_velocityX = GameObject.FindGameObjectWithTag("Player").GetComponent<JoystickController>()._velocityX;
        //_velocityZ = GameObject.FindGameObjectWithTag("Player").GetComponent<JoystickController>()._velocityZ;
        //Debug.Log(_velocityX);
        //Debug.Log(_velocityZ);

        _odenecekBedel -= 10;
        _bedelText.transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.2f).OnComplete(() => _bedelText.transform.DOScale(new Vector3(1f, 1f, 1f), 0.2f));
        _bedelText.text = "$" + _odenecekBedel.ToString();


        if (_alan1Kabin1)
        {
            PlayerPrefs.SetInt("Alan1Kabin1", _odenecekBedel);
            _bedelText.text = "$" + _odenecekBedel.ToString();
        }
        else if (_alan1Kabin2)
        {
            PlayerPrefs.SetInt("Alan1Kabin2", _odenecekBedel);
            _bedelText.text = "$" + _odenecekBedel.ToString();
        }
        else if (_alan1Dus1)
        {
            PlayerPrefs.SetInt("Alan1Dus1", _odenecekBedel);
            _bedelText.text = "$" + _odenecekBedel.ToString();
        }
        else if (_alan1SezlongAlani)
        {
            PlayerPrefs.SetInt("Alan1SezlongAlani", _odenecekBedel);
            _bedelText.text = "$" + _odenecekBedel.ToString();
        }
        else if (_alan1DenizAlani)
        {
            PlayerPrefs.SetInt("Alan1DenizAlani", _odenecekBedel);
            _bedelText.text = "$" + _odenecekBedel.ToString();
        }
        else if (_alan1Drink)
        {
            PlayerPrefs.SetInt("Alan1Drink", _odenecekBedel);
            _bedelText.text = "$" + _odenecekBedel.ToString();
        }
        else if (_alan1IceCream)
        {
            PlayerPrefs.SetInt("Alan1IceCream", _odenecekBedel);
            _bedelText.text = "$" + _odenecekBedel.ToString();
        }
        else
        {

        }


    }
}
