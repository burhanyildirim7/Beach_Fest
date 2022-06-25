using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanSimidiSandigi : MonoBehaviour
{
    [Header("Stuff Toplama Hizi")]
    [SerializeField] private float _spawnHizi;
    [Header("Slider")]
    [SerializeField] private Slider _slider;
    [Header("Sinir Text")]
    [SerializeField] private Text _sinirText;
    [Header("Image")]
    [SerializeField] private GameObject _image;

    private float _timer;

    private int _üretilenStuff;

    private float _velocityX;
    private float _velocityZ;

    void Start()
    {
        _üretilenStuff = 0;
        _sinirText.gameObject.SetActive(false);
        _image.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _timer = 0;
            _slider.value = 0;
            _image.SetActive(true);
            _sinirText.gameObject.SetActive(true);

            if (other.gameObject.GetComponent<SirtCantasiScript>()._canSimidi.activeSelf == false)
            {

                _sinirText.text = "0 / 1";

            }
            else
            {
                _sinirText.text = "1 / 1";
            }

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
            _image.SetActive(false);
            _sinirText.gameObject.SetActive(false);
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

                if (other.gameObject.GetComponent<SirtCantasiScript>()._canSimidi.activeSelf == false)
                {

                    _timer += Time.deltaTime;
                    _slider.value += Time.deltaTime;

                    if (_timer > _spawnHizi)
                    {

                        other.gameObject.GetComponent<SirtCantasiScript>().CanSimidiTopla();
                        _timer = 0;
                        _slider.value = 0;
                        _sinirText.text = "0 / 1";
                    }
                    else
                    {

                    }
                }
                else
                {
                    _sinirText.text = "1 / 1";
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
