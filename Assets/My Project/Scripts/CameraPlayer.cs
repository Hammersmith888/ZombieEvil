using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    private Animator Anim;
    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        if(SaveScript.PlayerDead == false){
            if(Input.GetMouseButtonDown(1)){
                Anim.SetBool("Aim", true);
            }
            
        
            if(Input.GetMouseButtonUp(1)){
                Anim.SetBool("Aim", false);
            }
            
        }
        
        
    }
}
