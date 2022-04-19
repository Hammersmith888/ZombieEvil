using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    [SerializeField] float DestroyTime = 0.05f;
    void Start()
    {
        Destroy(gameObject, DestroyTime);
    }

    
    void Update()
    {
        
    }
}
