using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuffDolabiScript : MonoBehaviour
{
    [Header("Uretilecek Stuff Objesi")]
    [SerializeField] private GameObject _stuff;
    [Header("Spawn Point")]
    [SerializeField] private GameObject _spawnPoint;
    [Header("Stuff Toplama Hizi")]
    [SerializeField] private float _spawnHizi;

    private float _timer;

    private int _üretilenStuff;

    void Start()
    {
        _üretilenStuff = 0;
    }


    void Update()
    {

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

            if (other.gameObject.GetComponent<SirtCantasiScript>()._cantadakiIceCreamObjeleri.Count == 0 && other.gameObject.GetComponent<SirtCantasiScript>()._cantadakiDrinkObjeleri.Count == 0)
            {
                if (other.gameObject.GetComponent<SirtCantasiScript>()._cantadakiStuffObjeleri.Count < other.gameObject.GetComponent<SirtCantasiScript>()._stuffStackSiniri)
                {
                    if (_timer > _spawnHizi)
                    {
                        GameObject stuff = Instantiate(_stuff, _spawnPoint.transform.position, Quaternion.identity);
                        other.gameObject.GetComponent<SirtCantasiScript>().StuffTopla(stuff);
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
        else
        {

        }
    }
}
