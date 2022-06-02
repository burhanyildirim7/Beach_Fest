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

    void Start()
    {

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

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _timer += Time.deltaTime;

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
}
