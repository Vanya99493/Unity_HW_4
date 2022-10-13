using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour {

    [SerializeField] private GameObject _explosion;

    private float _speed = 0.0f;
    private float _ySpeed = 0.0f;
    private float _mass = 30.0f;
    private float _force = 4.0f;
    private float _drag = 1.0f;
    private float _gravity = -9.8f;
    private float _gAccel;
    private float _acceleration;

    private void OnCollisionEnter(Collision col) 
    {
        if (col.gameObject.tag == "tank") 
        {
            GameObject exp = Instantiate(_explosion, transform.position, Quaternion.identity);
            Destroy(exp, 0.5f);
            Destroy(gameObject);
        }
    }

    private void Start() 
    {
        _acceleration = _force / _mass;
        _speed += _acceleration * 1.0f;
        _gAccel = _gravity / _mass;
    }

    private void LateUpdate() 
    {
        _speed *= (1 - Time.deltaTime * _drag);
        _ySpeed += _gAccel * Time.deltaTime;
        transform.Translate(0.0f, _ySpeed, _speed);
    }
}
