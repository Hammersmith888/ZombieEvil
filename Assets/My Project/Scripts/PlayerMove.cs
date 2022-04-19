using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Animator Anim;
    [SerializeField] float StillRotateSpeed = 0.5f;
    [SerializeField] float WalkRotateSpeed = 1.5f;
    [SerializeField] float RunRotateSpeed = 1.5f;
    [SerializeField] float AimRotateSpeed = 0.6f;
    [SerializeField] GameObject Crosshair;
    [SerializeField] GameObject BloodFX;
    private float RotateSpeed;
    
    private AnimatorStateInfo PlayerInfo;
    private AnimatorStateInfo PlayerInfoL2;
    void Start()
    {
        Anim = GetComponent<Animator>();
        Crosshair.gameObject.SetActive(false);
        BloodFX.gameObject.SetActive(false);
    }

    
    void Update()
    {
        PlayerInfo = Anim.GetCurrentAnimatorStateInfo(0);
        PlayerInfoL2 = Anim.GetCurrentAnimatorStateInfo(1);

        float MoveDirection = Input.GetAxis("Vertical");
        float RotateDirection = Input.GetAxis("Mouse X");

        if(PlayerInfo.IsTag("Still")){
            RotateSpeed = StillRotateSpeed;
            Crosshair.gameObject.SetActive(false);

        }
        if(PlayerInfo.IsTag("Walk")){
            RotateSpeed = WalkRotateSpeed;

        }
        if(PlayerInfo.IsTag("Run")){
            RotateSpeed = RunRotateSpeed;
        }
        if(PlayerInfo.IsTag("Aiming")){
            RotateSpeed = AimRotateSpeed;
            Crosshair.gameObject.SetActive(true);
        }

        if(PlayerInfoL2.IsTag("Hit")){
            Anim.SetLayerWeight(1,1);
            BloodFX.gameObject.SetActive(true);
            
        }
        else if(PlayerInfoL2.IsTag("Idle")){
            Anim.SetLayerWeight(1,0);
            BloodFX.gameObject.SetActive(false);
            
        }

        if(MoveDirection > 0){
            if(Input.GetKeyDown(KeyCode.LeftShift)){
                Anim.SetBool("Running", true);
            }
            else if(Input.GetKeyUp(KeyCode.LeftShift)){
                Anim.SetBool("Running", false);
            }
            else{
                Anim.SetBool("Walk", true);
            }
            
        }
        if(RotateDirection > 0){
            this.transform.Rotate(Vector3.up * RotateSpeed);
        }
        if(MoveDirection == 0){
            Anim.SetBool("Walk", false);
            Anim.SetBool("WalkBack", false);
            Anim.SetBool("Running", false);
        }
        if(MoveDirection < 0){
            Anim.SetBool("WalkBack", true);
        }
        if(RotateDirection < 0){
            this.transform.Rotate(Vector3.up * -RotateSpeed);
        }
        if(Input.GetMouseButtonDown(1)){
            Anim.SetBool("Aim", true);
        }
        if(Input.GetMouseButtonUp(1)){
            Anim.SetBool("Aim", false);
        }
    }
    public void GetHit(){
        //Anim.SetLayerWeight(1,1);
        Anim.SetTrigger("React");
    }
}
