using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickController : MonoBehaviour
{
    public float _speed;
    public FloatingJoystick _floatingJoystick;
    public Rigidbody _rigidbody;

    public float _velocityX;
    public float _velocityZ;

    [SerializeField] private PlayerController _playerController;

    [SerializeField] private Animator _animator;

    public void FixedUpdate()
    {
        if (GameController.instance.isContinue == true && GameController.instance._kameraHareketli == false)
        {
            Vector3 direction = Vector3.forward * _floatingJoystick.Vertical + Vector3.right * _floatingJoystick.Horizontal;
            // transform.Translate(direction * Time.deltaTime * _speed);
            _rigidbody.velocity = new Vector3(_floatingJoystick.Horizontal * _speed, _rigidbody.velocity.y, _floatingJoystick.Vertical * _speed);

            if (_floatingJoystick.Horizontal != 0 || _floatingJoystick.Vertical != 0)
            {
                transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
            }

            /*
            if (_floatingJoystick.Horizontal == 0 && _floatingJoystick.Vertical == 0)
            {
                _rigidbody.velocity = Vector3.zero;

            }
            */
            _velocityX = _rigidbody.velocity.x;
            _velocityZ = _rigidbody.velocity.z;


            if (_rigidbody.velocity.x != 0 || _rigidbody.velocity.z != 0)
            {
                if (_playerController._yuzuyorMu == true)
                {
                    _animator.SetBool("walk", false);
                    _animator.SetBool("swimidle", false);
                    _animator.SetBool("swim", true);
                }
                else
                {
                    _animator.SetBool("swimidle", false);
                    _animator.SetBool("swim", false);


                    if (_playerController._elindeStaffVarMi == true)
                    {
                        _animator.SetBool("walk", false);
                        _animator.SetBool("swim", false);
                        _animator.SetBool("swimidle", false);
                        _animator.SetBool("carryidle", false);
                        _animator.SetBool("carry", true);
                    }
                    else
                    {
                        _animator.SetBool("swim", false);
                        _animator.SetBool("swimidle", false);
                        _animator.SetBool("carry", false);
                        _animator.SetBool("carryidle", false);
                        _animator.SetBool("walk", true);

                    }

                }

            }
            else
            {
                if (_playerController._yuzuyorMu == true)
                {
                    _animator.SetBool("walk", false);
                    _animator.SetBool("swim", false);
                    _animator.SetBool("swimidle", true);
                }
                else
                {
                    _animator.SetBool("swim", false);
                    _animator.SetBool("swimidle", false);


                    if (_playerController._elindeStaffVarMi == true)
                    {
                        _animator.SetBool("walk", false);
                        _animator.SetBool("swim", false);
                        _animator.SetBool("swimidle", false);
                        _animator.SetBool("carry", false);
                        _animator.SetBool("carryidle", true);
                    }
                    else
                    {
                        _animator.SetBool("swim", false);
                        _animator.SetBool("swimidle", false);
                        _animator.SetBool("carry", false);
                        _animator.SetBool("carryidle", false);
                        _animator.SetBool("walk", false);

                    }

                }

            }


            //transform.Rotate(0, _floatingJoystick.Horizontal * 1f, 0);
        }
        else
        {

        }



    }



}
