using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieScript : MonoBehaviour
{
    [SerializeField] Material DissolveMat;

    void Start()
    {
        GetComponent<Renderer>().material = DissolveMat;
        GetComponent<SpawnEffect>().enabled = true;
    }

    
    void Update()
    {
        
    }
}
