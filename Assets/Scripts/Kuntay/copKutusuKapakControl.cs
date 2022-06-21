using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class copKutusuKapakControl : MonoBehaviour
{
    [SerializeField] Animator kapakAnimator;
    [SerializeField] private Transform _malKabulNoktasi;

    private float _timer;

    private SirtCantasiScript _sirtCantasiScript;
    private float _velocityX;
    private float _velocityZ;

    private void Start()
    {
        _sirtCantasiScript = GameObject.FindGameObjectWithTag("Player").GetComponent<SirtCantasiScript>();
        //_playerRigidbody = GameObject.FindGameObjectWithTag("Player").GetComponent<JoystickController>()._rigidbody;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            kapakAnimator.SetBool("open", true);
            kapakAnimator.SetBool("close", false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            kapakAnimator.SetBool("open", false);
            kapakAnimator.SetBool("close", true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _velocityX = GameObject.FindGameObjectWithTag("Player").GetComponent<JoystickController>()._velocityX;
            _velocityZ = GameObject.FindGameObjectWithTag("Player").GetComponent<JoystickController>()._velocityZ;
            //Debug.Log(_velocityX);
            //Debug.Log(_velocityZ);
            if (_velocityX == 0 || _velocityZ == 0)
            {
                _timer += Time.deltaTime;

                if (_timer > 0.1f)
                {
                    _sirtCantasiScript.CopKutusunaAt(_malKabulNoktasi);

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
