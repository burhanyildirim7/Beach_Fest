using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CanvasBuyutmeScript : MonoBehaviour
{
    [SerializeField] private GameObject _canvas;


    private Vector3 _boyut;

    private void Start()
    {
        _boyut = _canvas.transform.localScale;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BedelOdemeMoney")
        {

        }
        else if (other.gameObject.tag == "Player")
        {
            _canvas.transform.DOScale(new Vector3(_boyut.x * 1.2f, _boyut.y * 1.2f, _boyut.z * 1.2f), 0.1f).OnComplete(() => BoyutGuncelle());

        }
        else
        {

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _canvas.transform.DOScale(new Vector3(_boyut.x / 1.2f, _boyut.y / 1.2f, _boyut.z / 1.2f), 0.1f).OnComplete(() => BoyutGuncelle());

        }
        else
        {

        }
    }

    private void BoyutGuncelle()
    {
        _boyut = _canvas.transform.localScale;
    }

}
