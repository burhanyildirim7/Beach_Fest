using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeAlaniScript : MonoBehaviour
{
    [Header("Slider")]
    [SerializeField] private Slider _slider;
    [Header("Ekran Acilis Hizi")]
    [SerializeField] private float _spawnHizi;

    private float _velocityX;
    private float _velocityZ;

    private float _timer;

    private bool _panelAcildi;

    void Start()
    {
        _panelAcildi = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _timer = 0;
            _slider.value = 0;


        }
        else
        {

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _timer = 0;
            _slider.value = 0;
            _panelAcildi = false;

        }
        else
        {

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            _velocityX = GameObject.FindGameObjectWithTag("Player").GetComponent<JoystickController>()._velocityX;
            _velocityZ = GameObject.FindGameObjectWithTag("Player").GetComponent<JoystickController>()._velocityZ;

            if (_velocityX == 0 || _velocityZ == 0)
            {
                if (_panelAcildi == false)
                {
                    _timer += Time.deltaTime;
                    _slider.value += Time.deltaTime;

                    if (_timer > _spawnHizi)
                    {
                        _slider.value = 0;
                        UIController.instance.UpgradeCanvasAc();
                        _panelAcildi = true;

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
}