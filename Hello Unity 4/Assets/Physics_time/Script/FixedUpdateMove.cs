using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedUpdateMove : MonoBehaviour
{
    [SerializeField] private float _speed = 0.5f;

    void FixedUpdate()
    {
        transform.Translate(0f, 0f, Time.fixedDeltaTime * _speed);
    }
}
