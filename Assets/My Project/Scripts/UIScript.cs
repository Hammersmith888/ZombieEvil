using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    [SerializeField] Text WeaponType;
    [SerializeField] Text Ammo;
    [SerializeField] Text AmmoLabel;
    [SerializeField] Text HealthAmt;
    [SerializeField] Text ScoreAmt;
    [SerializeField] Image BossHealthBar;
    void Start()
    {
        
    }

    
    void Update()
    {
        WeaponType.text = SaveScript.WeaponName;
        HealthAmt.text = SaveScript.HealthAmt.ToString();
        ScoreAmt.text = SaveScript.Score.ToString("n0");

        BossHealthBar.fillAmount = SaveScript.BossHeath;

        if(SaveScript.WeaponID == 1){
            Ammo.text = SaveScript.AmmoAmt.ToString();
        }
        if(SaveScript.WeaponID > 1){
            Ammo.text = SaveScript.PickupAmo.ToString();
        }

        if(SaveScript.WeaponID == 4){
            AmmoLabel.text = "Fuel";
            Ammo.text = (Mathf.Round(SaveScript.PickupAmo).ToString());
        }
        else{
            AmmoLabel.text = "Ammo";
        }
    }
}
