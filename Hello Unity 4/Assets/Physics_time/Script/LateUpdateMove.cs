using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LateUpdateMove : MonoBehaviour
{
    [SerializeField] private float _speed = 0.5f;

    void LateUpdate()
    {
        transform.Translate(0f, 0f, Time.deltaTime * _speed);
    }
}
