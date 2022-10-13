using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour 
{
    public float speed = 10.0f;

    [SerializeField] private float _rotationSpeed = 100.0f;
    [SerializeField] private Transform _transGun;
    [SerializeField] private Transform _gun;
    [SerializeField] private GameObject _bulletObj;

    private void Update() 
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * _rotationSpeed;

        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        transform.Translate(0, 0, translation);

        transform.Rotate(0, rotation, 0);

        if (Input.GetKey(KeyCode.T)) 
        {
            _transGun.RotateAround(_transGun.position, _transGun.right, -2.0f);
        } else if (Input.GetKey(KeyCode.G)) 
        {
            _transGun.RotateAround(_transGun.position, _transGun.right, 2.0f);
        } else if (Input.GetKeyDown(KeyCode.B)) 
        {
            Instantiate(_bulletObj, _gun.position, _gun.rotation);
        }
    }
}