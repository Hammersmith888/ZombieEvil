using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveScript : MonoBehaviour
{
    public static int WeaponID = 1;
    public static string WeaponName;
    public static float PickupAmo;
    public static float AmmoAmt;
    public static int HealthAmt = 100;
    public static int Score = 0;
    public static int MonionCount = 0;
    public static bool PlayerDead = false;
    public static float BossHeath = 1.0f;
    [SerializeField] GameObject DeathPanel;

    void Start()
    {
        Cursor.visible = false;
        AmmoAmt = 1000f;
        WeaponName = "SingleShot";
        PlayerDead = false;
        HealthAmt = 100;
    }

    
    void Update()
    {
        if(PickupAmo <= 0){
            WeaponID = 1;
            WeaponName = "SingleShot";
            
        }

        if(HealthAmt <= 0){
            DeathPanel.gameObject.SetActive(true);
            PlayerDead = true;

        }
        if(Input.GetKeyDown(KeyCode.T)){
            HealthAmt = 0;
        }

    }

    public void Replay(){
        SceneManager.LoadScene(0);

    }
}
