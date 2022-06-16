using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BedelOdemeler : MonoBehaviour
{

    [SerializeField] private Text _bedelText;

    [SerializeField] private int _odenecekBedel;

    private float _velocityX;
    private float _velocityZ;

    public void BedelOdeUlen()
    {
        _velocityX = GameObject.FindGameObjectWithTag("Player").GetComponent<JoystickController>()._velocityX;
        _velocityZ = GameObject.FindGameObjectWithTag("Player").GetComponent<JoystickController>()._velocityZ;
        //Debug.Log(_velocityX);
        //Debug.Log(_velocityZ);
        if (_velocityX == 0 || _velocityZ == 0)
        {
            _odenecekBedel -= 10;
            _bedelText.transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.2f).OnComplete(() => _bedelText.transform.DOScale(new Vector3(1f, 1f, 1f), 0.2f));
            _bedelText.text = "$" + _odenecekBedel.ToString();
        }
        else
        {

        }




    }
}
