using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCreamDolabiScript : MonoBehaviour
{

    [Header("Stuff Toplama Hizi")]
    [SerializeField] private float _spawnHizi;

    private float _timer;

    private int _üretilenStuff;

    void Start()
    {
        _üretilenStuff = 0;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _timer = 0;
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
        }
        else
        {

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _timer += Time.deltaTime;

            if (other.gameObject.GetComponent<SirtCantasiScript>()._cantadakiIceCreamObjeleri.Count < other.gameObject.GetComponent<SirtCantasiScript>()._iceCreamStackSiniri)
            {
                if (_timer > _spawnHizi)
                {

                    other.gameObject.GetComponent<SirtCantasiScript>().IceCreamTopla();
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

        }
    }
}
