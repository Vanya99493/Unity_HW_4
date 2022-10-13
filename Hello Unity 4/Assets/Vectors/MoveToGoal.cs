using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToGoal : MonoBehaviour
{
    [SerializeField] private float _speed = 2.0f;
    [SerializeField] private float _accuracy = 0.01f;
    [SerializeField] private Transform _goal;

    private void LateUpdate()
    {
        transform.LookAt(_goal.position);
        Vector3 direction = _goal.position - transform.position;

        if(direction.magnitude > _accuracy)
        {
            transform.Translate(direction.normalized * _speed * Time.deltaTime, Space.World);
        }
    }
}