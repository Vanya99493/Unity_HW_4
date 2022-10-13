using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondsUpdate : MonoBehaviour
{
    [SerializeField] private float _timeStartOffset = 0f;
    [SerializeField] private float _speed = 0.5f;

    private bool _gotStartTime = false;

    void Update()
    {
        if (!_gotStartTime)
        {
            _timeStartOffset = Time.realtimeSinceStartup;
            _gotStartTime = true;
        }

        transform.position = new Vector3(
            transform.position.x,
            transform.position.y,
            _speed * (Time.realtimeSinceStartup - _timeStartOffset)
            );
    }
}
