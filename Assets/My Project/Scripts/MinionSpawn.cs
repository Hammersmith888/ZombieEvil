using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionSpawn : MonoBehaviour
{
    [SerializeField] GameObject RunningMinion;
    [SerializeField] GameObject CrawlingMinion;
    [SerializeField] GameObject DraggingMinion;
    [SerializeField] Transform SpawnPlace;
    private bool CanSpawn = true;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (SaveScript.MonionCount < 80){
            if(CanSpawn == true){
                CanSpawn = false;
                StartCoroutine(Spawning());
            }
              
        }
        
                
            
        
        
    }
    IEnumerator Spawning(){
        yield return new WaitForSeconds(0.1f);

        Instantiate(RunningMinion, SpawnPlace.position, SpawnPlace.rotation);
        SaveScript.MonionCount += 1;
        

        yield return new WaitForSeconds(1.5f);

        Instantiate(RunningMinion, SpawnPlace.position, SpawnPlace.rotation);
        SaveScript.MonionCount += 1;

        yield return new WaitForSeconds(2f);

        Instantiate(RunningMinion, SpawnPlace.position, SpawnPlace.rotation);
        SaveScript.MonionCount += 1;


        yield return new WaitForSeconds(3f);

        Instantiate(RunningMinion, SpawnPlace.position, SpawnPlace.rotation);
        SaveScript.MonionCount += 1;


        //yield return new WaitForSeconds(3.1f);

        //Instantiate(CrawlingMinion, SpawnPlace.position, SpawnPlace.rotation);
        //SaveScript.MonionCount += 1;


        yield return new WaitForSeconds(1.2f);

        Instantiate(RunningMinion, SpawnPlace.position, SpawnPlace.rotation);
        SaveScript.MonionCount += 1;


        //yield return new WaitForSeconds(3f);

        //Instantiate(DraggingMinion, SpawnPlace.position, SpawnPlace.rotation);
        //SaveScript.MonionCount += 1;


        yield return new WaitForSeconds(3f);

        Instantiate(RunningMinion, SpawnPlace.position, SpawnPlace.rotation);
        SaveScript.MonionCount += 1;


        yield return new WaitForSeconds(3f);

        Instantiate(RunningMinion, SpawnPlace.position, SpawnPlace.rotation);
        SaveScript.MonionCount += 1;

        yield return new WaitForSeconds(0.8f);
        

        

        CanSpawn = true;



    }
}
