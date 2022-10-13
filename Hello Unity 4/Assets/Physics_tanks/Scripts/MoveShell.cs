using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShell : MonoBehaviour 
{
    [SerializeField] private float _speed = 1.0f;

    private void Update() 
    {
        transform.Translate(0.0f, 0.0f, Time.deltaTime * _speed);
    }
}