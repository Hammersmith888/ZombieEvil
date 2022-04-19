using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeBarrel : MonoBehaviour
{
    [SerializeField] GameObject Explosion;
    [SerializeField] bool SpawnDestroyer = false;
    
    public void Explode(){
        Instantiate(Explosion, this.transform.position, this.transform.rotation);
        if(SpawnDestroyer == true){
            GetComponent<DestroySpawn>().enabled = true;
        }
        Destroy(gameObject, 0.1f);
    }
}
