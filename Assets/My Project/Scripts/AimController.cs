using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class AimController : MonoBehaviour
{
    public GameObject Target;
    public GameObject RigObject;
    private bool On = false;
    
    void Start()
    {
        RigObject.GetComponent<Rig>().weight = 0.0f;
    }

    
    void Update()
    {
        Vector3 Pos = Input.mousePosition;
        Pos.z = 3000;
        Vector3 WPos = Camera.main.ScreenToWorldPoint(Pos);

        if(Input.GetMouseButtonDown(1)){
            On = true;
            RigObject.GetComponent<Rig>().weight = 1.0f;
        }
        if(Input.GetMouseButtonDown(1)){
            On = false;
            RigObject.GetComponent<Rig>().weight = 0.0f;
        }
        if(On == true){
            Target.transform.LookAt(WPos);
        }
    }
}
