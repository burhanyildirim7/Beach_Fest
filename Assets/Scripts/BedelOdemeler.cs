using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BedelOdemeler : MonoBehaviour
{

    [SerializeField] private Text _bedelText;

    public int _odenecekBedel;

    private float _velocityX;
    private float _velocityZ;

    private Vector3 _boyut;

    private void Start()
    {
        _boyut = _bedelText.transform.parent.gameObject.transform.parent.gameObject.transform.localScale;
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





    }
}
