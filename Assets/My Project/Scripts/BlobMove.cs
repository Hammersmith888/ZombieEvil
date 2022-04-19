using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobMove : MonoBehaviour
{
    [SerializeField] float MoveSpeed = 2.0f;
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * MoveSpeed;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Stone")){
            Destroy(gameObject);
        }
        if(other.gameObject.CompareTag("Player")){
            SaveScript.HealthAmt -= 5;
            other.transform.gameObject.SendMessage("GetHit");
            Destroy(gameObject);
        }
    }
}
