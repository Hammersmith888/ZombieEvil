using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBurn : MonoBehaviour
{
    private bool CanBurn = true;
    private void Start(){
        CanBurn = true;
    }
    
    private void OnParticleCollision(GameObject other) {
        gameObject.SendMessageUpwards("Hit");
        if(CanBurn == true){
            CanBurn = false;
            SaveScript.BossHeath -= 0.1f;

        }
        
    }
}
