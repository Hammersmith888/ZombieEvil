using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMinion : MonoBehaviour
{
    [SerializeField] GameObject PlayerTarget;
    [SerializeField] float DragSpeed = 0.6f;
    [SerializeField] float CrawlSpeed = 1.1f;
    [SerializeField] float RunSpeed = 2.3f;
    [SerializeField] float AttackDistance = 1.3f;
    [SerializeField] Collider MinionCol;
    
    private NavMeshAgent Nav;
        
    private Animator Anim;
    private float DistanceToPlayer;
    private bool CanMove = true;
    private NavMeshObstacle NavObstacle;
    [Tooltip("1 = Running, 2 = Crawl, 3 = Drag")]
    [SerializeField] int MinionType = 1;
    private float NavMinionSpeed;
    private AnimatorStateInfo MinionInfo;
    private AnimatorStateInfo MinionInfo2;
    private AnimatorStateInfo MinionInfo3;
    private bool Moving = true;
    private bool AlreadyDead = false;
    [SerializeField] float RotationSpeed = 2.0f;
    void Start()
    {
        Nav = GetComponent<NavMeshAgent>();

        PlayerTarget = GameObject.FindGameObjectWithTag("Player");
        Anim = GetComponent<Animator>();
        NavObstacle = GetComponent<NavMeshObstacle>();
        NavObstacle.enabled = false;
        if(MinionType == 1){
            NavMinionSpeed = RunSpeed;
        }

        if(MinionType == 2){
            Anim.SetLayerWeight(1, 1);
            NavMinionSpeed = CrawlSpeed;

        }
        if(MinionType == 3){
            Anim.SetLayerWeight(2, 1);
            NavMinionSpeed = DragSpeed;

        }
        

    }

    
    void Update()
    {
        
        if (MinionType == 1){
            MinionInfo = Anim.GetCurrentAnimatorStateInfo(0);
        }
        else if (MinionType == 2){
            MinionInfo = Anim.GetCurrentAnimatorStateInfo(1);
        }
        else if (MinionType == 3){
            MinionInfo = Anim.GetCurrentAnimatorStateInfo(2);
        }
        if(MinionInfo.IsTag("Death") || MinionInfo2.IsTag("Death") || MinionInfo3.IsTag("Death")){
            Moving = false;
            Nav.enabled = false;
            Debug.Log("Minion is dead");
        }
        else{
            Moving = true;
        }
        if (Moving == true){
            DistanceToPlayer = Vector3.Distance(PlayerTarget.transform.position, transform.position);

            if(DistanceToPlayer < AttackDistance){
                Anim.SetBool("Attack", true);
                //MinionCol.enabled = true;
                //Nav.enabled = false;
                //NavObstacle.enabled = true;
                Nav.isStopped = true;
                CanMove = false;
                Vector3 Pos = (PlayerTarget.transform.position - transform.position).normalized;
                Quaternion PosRotation = Quaternion.LookRotation(new Vector3(Pos.x, 0, Pos.z));
                transform.rotation = Quaternion.Slerp(transform.rotation, PosRotation, Time.deltaTime * RotationSpeed);
            }
            
        
            else if(DistanceToPlayer > AttackDistance + 1){
                Anim.SetBool("Attack", false);
                //MinionCol.enabled = false;
                Nav.isStopped = false;
                //NavObstacle.enabled = false;
                //Nav.enabled = true;
                CanMove = true;
            }
            
        
            if(CanMove == true){
                Nav.speed = NavMinionSpeed;
                Nav.SetDestination(PlayerTarget.transform.position);
            }
            
        }
        
        
    }
    public void MinionDeath(){
        if(AlreadyDead == false){
            Anim.SetTrigger("Death");
            Nav.enabled = false;
            AlreadyDead = true;
            SaveScript.Score += 1000;
            
        }
        
    }

    public void MinionBurned(){
        if(AlreadyDead == false){
            if(MinionType == 1){
                Anim.SetTrigger("Burned");
                Nav.enabled = false;
                AlreadyDead = true;
                SaveScript.Score += 1000;

            }
            else{
                Anim.SetTrigger("Death");
                Nav.enabled = false;
                AlreadyDead = true;
                SaveScript.Score += 1000;
            
            }
            
        }
        
    }
    public void DestoyOnDeath(){
        StartCoroutine(WaitForDestroy());
    }
    IEnumerator WaitForDestroy(){
        yield return new WaitForSeconds(1.5f);
        SaveScript.MonionCount -= 1;
        Destroy(gameObject);
    }
        
    
}