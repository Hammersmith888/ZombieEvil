using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoom : MonoBehaviour
{
    [SerializeField] GameObject Boss;
    [SerializeField] GameObject BossHB;
    
    
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")){
            Boss.gameObject.SetActive(true);
            BossHB.gameObject.SetActive(true);
            
        }
    }
}
