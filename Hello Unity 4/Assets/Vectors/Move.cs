using UnityEngine;

public class Move : MonoBehaviour 
{
    [SerializeField] private Vector3 _goal = new Vector3(5, 0, 4);
    [SerializeField] private float _speed = 0.1f;

    private void LateUpdate() 
    {
        transform.Translate(_goal.normalized * _speed * Time.deltaTime);
    }
}