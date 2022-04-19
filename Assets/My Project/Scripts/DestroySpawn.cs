using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySpawn : MonoBehaviour
{
    [SerializeField] GameObject SpawnGas;

    
    void Start()
    {
        Destroy(SpawnGas, 0.2f);
    }

    
    void Update()
    {
        
    }
}
