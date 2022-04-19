using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    private GameObject PlayerTarget;
    [SerializeField] float RotationSpeed = 2.0f;
    [SerializeField] GameObject SpawnPlace1, SpawnPlace2, SpawnPlace3, SpawnPlace4, SpawnPlace5;
    private Animator Anim;
    private int SpawnID = 0;
    [SerializeField] float DestroyTime = 1.0f;
    [SerializeField] GameObject BossVampire;
    [SerializeField] Transform BlobSpawn;
    [SerializeField] GameObject Blob;
    private bool Attack = false;
    [SerializeField] float AttackTime = 3.0f;
    private AudioSource BossAudio;
    [SerializeField] AudioClip SpawnSound;
    [SerializeField] AudioClip HitSound;
    private bool AlreadyHit = false;
    void Start()
    {
        PlayerTarget = GameObject.FindGameObjectWithTag("Player");
        Anim = GetComponent<Animator>();
        BossAudio = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        Vector3 Pos = (PlayerTarget.transform.position - transform.position).normalized;
        Quaternion PosRotation = Quaternion.LookRotation(new Vector3(Pos.x, 0, Pos.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, PosRotation, Time.deltaTime * RotationSpeed);


        if(Attack == false){
            Attack = true;
            StartCoroutine(AttackPlayer());
        }
    }
    public void Hit(){
        if(AlreadyHit == false){
            
            SaveScript.BossHeath -= 0.1f;
            SaveScript.Score += 1000;
            AlreadyHit = true;
            Anim.SetTrigger("Spin");
            BossAudio.clip = HitSound;
            BossAudio.priority = 60;
            BossAudio.pitch = 1.4f;
            BossAudio.Play();
            SpawnID = Random.Range(1,6);
            StartCoroutine(Spins());

        }
        
    }
    public void BlobSpawning(){
        Instantiate(Blob, BlobSpawn.position, BlobSpawn.rotation);
        BossAudio.clip = SpawnSound;
        BossAudio.priority = 128;
        BossAudio.pitch = 0.6f;
        BossAudio.Play();

    }

    void Respawn(){
        if(SpawnID == 1){
            Instantiate(BossVampire, SpawnPlace1.transform.position, SpawnPlace1.transform.rotation);
        }
        if(SpawnID == 2){
            Instantiate(BossVampire, SpawnPlace2.transform.position, SpawnPlace2.transform.rotation);
        }
        if(SpawnID == 3){
            Instantiate(BossVampire, SpawnPlace3.transform.position, SpawnPlace3.transform.rotation);
        }
        if(SpawnID == 4){
            Instantiate(BossVampire, SpawnPlace4.transform.position, SpawnPlace4.transform.rotation);
        }
        if(SpawnID == 5){
            Instantiate(BossVampire, SpawnPlace5.transform.position, SpawnPlace5.transform.rotation);
        }
    }
    IEnumerator Spins(){
        yield return new WaitForSeconds(DestroyTime);

        Respawn();
        Destroy(gameObject);
    }
    IEnumerator AttackPlayer(){
        yield return new WaitForSeconds(AttackTime);
        Anim.SetTrigger("Bite");
        Attack = false;
    }
}
