using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMinionSounds : MonoBehaviour
{
    private AudioSource MinionAudio;
    [SerializeField] AudioClip Sound1;
    [SerializeField] AudioClip Sound2;
    [SerializeField] AudioClip Sound3;
    private int Selection = 1;
    private bool Randomizer = false;
    private bool RandomSoundDelay = false;
    [SerializeField] float DelayTime = 3.0f;

    
    void Start()
    {
        MinionAudio = GetComponent<AudioSource>();
        Randomizer = true;
    }

    
    void Update()
    {
        if(Randomizer == true){
            Randomizer = false;
            Selection = Random.Range(1, 4);

            if(Selection == 1){
                MinionAudio.clip = Sound1;
                MinionAudio.Play();
            }
            else if(Selection == 2){
                MinionAudio.clip = Sound2;
                MinionAudio.Play();
            }
            else if(Selection == 3){
                MinionAudio.clip = Sound3;
                MinionAudio.Play();
            }

            if(RandomSoundDelay == false){
                RandomSoundDelay = true;
                StartCoroutine(NewSound());
            }


        }
    }
    IEnumerator NewSound(){
        yield return new WaitForSeconds(DelayTime);
        RandomSoundDelay = false;
        Randomizer = true;

    }
}
