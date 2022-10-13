using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateMove : MonoBehaviour
{
    [SerializeField] private float _speed = 0.5f;

    void Update()
    {
        transform.Translate(0f, 0f, Time.deltaTime * _speed);
    }
}
