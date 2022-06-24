using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrinkDolabiScript : MonoBehaviour
{
    [Header("Stuff Toplama Hizi")]
    [SerializeField] private float _spawnHizi;
    [Header("Slider")]
    [SerializeField] private Slider _slider;
    [Header("Sinir Text")]
    [SerializeField] private Text _sinirText;

    private float _timer;
    private float _garsonTimer;

    private int _üretilenStuff;

    private float _velocityX;
    private float _velocityZ;

    void Start()
    {
        _üretilenStuff = 0;
        Invoke("Yerlestir", 1f);
        _sinirText.gameObject.SetActive(false);
    }

    private void Yerlestir()
    {
        transform.localPosition = new Vector3(-2.1f, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _timer = 0;
            _slider.value = 0;
            _sinirText.gameObject.SetActive(true);
            _sinirText.text = other.gameObject.GetComponent<SirtCantasiScript>()._cantadakiDrinkObjeleri.Count.ToString() + " / " + other.gameObject.GetComponent<SirtCantasiScript>()._drinkStackSiniri.ToString();
        }
        else if (other.gameObject.tag == "Garson")
        {
            _garsonTimer = 0;
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
            _sinirText.gameObject.SetActive(false);
        }
        else if (other.gameObject.tag == "Garson")
        {
            _garsonTimer = 0;
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

                if (other.gameObject.GetComponent<SirtCantasiScript>()._cantadakiIceCreamObjeleri.Count == 0 && other.gameObject.GetComponent<SirtCantasiScript>()._cantadakiStuffObjeleri.Count == 0)
                {
                    if (other.gameObject.GetComponent<SirtCantasiScript>()._cantadakiDrinkObjeleri.Count < other.gameObject.GetComponent<SirtCantasiScript>()._drinkStackSiniri)
                    {
                        _timer += Time.deltaTime;
                        _slider.value += Time.deltaTime;

                        if (_timer > _spawnHizi)
                        {

                            other.gameObject.GetComponent<SirtCantasiScript>().DrinkTopla();
                            _timer = 0;
                            _slider.value = 0;
                            _sinirText.text = other.gameObject.GetComponent<SirtCantasiScript>()._cantadakiDrinkObjeleri.Count.ToString() + " / " + other.gameObject.GetComponent<SirtCantasiScript>()._drinkStackSiniri.ToString();
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
        else if (other.gameObject.tag == "Garson")
        {

            if (other.gameObject.GetComponent<GarsonScript>()._cantadakiDrinkObjeleri.Count < other.gameObject.GetComponent<GarsonScript>()._drinkStackSiniri)
            {
                _garsonTimer += Time.deltaTime;


                if (_garsonTimer > 3)
                {

                    other.gameObject.GetComponent<GarsonScript>().DrinkTopla();
                    _garsonTimer = 0;


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
