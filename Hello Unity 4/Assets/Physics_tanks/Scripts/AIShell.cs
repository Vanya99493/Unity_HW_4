using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShell : MonoBehaviour {

    [SerializeField] private GameObject _explosion;
    
    private Rigidbody _rigidbody;

    private void OnCollisionEnter(Collision col) {

        if (col.gameObject.tag == "tank") 
        {
            Debug.Log("Hit tank");
            GameObject exp = Instantiate(_explosion, transform.position, Quaternion.identity);
            Destroy(exp, 0.5f);
            Destroy(gameObject);
        }
    }

    private void Start() 
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update() 
    {
        transform.forward = _rigidbody.velocity;
    }
}