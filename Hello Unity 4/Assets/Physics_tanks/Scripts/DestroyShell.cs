using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyShell : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 5);  
    }
}