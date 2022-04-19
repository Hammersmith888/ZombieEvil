using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] Transform MuzzleSpawn;
    [SerializeField] GameObject MuzzleFlash;
    [SerializeField] GameObject ImpactStone;
    [SerializeField] GameObject ImpactMetal;
    [SerializeField] AudioClip SingleShotSound;
    [SerializeField] AudioClip RapidShotSound;
    [SerializeField] float RapidDelay = 0.1f;
    [SerializeField] GameObject GrenadeSmoke;
    [SerializeField] AudioClip GrenadeSound;
    [SerializeField] GameObject GrenadeExplosion; 
    [SerializeField] GameObject Flames;
    [SerializeField] AudioClip FlameSound;
    [SerializeField] AudioClip PickupFX;
    [SerializeField] GameObject BloodImpact;
    [SerializeField] float ImpactDistance = 0.001f;
    
    
    private bool RapidPlay = true;
    private bool RapidShooting = true;
    private bool FireFuel = false;
    [SerializeField] LayerMask PlayerLayer;
    [SerializeField] LayerMask BarrelLayer;

    private AudioSource PlayerAudio;

    RaycastHit hit;

    void Start()
    {
        PlayerAudio = GetComponent<AudioSource>();
        Flames.gameObject.SetActive(false);
    }

    
    void Update()
    {
        
        if(SaveScript.WeaponID == 1){
            if(Input.GetMouseButton(1) && Input.GetMouseButtonDown(0)){
                Instantiate(MuzzleFlash, MuzzleSpawn.position, MuzzleSpawn.rotation);

                SaveScript.AmmoAmt -= 1;

                PlayerAudio.clip = SingleShotSound;
                PlayerAudio.loop = false;
                PlayerAudio.pitch = 1;
                PlayerAudio.Play();



                Hits();
            }
            

        }
        if(SaveScript.WeaponID == 2){
            if(Input.GetMouseButton(1) && Input.GetMouseButton(0)){
                Instantiate(MuzzleFlash, MuzzleSpawn.position, MuzzleSpawn.rotation);

                if(RapidPlay == true){
                    RapidPlay = false;
                    PlayerAudio.clip = RapidShotSound;
                    PlayerAudio.loop = true;
                    PlayerAudio.pitch = 3;
                    PlayerAudio.Play();
                }
                if(RapidShooting == true){
                    RapidShooting = false;
                    StartCoroutine(RapidFire());

                }

                



                
            }
            if(Input.GetMouseButtonUp(0)){
                PlayerAudio.Stop();
                RapidPlay = true;
            }
            

        }
        if(SaveScript.WeaponID == 3){
            if(Input.GetMouseButton(1) && Input.GetMouseButtonDown(0)){
                Instantiate(GrenadeSmoke, MuzzleSpawn.position, MuzzleSpawn.rotation);

                SaveScript.PickupAmo -= 1;


                PlayerAudio.clip = GrenadeSound;
                PlayerAudio.loop = false;
                PlayerAudio.pitch = 1;
                PlayerAudio.PlayDelayed(0.3f);


                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if(Physics.Raycast(ray, out hit, 1000, ~PlayerLayer)){
                    StartCoroutine(Grenade());
                }





                
            }
            

        }
        if(SaveScript.WeaponID == 4){
            if(Input.GetMouseButton(1) && Input.GetMouseButtonDown(0)){
                Flames.gameObject.SetActive(true);

                if(RapidPlay == true){
                    RapidPlay = false;
                    FireFuel = true;
                    PlayerAudio.clip = FlameSound;
                    PlayerAudio.loop = true;
                    PlayerAudio.pitch = 0.1f;
                    PlayerAudio.Play();
                }

            }
            if(Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1)){
                Flames.gameObject.SetActive(false);
                if(RapidPlay == false){
                    PlayerAudio.Stop();
                    FireFuel = false;
                    RapidPlay = true;

                }
            }
        }
        if(FireFuel == true){
            SaveScript.PickupAmo -= 3 * Time.deltaTime;
            if(SaveScript.PickupAmo <= 0){
                Flames.gameObject.SetActive(false);
                if(RapidPlay == false){
                    PlayerAudio.Stop();
                    FireFuel = false;
                    RapidPlay = true;

                }
            }
                
        }
            
        
        
    }
    void Hits(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit, 1000, ~PlayerLayer)){
            if(hit.transform.tag == "Stone"){
                Instantiate(ImpactStone, hit.point, Quaternion.LookRotation(hit.normal));
            }
            if(hit.transform.tag == "Metal"){
                Instantiate(ImpactMetal, hit.point, Quaternion.LookRotation(hit.normal));
            }
            if(hit.transform.tag == "Minion"){
                Instantiate(BloodImpact, hit.point + hit.normal * ImpactDistance, Quaternion.LookRotation(hit.normal));
                hit.transform.gameObject.SendMessageUpwards("MinionDeath");
            }
            if(hit.transform.tag == "Boss"){
                Instantiate(BloodImpact, hit.point + hit.normal * ImpactDistance, Quaternion.LookRotation(hit.normal));
                //SaveScript.BossHeath -= 0.1f;
                //SaveScript.Score += 1000;
                hit.transform.gameObject.SendMessage("Hit");
            }

        }
        if (Physics.Raycast(ray, out hit, 1000, BarrelLayer)){
            if(hit.transform.tag == "ExplodingBarrel"){
                hit.transform.gameObject.SendMessage("Explode");
            }
        }


    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag ("RapidFire")){
            SaveScript.WeaponID = 2;
            SaveScript.WeaponName = "Rapid Fire";
            SaveScript.PickupAmo = 1500f;
            PickupSound();
            Destroy(other.gameObject, 0.2f);
        }
        if(other.gameObject.CompareTag ("GranedAmo")){
            SaveScript.WeaponID = 3;
            SaveScript.WeaponName = "Grenade Launcher";
            SaveScript.PickupAmo = 3f;
            PickupSound();
            Destroy(other.gameObject, 0.2f);
        }
        if(other.gameObject.CompareTag ("FlameLover")){
            SaveScript.WeaponID = 4;
            SaveScript.WeaponName = "Flame Thrower";
            SaveScript.PickupAmo = 100f;
            PickupSound();
            Destroy(other.gameObject, 0.2f);
        }
        if(other.gameObject.CompareTag ("HealthPickUp")){
            SaveScript.HealthAmt += 40;
            if(SaveScript.HealthAmt >= 100){
                SaveScript.HealthAmt = 100;
            }
            PickupSound();
            Destroy(other.gameObject, 0.2f);
        }
    }
    void PickupSound(){
        PlayerAudio.clip = PickupFX;
        PlayerAudio.loop = false;
        PlayerAudio.pitch = 0.7f;
        PlayerAudio.Play();

    }

    IEnumerator RapidFire(){
        yield return new WaitForSeconds (RapidDelay);
        SaveScript.PickupAmo -= 1;

        Hits();
        RapidShooting = true;
    }
    IEnumerator Grenade(){
        yield return new WaitForSeconds(0.3f);

        Instantiate(GrenadeExplosion, hit.point, Quaternion.LookRotation(hit.normal));

        if(hit.transform.tag == "ExplodingBarrel"){
            hit.transform.gameObject.SendMessage("Explode");
        }
    }
}
